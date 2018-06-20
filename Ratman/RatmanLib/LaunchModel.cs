using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.Optimization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatmanLib
{
    public class LaunchModel
    {
        public LaunchModel()
        {
            Constants = new Constants();
            SimulationSteps = new List<SimulationStep>();
            Output = new OutputParams();
            OutputByStage = new List<OutputParams>();
            OutputOrbit = new OrbitOutput();
            ControlOptimization = new ControlOptimization();
        }

        public string Name { get; set; }

        public Launcher Launcher { get; set; }

        public Spaceport Spaceport { get; set; }

        public OrbitInput Orbit { get; set; }

        public Constants Constants { get; private set; }

        public PitchProgram PitchProgram { get; set; }

        public Restrictions Restrictions { get; set; }

        /// <summary>
        /// Delta-T, s
        /// </summary>
        public double DeltaT { get; set; }

        public List<SimulationStep> SimulationSteps { get; private set; }

        public OutputParams Output { get; private set; }

        public List<OutputParams> OutputByStage { get; private set; }

        public OrbitOutput OutputOrbit { get; private set; }

        public ControlOptimization ControlOptimization { get; private set; }

        public void StartSimulation()
        {
            WriteToLog(Launcher.GetLogMessage());
            WriteToLog(Spaceport.GetLogMessage());
            WriteToLog(Orbit.GetLogMessage());
            // WriteToLog(Constants.GetLogMessage());
            WriteToLog(string.Format("Delta-T = {0}", DeltaT));
            WriteToLog(PitchProgram.ToLogMessage());

            RunSimulation();

            OutputByStage.ForEach(os => WriteToLog(os.GetLogMessage()));
            WriteToLog(Output.GetLogMessage());
            WriteToLog(OutputOrbit.GetLogMessage());
            WriteToLog(ControlOptimization.ToLogMessage());
        }

        public void StartOptimization()
        {
            RunOptimizationNelderMeadSimplex();

            StartSimulation();
        }

        private void RunOptimizationNelderMeadSimplex()
        {
            var solver = new NelderMeadSimplex(0.0001, 10000);

            var objectiveFunction = ObjectiveFunction.Value((v) =>
            {
                PitchProgram.Theta0 = v[0];
                PitchProgram.ThetaMax = v[1];
                RunSimulation();
                return ControlOptimization.PenaltyFunction;
            });

            var res = solver.FindMinimum(
                objectiveFunction, 
                new DenseVector(new[] { PitchProgram.Theta0, PitchProgram.ThetaMax }),
                new DenseVector(new[] { 1.0, 1.0 }));

            PitchProgram.Theta0 = res.MinimizingPoint[0];
            PitchProgram.ThetaMax = res.MinimizingPoint[1];

            WriteToLog(res.ToLogMessage());
        }

        private void RunOptmization(double theta0Start = 90.0, double theta0End = 0.0, double thetaMaxStart = -90.0, double thetaMaxEnd = 45.0, double step = 1.0)
        {
            double theta0Best = 90.0;
            double thetaMaxBest = -90.0;
            double penaltyBest = double.MaxValue;

            int count = 0;

            try
            {
                for (double theta0Current = theta0Start; theta0Current > theta0End; theta0Current -= step)
                {
                    for (double thetaMaxCurrent = thetaMaxStart; thetaMaxCurrent < thetaMaxEnd; thetaMaxCurrent += step)
                    {
                        PitchProgram.Theta0 = theta0Current;
                        PitchProgram.ThetaMax = thetaMaxCurrent;
                        RunSimulation();

                        if (ControlOptimization.PenaltyFunction < penaltyBest)
                        {
                            theta0Best = theta0Current;
                            thetaMaxBest = thetaMaxCurrent;
                            penaltyBest = ControlOptimization.PenaltyFunction;

                            WriteToLog($"Found solution: Theta0={theta0Current} ThetaMax={ thetaMaxCurrent} Penalty={penaltyBest}");
                        }

                        count++;

                        if (count > 100000)
                        {
                            return;
                        }
                    }
                }
            }
            finally
            {
                PitchProgram.Theta0 = theta0Best;
                PitchProgram.ThetaMax = thetaMaxBest;
            }
        }

        private void RunSimulation(int maxSteps = 10000)
        {
            SimulationSteps.Clear();
            OutputByStage.Clear();
            Output = new OutputParams();
            OutputOrbit = new OrbitOutput();

            SimulationStep first = CalculateFirstStep(null);
            SimulationSteps.Add(first);

            SimulationStep prev = first;
            for (int i = 0; i < maxSteps; i++)
            {
                var current = CalculateStep(prev, null);
                prev.NextStep = current;
                SimulationSteps.Add(current);
                if (current.Stage == 0)
                {
                    break;
                }

                prev = current;
            }

            OutputByStage.Clear();

            CalculateFirstStep(first);
            prev = first;

            for (int i = 1; i < SimulationSteps.Count; i++)
            {
                var current = SimulationSteps[i];
                CalculateStep(prev, current);
                var output = CheckOutput(prev, current);
                if (current.Stage == 0)
                {
                    Output = output;
                    break;
                }

                prev = current;
            }

            CalculateOutputOrbit();
            if (PitchProgram.Tmax != Output.T)
            {
                PitchProgram.Tmax = Output.T;
                RunSimulation(maxSteps);
                return;
            }

            CalculateControlOptimization();
        }

        private SimulationStep CalculateFirstStep(SimulationStep step)
        {
            if (step == null)
            {
                step = new SimulationStep()
                {
                    Index = 0,
                    T = 0,
                    Stage = 1
                };
            }

            step.Coordinates.Altitude = Spaceport.Altitude;
            step.Coordinates.Distance = 0.0;
            step.Velocity.Vx = Spaceport.Velocity * Math.Cos(Math.PI / 180.0 * Spaceport.Angle);
            step.Velocity.Vxabs = step.Velocity.Vx + Spaceport.GetEarthRotationVelocity(Constants.EarthRadius);
            step.Velocity.Vy = Spaceport.Velocity * Math.Sin(Math.PI / 180.0 * Spaceport.Angle);
            step.Velocity.V = Math.Sqrt(step.Velocity.Vx * step.Velocity.Vx + step.Velocity.Vy * step.Velocity.Vy);
            step.DryMass = Launcher.Stages.Sum(s => s.EmptyMass) + Launcher.FairingMass + Launcher.Payload;
            step.FuelMass = Launcher.Stages.Select(s => s.FullMass - s.EmptyMass).ToArray();
            step.M = step.DryMass + step.FuelMass.Sum();

            step.Atmosphere.Tc = GetTemperature(step.Coordinates.Altitude);
            step.Atmosphere.Ro = GetDensity(step.Coordinates.Altitude);

            step.Throttle = Launcher.Stages.Select(s => s.GetThrottle(step.Stage, step.T)).ToArray();

            step.ThrustKgf = Launcher.Stages.Select(s => 
                s.FuelConsumption * 
                step.Throttle[s.Index] * 
                (s.IspVac - (s.IspVac - s.IspAtm) * step.Atmosphere.Ro) * 
                Math.Min(step.FuelMass[s.Index], s.FuelConsumption * DeltaT) / 
                Math.Max(s.FuelConsumption * DeltaT, 1.0)).ToArray();

            step.ThrustN = Constants.GravityOfEarthStandard * step.ThrustKgf.Sum();

            // =IF(AND(E5=E8;E8>0);(R6/Q6+R5/Q5)/2;R5/Q5)
            if (step.Stage > 0 && (step?.NextStep?.NextStep?.NextStep?.Stage ?? 0) == step.Stage)
            {
                step.A = (step.NextStep.ThrustN / step.NextStep.M + step.ThrustN / step.M) / 2.0;
            }
            else
            {
                step.A = step.ThrustN / step.M;
            }

            step.CV = 0.0;

            step.Acceleration.G = Constants.GravityOfEarthPolar * Math.Pow(1000.0 * Constants.EarthRadius / (1000.0 * Constants.EarthRadius + step.Coordinates.Altitude), 2.0);
            step.Acceleration.Acentr = step.Velocity.Vxabs * step.Velocity.Vxabs / (1000.0 * Constants.EarthRadius + step.Coordinates.Altitude);
            step.Acceleration.Acoriol = step.Velocity.Vy * step.Velocity.Vxabs / (1000.0 * Constants.EarthRadius + step.Coordinates.Altitude);

            step.Aerodynamics.AOA = 0.0;
            step.Aerodynamics.Q = 0.5 * Constants.AirDensity * step.Atmosphere.Ro * step.Velocity.V * step.Velocity.V;

            var firstStage = Launcher.Stages.First();
            step.Aerodynamics.Cx = firstStage.Cx;
            step.Aerodynamics.Cy = firstStage.Cy;
            step.Aerodynamics.Rl = step.Aerodynamics.Q * step.Aerodynamics.Cy * firstStage.Sy * Math.Sin(step.Aerodynamics.AOA / 180.0 * Math.PI);

            step.Control.T = 0;

            step.Control.ControlInterval.Value1 = 1;

            // =MAX(0; (B5-OFFSET(Main!D$32;0;O5))/(OFFSET(Main!D$32;0;O5+1)-OFFSET(Main!D$32;0;O5)))
            step.Control.ControlInterval.Value2 = Math.Max(0, (step.T - PitchProgram.T0) / (PitchProgram.Tmax - PitchProgram.T0));

            // =180/PI()*ATAN(TAN(PI()/180*OFFSET(Main!$D$34;0;O5))*(1-P5)+TAN(PI()/180*OFFSET(Main!$D$34;0;O5+1))*P5)
            step.Control.ControlLinearTheta = 180.0 / Math.PI * Math.Atan(
                Math.Tan(Math.PI / 180.0 * PitchProgram.Theta0) * (1.0 - step.Control.ControlInterval.Value2) +
                Math.Tan(Math.PI / 180.0 * PitchProgram.ThetaMax) * step.Control.ControlInterval.Value2);

            // = IF(Main!B$41 = "+"; AU5; IF(Main!B$38 = "+"; AO5; IF(Main!B$35 = "+"; Y5; R5)))
            step.Control.ThetaOpt = step.Control.ControlLinearTheta;

            // =IF(Main!$B$38="+";AQ5;E5)
            step.Control.ChiOpt = step.Control.ThetaOpt;

            step.Control.QAlpha.AlphaMax = 90.0;
            step.Control.QAlpha.Nu = 90.0;

            // =IF(AND(Main!$B$47="+");Main!$E$47;MAX(-90;M5-L5))
            step.Control.ThetaMin = Restrictions.LaunchPosition != null ? Restrictions.LaunchPosition.Value : Math.Max(-90.0, step.Control.QAlpha.Nu - step.Control.QAlpha.AlphaMax);

            // =IF(AND(Main!$B$47="+");Main!$E$47;MIN(90;M5+L5))
            step.Control.ThetaMax = Restrictions.LaunchPosition != null ? Restrictions.LaunchPosition.Value : Math.Max(-90.0, step.Control.QAlpha.Nu + step.Control.QAlpha.AlphaMax);

            step.Control.Theta = Math.Max(step.Control.ThetaMax, Math.Min(step.Control.ThetaMin, step.Control.ThetaOpt));
            step.Control.Chi = Math.Max(step.Control.ThetaMax, Math.Min(step.Control.ThetaMin, step.Control.ChiOpt));

            // =IF(E5;Control!I5;0)
            step.Pitch.Thrust = step.Control.Theta;

            // =IF(E5;Control!J5;0)
            step.Pitch.AD = step.Control.Chi;

            // =S5*COS(F5*PI()/180)+AK5/Q5
            step.Acceleration.Ax = step.A * Math.Cos(step.Pitch.Thrust * Math.PI / 180.0) + step.Aerodynamics.Rx / step.M;

            // =S5*SIN(F5*PI()/180)+AL5/Q5
            step.Acceleration.Ay = step.A * Math.Sin(step.Pitch.Thrust * Math.PI / 180.0) + step.Aerodynamics.Ry / step.M;

            // TODO : first step Rd
            // =AF5*AG5*Control!AF5*COS(AE5/180*PI())
            // step.Aerodynamics.Rd = 0.0;

            // =-AI5*COS(G5*PI()/180)-AJ5*SIN(G5*PI()/180)
            step.Aerodynamics.Rx = -step.Aerodynamics.Rd * Math.Cos(step.Pitch.AD * Math.PI / 180.0) - step.Aerodynamics.Rl * Math.Sin(step.Pitch.AD * Math.PI / 180.0);

            // -AI5*SIN(G5*PI()/180)+AJ5*COS(G5*PI()/180)
            step.Aerodynamics.Ry = -step.Aerodynamics.Rd * Math.Sin(step.Pitch.AD * Math.PI / 180.0) + step.Aerodynamics.Rl * Math.Cos(step.Pitch.AD * Math.PI / 180.0);

            return step;
        }

        private SimulationStep CalculateStep(SimulationStep prev, SimulationStep step)
        {
            if (step == null)
            {
                step = new SimulationStep();
            }

            step.Index = prev.Index + 1;

            // =B5+Main!$P$11
            step.T = prev.T + DeltaT;

            // =IF(AZ5+AZ6>0;1;IF(BA5+BA6>0;2;IF(BB5+BB6>0;3;IF(BC5+BC6>0;4;FALSE))))
            step.Stage = prev.FuelMass[prev.StageIndex] > 0 ? prev.Stage : prev.Stage + 1;
            if (step.Stage > Launcher.Stages.Count)
            {
                step.Stage = 0;
            }

            // =I5+N5*Main!$P$11
            step.Coordinates.Altitude = prev.Coordinates.Altitude + prev.Velocity.Vy * DeltaT;

            // = J5 + L5 * Main!$P$11
            step.Coordinates.Distance = prev.Coordinates.Distance + prev.Velocity.Vx * DeltaT;

            // =L5+(V5-Z5)*Main!$P$11
            step.Velocity.Vx = prev.Velocity.Vx + (prev.Acceleration.Ax - prev.Acceleration.Acoriol) * DeltaT;
            
            // =L6+Main!$M$19
            step.Velocity.Vxabs = step.Velocity.Vx + Spaceport.GetEarthRotationVelocity(Constants.EarthRadius);

            // =N5+(W5+Y5-X5)*Main!$P$11
            step.Velocity.Vy = prev.Velocity.Vy + (prev.Acceleration.Ay + prev.Acceleration.Acentr - prev.Acceleration.G) * DeltaT;

            step.Velocity.V = Math.Sqrt(step.Velocity.Vx * step.Velocity.Vx + step.Velocity.Vy * step.Velocity.Vy);

            step.DryMass = 
                (from s in Launcher.Stages where s.Number >= step.Stage && step.Stage > 0 select s.EmptyMass).Sum() + 
                (step.T <= Launcher.FairingJettision ? Launcher.FairingMass : 0.0) + 
                Launcher.Payload;

            // =MAX(AZ5-Main!E$15*AO5*Main!$P$11;0)
            step.FuelMass = Launcher.Stages.Select(s => Math.Max(prev.FuelMass[s.Index] - s.FuelConsumption * prev.Throttle[s.Index] * DeltaT, 0.0)).ToArray();

            // =SUM(AY6:BC6)
            step.M = step.DryMass + step.FuelMass.Sum();

            step.Atmosphere.Tc = GetTemperature(step.Coordinates.Altitude);
            step.Atmosphere.Ro = GetDensity(step.Coordinates.Altitude);

            step.Throttle = Launcher.Stages.Select(s => s.GetThrottle(step.Stage, step.T)).ToArray();

            step.ThrustKgf = Launcher.Stages.Select(s =>
                s.FuelConsumption * 
                step.Throttle[s.Index] * 
                (s.IspVac - (s.IspVac - s.IspAtm) * step.Atmosphere.Ro) *
                Math.Min(step.FuelMass[s.Index], s.FuelConsumption * DeltaT) /
                Math.Max(s.FuelConsumption * DeltaT, 1.0)).ToArray();

            step.ThrustN = Constants.GravityOfEarthStandard * step.ThrustKgf.Sum();

            // =IF(AND(E5=E8;E8>0);(R6/Q6+R5/Q5)/2;R5/Q5)
            if (step.Stage > 0 && (step?.NextStep?.NextStep?.NextStep?.Stage ?? 0) == step.Stage)
            {
                step.A = (step.NextStep.ThrustN / step.NextStep.M + step.ThrustN / step.M) / 2.0;
            }
            else
            {
                step.A = step.ThrustN / step.M;
            }

            // =T5+Main!$P$11*S5
            step.CV = prev.CV + DeltaT * prev.A;

            step.Acceleration.G = Constants.GravityOfEarthPolar * Math.Pow(1000.0 * Constants.EarthRadius / (1000.0 * Constants.EarthRadius + step.Coordinates.Altitude), 2.0);
            step.Acceleration.Acentr = step.Velocity.Vxabs * step.Velocity.Vxabs / (1000.0 * Constants.EarthRadius + step.Coordinates.Altitude);
            step.Acceleration.Acoriol = step.Velocity.Vy * step.Velocity.Vxabs / (1000.0 * Constants.EarthRadius + step.Coordinates.Altitude);

            var currentStage = step.Stage > 0 ? Launcher.Stages[step.StageIndex] : null;
            step.Aerodynamics.Cx = currentStage?.Cx ?? 0.0;
            step.Aerodynamics.Cy = currentStage?.Cy ?? 0.0;

            // =0,5*Main!Q$9*AC6*O6*O6
            step.Aerodynamics.Q = 0.5 * Constants.AirDensity * step.Atmosphere.Ro * step.Velocity.V * step.Velocity.V;

            step.Control.T = step.T;

            step.Control.ControlInterval.Value1 = 1;

            // =MAX(0; (B5-OFFSET(Main!D$32;0;O5))/(OFFSET(Main!D$32;0;O5+1)-OFFSET(Main!D$32;0;O5)))
            step.Control.ControlInterval.Value2 = Math.Max(0, (step.T - PitchProgram.T0) / (PitchProgram.Tmax - PitchProgram.T0));

            // =180/PI()*ATAN(TAN(PI()/180*OFFSET(Main!$D$34;0;O5))*(1-P5)+TAN(PI()/180*OFFSET(Main!$D$34;0;O5+1))*P5)
            step.Control.ControlLinearTheta = 180.0 / Math.PI * Math.Atan(
                Math.Tan(Math.PI / 180.0 * PitchProgram.Theta0) * (1.0 - step.Control.ControlInterval.Value2) +
                Math.Tan(Math.PI / 180.0 * PitchProgram.ThetaMax) * step.Control.ControlInterval.Value2);

            // = IF(Main!B$41 = "+"; AU5; IF(Main!B$38 = "+"; AO5; IF(Main!B$35 = "+"; Y5; R5)))
            step.Control.ThetaOpt = step.Control.ControlLinearTheta;

            // =IF(Main!$B$38="+";AQ5;E5)
            step.Control.ChiOpt = step.Control.ThetaOpt;

            // =IF(Main!$B$51="+";MIN(90;180/PI()*Main!E$51/Simulation!AF6);90)
            step.Control.QAlpha.AlphaMax = Restrictions.QAlpha != null ? Math.Min(90.0, 180.0 / Math.PI * Restrictions.QAlpha.Value / step.Aerodynamics.Q) : 90.0;

            // =180/PI()*ATAN2(Simulation!L6;Simulation!N6)
            step.Control.QAlpha.Nu = 180.0 / Math.PI * Math.Atan2(step.Velocity.Vy, step.Velocity.Vx);

            // = IF(AND(Main!$B$47 = "+"; Main!$B$48 = "+"; B6 < Main!$E$48); Main!$E$47; MAX(-90; M6 - L6))
            step.Control.ThetaMin = Restrictions.LaunchPosition != null && Restrictions.ClearingTower != null && step.T < Restrictions.ClearingTower.Value ? 
                Restrictions.LaunchPosition.Value : Math.Max(-90.0, step.Control.QAlpha.Nu - step.Control.QAlpha.AlphaMax);

            // =IF(AND(Main!$B$47="+";Main!$B$48="+";B6<Main!$E$48);Main!$E$47;MIN(90;M6+L6))
            step.Control.ThetaMax = Restrictions.LaunchPosition != null && Restrictions.ClearingTower != null && step.T < Restrictions.ClearingTower.Value ? 
                Restrictions.LaunchPosition.Value : Math.Min(90.0, step.Control.QAlpha.Nu + step.Control.QAlpha.AlphaMax);

            // =IF(Main!$B$49="+";Main!$P$11*Main!$E$49;90)
            var maxTheta = Restrictions.MaxTurn != null ? DeltaT * Restrictions.MaxTurn.Value : 90.0;

            // =MIN(I5+I$3;MAX(I5-I$3;MIN(H6;MAX(G6;E6))))
            step.Control.Theta = Math.Min(
                prev.Control.Theta + maxTheta, 
                Math.Max(prev.Control.Theta - maxTheta, Math.Min(step.Control.ThetaMax, Math.Max(step.Control.ThetaMin, step.Control.ThetaOpt))));

            // =MIN(J5+I$3;MAX(J5-I$3;MIN(H6;MAX(G6;F6))))
            step.Control.Chi = Math.Min(
                prev.Control.Chi + maxTheta,
                Math.Max(prev.Control.Chi - maxTheta, Math.Min(step.Control.ThetaMax, Math.Max(step.Control.ThetaMin, step.Control.ThetaOpt))));

            // =IF(E5;Control!I5;0)
            step.Pitch.Thrust = step.Control.Theta;

            // =IF(E5;Control!J5;0)
            step.Pitch.AD = step.Control.Chi;

            // =G6-ATAN2(L6; N6)/PI()*180
            step.Aerodynamics.AOA = step.Pitch.AD - Math.Atan2(step.Velocity.Vy, step.Velocity.Vx) / Math.PI * 180.0;

            // =AF6*AH6*OFFSET(Main!D$24;0;E6)*SIN(AE6/180*PI())
            step.Aerodynamics.Rl = step.Aerodynamics.Q * step.Aerodynamics.Cy * (currentStage?.Sy ?? 0.0) * Math.Sin(step.Aerodynamics.AOA / 180.0 * Math.PI);

            // =AF6*AG6*OFFSET(Main!D$23;0;E6)*COS(AE6/180*PI())
            step.Aerodynamics.Rd = step.Aerodynamics.Q * step.Aerodynamics.Cx * (currentStage?.Sx ?? 0.0) * Math.Cos(step.Aerodynamics.AOA / 180.0 * Math.PI);

            // =-AI5*COS(G5*PI()/180)-AJ5*SIN(G5*PI()/180)
            step.Aerodynamics.Rx = -step.Aerodynamics.Rd * Math.Cos(step.Pitch.AD * Math.PI / 180.0) - step.Aerodynamics.Rl * Math.Sin(step.Pitch.AD * Math.PI / 180.0);

            // -AI5*SIN(G5*PI()/180)+AJ5*COS(G5*PI()/180)
            step.Aerodynamics.Ry = -step.Aerodynamics.Rd * Math.Sin(step.Pitch.AD * Math.PI / 180.0) + step.Aerodynamics.Rl * Math.Cos(step.Pitch.AD * Math.PI / 180.0);

            // =S5*COS(F5*PI()/180)+AK5/Q5
            step.Acceleration.Ax = step.A * Math.Cos(step.Pitch.Thrust * Math.PI / 180.0) + step.Aerodynamics.Rx / step.M;

            // =S5*SIN(F5*PI()/180)+AL5/Q5
            step.Acceleration.Ay = step.A * Math.Sin(step.Pitch.Thrust * Math.PI / 180.0) + step.Aerodynamics.Ry / step.M;

            return step;
        }

        private OutputParams CheckOutput(SimulationStep prev, SimulationStep current)
        {
            if (prev == null || prev.Stage == current.Stage)
            {
                return null;
            }

            var stageOutput = new OutputParams();
            stageOutput.T = current.T;
            stageOutput.Index = current.Index;
            stageOutput.CV = current.CV;

            // ?
            stageOutput.Stage = prev.Stage;

            OutputParams prevStageOutput = null;
            if (prev.Stage > 1)
            {
                prevStageOutput = OutputByStage[prev.StageIndex - 1];
                stageOutput.CVdelta = stageOutput.CV - prevStageOutput.CV;
            }

            stageOutput.V = current.Velocity.V;
            stageOutput.Vx = current.Velocity.Vxabs;
            stageOutput.Vy = current.Velocity.Vy;
            stageOutput.H = current.Coordinates.Altitude / 1000.0;
            stageOutput.MassT = current.M / 1000.0;
            stageOutput.Pitch = current.Pitch.Thrust;
            stageOutput.MaxQ = (from ss in SimulationSteps where ss.Stage == stageOutput.Stage select ss.Aerodynamics.Q).Max();
            stageOutput.MaxG = (from ss in SimulationSteps where ss.Stage == stageOutput.Stage select ss.A).Max() / Constants.GravityOfEarthStandard;

            OutputByStage.Add(stageOutput);

            // TODO : Stage, CVreserve?

            return stageOutput;
        }

        private void CalculateOutputOrbit()
        {
            OutputOrbit.Vxabs = Output.Vx;

            // =SQRT(L51*L51+L39*L39)
            OutputOrbit.Vabs = Math.Sqrt(OutputOrbit.Vxabs * OutputOrbit.Vxabs + Output.Vy * Output.Vy);

            // =L52*L52/2-Q8/(Q7+L40)/1000
            OutputOrbit.E = OutputOrbit.Vabs * OutputOrbit.Vabs / 2.0 - Constants.Mu / (Constants.EarthRadius + Output.H) / 1000.0;

            // =L51*1000*(Q7+L40)
            OutputOrbit.M = OutputOrbit.Vxabs * 1000.0 * (Constants.EarthRadius + Output.H);

            // =-(Q8-SQRT(MAX(0;Q8*Q8+2*L53*L54*L54)))/2/L53/1000
            OutputOrbit.R1 = -(Constants.Mu - Math.Sqrt(Math.Max(0, Constants.Mu * Constants.Mu + 2.0 * OutputOrbit.E * OutputOrbit.M * OutputOrbit.M))) / 2.0 / OutputOrbit.E / 1000.0;

            // =-(Q8+SQRT(MAX(0;Q8*Q8+2*L53*L54*L54)))/2/L53/1000
            OutputOrbit.R2 = -(Constants.Mu + Math.Sqrt(Math.Max(0, Constants.Mu * Constants.Mu + 2.0 * OutputOrbit.E * OutputOrbit.M * OutputOrbit.M))) / 2.0 / OutputOrbit.E / 1000.0;

            OutputOrbit.Perigee = OutputOrbit.R1 - Constants.EarthRadius;
            OutputOrbit.Apogee = OutputOrbit.R2 - Constants.EarthRadius;
        }

        private void CalculateControlOptimization()
        {
            // =L39^2+(L40-M14)^2
            ControlOptimization.PenaltyFunction = Math.Pow(Output.Vy, 2.0) + Math.Pow(Output.H - Orbit.Perigee, 2.0);

            // =L39^2+(L40-M14)^2+(L38-M21)^2-0,1*E7
            ControlOptimization.TargetFunction = 
                Math.Pow(Output.Vy, 2.0) + 
                Math.Pow(Output.H - Orbit.Perigee, 2.0) + 
                Math.Pow(Output.Vx - Orbit.GetPerigeeVelocityAbsolute(Constants.GravityOfEarthStandard, Constants.EarthRadius), 2.0) -
                0.1 * Launcher.Payload;
        }

        private double GetTemperature(double altitude)
        {
            double result;
            if (altitude < 11000)
            {
                result = 15.04 - 0.00649 * altitude;
            }
            else if (altitude < 25000)
            {
                result = -56.46;
            }
            else
            {
                result = -131.21 + 0.00299 * altitude;
            }

            return result;
        }

        private double GetDensity(double altitude)
        {
            double p;
            var t = GetTemperature(altitude);

            if (altitude < 11000)
            {
                p = 101.29 * Math.Pow((t + 273.1) / 288.08, 5.256);
            }
            else if (altitude < 25000)
            {
                p = 22.65 * Math.Exp(1.73 - 0.000157 * altitude);
            }
            else
            {
                p = 2.488 * Math.Pow((t + 273.1) / 216.6, -11.388);
            }

            var density = p / (0.2869 * (t + 273.1)) / 1.226613787;

            if (altitude > 80000 && altitude <= 100000)
            {
                density = 0.000001;
            }
            else if (altitude > 100000 && altitude <= 150000)
            {
                density = 0.00000001;
            }
            else if (altitude > 150000 && altitude <= 200000)
            {
                density = 0.0000000005;
            }
            else if (altitude > 200000 && altitude <= 300000)
            {
                density = 0.00000000005;
            }

            return density;
        }

        private void WriteToLog(string message)
        {
            if (LogMessage != null)
            {
                LogMessage(message);
            }
        }

        public event Action<string> LogMessage;
    }
}
