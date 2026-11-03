
namespace My_DVLD
{
    partial class frmTestsAppointments
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.lbTestAppointments = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsEditAppointments = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsTakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.ucApplicationIBasicnfo1 = new My_DVLD.UCApplicationIBasicnfo();
            this.ucDrivingLicenseApplicationInfo1 = new My_DVLD.UcDrivingLicenseApplicationInfo();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btnScheduleTest = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pbTestAppointments = new System.Windows.Forms.PictureBox();
            this.dtTestAppointments = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.lbRecords = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTestAppointments)).BeginInit();
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
            // lbTestAppointments
            // 
            this.lbTestAppointments.AutoSize = true;
            this.lbTestAppointments.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTestAppointments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.lbTestAppointments.Location = new System.Drawing.Point(350, 25);
            this.lbTestAppointments.Name = "lbTestAppointments";
            this.lbTestAppointments.Size = new System.Drawing.Size(308, 32);
            this.lbTestAppointments.TabIndex = 104;
            this.lbTestAppointments.Text = "Vision Test Appointments";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.label5.Location = new System.Drawing.Point(101, 669);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 21);
            this.label5.TabIndex = 110;
            this.label5.Text = "Records: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.label1.Location = new System.Drawing.Point(101, 482);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 21);
            this.label1.TabIndex = 109;
            this.label1.Text = "Appointments";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsEditAppointments,
            this.toolStripSeparator2,
            this.tsTakeTest});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(138, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // tsEditAppointments
            // 
            this.tsEditAppointments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsEditAppointments.Image = global::My_DVLD.Properties.Resources.edit;
            this.tsEditAppointments.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsEditAppointments.Name = "tsEditAppointments";
            this.tsEditAppointments.Size = new System.Drawing.Size(137, 30);
            this.tsEditAppointments.Text = "Edit";
            this.tsEditAppointments.Click += new System.EventHandler(this.tsEditAppointments_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(134, 6);
            // 
            // tsTakeTest
            // 
            this.tsTakeTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsTakeTest.Image = global::My_DVLD.Properties.Resources.test__2_;
            this.tsTakeTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsTakeTest.Name = "tsTakeTest";
            this.tsTakeTest.Size = new System.Drawing.Size(137, 30);
            this.tsTakeTest.Text = "Take Test";
            this.tsTakeTest.Click += new System.EventHandler(this.tsTakeTest_Click);
            // 
            // ucApplicationIBasicnfo1
            // 
            this.ucApplicationIBasicnfo1.Location = new System.Drawing.Point(101, 228);
            this.ucApplicationIBasicnfo1.Name = "ucApplicationIBasicnfo1";
            this.ucApplicationIBasicnfo1.Size = new System.Drawing.Size(774, 235);
            this.ucApplicationIBasicnfo1.TabIndex = 107;
            // 
            // ucDrivingLicenseApplicationInfo1
            // 
            this.ucDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(101, 80);
            this.ucDrivingLicenseApplicationInfo1.Name = "ucDrivingLicenseApplicationInfo1";
            this.ucDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(773, 142);
            this.ucDrivingLicenseApplicationInfo1.TabIndex = 106;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 8;
            this.guna2Elipse1.TargetControl = this.contextMenuStrip1;
            // 
            // btnScheduleTest
            // 
            this.btnScheduleTest.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(113)))), ((int)(((byte)(101)))));
            this.btnScheduleTest.BorderRadius = 10;
            this.btnScheduleTest.BorderThickness = 2;
            this.btnScheduleTest.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnScheduleTest.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnScheduleTest.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnScheduleTest.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnScheduleTest.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnScheduleTest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnScheduleTest.ForeColor = System.Drawing.Color.White;
            this.btnScheduleTest.Image = global::My_DVLD.Properties.Resources.healthcare;
            this.btnScheduleTest.ImageSize = new System.Drawing.Size(28, 28);
            this.btnScheduleTest.Location = new System.Drawing.Point(809, 474);
            this.btnScheduleTest.Name = "btnScheduleTest";
            this.btnScheduleTest.Size = new System.Drawing.Size(65, 34);
            this.btnScheduleTest.TabIndex = 112;
            this.btnScheduleTest.Click += new System.EventHandler(this.btnScheduleTest_Click);
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
            this.btnClose.Location = new System.Drawing.Point(769, 688);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 40);
            this.btnClose.TabIndex = 111;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbTestAppointments
            // 
            this.pbTestAppointments.Image = global::My_DVLD.Properties.Resources.eye__1_;
            this.pbTestAppointments.Location = new System.Drawing.Point(287, 19);
            this.pbTestAppointments.Name = "pbTestAppointments";
            this.pbTestAppointments.Size = new System.Drawing.Size(57, 47);
            this.pbTestAppointments.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestAppointments.TabIndex = 105;
            this.pbTestAppointments.TabStop = false;
            // 
            // dtTestAppointments
            // 
            this.dtTestAppointments.AllowUserToAddRows = false;
            this.dtTestAppointments.AllowUserToDeleteRows = false;
            this.dtTestAppointments.AllowUserToOrderColumns = true;
            this.dtTestAppointments.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dtTestAppointments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtTestAppointments.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtTestAppointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtTestAppointments.ColumnHeadersHeight = 40;
            this.dtTestAppointments.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtTestAppointments.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtTestAppointments.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.dtTestAppointments.Location = new System.Drawing.Point(105, 516);
            this.dtTestAppointments.Name = "dtTestAppointments";
            this.dtTestAppointments.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtTestAppointments.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtTestAppointments.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dtTestAppointments.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dtTestAppointments.RowTemplate.Height = 35;
            this.dtTestAppointments.Size = new System.Drawing.Size(769, 150);
            this.dtTestAppointments.TabIndex = 113;
            this.dtTestAppointments.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;
            this.dtTestAppointments.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.dtTestAppointments.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.dtTestAppointments.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(52)))));
            this.dtTestAppointments.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dtTestAppointments.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dtTestAppointments.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.dtTestAppointments.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.dtTestAppointments.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTestAppointments.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtTestAppointments.ThemeStyle.HeaderStyle.Height = 40;
            this.dtTestAppointments.ThemeStyle.ReadOnly = true;
            this.dtTestAppointments.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dtTestAppointments.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTestAppointments.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.dtTestAppointments.ThemeStyle.RowsStyle.Height = 35;
            this.dtTestAppointments.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(52)))));
            this.dtTestAppointments.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dtTestAppointments.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtTestAppointments_CellFormatting);
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 16;
            this.guna2Elipse2.TargetControl = this.dtTestAppointments;
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lbRecords.Location = new System.Drawing.Point(169, 669);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(19, 21);
            this.lbRecords.TabIndex = 114;
            this.lbRecords.Text = "0";
            // 
            // frmTestsAppointments
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(978, 749);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.dtTestAppointments);
            this.Controls.Add(this.btnScheduleTest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucApplicationIBasicnfo1);
            this.Controls.Add(this.ucDrivingLicenseApplicationInfo1);
            this.Controls.Add(this.pbTestAppointments);
            this.Controls.Add(this.lbTestAppointments);
            this.Name = "frmTestsAppointments";
            this.Text = "DVLD Management system";
            this.Load += new System.EventHandler(this.frmTestsAppointments_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestAppointments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTestAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.PictureBox pbTestAppointments;
        private System.Windows.Forms.Label lbTestAppointments;
        private UcDrivingLicenseApplicationInfo ucDrivingLicenseApplicationInfo1;
        private UCApplicationIBasicnfo ucApplicationIBasicnfo1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnScheduleTest;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsEditAppointments;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsTakeTest;
        private Guna.UI2.WinForms.Guna2DataGridView dtTestAppointments;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private System.Windows.Forms.Label lbRecords;
    }
}