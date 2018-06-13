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
                    Spaceport = SpaceportLibrary.CapCanaveral,
                    Orbit = new OrbitInput { Perigee = 200, Apogee = 200, Inclination = 28.5 },
                    PitchProgram = new PitchProgram { T0 = 0.0, Tmax = 540.0, Theta0 = 50.7359012901344, ThetaMax = -3.75814564514969 },
                    Restrictions = new Restrictions { LaunchPosition = 90.0, ClearingTower = 10.0, MaxTurn = 2.0, QAlpha = 12000.0 },
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
                    Spaceport = SpaceportLibrary.CapCanaveral,
                    Orbit = new OrbitInput { Perigee = 200, Apogee = 200, Inclination = 28.5 },
                    PitchProgram = new PitchProgram { T0 = 0.0, Tmax = 540.0, Theta0 = 50.0, ThetaMax = 0.0 },
                    Restrictions = new Restrictions { LaunchPosition = 90.0, ClearingTower = 10.0, MaxTurn = 0.56, QAlpha = 12000.0 },
                    DeltaT = 1.0
                };
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
                    DeltaT = 1.0
                };
            }
        }
    }
}
