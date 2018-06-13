﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatmanLib.Models
{
    public static class LauncherLibrary
    {
        public static Launcher Falcon9Block5
        {
            get
            {
                return new Launcher
                {
                    Name = "Falcon 9 Block 5",
                    Payload = 24040,
                    Stages = new List<LauncherStage>
                    {
                        new LauncherStage { Number = 1, FullMass = 425353, EmptyMass = 26530, IspAtm = 286, IspVac = 312, ThrustVac = 838.9076967, Sx = 12, Sy = 256, Cx = 0.3, Cy = 0.3 },
                        new LauncherStage { Number = 2, FullMass = 111560, EmptyMass = 5135, IspAtm = 250, IspVac = 348, ThrustVac = 95.24003752, Sx = 12, Sy = 100, Cx = 0.3, Cy = 0.3 }
                    },
                    FairingMass = 1750,
                    FairingJettision = 239
                };
            }
        }
    }
}