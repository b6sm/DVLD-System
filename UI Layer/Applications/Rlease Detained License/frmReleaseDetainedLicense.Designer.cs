
namespace My_DVLD
{
    partial class frmReleaseDetainedLicense
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
            this.btnReleaseDetainLicense = new Guna.UI2.WinForms.Guna2Button();
            this.ucDriverLicenseInfo1 = new My_DVLD.UCDriverLicenseInfo();
            this.label2 = new System.Windows.Forms.Label();
            this.ucFilterByLicenseID1 = new My_DVLD.UCFilterByLicenseID();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.ucDetainLicenseInfo1 = new My_DVLD.UcDetainLicenseInfo();
            this.pbTestAppointments = new System.Windows.Forms.PictureBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
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
            this.llbShowLicenseInfo.Location = new System.Drawing.Point(264, 766);
            this.llbShowLicenseInfo.Name = "llbShowLicenseInfo";
            this.llbShowLicenseInfo.Size = new System.Drawing.Size(147, 21);
            this.llbShowLicenseInfo.TabIndex = 120;
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
            this.llbShowLicenseHistory.Location = new System.Drawing.Point(86, 766);
            this.llbShowLicenseHistory.Name = "llbShowLicenseHistory";
            this.llbShowLicenseHistory.Size = new System.Drawing.Size(172, 21);
            this.llbShowLicenseHistory.TabIndex = 119;
            this.llbShowLicenseHistory.TabStop = true;
            this.llbShowLicenseHistory.Text = "Show License History";
            this.llbShowLicenseHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llbShowLicenseHistory.Visible = false;
            this.llbShowLicenseHistory.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(212)))));
            this.llbShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbShowLicenseHistory_LinkClicked);
            // 
            // btnReleaseDetainLicense
            // 
            this.btnReleaseDetainLicense.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnReleaseDetainLicense.BorderRadius = 10;
            this.btnReleaseDetainLicense.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReleaseDetainLicense.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReleaseDetainLicense.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReleaseDetainLicense.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReleaseDetainLicense.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnReleaseDetainLicense.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnReleaseDetainLicense.ForeColor = System.Drawing.Color.White;
            this.btnReleaseDetainLicense.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.btnReleaseDetainLicense.Image = global::My_DVLD.Properties.Resources._unsafe;
            this.btnReleaseDetainLicense.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReleaseDetainLicense.ImageOffset = new System.Drawing.Point(0, 1);
            this.btnReleaseDetainLicense.Location = new System.Drawing.Point(642, 756);
            this.btnReleaseDetainLicense.Name = "btnReleaseDetainLicense";
            this.btnReleaseDetainLicense.Size = new System.Drawing.Size(106, 40);
            this.btnReleaseDetainLicense.TabIndex = 118;
            this.btnReleaseDetainLicense.Text = "Release";
            this.btnReleaseDetainLicense.TextOffset = new System.Drawing.Point(5, 0);
            this.btnReleaseDetainLicense.Visible = false;
            this.btnReleaseDetainLicense.Click += new System.EventHandler(this.btnReleaseDetainLicense_Click);
            // 
            // ucDriverLicenseInfo1
            // 
            this.ucDriverLicenseInfo1.Location = new System.Drawing.Point(90, 144);
            this.ucDriverLicenseInfo1.Name = "ucDriverLicenseInfo1";
            this.ucDriverLicenseInfo1.Size = new System.Drawing.Size(773, 378);
            this.ucDriverLicenseInfo1.TabIndex = 104;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Location = new System.Drawing.Point(379, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 30);
            this.label2.TabIndex = 103;
            this.label2.Text = "Release Detained License";
            // 
            // ucFilterByLicenseID1
            // 
            this.ucFilterByLicenseID1.Location = new System.Drawing.Point(218, 70);
            this.ucFilterByLicenseID1.Name = "ucFilterByLicenseID1";
            this.ucFilterByLicenseID1.Size = new System.Drawing.Size(516, 71);
            this.ucFilterByLicenseID1.TabIndex = 102;
            this.ucFilterByLicenseID1.OnSearchButton += new System.Action<Busnise_Layer.ClsLicenseContent>(this.ucFilterByLicenseID1_OnSearchButton);
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
            // ucDetainLicenseInfo1
            // 
            this.ucDetainLicenseInfo1.Location = new System.Drawing.Point(90, 528);
            this.ucDetainLicenseInfo1.Name = "ucDetainLicenseInfo1";
            this.ucDetainLicenseInfo1.Size = new System.Drawing.Size(773, 214);
            this.ucDetainLicenseInfo1.TabIndex = 121;
            // 
            // pbTestAppointments
            // 
            this.pbTestAppointments.Image = global::My_DVLD.Properties.Resources.unsafe__2_;
            this.pbTestAppointments.Location = new System.Drawing.Point(319, 12);
            this.pbTestAppointments.Name = "pbTestAppointments";
            this.pbTestAppointments.Size = new System.Drawing.Size(57, 47);
            this.pbTestAppointments.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestAppointments.TabIndex = 122;
            this.pbTestAppointments.TabStop = false;
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
            this.btnClose.Location = new System.Drawing.Point(755, 756);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 40);
            this.btnClose.TabIndex = 117;
            this.btnClose.Text = "Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmReleaseDetainedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 807);
            this.Controls.Add(this.pbTestAppointments);
            this.Controls.Add(this.ucDetainLicenseInfo1);
            this.Controls.Add(this.llbShowLicenseInfo);
            this.Controls.Add(this.llbShowLicenseHistory);
            this.Controls.Add(this.btnReleaseDetainLicense);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucDriverLicenseInfo1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ucFilterByLicenseID1);
            this.Name = "frmReleaseDetainedLicense";
            this.Load += new System.EventHandler(this.frmReleaseDetainedLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UCDriverLicenseInfo ucDriverLicenseInfo1;
        private System.Windows.Forms.Label label2;
        private UCFilterByLicenseID ucFilterByLicenseID1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.LinkLabel llbShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llbShowLicenseHistory;
        private Guna.UI2.WinForms.Guna2Button btnReleaseDetainLicense;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private UcDetainLicenseInfo ucDetainLicenseInfo1;
        private System.Windows.Forms.PictureBox pbTestAppointments;
    }
}