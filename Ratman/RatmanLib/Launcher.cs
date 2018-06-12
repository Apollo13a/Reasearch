using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatmanLib
{
    public class Launcher
    {
        public Launcher()
        {
            Stages = new List<LauncherStage>();
        }

        /// <summary>
        /// Launch mass, kg
        /// </summary>
        public double LaunchMass
        {
            get
            {
                return Payload + Stages.Sum(s => s.FullMass) + FairingMass;
            }
        }

        /// <summary>
        /// Payload mass, kg
        /// </summary>
        public double Payload
        {
            get;
            set;
        }

        /// <summary>
        /// List of stages
        /// </summary>
        public List<LauncherStage> Stages
        {
            get;
            set;
        }

        /// <summary>
        /// Fairing mass, kg
        /// </summary>
        public double FairingMass
        {
            get;
            set;
        }

        /// <summary>
        /// Fairing jettision, s
        /// </summary>
        public double FairingJettision
        {
            get;
            set;
        }

        public string GetLogMessage()
        {
            return string.Format(@"------------- Launcher --------------
Launch mass (kg) = {0}
Payload (kg) = {1}
Stages:
{2}
Fairing mass (kg) = {3}
Fairing jettision (s) = {4}
------------- Launcher --------------",
                LaunchMass,
                Payload,
                string.Join("\r\n", Stages.Select(s => s.GetLogMessage())),
                FairingMass,
                FairingJettision);
        }

    }
}
