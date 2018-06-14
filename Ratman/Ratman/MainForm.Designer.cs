namespace Ratman
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnRunSimulation = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnRunOptimization = new System.Windows.Forms.Button();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpLog = new System.Windows.Forms.TabPage();
            this.tpSimulation = new System.Windows.Forms.TabPage();
            this.dgvSimulation = new System.Windows.Forms.DataGridView();
            this.velocityInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tpControl = new System.Windows.Forms.TabPage();
            this.dgvSimulationPitchThrust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSimulationPitchAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSimulationCoordinatesAltitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSimulationCoordinatesDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSimulationVelocityV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSimulationAtmosphereRo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSimulationAerodynamicsAOA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSimulationAerodynamicsQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stageIndexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coordinatesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.velocityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thrustNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accelerationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.atmosphereDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aerodynamicsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dryMassDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.controlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcMain.SuspendLayout();
            this.tpLog.SuspendLayout();
            this.tpSimulation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.velocityInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRunSimulation
            // 
            this.btnRunSimulation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunSimulation.Location = new System.Drawing.Point(1037, 10);
            this.btnRunSimulation.Name = "btnRunSimulation";
            this.btnRunSimulation.Size = new System.Drawing.Size(96, 23);
            this.btnRunSimulation.TabIndex = 0;
            this.btnRunSimulation.Text = "Run simulation";
            this.btnRunSimulation.UseVisualStyleBackColor = true;
            this.btnRunSimulation.Click += new System.EventHandler(this.BtnRunSimulation_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLog.Location = new System.Drawing.Point(6, 7);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(999, 425);
            this.rtbLog.TabIndex = 1;
            this.rtbLog.Text = "";
            // 
            // btnRunOptimization
            // 
            this.btnRunOptimization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunOptimization.Location = new System.Drawing.Point(1037, 39);
            this.btnRunOptimization.Name = "btnRunOptimization";
            this.btnRunOptimization.Size = new System.Drawing.Size(96, 23);
            this.btnRunOptimization.TabIndex = 2;
            this.btnRunOptimization.Text = "Run optimization";
            this.btnRunOptimization.UseVisualStyleBackColor = true;
            this.btnRunOptimization.Click += new System.EventHandler(this.BtnRunOptimization_Click);
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.tpLog);
            this.tcMain.Controls.Add(this.tpSimulation);
            this.tcMain.Controls.Add(this.tpControl);
            this.tcMain.Location = new System.Drawing.Point(12, 12);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(1019, 464);
            this.tcMain.TabIndex = 3;
            // 
            // tpLog
            // 
            this.tpLog.Controls.Add(this.rtbLog);
            this.tpLog.Location = new System.Drawing.Point(4, 22);
            this.tpLog.Name = "tpLog";
            this.tpLog.Padding = new System.Windows.Forms.Padding(3);
            this.tpLog.Size = new System.Drawing.Size(1011, 438);
            this.tpLog.TabIndex = 0;
            this.tpLog.Text = "Log";
            this.tpLog.UseVisualStyleBackColor = true;
            // 
            // tpSimulation
            // 
            this.tpSimulation.Controls.Add(this.dgvSimulation);
            this.tpSimulation.Location = new System.Drawing.Point(4, 22);
            this.tpSimulation.Name = "tpSimulation";
            this.tpSimulation.Padding = new System.Windows.Forms.Padding(3);
            this.tpSimulation.Size = new System.Drawing.Size(1011, 438);
            this.tpSimulation.TabIndex = 1;
            this.tpSimulation.Text = "Simulation";
            this.tpSimulation.UseVisualStyleBackColor = true;
            // 
            // dgvSimulation
            // 
            this.dgvSimulation.AllowUserToAddRows = false;
            this.dgvSimulation.AllowUserToDeleteRows = false;
            this.dgvSimulation.AllowUserToOrderColumns = true;
            this.dgvSimulation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSimulation.AutoGenerateColumns = false;
            this.dgvSimulation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSimulation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvSimulationPitchThrust,
            this.dgvSimulationPitchAD,
            this.dgvSimulationCoordinatesAltitude,
            this.dgvSimulationCoordinatesDistance,
            this.dgvSimulationVelocityV,
            this.dgvSimulationAtmosphereRo,
            this.dgvSimulationAerodynamicsAOA,
            this.dgvSimulationAerodynamicsQ,
            this.indexDataGridViewTextBoxColumn,
            this.tDataGridViewTextBoxColumn,
            this.stageDataGridViewTextBoxColumn,
            this.stageIndexDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.coordinatesDataGridViewTextBoxColumn,
            this.velocityDataGridViewTextBoxColumn,
            this.mDataGridViewTextBoxColumn,
            this.thrustNDataGridViewTextBoxColumn,
            this.aDataGridViewTextBoxColumn,
            this.cVDataGridViewTextBoxColumn,
            this.accelerationDataGridViewTextBoxColumn,
            this.atmosphereDataGridViewTextBoxColumn,
            this.aerodynamicsDataGridViewTextBoxColumn,
            this.dryMassDataGridViewTextBoxColumn,
            this.controlDataGridViewTextBoxColumn});
            this.dgvSimulation.DataSource = this.velocityInfoBindingSource;
            this.dgvSimulation.Location = new System.Drawing.Point(6, 6);
            this.dgvSimulation.Name = "dgvSimulation";
            this.dgvSimulation.ReadOnly = true;
            this.dgvSimulation.Size = new System.Drawing.Size(999, 426);
            this.dgvSimulation.TabIndex = 0;
            // 
            // velocityInfoBindingSource
            // 
            this.velocityInfoBindingSource.DataSource = typeof(RatmanLib.SimulationStep);
            // 
            // tpControl
            // 
            this.tpControl.Location = new System.Drawing.Point(4, 22);
            this.tpControl.Name = "tpControl";
            this.tpControl.Size = new System.Drawing.Size(1011, 438);
            this.tpControl.TabIndex = 2;
            this.tpControl.Text = "Control";
            this.tpControl.UseVisualStyleBackColor = true;
            // 
            // dgvSimulationPitchThrust
            // 
            this.dgvSimulationPitchThrust.DataPropertyName = "Pitch.Thrust";
            this.dgvSimulationPitchThrust.HeaderText = "Pith.Thrust";
            this.dgvSimulationPitchThrust.Name = "dgvSimulationPitchThrust";
            this.dgvSimulationPitchThrust.ReadOnly = true;
            // 
            // dgvSimulationPitchAD
            // 
            this.dgvSimulationPitchAD.DataPropertyName = "Pitch.AD";
            this.dgvSimulationPitchAD.HeaderText = "Pitch.AD";
            this.dgvSimulationPitchAD.Name = "dgvSimulationPitchAD";
            this.dgvSimulationPitchAD.ReadOnly = true;
            // 
            // dgvSimulationCoordinatesAltitude
            // 
            this.dgvSimulationCoordinatesAltitude.DataPropertyName = "Coordinates.Altitude";
            this.dgvSimulationCoordinatesAltitude.HeaderText = "Altitude";
            this.dgvSimulationCoordinatesAltitude.Name = "dgvSimulationCoordinatesAltitude";
            this.dgvSimulationCoordinatesAltitude.ReadOnly = true;
            // 
            // dgvSimulationCoordinatesDistance
            // 
            this.dgvSimulationCoordinatesDistance.DataPropertyName = "Coordinates.Distance";
            this.dgvSimulationCoordinatesDistance.HeaderText = "Distance";
            this.dgvSimulationCoordinatesDistance.Name = "dgvSimulationCoordinatesDistance";
            this.dgvSimulationCoordinatesDistance.ReadOnly = true;
            // 
            // dgvSimulationVelocityV
            // 
            this.dgvSimulationVelocityV.DataPropertyName = "Velocity.V";
            this.dgvSimulationVelocityV.HeaderText = "V";
            this.dgvSimulationVelocityV.Name = "dgvSimulationVelocityV";
            this.dgvSimulationVelocityV.ReadOnly = true;
            // 
            // dgvSimulationAtmosphereRo
            // 
            this.dgvSimulationAtmosphereRo.DataPropertyName = "Atmosphere.Ro";
            this.dgvSimulationAtmosphereRo.HeaderText = "Atmosphere.Ro";
            this.dgvSimulationAtmosphereRo.Name = "dgvSimulationAtmosphereRo";
            this.dgvSimulationAtmosphereRo.ReadOnly = true;
            // 
            // dgvSimulationAerodynamicsAOA
            // 
            this.dgvSimulationAerodynamicsAOA.DataPropertyName = "Aerodynamics.AOA";
            this.dgvSimulationAerodynamicsAOA.HeaderText = "Aerodynamics.AOA";
            this.dgvSimulationAerodynamicsAOA.Name = "dgvSimulationAerodynamicsAOA";
            this.dgvSimulationAerodynamicsAOA.ReadOnly = true;
            // 
            // dgvSimulationAerodynamicsQ
            // 
            this.dgvSimulationAerodynamicsQ.DataPropertyName = "Aerodynamics.Q";
            this.dgvSimulationAerodynamicsQ.HeaderText = "Aerodynamics.Q";
            this.dgvSimulationAerodynamicsQ.Name = "dgvSimulationAerodynamicsQ";
            this.dgvSimulationAerodynamicsQ.ReadOnly = true;
            // 
            // indexDataGridViewTextBoxColumn
            // 
            this.indexDataGridViewTextBoxColumn.DataPropertyName = "Index";
            this.indexDataGridViewTextBoxColumn.HeaderText = "Index";
            this.indexDataGridViewTextBoxColumn.Name = "indexDataGridViewTextBoxColumn";
            this.indexDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tDataGridViewTextBoxColumn
            // 
            this.tDataGridViewTextBoxColumn.DataPropertyName = "T";
            this.tDataGridViewTextBoxColumn.HeaderText = "T";
            this.tDataGridViewTextBoxColumn.Name = "tDataGridViewTextBoxColumn";
            this.tDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stageDataGridViewTextBoxColumn
            // 
            this.stageDataGridViewTextBoxColumn.DataPropertyName = "Stage";
            this.stageDataGridViewTextBoxColumn.HeaderText = "Stage";
            this.stageDataGridViewTextBoxColumn.Name = "stageDataGridViewTextBoxColumn";
            this.stageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stageIndexDataGridViewTextBoxColumn
            // 
            this.stageIndexDataGridViewTextBoxColumn.DataPropertyName = "StageIndex";
            this.stageIndexDataGridViewTextBoxColumn.HeaderText = "StageIndex";
            this.stageIndexDataGridViewTextBoxColumn.Name = "stageIndexDataGridViewTextBoxColumn";
            this.stageIndexDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Pitch";
            this.dataGridViewTextBoxColumn1.HeaderText = "Pitch";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // coordinatesDataGridViewTextBoxColumn
            // 
            this.coordinatesDataGridViewTextBoxColumn.DataPropertyName = "Coordinates";
            this.coordinatesDataGridViewTextBoxColumn.HeaderText = "Coordinates";
            this.coordinatesDataGridViewTextBoxColumn.Name = "coordinatesDataGridViewTextBoxColumn";
            this.coordinatesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // velocityDataGridViewTextBoxColumn
            // 
            this.velocityDataGridViewTextBoxColumn.DataPropertyName = "Velocity";
            this.velocityDataGridViewTextBoxColumn.HeaderText = "Velocity";
            this.velocityDataGridViewTextBoxColumn.Name = "velocityDataGridViewTextBoxColumn";
            this.velocityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mDataGridViewTextBoxColumn
            // 
            this.mDataGridViewTextBoxColumn.DataPropertyName = "M";
            this.mDataGridViewTextBoxColumn.HeaderText = "M";
            this.mDataGridViewTextBoxColumn.Name = "mDataGridViewTextBoxColumn";
            this.mDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // thrustNDataGridViewTextBoxColumn
            // 
            this.thrustNDataGridViewTextBoxColumn.DataPropertyName = "ThrustN";
            this.thrustNDataGridViewTextBoxColumn.HeaderText = "ThrustN";
            this.thrustNDataGridViewTextBoxColumn.Name = "thrustNDataGridViewTextBoxColumn";
            this.thrustNDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aDataGridViewTextBoxColumn
            // 
            this.aDataGridViewTextBoxColumn.DataPropertyName = "A";
            this.aDataGridViewTextBoxColumn.HeaderText = "A";
            this.aDataGridViewTextBoxColumn.Name = "aDataGridViewTextBoxColumn";
            this.aDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cVDataGridViewTextBoxColumn
            // 
            this.cVDataGridViewTextBoxColumn.DataPropertyName = "CV";
            this.cVDataGridViewTextBoxColumn.HeaderText = "CV";
            this.cVDataGridViewTextBoxColumn.Name = "cVDataGridViewTextBoxColumn";
            this.cVDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // accelerationDataGridViewTextBoxColumn
            // 
            this.accelerationDataGridViewTextBoxColumn.DataPropertyName = "Acceleration";
            this.accelerationDataGridViewTextBoxColumn.HeaderText = "Acceleration";
            this.accelerationDataGridViewTextBoxColumn.Name = "accelerationDataGridViewTextBoxColumn";
            this.accelerationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // atmosphereDataGridViewTextBoxColumn
            // 
            this.atmosphereDataGridViewTextBoxColumn.DataPropertyName = "Atmosphere";
            this.atmosphereDataGridViewTextBoxColumn.HeaderText = "Atmosphere";
            this.atmosphereDataGridViewTextBoxColumn.Name = "atmosphereDataGridViewTextBoxColumn";
            this.atmosphereDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aerodynamicsDataGridViewTextBoxColumn
            // 
            this.aerodynamicsDataGridViewTextBoxColumn.DataPropertyName = "Aerodynamics";
            this.aerodynamicsDataGridViewTextBoxColumn.HeaderText = "Aerodynamics";
            this.aerodynamicsDataGridViewTextBoxColumn.Name = "aerodynamicsDataGridViewTextBoxColumn";
            this.aerodynamicsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dryMassDataGridViewTextBoxColumn
            // 
            this.dryMassDataGridViewTextBoxColumn.DataPropertyName = "DryMass";
            this.dryMassDataGridViewTextBoxColumn.HeaderText = "DryMass";
            this.dryMassDataGridViewTextBoxColumn.Name = "dryMassDataGridViewTextBoxColumn";
            this.dryMassDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // controlDataGridViewTextBoxColumn
            // 
            this.controlDataGridViewTextBoxColumn.DataPropertyName = "Control";
            this.controlDataGridViewTextBoxColumn.HeaderText = "Control";
            this.controlDataGridViewTextBoxColumn.Name = "controlDataGridViewTextBoxColumn";
            this.controlDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 488);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.btnRunOptimization);
            this.Controls.Add(this.btnRunSimulation);
            this.Name = "MainForm";
            this.Text = "Ratman";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tcMain.ResumeLayout(false);
            this.tpLog.ResumeLayout(false);
            this.tpSimulation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.velocityInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRunSimulation;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btnRunOptimization;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpLog;
        private System.Windows.Forms.TabPage tpSimulation;
        private System.Windows.Forms.DataGridView dgvSimulation;
        private System.Windows.Forms.TabPage tpControl;
        private System.Windows.Forms.BindingSource velocityInfoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn pitchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSimulationPitchThrust;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSimulationPitchAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSimulationCoordinatesAltitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSimulationCoordinatesDistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSimulationVelocityV;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSimulationAtmosphereRo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSimulationAerodynamicsAOA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSimulationAerodynamicsQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn indexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stageIndexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn coordinatesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn velocityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thrustNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accelerationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn atmosphereDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aerodynamicsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dryMassDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn controlDataGridViewTextBoxColumn;
    }
}

