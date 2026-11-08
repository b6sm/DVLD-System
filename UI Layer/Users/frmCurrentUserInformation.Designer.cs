
namespace My_DVLD
{
    partial class frmCurrentUserInformation
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
            this.guna2Button6 = new Guna.UI2.WinForms.Guna2Button();
            this.ucPersonal_info1 = new My_DVLD.UCPersonal_info();
            this.ucLoginInformation1 = new My_DVLD.UCLoginInformation();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(399, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 30);
            this.label2.TabIndex = 89;
            this.label2.Text = "User Information";
            // 
            // guna2Button6
            // 
            this.guna2Button6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.guna2Button6.BorderRadius = 10;
            this.guna2Button6.BorderThickness = 1;
            this.guna2Button6.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button6.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button6.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button6.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button6.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button6.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.guna2Button6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.guna2Button6.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.guna2Button6.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.guna2Button6.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button6.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button6.Location = new System.Drawing.Point(770, 443);
            this.guna2Button6.Name = "guna2Button6";
            this.guna2Button6.Size = new System.Drawing.Size(106, 40);
            this.guna2Button6.TabIndex = 96;
            this.guna2Button6.Text = "Close";
            this.guna2Button6.Click += new System.EventHandler(this.guna2Button6_Click);
            // 
            // ucPersonal_info1
            // 
            this.ucPersonal_info1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ucPersonal_info1.Location = new System.Drawing.Point(102, 54);
            this.ucPersonal_info1.Name = "ucPersonal_info1";
            this.ucPersonal_info1.Size = new System.Drawing.Size(774, 280);
            this.ucPersonal_info1.TabIndex = 98;
            // 
            // ucLoginInformation1
            // 
            this.ucLoginInformation1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ucLoginInformation1.Location = new System.Drawing.Point(102, 340);
            this.ucLoginInformation1.Name = "ucLoginInformation1";
            this.ucLoginInformation1.Size = new System.Drawing.Size(774, 89);
            this.ucLoginInformation1.TabIndex = 99;
            // 
            // frmCurrentUserInformation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(978, 497);
            this.Controls.Add(this.ucLoginInformation1);
            this.Controls.Add(this.ucPersonal_info1);
            this.Controls.Add(this.guna2Button6);
            this.Controls.Add(this.label2);
            this.Name = "frmCurrentUserInformation";
            this.Text = "DVLD Management system";
            this.Load += new System.EventHandler(this.frmCurrentUserInformation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button guna2Button6;
        private UCPersonal_info ucPersonal_info1;
        private UCLoginInformation ucLoginInformation1;
    }
}