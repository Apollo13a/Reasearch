using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatmanLib
{
    public class SimulationStep
    {
        public SimulationStep()
        {
            Pitch = new PitchInfo();
            Control = new ControlInfo();
            Coordinates = new CoordinatesInfo();
            Velocity = new VelocityInfo();
            Acceleration = new AccelerationInfo();
            Atmosphere = new AtmosphereInfo();
            Aerodynamics = new AerodynamicsInfo();
            Control = new ControlInfo();
        }

        public int Index { get; set; }

        /// <summary>
        /// Time from start, s
        /// </summary>
        public double T { get; set; }

        /// <summary>
        /// Stage number
        /// </summary>
        public int Stage { get; set; }

        /// <summary>
        /// Stage index in arrays
        /// </summary>
        public int StageIndex
        {
            get
            {
                return Stage - 1;
            }
        }

        /// <summary>
        /// Pitch
        /// </summary>
        public PitchInfo Pitch { get; set; }

        public CoordinatesInfo Coordinates { get; set; }

        public VelocityInfo Velocity { get; set; }

        public double M { get; set; }

        public double ThrustN { get; set; }

        public double A { get; set; }

        public double CV { get; set; }

        public AccelerationInfo Acceleration { get; set; }

        public AtmosphereInfo Atmosphere { get; set; }

        public AerodynamicsInfo Aerodynamics { get; set; }

        public double[] Throttle { get; set; }

        /// <summary>
        /// Thrust (kgf)
        /// </summary>
        public double[] ThrustKgf { get; set; }

        /// <summary>
        /// Dry mass, kg
        /// </summary>
        public double DryMass { get; set; }

        /// <summary>
        /// Fuel mass, kg
        /// </summary>
        public double[] FuelMass { get; set; }

        public ControlInfo Control { get; set; }

        public string GetLogMessage()
        {
            return string.Format(@"------------- Simulation ------------
{0}
{1}
{2}
{3}
{4}
{5}
{6}
{7}
{8}
{9}
------------- Simulation ------------",
                this.ToLogMessage(),
                Acceleration.ToLogMessage(),
                Aerodynamics.ToLogMessage(),
                Atmosphere.ToLogMessage(),
                Control.ToLogMessage(),
                Control.ControlInterval.ToLogMessage(),
                Control.QAlpha.ToLogMessage(),
                Coordinates.ToLogMessage(),
                Pitch.ToLogMessage(),
                Velocity.ToLogMessage());
        }

        public class PitchInfo
        {
            /// <summary>
            /// Thrust
            /// </summary>
            public double Thrust { get; set; }

            /// <summary>
            /// a/d
            /// </summary>
            public double AD { get; set; }
        }

        public class CoordinatesInfo
        {
            public double Altitude { get; set; }

            public double Distance { get; set; }
        }

        public class VelocityInfo
        {
            public double Vx { get; set; }

            public double Vxabs { get; set; }

            public double Vy { get; set; }

            public double V
            {
                get
                {
                    return Math.Sqrt(Vx * Vx + Vy * Vy);
                }
            }
        }

        public class AccelerationInfo
        {
            public double Ax { get; set; }

            public double Ay { get; set; }

            public double G { get; set; }

            public double Acentr { get; set; }

            public double Acoriol { get; set; }

            public string GetLogMessage()
            {
                return string.Format(@"Ax = {0}
Ay = {0}
G = {0}
Acentr = {0}
Acoriol = {0}",
                    Ax,
                    Ay,
                    G,
                    Acentr,
                    Acoriol);
            }
        }

        public class AtmosphereInfo
        {
            /// <summary>
            /// t (degrees Celsius)
            /// </summary>
            public double Tc { get; set; }

            public double Ro { get; set; }
        }

        public class AerodynamicsInfo
        {
            public double AOA { get; set; }

            public double Q { get; set; }

            public double Cx { get; set; }

            public double Cy { get; set; }

            public double Rd { get; set; }

            public double Rl { get; set; }

            public double Rx { get; set; }

            public double Ry { get; set; }
        }

        public class ControlInfo
        {
            public ControlInfo()
            {
                QAlpha = new QAlphaInfo();
                ControlInterval = new ControlIntervalInfo();
            }

            public double T { get; set; }

            public double ThetaOpt { get; set; }

            public double ChiOpt { get; set; }

            public double ThetaMin { get; set; }

            public double ThetaMax { get; set; }

            public double Theta { get; set; }

            public double Chi { get; set; }

            public QAlphaInfo QAlpha { get; set; }

            public ControlIntervalInfo ControlInterval { get; set; }

            public double ControlLinearTheta { get; set; }
        }

        public class QAlphaInfo
        {
            public double AlphaMax { get; set; }

            public double Nu { get; set; }
        }

        public class ControlIntervalInfo
        {
            public int Value1 { get; set; }

            public double Value2 { get; set; }
        }
    }
}
