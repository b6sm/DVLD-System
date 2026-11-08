
namespace My_DVLD
{
    partial class frmRenewLicenseApplication
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
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pbTestAppointments = new System.Windows.Forms.PictureBox();
            this.lbTestAppointments = new System.Windows.Forms.Label();
            this.ucFilterByLicenseID1 = new My_DVLD.UCFilterByLicenseID();
            this.ucDriverLicenseInfo1 = new My_DVLD.UCDriverLicenseInfo();
            this.ucApplicationNewLicenseInfo1 = new My_DVLD.UCApplicationNewLicenseInfo();
            this.llbShowNewLicense = new System.Windows.Forms.LinkLabel();
            this.llbShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnRenewLicense = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 16;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockForm = false;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 1D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pbTestAppointments
            // 
            this.pbTestAppointments.Image = global::My_DVLD.Properties.Resources.card__1_;
            this.pbTestAppointments.Location = new System.Drawing.Point(288, 13);
            this.pbTestAppointments.Name = "pbTestAppointments";
            this.pbTestAppointments.Size = new System.Drawing.Size(57, 47);
            this.pbTestAppointments.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestAppointments.TabIndex = 116;
            this.pbTestAppointments.TabStop = false;
            // 
            // lbTestAppointments
            // 
            this.lbTestAppointments.AutoSize = true;
            this.lbTestAppointments.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTestAppointments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lbTestAppointments.Location = new System.Drawing.Point(346, 19);
            this.lbTestAppointments.Name = "lbTestAppointments";
            this.lbTestAppointments.Size = new System.Drawing.Size(319, 32);
            this.lbTestAppointments.TabIndex = 115;
            this.lbTestAppointments.Text = "Renew License Application";
            // 
            // ucFilterByLicenseID1
            // 
            this.ucFilterByLicenseID1.Location = new System.Drawing.Point(217, 68);
            this.ucFilterByLicenseID1.Name = "ucFilterByLicenseID1";
            this.ucFilterByLicenseID1.Size = new System.Drawing.Size(517, 70);
            this.ucFilterByLicenseID1.TabIndex = 118;
            this.ucFilterByLicenseID1.OnSearchButton += new System.Action<Busnise_Layer.ClsLicenseContent>(this.ucFilterByLicenseID1_OnSearchButton);
            // 
            // ucDriverLicenseInfo1
            // 
            this.ucDriverLicenseInfo1.Location = new System.Drawing.Point(89, 138);
            this.ucDriverLicenseInfo1.Name = "ucDriverLicenseInfo1";
            this.ucDriverLicenseInfo1.Size = new System.Drawing.Size(773, 378);
            this.ucDriverLicenseInfo1.TabIndex = 117;
            // 
            // ucApplicationNewLicenseInfo1
            // 
            this.ucApplicationNewLicenseInfo1.Location = new System.Drawing.Point(89, 516);
            this.ucApplicationNewLicenseInfo1.Name = "ucApplicationNewLicenseInfo1";
            this.ucApplicationNewLicenseInfo1.Size = new System.Drawing.Size(774, 321);
            this.ucApplicationNewLicenseInfo1.TabIndex = 119;
            // 
            // llbShowNewLicense
            // 
            this.llbShowNewLicense.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(124)))), ((int)(((byte)(227)))));
            this.llbShowNewLicense.AutoSize = true;
            this.llbShowNewLicense.BackColor = System.Drawing.Color.Transparent;
            this.llbShowNewLicense.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbShowNewLicense.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.llbShowNewLicense.Location = new System.Drawing.Point(263, 857);
            this.llbShowNewLicense.Name = "llbShowNewLicense";
            this.llbShowNewLicense.Size = new System.Drawing.Size(186, 21);
            this.llbShowNewLicense.TabIndex = 125;
            this.llbShowNewLicense.TabStop = true;
            this.llbShowNewLicense.Text = "Show New License Info";
            this.llbShowNewLicense.Visible = false;
            this.llbShowNewLicense.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(212)))));
            this.llbShowNewLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbShowNewLicense_LinkClicked);
            // 
            // llbShowLicenseHistory
            // 
            this.llbShowLicenseHistory.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(124)))), ((int)(((byte)(227)))));
            this.llbShowLicenseHistory.AutoSize = true;
            this.llbShowLicenseHistory.BackColor = System.Drawing.Color.Transparent;
            this.llbShowLicenseHistory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbShowLicenseHistory.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.llbShowLicenseHistory.Location = new System.Drawing.Point(85, 857);
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
            // btnRenewLicense
            // 
            this.btnRenewLicense.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnRenewLicense.BorderRadius = 10;
            this.btnRenewLicense.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRenewLicense.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRenewLicense.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRenewLicense.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRenewLicense.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnRenewLicense.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnRenewLicense.ForeColor = System.Drawing.Color.White;
            this.btnRenewLicense.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.btnRenewLicense.Image = global::My_DVLD.Properties.Resources.credit_limit;
            this.btnRenewLicense.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRenewLicense.ImageSize = new System.Drawing.Size(24, 24);
            this.btnRenewLicense.Location = new System.Drawing.Point(640, 847);
            this.btnRenewLicense.Name = "btnRenewLicense";
            this.btnRenewLicense.Size = new System.Drawing.Size(108, 40);
            this.btnRenewLicense.TabIndex = 123;
            this.btnRenewLicense.Text = "Renew";
            this.btnRenewLicense.TextOffset = new System.Drawing.Point(6, 0);
            this.btnRenewLicense.Visible = false;
            this.btnRenewLicense.Click += new System.EventHandler(this.btnRenewLicense_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.BorderThickness = 2;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.Transparent;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(211)))));
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.btnCancel.Image = global::My_DVLD.Properties.Resources.icons8_exit_24;
            this.btnCancel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCancel.Location = new System.Drawing.Point(754, 847);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 40);
            this.btnCancel.TabIndex = 122;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmRenewLicenseApplication
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(951, 900);
            this.Controls.Add(this.llbShowNewLicense);
            this.Controls.Add(this.llbShowLicenseHistory);
            this.Controls.Add(this.btnRenewLicense);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ucApplicationNewLicenseInfo1);
            this.Controls.Add(this.ucFilterByLicenseID1);
            this.Controls.Add(this.ucDriverLicenseInfo1);
            this.Controls.Add(this.pbTestAppointments);
            this.Controls.Add(this.lbTestAppointments);
            this.Name = "frmRenewLicenseApplication";
            this.Text = "DVLD Management system";
            this.Load += new System.EventHandler(this.frmRenewLicenseApplication_Load);
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
        private UCApplicationNewLicenseInfo ucApplicationNewLicenseInfo1;
        private System.Windows.Forms.LinkLabel llbShowNewLicense;
        private System.Windows.Forms.LinkLabel llbShowLicenseHistory;
        private Guna.UI2.WinForms.Guna2Button btnRenewLicense;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}