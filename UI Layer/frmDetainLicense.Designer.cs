
namespace My_DVLD
{
    partial class frmDetainLicense
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
            this.label2 = new System.Windows.Forms.Label();
            this.ucDetain_License1 = new My_DVLD.UcDetain_License();
            this.ucDriverLicenseInfo1 = new My_DVLD.UCDriverLicenseInfo();
            this.ucFilterByLicenseID1 = new My_DVLD.UCFilterByLicenseID();
            this.llbShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.llbShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.pbTestAppointments = new System.Windows.Forms.PictureBox();
            this.btnDetainLicense = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 16;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 1D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Location = new System.Drawing.Point(429, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 30);
            this.label2.TabIndex = 100;
            this.label2.Text = "Detain License";
            // 
            // ucDetain_License1
            // 
            this.ucDetain_License1.Location = new System.Drawing.Point(90, 528);
            this.ucDetain_License1.Name = "ucDetain_License1";
            this.ucDetain_License1.Size = new System.Drawing.Size(772, 183);
            this.ucDetain_License1.TabIndex = 102;
            // 
            // ucDriverLicenseInfo1
            // 
            this.ucDriverLicenseInfo1.Location = new System.Drawing.Point(90, 144);
            this.ucDriverLicenseInfo1.Name = "ucDriverLicenseInfo1";
            this.ucDriverLicenseInfo1.Size = new System.Drawing.Size(773, 378);
            this.ucDriverLicenseInfo1.TabIndex = 101;
            // 
            // ucFilterByLicenseID1
            // 
            this.ucFilterByLicenseID1.Location = new System.Drawing.Point(218, 70);
            this.ucFilterByLicenseID1.Name = "ucFilterByLicenseID1";
            this.ucFilterByLicenseID1.Size = new System.Drawing.Size(516, 71);
            this.ucFilterByLicenseID1.TabIndex = 0;
            this.ucFilterByLicenseID1.OnSearchButton += new System.Action<Busnise_Layer.ClsLicenseContent>(this.ucFilterByLicenseID1_OnSearchButton);
            // 
            // llbShowLicenseHistory
            // 
            this.llbShowLicenseHistory.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(124)))), ((int)(((byte)(227)))));
            this.llbShowLicenseHistory.AutoSize = true;
            this.llbShowLicenseHistory.BackColor = System.Drawing.Color.Transparent;
            this.llbShowLicenseHistory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbShowLicenseHistory.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.llbShowLicenseHistory.Location = new System.Drawing.Point(86, 737);
            this.llbShowLicenseHistory.Name = "llbShowLicenseHistory";
            this.llbShowLicenseHistory.Size = new System.Drawing.Size(172, 21);
            this.llbShowLicenseHistory.TabIndex = 115;
            this.llbShowLicenseHistory.TabStop = true;
            this.llbShowLicenseHistory.Text = "Show License History";
            this.llbShowLicenseHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llbShowLicenseHistory.Visible = false;
            this.llbShowLicenseHistory.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(212)))));
            this.llbShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbShowLicenseHistory_LinkClicked);
            // 
            // llbShowLicenseInfo
            // 
            this.llbShowLicenseInfo.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(124)))), ((int)(((byte)(227)))));
            this.llbShowLicenseInfo.AutoSize = true;
            this.llbShowLicenseInfo.BackColor = System.Drawing.Color.Transparent;
            this.llbShowLicenseInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbShowLicenseInfo.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.llbShowLicenseInfo.Location = new System.Drawing.Point(264, 737);
            this.llbShowLicenseInfo.Name = "llbShowLicenseInfo";
            this.llbShowLicenseInfo.Size = new System.Drawing.Size(147, 21);
            this.llbShowLicenseInfo.TabIndex = 116;
            this.llbShowLicenseInfo.TabStop = true;
            this.llbShowLicenseInfo.Text = "Show License Info";
            this.llbShowLicenseInfo.Visible = false;
            this.llbShowLicenseInfo.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(212)))));
            this.llbShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbShowLicenseInfo_LinkClicked);
            // 
            // pbTestAppointments
            // 
            this.pbTestAppointments.Image = global::My_DVLD.Properties.Resources._lock;
            this.pbTestAppointments.Location = new System.Drawing.Point(370, 14);
            this.pbTestAppointments.Name = "pbTestAppointments";
            this.pbTestAppointments.Size = new System.Drawing.Size(57, 47);
            this.pbTestAppointments.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestAppointments.TabIndex = 117;
            this.pbTestAppointments.TabStop = false;
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnDetainLicense.BorderRadius = 10;
            this.btnDetainLicense.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDetainLicense.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDetainLicense.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDetainLicense.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDetainLicense.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnDetainLicense.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnDetainLicense.ForeColor = System.Drawing.Color.White;
            this.btnDetainLicense.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.btnDetainLicense.Image = global::My_DVLD.Properties.Resources.lock__1_;
            this.btnDetainLicense.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDetainLicense.ImageOffset = new System.Drawing.Point(0, 2);
            this.btnDetainLicense.Location = new System.Drawing.Point(642, 727);
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.Size = new System.Drawing.Size(106, 40);
            this.btnDetainLicense.TabIndex = 114;
            this.btnDetainLicense.Text = "Detain";
            this.btnDetainLicense.TextOffset = new System.Drawing.Point(3, 0);
            this.btnDetainLicense.Visible = false;
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetainLicense_Click);
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
            this.btnCancel.Location = new System.Drawing.Point(754, 727);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 40);
            this.btnCancel.TabIndex = 103;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmDetainLicense
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(951, 782);
            this.Controls.Add(this.pbTestAppointments);
            this.Controls.Add(this.llbShowLicenseInfo);
            this.Controls.Add(this.llbShowLicenseHistory);
            this.Controls.Add(this.btnDetainLicense);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ucDetain_License1);
            this.Controls.Add(this.ucDriverLicenseInfo1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ucFilterByLicenseID1);
            this.Name = "frmDetainLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DVLD Management system";
            this.Load += new System.EventHandler(this.frmDetainLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private UCFilterByLicenseID ucFilterByLicenseID1;
        private UcDetain_License ucDetain_License1;
        private UCDriverLicenseInfo ucDriverLicenseInfo1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnDetainLicense;
        private System.Windows.Forms.LinkLabel llbShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llbShowLicenseHistory;
        private System.Windows.Forms.PictureBox pbTestAppointments;
    }
}