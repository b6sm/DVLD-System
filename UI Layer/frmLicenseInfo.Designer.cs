
namespace My_DVLD
{
    partial class frmLicenseInfo
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
            this.pbTestAppointments = new System.Windows.Forms.PictureBox();
            this.lbTestAppointments = new System.Windows.Forms.Label();
            this.ucDriverLicenseInfo1 = new My_DVLD.UCDriverLicenseInfo();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTestAppointments
            // 
            this.pbTestAppointments.Image = global::My_DVLD.Properties.Resources.identification__2_;
            this.pbTestAppointments.Location = new System.Drawing.Point(327, 22);
            this.pbTestAppointments.Name = "pbTestAppointments";
            this.pbTestAppointments.Size = new System.Drawing.Size(57, 47);
            this.pbTestAppointments.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestAppointments.TabIndex = 111;
            this.pbTestAppointments.TabStop = false;
            // 
            // lbTestAppointments
            // 
            this.lbTestAppointments.AutoSize = true;
            this.lbTestAppointments.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTestAppointments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.lbTestAppointments.Location = new System.Drawing.Point(385, 28);
            this.lbTestAppointments.Name = "lbTestAppointments";
            this.lbTestAppointments.Size = new System.Drawing.Size(230, 32);
            this.lbTestAppointments.TabIndex = 110;
            this.lbTestAppointments.Text = "Driver License Info";
            // 
            // ucDriverLicenseInfo1
            // 
            this.ucDriverLicenseInfo1.Location = new System.Drawing.Point(103, 75);
            this.ucDriverLicenseInfo1.Name = "ucDriverLicenseInfo1";
            this.ucDriverLicenseInfo1.Size = new System.Drawing.Size(773, 378);
            this.ucDriverLicenseInfo1.TabIndex = 112;
            // 
            // btnClose
            // 
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnClose.BorderRadius = 10;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnClose.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnClose.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::My_DVLD.Properties.Resources.icons8_exit_24;
            this.btnClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClose.Location = new System.Drawing.Point(770, 469);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 40);
            this.btnClose.TabIndex = 113;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 16;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockForm = false;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 1D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // frmLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 530);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucDriverLicenseInfo1);
            this.Controls.Add(this.pbTestAppointments);
            this.Controls.Add(this.lbTestAppointments);
            this.Name = "frmLicenseInfo";
            this.Text = "DVLD Management system";
            this.Load += new System.EventHandler(this.frmLicenseInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTestAppointments;
        private System.Windows.Forms.Label lbTestAppointments;
        private UCDriverLicenseInfo ucDriverLicenseInfo1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}