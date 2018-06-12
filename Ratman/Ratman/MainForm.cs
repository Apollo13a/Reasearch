using RatmanLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ratman
{
    public partial class MainForm : Form
    {
        private StringBuilder log = new StringBuilder();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Launcher: Falcon 9
            // Apaceport: Cape Canaveral
            // Orbit: LEO
            var model = new LaunchModel
            {
                Launcher = new Launcher
                {
                    Payload = 24040,
                    Stages = new List<LauncherStage>
                    {
                        new LauncherStage { Number = 1, FullMass = 425353, EmptyMass = 26530, IspAtm = 286, IspVac = 312, ThrustVac = 838.9076967, Sx = 12, Sy = 256, Cx = 0.3, Cy = 0.3 },
                        new LauncherStage { Number = 2, FullMass = 111560, EmptyMass = 5135, IspAtm = 250, IspVac = 348, ThrustVac = 95.24003752, Sx = 12, Sy = 100, Cx = 0.3, Cy = 0.3 }
                    },
                    FairingMass = 1750,
                    FairingJettision = 239
                },
                Spaceport = new Spaceport { Latitude = 28.5, Altitude = 3, Velocity = 0, Angle = 0 },
                Orbit = new OrbitInput { Perigee = 200, Apogee = 200, Inclination = 28.5 },
                PitchProgram = new PitchProgram { T0 = 0.0, Tmax = 540.0, Theta0 = 50.7359012901344, ThetaMax = -3.75814564514969 },
                Restrictions = new Restrictions { LaunchPosition = 90.0, ClearingTower = 10.0, MaxTurn = 2.0, QAlpha = 12000.0 },
                DeltaT = 1.0
            };

            log.Clear();
            model.LogMessage += new Action<string>(model_LogMessage);
            model.Start();

            rtbLog.Text = log.ToString();
        }

        void model_LogMessage(string obj)
        {
            log.AppendLine(obj);
        }
    }
}
