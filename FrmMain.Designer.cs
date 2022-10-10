namespace HospitalApp
{
    partial class FrmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.descriptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDepartments = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDrSpecalities = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDoctors = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAssistants = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOperators = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPatients = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRegisterPatient = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSatientExam = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsmCities = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.descriptionsToolStripMenuItem,
            this.actionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1118, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // descriptionsToolStripMenuItem
            // 
            this.descriptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDepartments,
            this.tsmDrSpecalities,
            this.tsmUsers,
            this.tsmDoctors,
            this.tsmAssistants,
            this.tsmOperators,
            this.tsmPatients,
            this.tsmCities});
            this.descriptionsToolStripMenuItem.Name = "descriptionsToolStripMenuItem";
            this.descriptionsToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
            this.descriptionsToolStripMenuItem.Text = "Descriptions";
            // 
            // tsmDepartments
            // 
            this.tsmDepartments.Name = "tsmDepartments";
            this.tsmDepartments.Size = new System.Drawing.Size(224, 26);
            this.tsmDepartments.Text = "Departments";
            this.tsmDepartments.Click += new System.EventHandler(this.tsmDepartments_Click);
            // 
            // tsmDrSpecalities
            // 
            this.tsmDrSpecalities.Name = "tsmDrSpecalities";
            this.tsmDrSpecalities.Size = new System.Drawing.Size(224, 26);
            this.tsmDrSpecalities.Text = "Dr Specalities";
            this.tsmDrSpecalities.Click += new System.EventHandler(this.tsmDrSpecalities_Click);
            // 
            // tsmUsers
            // 
            this.tsmUsers.Name = "tsmUsers";
            this.tsmUsers.Size = new System.Drawing.Size(224, 26);
            this.tsmUsers.Text = "Users";
            this.tsmUsers.Click += new System.EventHandler(this.tsmUsers_Click);
            // 
            // tsmDoctors
            // 
            this.tsmDoctors.Name = "tsmDoctors";
            this.tsmDoctors.Size = new System.Drawing.Size(224, 26);
            this.tsmDoctors.Text = "Doctors";
            this.tsmDoctors.Click += new System.EventHandler(this.tsmDoctors_Click);
            // 
            // tsmAssistants
            // 
            this.tsmAssistants.Name = "tsmAssistants";
            this.tsmAssistants.Size = new System.Drawing.Size(224, 26);
            this.tsmAssistants.Text = "Assistants";
            this.tsmAssistants.Click += new System.EventHandler(this.tsmAssistants_Click);
            // 
            // tsmOperators
            // 
            this.tsmOperators.Name = "tsmOperators";
            this.tsmOperators.Size = new System.Drawing.Size(224, 26);
            this.tsmOperators.Text = "Operators";
            this.tsmOperators.Click += new System.EventHandler(this.tsmOperators_Click);
            // 
            // tsmPatients
            // 
            this.tsmPatients.Name = "tsmPatients";
            this.tsmPatients.Size = new System.Drawing.Size(224, 26);
            this.tsmPatients.Text = "Patients";
            this.tsmPatients.Click += new System.EventHandler(this.tsmPatients_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmRegisterPatient,
            this.tsmSatientExam});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // tsmRegisterPatient
            // 
            this.tsmRegisterPatient.Name = "tsmRegisterPatient";
            this.tsmRegisterPatient.Size = new System.Drawing.Size(224, 26);
            this.tsmRegisterPatient.Text = "Register Patients";
            this.tsmRegisterPatient.Click += new System.EventHandler(this.tsmRegisterPatient_Click);
            // 
            // tsmSatientExam
            // 
            this.tsmSatientExam.Name = "tsmSatientExam";
            this.tsmSatientExam.Size = new System.Drawing.Size(224, 26);
            this.tsmSatientExam.Text = "Patient Exam";
            this.tsmSatientExam.Click += new System.EventHandler(this.tsmSatientExam_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 805);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1118, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // tsmCities
            // 
            this.tsmCities.Name = "tsmCities";
            this.tsmCities.Size = new System.Drawing.Size(224, 26);
            this.tsmCities.Text = "Cites And Towns";
            this.tsmCities.Click += new System.EventHandler(this.tsmCities_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 831);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "Hospital Appointment Systems";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem descriptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmUsers;
        private System.Windows.Forms.ToolStripMenuItem tsmDoctors;
        private System.Windows.Forms.ToolStripMenuItem tsmAssistants;
        private System.Windows.Forms.ToolStripMenuItem tsmOperators;
        private System.Windows.Forms.ToolStripMenuItem tsmDepartments;
        private System.Windows.Forms.ToolStripMenuItem tsmDrSpecalities;
        private System.Windows.Forms.ToolStripMenuItem tsmPatients;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmRegisterPatient;
        private System.Windows.Forms.ToolStripMenuItem tsmSatientExam;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem tsmCities;
    }
}