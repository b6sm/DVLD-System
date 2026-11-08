
namespace My_DVLD
{
    partial class frmInterNationalDrivingLicenseApplication
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
            this.llbShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llbShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.lbTestAppointments = new System.Windows.Forms.Label();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.ucInterNationalLicenseApplicationInfo1 = new My_DVLD.UCInterNationalLicenseApplicationInfo();
            this.ucFilterByLicenseID1 = new My_DVLD.UCFilterByLicenseID();
            this.ucDriverLicenseInfo1 = new My_DVLD.UCDriverLicenseInfo();
            this.btnIssueLicense = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pbTestAppointments = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // llbShowLicenseInfo
            // 
            this.llbShowLicenseInfo.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(124)))), ((int)(((byte)(227)))));
            this.llbShowLicenseInfo.AutoSize = true;
            this.llbShowLicenseInfo.BackColor = System.Drawing.Color.Transparent;
            this.llbShowLicenseInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbShowLicenseInfo.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.llbShowLicenseInfo.Location = new System.Drawing.Point(278, 791);
            this.llbShowLicenseInfo.Name = "llbShowLicenseInfo";
            this.llbShowLicenseInfo.Size = new System.Drawing.Size(147, 21);
            this.llbShowLicenseInfo.TabIndex = 125;
            this.llbShowLicenseInfo.TabStop = true;
            this.llbShowLicenseInfo.Text = "Show License Info";
            this.llbShowLicenseInfo.Visible = false;
            this.llbShowLicenseInfo.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(212)))));
            this.llbShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbShowLicenseInfo_LinkClicked);
            // 
            // llbShowLicenseHistory
            // 
            this.llbShowLicenseHistory.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(124)))), ((int)(((byte)(227)))));
            this.llbShowLicenseHistory.AutoSize = true;
            this.llbShowLicenseHistory.BackColor = System.Drawing.Color.Transparent;
            this.llbShowLicenseHistory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbShowLicenseHistory.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.llbShowLicenseHistory.Location = new System.Drawing.Point(100, 791);
            this.llbShowLicenseHistory.Name = "llbShowLicenseHistory";
            this.llbShowLicenseHistory.Size = new System.Drawing.Size(172, 21);
            this.llbShowLicenseHistory.TabIndex = 124;
            this.llbShowLicenseHistory.TabStop = true;
            this.llbShowLicenseHistory.Text = "Show License History";
            this.llbShowLicenseHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llbShowLicenseHistory.Visible = false;
            this.llbShowLicenseHistory.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(212)))));
            this.llbShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbShowLicenseHistory_LinkClicked);
            // 
            // lbTestAppointments
            // 
            this.lbTestAppointments.AutoSize = true;
            this.lbTestAppointments.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTestAppointments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.lbTestAppointments.Location = new System.Drawing.Point(283, 29);
            this.lbTestAppointments.Name = "lbTestAppointments";
            this.lbTestAppointments.Size = new System.Drawing.Size(471, 32);
            this.lbTestAppointments.TabIndex = 115;
            this.lbTestAppointments.Text = "International Driver License Application";
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 16;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockForm = false;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 1D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // ucInterNationalLicenseApplicationInfo1
            // 
            this.ucInterNationalLicenseApplicationInfo1.Location = new System.Drawing.Point(103, 546);
            this.ucInterNationalLicenseApplicationInfo1.Name = "ucInterNationalLicenseApplicationInfo1";
            this.ucInterNationalLicenseApplicationInfo1.Size = new System.Drawing.Size(773, 229);
            this.ucInterNationalLicenseApplicationInfo1.TabIndex = 119;
            // 
            // ucFilterByLicenseID1
            // 
            this.ucFilterByLicenseID1.Location = new System.Drawing.Point(230, 85);
            this.ucFilterByLicenseID1.Name = "ucFilterByLicenseID1";
            this.ucFilterByLicenseID1.Size = new System.Drawing.Size(517, 73);
            this.ucFilterByLicenseID1.TabIndex = 118;
            this.ucFilterByLicenseID1.OnSearchButton += new System.Action<Busnise_Layer.ClsLicenseContent>(this.ucFilterByLicenseID1_OnSearchButton);
            // 
            // ucDriverLicenseInfo1
            // 
            this.ucDriverLicenseInfo1.Location = new System.Drawing.Point(103, 162);
            this.ucDriverLicenseInfo1.Name = "ucDriverLicenseInfo1";
            this.ucDriverLicenseInfo1.Size = new System.Drawing.Size(773, 378);
            this.ucDriverLicenseInfo1.TabIndex = 117;
            // 
            // btnIssueLicense
            // 
            this.btnIssueLicense.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnIssueLicense.BorderRadius = 10;
            this.btnIssueLicense.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIssueLicense.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIssueLicense.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIssueLicense.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnIssueLicense.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnIssueLicense.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnIssueLicense.ForeColor = System.Drawing.Color.White;
            this.btnIssueLicense.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.btnIssueLicense.Image = global::My_DVLD.Properties.Resources.global_payment;
            this.btnIssueLicense.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnIssueLicense.ImageSize = new System.Drawing.Size(24, 24);
            this.btnIssueLicense.Location = new System.Drawing.Point(620, 781);
            this.btnIssueLicense.Name = "btnIssueLicense";
            this.btnIssueLicense.Size = new System.Drawing.Size(142, 40);
            this.btnIssueLicense.TabIndex = 128;
            this.btnIssueLicense.Text = "Issue License";
            this.btnIssueLicense.TextOffset = new System.Drawing.Point(8, 0);
            this.btnIssueLicense.Visible = false;
            this.btnIssueLicense.Click += new System.EventHandler(this.btnIssueLicense_Click);
            // 
            // btnClose
            // 
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.btnClose.BorderRadius = 10;
            this.btnClose.BorderThickness = 2;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(211)))));
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.btnClose.Image = global::My_DVLD.Properties.Resources.icons8_exit_24;
            this.btnClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClose.Location = new System.Drawing.Point(768, 781);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 40);
            this.btnClose.TabIndex = 122;
            this.btnClose.Text = "Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbTestAppointments
            // 
            this.pbTestAppointments.Image = global::My_DVLD.Properties.Resources.driver_license__3_;
            this.pbTestAppointments.Location = new System.Drawing.Point(225, 23);
            this.pbTestAppointments.Name = "pbTestAppointments";
            this.pbTestAppointments.Size = new System.Drawing.Size(57, 47);
            this.pbTestAppointments.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestAppointments.TabIndex = 116;
            this.pbTestAppointments.TabStop = false;
            // 
            // frmInterNationalDrivingLicenseApplication
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(978, 830);
            this.Controls.Add(this.btnIssueLicense);
            this.Controls.Add(this.llbShowLicenseInfo);
            this.Controls.Add(this.llbShowLicenseHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucInterNationalLicenseApplicationInfo1);
            this.Controls.Add(this.ucFilterByLicenseID1);
            this.Controls.Add(this.ucDriverLicenseInfo1);
            this.Controls.Add(this.pbTestAppointments);
            this.Controls.Add(this.lbTestAppointments);
            this.Name = "frmInterNationalDrivingLicenseApplication";
            this.Text = "DVLD Management system";
            ((System.ComponentModel.ISupportInitialize)(this.pbTestAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.PictureBox pbTestAppointments;
        private System.Windows.Forms.Label lbTestAppointments;
        private UCFilterByLicenseID ucFilterByLicenseID1;
        private UCDriverLicenseInfo ucDriverLicenseInfo1;
        private UCInterNationalLicenseApplicationInfo ucInterNationalLicenseApplicationInfo1;
        private System.Windows.Forms.LinkLabel llbShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llbShowLicenseHistory;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnIssueLicense;
    }
}