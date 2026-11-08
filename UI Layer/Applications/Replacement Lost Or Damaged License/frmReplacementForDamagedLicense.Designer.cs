
namespace My_DVLD
{
    partial class frmReplacementForDamagedLicense
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
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.rbLostLicense = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbDamagedLicense = new Guna.UI2.WinForms.Guna2RadioButton();
            this.llbShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llbShowLicensHistory = new System.Windows.Forms.LinkLabel();
            this.btnIssueReplacement = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.ucApplicationInfoForLicenseReplacement1 = new My_DVLD.UCApplicationInfoForLicenseReplacement();
            this.ucFilterByLicenseID1 = new My_DVLD.UCFilterByLicenseID();
            this.ucDriverLicenseInfo1 = new My_DVLD.UCDriverLicenseInfo();
            this.pbTestAppointments = new System.Windows.Forms.PictureBox();
            this.lbTestAppointments = new System.Windows.Forms.Label();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.guna2GroupBox1.BorderRadius = 16;
            this.guna2GroupBox1.Controls.Add(this.rbLostLicense);
            this.guna2GroupBox1.Controls.Add(this.rbDamagedLicense);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.guna2GroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.guna2GroupBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(610, 70);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(251, 69);
            this.guna2GroupBox1.TabIndex = 122;
            this.guna2GroupBox1.Text = "Replacement For:";
            this.guna2GroupBox1.TextOffset = new System.Drawing.Point(0, -8);
            // 
            // rbLostLicense
            // 
            this.rbLostLicense.AutoSize = true;
            this.rbLostLicense.BackColor = System.Drawing.Color.Transparent;
            this.rbLostLicense.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.rbLostLicense.CheckedState.BorderThickness = 0;
            this.rbLostLicense.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.rbLostLicense.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.rbLostLicense.CheckedState.InnerOffset = -4;
            this.rbLostLicense.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLostLicense.ForeColor = System.Drawing.Color.White;
            this.rbLostLicense.Location = new System.Drawing.Point(47, 44);
            this.rbLostLicense.Name = "rbLostLicense";
            this.rbLostLicense.Size = new System.Drawing.Size(106, 24);
            this.rbLostLicense.TabIndex = 126;
            this.rbLostLicense.Text = "Lost License";
            this.rbLostLicense.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.rbLostLicense.UncheckedState.BorderThickness = 2;
            this.rbLostLicense.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.rbLostLicense.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbLostLicense.UseVisualStyleBackColor = false;
            this.rbLostLicense.CheckedChanged += new System.EventHandler(this.rbLostLicense_CheckedChanged);
            // 
            // rbDamagedLicense
            // 
            this.rbDamagedLicense.AutoSize = true;
            this.rbDamagedLicense.BackColor = System.Drawing.Color.Transparent;
            this.rbDamagedLicense.Checked = true;
            this.rbDamagedLicense.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.rbDamagedLicense.CheckedState.BorderThickness = 0;
            this.rbDamagedLicense.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.rbDamagedLicense.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.rbDamagedLicense.CheckedState.InnerOffset = -4;
            this.rbDamagedLicense.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDamagedLicense.ForeColor = System.Drawing.Color.White;
            this.rbDamagedLicense.Location = new System.Drawing.Point(47, 22);
            this.rbDamagedLicense.Name = "rbDamagedLicense";
            this.rbDamagedLicense.Size = new System.Drawing.Size(145, 24);
            this.rbDamagedLicense.TabIndex = 125;
            this.rbDamagedLicense.TabStop = true;
            this.rbDamagedLicense.Text = "Damaged License";
            this.rbDamagedLicense.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.rbDamagedLicense.UncheckedState.BorderThickness = 2;
            this.rbDamagedLicense.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.rbDamagedLicense.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbDamagedLicense.UseVisualStyleBackColor = false;
            this.rbDamagedLicense.CheckedChanged += new System.EventHandler(this.rbDamagedLicense_CheckedChanged);
            // 
            // llbShowNewLicenseInfo
            // 
            this.llbShowNewLicenseInfo.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(124)))), ((int)(((byte)(227)))));
            this.llbShowNewLicenseInfo.AutoSize = true;
            this.llbShowNewLicenseInfo.BackColor = System.Drawing.Color.Transparent;
            this.llbShowNewLicenseInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbShowNewLicenseInfo.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.llbShowNewLicenseInfo.Location = new System.Drawing.Point(263, 741);
            this.llbShowNewLicenseInfo.Name = "llbShowNewLicenseInfo";
            this.llbShowNewLicenseInfo.Size = new System.Drawing.Size(186, 21);
            this.llbShowNewLicenseInfo.TabIndex = 121;
            this.llbShowNewLicenseInfo.TabStop = true;
            this.llbShowNewLicenseInfo.Text = "Show New License Info";
            this.llbShowNewLicenseInfo.Visible = false;
            this.llbShowNewLicenseInfo.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(212)))));
            this.llbShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbShowNewLicenseInfo_LinkClicked);
            // 
            // llbShowLicensHistory
            // 
            this.llbShowLicensHistory.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(124)))), ((int)(((byte)(227)))));
            this.llbShowLicensHistory.AutoSize = true;
            this.llbShowLicensHistory.BackColor = System.Drawing.Color.Transparent;
            this.llbShowLicensHistory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbShowLicensHistory.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.llbShowLicensHistory.Location = new System.Drawing.Point(85, 741);
            this.llbShowLicensHistory.Name = "llbShowLicensHistory";
            this.llbShowLicensHistory.Size = new System.Drawing.Size(172, 21);
            this.llbShowLicensHistory.TabIndex = 120;
            this.llbShowLicensHistory.TabStop = true;
            this.llbShowLicensHistory.Text = "Show License History";
            this.llbShowLicensHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llbShowLicensHistory.Visible = false;
            this.llbShowLicensHistory.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(212)))));
            this.llbShowLicensHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbShowLicensHistory_LinkClicked);
            // 
            // btnIssueReplacement
            // 
            this.btnIssueReplacement.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnIssueReplacement.BorderRadius = 10;
            this.btnIssueReplacement.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIssueReplacement.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIssueReplacement.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIssueReplacement.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnIssueReplacement.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnIssueReplacement.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnIssueReplacement.ForeColor = System.Drawing.Color.White;
            this.btnIssueReplacement.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.btnIssueReplacement.Image = global::My_DVLD.Properties.Resources.credit_limit;
            this.btnIssueReplacement.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnIssueReplacement.ImageSize = new System.Drawing.Size(24, 24);
            this.btnIssueReplacement.Location = new System.Drawing.Point(567, 731);
            this.btnIssueReplacement.Name = "btnIssueReplacement";
            this.btnIssueReplacement.Size = new System.Drawing.Size(180, 40);
            this.btnIssueReplacement.TabIndex = 119;
            this.btnIssueReplacement.Text = "Issue Replacment";
            this.btnIssueReplacement.TextOffset = new System.Drawing.Point(6, 0);
            this.btnIssueReplacement.Visible = false;
            this.btnIssueReplacement.Click += new System.EventHandler(this.btnIssueReplacement_Click);
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
            this.btnCancel.Location = new System.Drawing.Point(753, 731);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 40);
            this.btnCancel.TabIndex = 118;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ucApplicationInfoForLicenseReplacement1
            // 
            this.ucApplicationInfoForLicenseReplacement1.Location = new System.Drawing.Point(90, 529);
            this.ucApplicationInfoForLicenseReplacement1.Name = "ucApplicationInfoForLicenseReplacement1";
            this.ucApplicationInfoForLicenseReplacement1.Size = new System.Drawing.Size(774, 190);
            this.ucApplicationInfoForLicenseReplacement1.TabIndex = 117;
            // 
            // ucFilterByLicenseID1
            // 
            this.ucFilterByLicenseID1.Location = new System.Drawing.Point(90, 70);
            this.ucFilterByLicenseID1.Name = "ucFilterByLicenseID1";
            this.ucFilterByLicenseID1.Size = new System.Drawing.Size(515, 69);
            this.ucFilterByLicenseID1.TabIndex = 116;
            this.ucFilterByLicenseID1.OnSearchButton += new System.Action<Busnise_Layer.ClsLicenseContent>(this.ucFilterByLicenseID1_OnSearchButton);
            // 
            // ucDriverLicenseInfo1
            // 
            this.ucDriverLicenseInfo1.Location = new System.Drawing.Point(90, 145);
            this.ucDriverLicenseInfo1.Name = "ucDriverLicenseInfo1";
            this.ucDriverLicenseInfo1.Size = new System.Drawing.Size(773, 378);
            this.ucDriverLicenseInfo1.TabIndex = 115;
            // 
            // pbTestAppointments
            // 
            this.pbTestAppointments.Image = global::My_DVLD.Properties.Resources.id_card;
            this.pbTestAppointments.Location = new System.Drawing.Point(212, 10);
            this.pbTestAppointments.Name = "pbTestAppointments";
            this.pbTestAppointments.Size = new System.Drawing.Size(57, 47);
            this.pbTestAppointments.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestAppointments.TabIndex = 114;
            this.pbTestAppointments.TabStop = false;
            // 
            // lbTestAppointments
            // 
            this.lbTestAppointments.AutoSize = true;
            this.lbTestAppointments.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTestAppointments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lbTestAppointments.Location = new System.Drawing.Point(270, 18);
            this.lbTestAppointments.Name = "lbTestAppointments";
            this.lbTestAppointments.Size = new System.Drawing.Size(470, 32);
            this.lbTestAppointments.TabIndex = 113;
            this.lbTestAppointments.Text = "Replacement For Damaged/Lost License";
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
            // frmReplacementForDamagedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(951, 790);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.llbShowNewLicenseInfo);
            this.Controls.Add(this.llbShowLicensHistory);
            this.Controls.Add(this.btnIssueReplacement);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ucApplicationInfoForLicenseReplacement1);
            this.Controls.Add(this.ucFilterByLicenseID1);
            this.Controls.Add(this.ucDriverLicenseInfo1);
            this.Controls.Add(this.pbTestAppointments);
            this.Controls.Add(this.lbTestAppointments);
            this.Name = "frmReplacementForDamagedLicense";
            this.Text = "DVLD Management system";
            this.Load += new System.EventHandler(this.frmReplacementForDamagedLicense_Load);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private UCDriverLicenseInfo ucDriverLicenseInfo1;
        private System.Windows.Forms.PictureBox pbTestAppointments;
        private System.Windows.Forms.Label lbTestAppointments;
        private UCApplicationInfoForLicenseReplacement ucApplicationInfoForLicenseReplacement1;
        private UCFilterByLicenseID ucFilterByLicenseID1;
        private System.Windows.Forms.LinkLabel llbShowNewLicenseInfo;
        private System.Windows.Forms.LinkLabel llbShowLicensHistory;
        private Guna.UI2.WinForms.Guna2Button btnIssueReplacement;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2RadioButton rbLostLicense;
        private Guna.UI2.WinForms.Guna2RadioButton rbDamagedLicense;
    }
}