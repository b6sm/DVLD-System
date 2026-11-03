
namespace My_DVLD
{
    partial class frmLocalDrivingLicenseApplicationInfo
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
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.ucDrivingLicenseApplicationInfo1 = new My_DVLD.UcDrivingLicenseApplicationInfo();
            this.ucApplicationIBasicnfo1 = new My_DVLD.UCApplicationIBasicnfo();
            this.pbTestAppointments = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 16;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockForm = false;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
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
            this.btnClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClose.Location = new System.Drawing.Point(769, 466);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 40);
            this.btnClose.TabIndex = 101;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ucDrivingLicenseApplicationInfo1
            // 
            this.ucDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(102, 75);
            this.ucDrivingLicenseApplicationInfo1.Name = "ucDrivingLicenseApplicationInfo1";
            this.ucDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(773, 142);
            this.ucDrivingLicenseApplicationInfo1.TabIndex = 102;
            // 
            // ucApplicationIBasicnfo1
            // 
            this.ucApplicationIBasicnfo1.Location = new System.Drawing.Point(101, 223);
            this.ucApplicationIBasicnfo1.Name = "ucApplicationIBasicnfo1";
            this.ucApplicationIBasicnfo1.Size = new System.Drawing.Size(774, 235);
            this.ucApplicationIBasicnfo1.TabIndex = 103;
            // 
            // pbTestAppointments
            // 
            this.pbTestAppointments.Image = global::My_DVLD.Properties.Resources.icons8_more_info_100;
            this.pbTestAppointments.Location = new System.Drawing.Point(260, 22);
            this.pbTestAppointments.Name = "pbTestAppointments";
            this.pbTestAppointments.Size = new System.Drawing.Size(57, 47);
            this.pbTestAppointments.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestAppointments.TabIndex = 119;
            this.pbTestAppointments.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.label2.Location = new System.Drawing.Point(318, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(386, 30);
            this.label2.TabIndex = 118;
            this.label2.Text = "Local Driving License Application Info";
            // 
            // frmLocalDrivingLicenseApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(978, 524);
            this.Controls.Add(this.pbTestAppointments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ucApplicationIBasicnfo1);
            this.Controls.Add(this.ucDrivingLicenseApplicationInfo1);
            this.Controls.Add(this.btnClose);
            this.Name = "frmLocalDrivingLicenseApplicationInfo";
            this.Text = "DVLD Management system";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenseApplicationInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private UcDrivingLicenseApplicationInfo ucDrivingLicenseApplicationInfo1;
        private UCApplicationIBasicnfo ucApplicationIBasicnfo1;
        private System.Windows.Forms.PictureBox pbTestAppointments;
        private System.Windows.Forms.Label label2;
    }
}