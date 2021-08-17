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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnableSCLogs));
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
            this.chechBoxLogEnabled.Location = new System.Drawing.Point(98, 12);
            this.chechBoxLogEnabled.Name = "chechBoxLogEnabled";
            this.chechBoxLogEnabled.Size = new System.Drawing.Size(94, 17);
            this.chechBoxLogEnabled.TabIndex = 0;
            this.chechBoxLogEnabled.Text = "Logs Enabled ";
            this.chechBoxLogEnabled.UseVisualStyleBackColor = true;
            // 
            // comboBoxHA
            // 
            this.comboBoxHA.FormattingEnabled = true;
            this.comboBoxHA.Items.AddRange(new object[] {
            "OnlyIntel",
            "OnlyNvidia",
            "AutoNvidia"});
            this.comboBoxHA.Location = new System.Drawing.Point(135, 118);
            this.comboBoxHA.Name = "comboBoxHA";
            this.comboBoxHA.Size = new System.Drawing.Size(116, 21);
            this.comboBoxHA.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hardware Acceleration:";
            // 
            // buttonCollectLogs
            // 
            this.buttonCollectLogs.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonCollectLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCollectLogs.Location = new System.Drawing.Point(135, 35);
            this.buttonCollectLogs.Name = "buttonCollectLogs";
            this.buttonCollectLogs.Size = new System.Drawing.Size(116, 33);
            this.buttonCollectLogs.TabIndex = 1;
            this.buttonCollectLogs.Text = "Collect Logs";
            this.buttonCollectLogs.UseVisualStyleBackColor = false;
            this.buttonCollectLogs.Click += new System.EventHandler(this.buttonCollectLogs_Click);
            // 
            // buttonLauchSC
            // 
            this.buttonLauchSC.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonLauchSC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLauchSC.Location = new System.Drawing.Point(12, 192);
            this.buttonLauchSC.Name = "buttonLauchSC";
            this.buttonLauchSC.Size = new System.Drawing.Size(239, 30);
            this.buttonLauchSC.TabIndex = 1;
            this.buttonLauchSC.Text = "Launch Smart Client";
            this.buttonLauchSC.UseVisualStyleBackColor = false;
            this.buttonLauchSC.Click += new System.EventHandler(this.buttonLauchSC_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(76, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 33);
            this.button1.TabIndex = 4;
            this.button1.Text = "Clear Cache";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(12, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 33);
            this.button2.TabIndex = 5;
            this.button2.Text = "View Logs";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(12, 149);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(239, 28);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // EnableSCLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(266, 243);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxHA);
            this.Controls.Add(this.buttonLauchSC);
            this.Controls.Add(this.buttonCollectLogs);
            this.Controls.Add(this.chechBoxLogEnabled);
            this.ForeColor = System.Drawing.Color.Snow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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

