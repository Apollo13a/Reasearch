using RatmanLib;
using RatmanLib.Models;
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

        private void BtnRunSimulation_Click(object sender, EventArgs e)
        {
            var model = LaunchModelLibrary.Falcon9b5v1;
            log.Clear();
            model.LogMessage += new Action<string>(Model_LogMessage);

            model.StartSimulation();
            rtbLog.Text = log.ToString();
        }

        void Model_LogMessage(string obj)
        {
            log.AppendLine(obj);
        }

        private void BtnRunOptimization_Click(object sender, EventArgs e)
        {
            var model = LaunchModelLibrary.Falcon9b5v2;
            log.Clear();
            model.LogMessage += new Action<string>(Model_LogMessage);

            model.StartOptimization();
            rtbLog.Text = log.ToString();
        }
    }
}
