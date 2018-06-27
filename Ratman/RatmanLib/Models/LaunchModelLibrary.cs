using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatmanLib.Models
{
    public static class LaunchModelLibrary
    {
        public static LaunchModel Falcon9b5v1
        {
            get
            {
                return new LaunchModel
                {
                    Name = "Falcon 9 Block 5 LEO. MaxTurn = 2.0",
                    Launcher = LauncherLibrary.Falcon9Block5,
                    Spaceport = SpaceportLibrary.CapeCanaveral,
                    Orbit = new OrbitInput { Perigee = 200, Apogee = 200, Inclination = 28.5 },
                    PitchProgram = new PitchProgram { T0 = 0.0, Tmax = 540.0, Theta0 = 50.2436933185272, ThetaMax = -3.51827540749036 },
                    Restrictions = new Restrictions { LaunchPosition = 90.0, ClearingTower = 10.0, MaxTurn = 2.0, QAlpha = 12000.0 },
                    Atmosphere = new Atmosphere { Type = AtmosphereType.NASAAndGOSTv1 },
                    DeltaT = 1.0
                };
            }
        }

        public static LaunchModel Falcon9b5v2
        {
            get
            {
                var launcher = LauncherLibrary.Falcon9Block5;
                launcher.Payload = 23220;
                return new LaunchModel
                {
                    Name = "Falcon 9 Block 5 LEO. MaxTurn = 0.56",
                    Launcher = launcher,
                    Spaceport = SpaceportLibrary.CapeCanaveral,
                    Orbit = new OrbitInput { Perigee = 200, Apogee = 200, Inclination = 28.5 },
                    PitchProgram = new PitchProgram { T0 = 0.0, Tmax = 540.0, Theta0 = 50.0, ThetaMax = 0.0 },
                    Restrictions = new Restrictions { LaunchPosition = 90.0, ClearingTower = 10.0, MaxTurn = 0.56, QAlpha = 12000.0 },
                    Atmosphere = new Atmosphere { Type = AtmosphereType.NASAAndGOSTv1 },
                    DeltaT = 1.0
                };
            }
        }

        public static LaunchModel Falcon9b5v3
        {
            get
            {
                var launcher = LauncherLibrary.Falcon9Block5;
                launcher.Payload = 22980;
                launcher.Stages[0].Throttle.Add(new TimeValue { Time = 49.0, Value = 0.6 });
                launcher.Stages[0].Throttle.Add(new TimeValue { Time = 71.0, Value = 1.0 });
                launcher.Stages[0].Throttle.Add(new TimeValue { Time = 140.0, Value = 0.79 });

                var model = new LaunchModel
                {
                    Name = "Falcon 9 Block 5 LEO. MaxTurn = 0.56, MaxG = 4; MaxQ = 30000;",
                    Launcher = launcher,
                    Spaceport = SpaceportLibrary.CapeCanaveral,
                    Orbit = new OrbitInput { Perigee = 200.0, Apogee = 200.0, Inclination = 28.5 },
                    PitchProgram = new PitchProgram { T0 = 0.0, Tmax = 553.0, Theta0 = 50.0, ThetaMax = 0.0 },
                    Restrictions = new Restrictions { LaunchPosition = 90.0, ClearingTower = 10.0, MaxTurn = 0.56, QAlpha = 12000.0 },
                    Atmosphere = new Atmosphere { Type = AtmosphereType.NASAAndGOSTv1 },
                    DeltaT = 1.0
                };

                return model;
            }
        }

        public static LaunchModel Zenit2
        {
            get
            {
                return new LaunchModel
                {
                    Name = "Zenit-2 LEO",
                    Launcher = LauncherLibrary.Zenit2,
                    Spaceport = SpaceportLibrary.Baikonur,
                    Orbit = new OrbitInput { Perigee = 200, Apogee = 200, Inclination = 51.6 },
                    PitchProgram = new PitchProgram { T0 = 0.0, Tmax = 414.0, Theta0 = 39.5972323417062, ThetaMax = -7.51251226418319 },
                    Restrictions = new Restrictions { LaunchPosition = 90.0, ClearingTower = 10.0, MaxTurn = 2.0, QAlpha = 12000.0 },
                    Atmosphere = new Atmosphere { Type = AtmosphereType.NASAAndGOSTv1 },
                    DeltaT = 1.0
                };
            }
        }
    }
}
