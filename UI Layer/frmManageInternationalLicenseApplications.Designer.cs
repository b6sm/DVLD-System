
namespace My_DVLD
{
    partial class frmManageInternationalLicenseApplications
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
            this.lbRecords = new System.Windows.Forms.Label();
            this.guna2VScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
            this.dtInternationalLicenseApplications = new Guna.UI2.WinForms.Guna2DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsShowPersonInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsShowLicenseInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsShowLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbFilterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnIssueInternationalLicense = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.cbShowActiveState = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtInternationalLicenseApplications)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lbRecords.Location = new System.Drawing.Point(87, 518);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(19, 21);
            this.lbRecords.TabIndex = 92;
            this.lbRecords.Text = "0";
            // 
            // guna2VScrollBar1
            // 
            this.guna2VScrollBar1.BindingContainer = this.dtInternationalLicenseApplications;
            this.guna2VScrollBar1.BorderRadius = 8;
            this.guna2VScrollBar1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.guna2VScrollBar1.InUpdate = false;
            this.guna2VScrollBar1.LargeChange = 10;
            this.guna2VScrollBar1.Location = new System.Drawing.Point(1189, 225);
            this.guna2VScrollBar1.Minimum = 1;
            this.guna2VScrollBar1.Name = "guna2VScrollBar1";
            this.guna2VScrollBar1.ScrollbarSize = 18;
            this.guna2VScrollBar1.Size = new System.Drawing.Size(18, 283);
            this.guna2VScrollBar1.TabIndex = 91;
            this.guna2VScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.guna2VScrollBar1.Value = 1;
            // 
            // dtInternationalLicenseApplications
            // 
            this.dtInternationalLicenseApplications.AllowUserToAddRows = false;
            this.dtInternationalLicenseApplications.AllowUserToDeleteRows = false;
            this.dtInternationalLicenseApplications.AllowUserToOrderColumns = true;
            this.dtInternationalLicenseApplications.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dtInternationalLicenseApplications.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtInternationalLicenseApplications.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtInternationalLicenseApplications.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtInternationalLicenseApplications.ColumnHeadersHeight = 40;
            this.dtInternationalLicenseApplications.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtInternationalLicenseApplications.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtInternationalLicenseApplications.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.dtInternationalLicenseApplications.Location = new System.Drawing.Point(12, 225);
            this.dtInternationalLicenseApplications.Name = "dtInternationalLicenseApplications";
            this.dtInternationalLicenseApplications.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtInternationalLicenseApplications.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtInternationalLicenseApplications.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dtInternationalLicenseApplications.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dtInternationalLicenseApplications.RowTemplate.Height = 35;
            this.dtInternationalLicenseApplications.Size = new System.Drawing.Size(1195, 283);
            this.dtInternationalLicenseApplications.TabIndex = 82;
            this.dtInternationalLicenseApplications.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;
            this.dtInternationalLicenseApplications.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.dtInternationalLicenseApplications.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.dtInternationalLicenseApplications.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(52)))));
            this.dtInternationalLicenseApplications.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dtInternationalLicenseApplications.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dtInternationalLicenseApplications.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.dtInternationalLicenseApplications.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.dtInternationalLicenseApplications.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtInternationalLicenseApplications.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtInternationalLicenseApplications.ThemeStyle.HeaderStyle.Height = 40;
            this.dtInternationalLicenseApplications.ThemeStyle.ReadOnly = true;
            this.dtInternationalLicenseApplications.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dtInternationalLicenseApplications.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtInternationalLicenseApplications.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.dtInternationalLicenseApplications.ThemeStyle.RowsStyle.Height = 35;
            this.dtInternationalLicenseApplications.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(52)))));
            this.dtInternationalLicenseApplications.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsShowPersonInfo,
            this.tsShowLicenseInfo,
            this.tsShowLicenseHistory});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(213, 94);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // tsShowPersonInfo
            // 
            this.tsShowPersonInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsShowPersonInfo.Image = global::My_DVLD.Properties.Resources.personal_profile;
            this.tsShowPersonInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsShowPersonInfo.Name = "tsShowPersonInfo";
            this.tsShowPersonInfo.Size = new System.Drawing.Size(212, 30);
            this.tsShowPersonInfo.Text = "Show Person Info";
            this.tsShowPersonInfo.Click += new System.EventHandler(this.tsShowPersonInfo_Click);
            // 
            // tsShowLicenseInfo
            // 
            this.tsShowLicenseInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsShowLicenseInfo.Image = global::My_DVLD.Properties.Resources.credit_card;
            this.tsShowLicenseInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsShowLicenseInfo.Name = "tsShowLicenseInfo";
            this.tsShowLicenseInfo.Size = new System.Drawing.Size(212, 30);
            this.tsShowLicenseInfo.Text = "Show License Info";
            this.tsShowLicenseInfo.Click += new System.EventHandler(this.tsShowLicenseInfo_Click);
            // 
            // tsShowLicenseHistory
            // 
            this.tsShowLicenseHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsShowLicenseHistory.Image = global::My_DVLD.Properties.Resources.history;
            this.tsShowLicenseHistory.Name = "tsShowLicenseHistory";
            this.tsShowLicenseHistory.Size = new System.Drawing.Size(212, 30);
            this.tsShowLicenseHistory.Text = "Show Licenses History";
            this.tsShowLicenseHistory.Click += new System.EventHandler(this.tsShowLicenseHistory_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.label3.Location = new System.Drawing.Point(12, 518);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 21);
            this.label3.TabIndex = 90;
            this.label3.Text = "Records:  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.label2.Location = new System.Drawing.Point(408, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(404, 32);
            this.label2.TabIndex = 88;
            this.label2.Text = "International License Applications";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.label1.Location = new System.Drawing.Point(12, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 21);
            this.label1.TabIndex = 87;
            this.label1.Text = "Filter By:";
            // 
            // tbxSearch
            // 
            this.tbxSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.tbxSearch.BorderRadius = 10;
            this.tbxSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxSearch.DefaultText = "";
            this.tbxSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbxSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbxSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.tbxSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.tbxSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbxSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.tbxSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.tbxSearch.Location = new System.Drawing.Point(411, 192);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.PlaceholderText = "";
            this.tbxSearch.SelectedText = "";
            this.tbxSearch.Size = new System.Drawing.Size(194, 27);
            this.tbxSearch.TabIndex = 86;
            this.tbxSearch.TextChanged += new System.EventHandler(this.tbxSearch_TextChanged);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.BackColor = System.Drawing.Color.Transparent;
            this.cbFilterBy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.cbFilterBy.BorderRadius = 10;
            this.cbFilterBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.cbFilterBy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbFilterBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbFilterBy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFilterBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.cbFilterBy.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.cbFilterBy.ItemHeight = 21;
            this.cbFilterBy.Items.AddRange(new object[] {
            "Int.License ID",
            "Application ID",
            "Driver ID",
            "L.License ID"});
            this.cbFilterBy.Location = new System.Drawing.Point(251, 192);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(154, 27);
            this.cbFilterBy.StartIndex = 1;
            this.cbFilterBy.TabIndex = 85;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
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
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 16;
            this.guna2Elipse1.TargetControl = this.dtInternationalLicenseApplications;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.guna2ControlBox1.BorderRadius = 8;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1192, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(26, 21);
            this.guna2ControlBox1.TabIndex = 93;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 16;
            this.guna2Elipse2.TargetControl = this.contextMenuStrip1;
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
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(211)))));
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.btnClose.Image = global::My_DVLD.Properties.Resources.icons8_exit_24;
            this.btnClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClose.ImageOffset = new System.Drawing.Point(4, 0);
            this.btnClose.Location = new System.Drawing.Point(1099, 518);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 40);
            this.btnClose.TabIndex = 89;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssueInternationalLicense
            // 
            this.btnIssueInternationalLicense.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(113)))), ((int)(((byte)(101)))));
            this.btnIssueInternationalLicense.BorderRadius = 10;
            this.btnIssueInternationalLicense.BorderThickness = 2;
            this.btnIssueInternationalLicense.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIssueInternationalLicense.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIssueInternationalLicense.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIssueInternationalLicense.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnIssueInternationalLicense.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnIssueInternationalLicense.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnIssueInternationalLicense.ForeColor = System.Drawing.Color.White;
            this.btnIssueInternationalLicense.Image = global::My_DVLD.Properties.Resources.global;
            this.btnIssueInternationalLicense.ImageSize = new System.Drawing.Size(24, 24);
            this.btnIssueInternationalLicense.Location = new System.Drawing.Point(1142, 185);
            this.btnIssueInternationalLicense.Name = "btnIssueInternationalLicense";
            this.btnIssueInternationalLicense.Size = new System.Drawing.Size(65, 34);
            this.btnIssueInternationalLicense.TabIndex = 84;
            this.btnIssueInternationalLicense.Click += new System.EventHandler(this.btnIssueInternationalLicense_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::My_DVLD.Properties.Resources.driver_license__3_;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(517, 35);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(185, 98);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 83;
            this.guna2PictureBox1.TabStop = false;
            // 
            // cbShowActiveState
            // 
            this.cbShowActiveState.BackColor = System.Drawing.Color.Transparent;
            this.cbShowActiveState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.cbShowActiveState.BorderRadius = 10;
            this.cbShowActiveState.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbShowActiveState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShowActiveState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.cbShowActiveState.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbShowActiveState.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cbShowActiveState.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbShowActiveState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.cbShowActiveState.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.cbShowActiveState.ItemHeight = 21;
            this.cbShowActiveState.Items.AddRange(new object[] {
            "Show All",
            "Active Only",
            "Not Active Only"});
            this.cbShowActiveState.Location = new System.Drawing.Point(91, 192);
            this.cbShowActiveState.Name = "cbShowActiveState";
            this.cbShowActiveState.Size = new System.Drawing.Size(154, 27);
            this.cbShowActiveState.StartIndex = 0;
            this.cbShowActiveState.TabIndex = 95;
            this.cbShowActiveState.SelectedIndexChanged += new System.EventHandler(this.cbShowActiveState_SelectedIndexChanged);
            // 
            // frmManageInternationalLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 570);
            this.Controls.Add(this.cbShowActiveState);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.guna2VScrollBar1);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.btnIssueInternationalLicense);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.dtInternationalLicenseApplications);
            this.Name = "frmManageInternationalLicenseApplications";
            this.Text = "DVLD Management system";
            this.Load += new System.EventHandler(this.frmManageInternationalLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtInternationalLicenseApplications)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbRecords;
        private Guna.UI2.WinForms.Guna2VScrollBar guna2VScrollBar1;
        private Guna.UI2.WinForms.Guna2DataGridView dtInternationalLicenseApplications;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox tbxSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilterBy;
        private Guna.UI2.WinForms.Guna2Button btnIssueInternationalLicense;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsShowPersonInfo;
        private System.Windows.Forms.ToolStripMenuItem tsShowLicenseInfo;
        private System.Windows.Forms.ToolStripMenuItem tsShowLicenseHistory;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2ComboBox cbShowActiveState;
    }
}