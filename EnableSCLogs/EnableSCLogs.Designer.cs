namespace EnableSCLogs
{
    partial class EnableSCLogs
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
            this.chechBoxLogEnabled = new System.Windows.Forms.CheckBox();
            this.comboBoxHA = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCollectLogs = new System.Windows.Forms.Button();
            this.buttonLauchSC = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chechBoxLogEnabled
            // 
            this.chechBoxLogEnabled.AutoSize = true;
            this.chechBoxLogEnabled.Location = new System.Drawing.Point(76, 23);
            this.chechBoxLogEnabled.Name = "chechBoxLogEnabled";
            this.chechBoxLogEnabled.Size = new System.Drawing.Size(94, 17);
            this.chechBoxLogEnabled.TabIndex = 0;
            this.chechBoxLogEnabled.Text = "Logs Enabled ";
            this.chechBoxLogEnabled.UseVisualStyleBackColor = true;
            this.chechBoxLogEnabled.CheckedChanged += new System.EventHandler(this.chechBoxLogEnabled_CheckedChanged);
            // 
            // comboBoxHA
            // 
            this.comboBoxHA.FormattingEnabled = true;
            this.comboBoxHA.Items.AddRange(new object[] {
            "OnlyIntel",
            "OnlyNvidia",
            "AutoNvidia"});
            this.comboBoxHA.Location = new System.Drawing.Point(300, 54);
            this.comboBoxHA.Name = "comboBoxHA";
            this.comboBoxHA.Size = new System.Drawing.Size(189, 21);
            this.comboBoxHA.TabIndex = 2;
            this.comboBoxHA.SelectedIndexChanged += new System.EventHandler(this.comboBoxHA_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hardware Acceleration:";
            // 
            // buttonCollectLogs
            // 
            this.buttonCollectLogs.Location = new System.Drawing.Point(135, 48);
            this.buttonCollectLogs.Name = "buttonCollectLogs";
            this.buttonCollectLogs.Size = new System.Drawing.Size(116, 33);
            this.buttonCollectLogs.TabIndex = 1;
            this.buttonCollectLogs.Text = "Collect Logs";
            this.buttonCollectLogs.UseVisualStyleBackColor = true;
            this.buttonCollectLogs.Click += new System.EventHandler(this.buttonCollectLogs_Click);
            // 
            // buttonLauchSC
            // 
            this.buttonLauchSC.Location = new System.Drawing.Point(135, 87);
            this.buttonLauchSC.Name = "buttonLauchSC";
            this.buttonLauchSC.Size = new System.Drawing.Size(116, 33);
            this.buttonLauchSC.TabIndex = 1;
            this.buttonLauchSC.Text = "Lauch Smart Client";
            this.buttonLauchSC.UseVisualStyleBackColor = true;
            this.buttonLauchSC.Click += new System.EventHandler(this.buttonLauchSC_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 33);
            this.button1.TabIndex = 4;
            this.button1.Text = "Clear Cache";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 33);
            this.button2.TabIndex = 5;
            this.button2.Text = "View Logs";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(337, 91);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(109, 28);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // EnableSCLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 382);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxHA);
            this.Controls.Add(this.buttonLauchSC);
            this.Controls.Add(this.buttonCollectLogs);
            this.Controls.Add(this.chechBoxLogEnabled);
            this.Name = "EnableSCLogs";
            this.Text = "SCLogCollectorV2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chechBoxLogEnabled;
        private System.Windows.Forms.ComboBox comboBoxHA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCollectLogs;
        private System.Windows.Forms.Button buttonLauchSC;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonSave;
    }
}

