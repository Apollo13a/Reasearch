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

            dgvSimulation.CellFormatting += DgvSimulation_CellFormatting;
            tcMain.SelectedIndex = 1;
        }

        private void DgvSimulation_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            DataGridViewRow row = grid.Rows[e.RowIndex];
            DataGridViewColumn col = grid.Columns[e.ColumnIndex];
            if (row.DataBoundItem != null && col.DataPropertyName.Contains("."))
            {
                string[] props = col.DataPropertyName.Split('.');
                var propInfo = row.DataBoundItem.GetType().GetProperty(props[0]);
                object val = propInfo.GetValue(row.DataBoundItem, null);

                for (int i = 1; i < props.Length; i++)
                {
                    if (val is double[] array)
                    {
                        val = array[Convert.ToInt32(props[i])];
                        break;
                    }

                    propInfo = val.GetType().GetProperty(props[i]);
                    val = propInfo.GetValue(val, null);
                }

                e.Value = val;
            }

        }

        private void DisplayModel(LaunchModel model)
        {
            rtbLog.Text = log.ToString();

            dgvSimulation.DataSource = model.SimulationSteps;
            dgvSimulation.Refresh();
        }

        private void BtnRunSimulation_Click(object sender, EventArgs e)
        {
            var model = LaunchModelLibrary.Falcon9b5v1;
            log.Clear();
            model.LogMessage += new Action<string>(Model_LogMessage);

            model.StartSimulation();
            DisplayModel(model);
        }

        void Model_LogMessage(string obj)
        {
            log.AppendLine(obj);
        }

        private void BtnRunOptimization_Click(object sender, EventArgs e)
        {
            var model = LaunchModelLibrary.Falcon9b5v3;
            log.Clear();
            model.LogMessage += new Action<string>(Model_LogMessage);

            model.StartOptimization();
            DisplayModel(model);
        }
    }
}
