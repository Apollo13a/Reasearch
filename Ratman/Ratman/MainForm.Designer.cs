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
            this.btnRunSimulation = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnRunOptimization = new System.Windows.Forms.Button();
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
            this.rtbLog.Location = new System.Drawing.Point(12, 12);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(1019, 464);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 488);
            this.Controls.Add(this.btnRunOptimization);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.btnRunSimulation);
            this.Name = "MainForm";
            this.Text = "Ratman";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRunSimulation;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btnRunOptimization;
    }
}

