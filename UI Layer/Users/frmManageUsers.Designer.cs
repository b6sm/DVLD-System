
namespace My_DVLD
{
    partial class frmManageUsers
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.dtUsers = new Guna.UI2.WinForms.Guna2DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAddNewUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPhoneCall = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2VScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.cbShowActiveState = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lbRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbFilterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddUser = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2BorderlessForm2 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtUsers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 16;
            this.guna2Elipse1.TargetControl = this.dtUsers;
            // 
            // dtUsers
            // 
            this.dtUsers.AllowUserToAddRows = false;
            this.dtUsers.AllowUserToDeleteRows = false;
            this.dtUsers.AllowUserToOrderColumns = true;
            this.dtUsers.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dtUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtUsers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtUsers.ColumnHeadersHeight = 40;
            this.dtUsers.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtUsers.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtUsers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.dtUsers.Location = new System.Drawing.Point(12, 225);
            this.dtUsers.Name = "dtUsers";
            this.dtUsers.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtUsers.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dtUsers.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dtUsers.RowTemplate.Height = 35;
            this.dtUsers.Size = new System.Drawing.Size(1048, 283);
            this.dtUsers.TabIndex = 99;
            this.dtUsers.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;
            this.dtUsers.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.dtUsers.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.dtUsers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(52)))));
            this.dtUsers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dtUsers.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dtUsers.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.dtUsers.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.dtUsers.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtUsers.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtUsers.ThemeStyle.HeaderStyle.Height = 40;
            this.dtUsers.ThemeStyle.ReadOnly = true;
            this.dtUsers.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dtUsers.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtUsers.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.dtUsers.ThemeStyle.RowsStyle.Height = 35;
            this.dtUsers.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(65)))), ((int)(((byte)(52)))));
            this.dtUsers.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsShowDetails,
            this.toolStripSeparator2,
            this.tsAddNewUser,
            this.tsEdit,
            this.tsDelete,
            this.tsChangePassword,
            this.toolStripSeparator3,
            this.tsSendEmail,
            this.tsPhoneCall});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(195, 248);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // tsShowDetails
            // 
            this.tsShowDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsShowDetails.Image = global::My_DVLD.Properties.Resources.personal_profile;
            this.tsShowDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsShowDetails.Name = "tsShowDetails";
            this.tsShowDetails.Size = new System.Drawing.Size(194, 30);
            this.tsShowDetails.Text = "Show Details";
            this.tsShowDetails.Click += new System.EventHandler(this.tsShowDetails_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(191, 6);
            // 
            // tsAddNewUser
            // 
            this.tsAddNewUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsAddNewUser.Image = global::My_DVLD.Properties.Resources.icons8_add_user_32;
            this.tsAddNewUser.Name = "tsAddNewUser";
            this.tsAddNewUser.Size = new System.Drawing.Size(194, 30);
            this.tsAddNewUser.Text = "Add New User";
            this.tsAddNewUser.Click += new System.EventHandler(this.tsAddNewUser_Click);
            // 
            // tsEdit
            // 
            this.tsEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsEdit.Image = global::My_DVLD.Properties.Resources.edit;
            this.tsEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsEdit.Name = "tsEdit";
            this.tsEdit.Size = new System.Drawing.Size(194, 30);
            this.tsEdit.Text = "Edit";
            this.tsEdit.Click += new System.EventHandler(this.tsEdit_Click);
            // 
            // tsDelete
            // 
            this.tsDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsDelete.Image = global::My_DVLD.Properties.Resources.trash;
            this.tsDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(194, 30);
            this.tsDelete.Text = "Delete";
            this.tsDelete.Click += new System.EventHandler(this.tsDelete_Click);
            // 
            // tsChangePassword
            // 
            this.tsChangePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsChangePassword.Image = global::My_DVLD.Properties.Resources.icons8_password_22;
            this.tsChangePassword.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsChangePassword.Name = "tsChangePassword";
            this.tsChangePassword.Size = new System.Drawing.Size(194, 30);
            this.tsChangePassword.Text = "Change Passsword";
            this.tsChangePassword.Click += new System.EventHandler(this.tsChangePassword_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(191, 6);
            // 
            // tsSendEmail
            // 
            this.tsSendEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsSendEmail.Image = global::My_DVLD.Properties.Resources.icons8_email_22;
            this.tsSendEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsSendEmail.Name = "tsSendEmail";
            this.tsSendEmail.Size = new System.Drawing.Size(194, 30);
            this.tsSendEmail.Text = "Send Email";
            this.tsSendEmail.Click += new System.EventHandler(this.tsSendEmail_Click);
            // 
            // tsPhoneCall
            // 
            this.tsPhoneCall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsPhoneCall.Image = global::My_DVLD.Properties.Resources.icons8_phone_22;
            this.tsPhoneCall.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsPhoneCall.Name = "tsPhoneCall";
            this.tsPhoneCall.Size = new System.Drawing.Size(194, 30);
            this.tsPhoneCall.Text = "Phone Call";
            this.tsPhoneCall.Click += new System.EventHandler(this.tsPhoneCall_Click);
            // 
            // guna2VScrollBar1
            // 
            this.guna2VScrollBar1.BindingContainer = this.dtUsers;
            this.guna2VScrollBar1.BorderRadius = 8;
            this.guna2VScrollBar1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.guna2VScrollBar1.InUpdate = false;
            this.guna2VScrollBar1.LargeChange = 10;
            this.guna2VScrollBar1.Location = new System.Drawing.Point(1042, 225);
            this.guna2VScrollBar1.Minimum = 1;
            this.guna2VScrollBar1.Name = "guna2VScrollBar1";
            this.guna2VScrollBar1.ScrollbarSize = 18;
            this.guna2VScrollBar1.Size = new System.Drawing.Size(18, 283);
            this.guna2VScrollBar1.TabIndex = 107;
            this.guna2VScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.guna2VScrollBar1.Value = 1;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.guna2ControlBox1.BorderRadius = 8;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1040, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(26, 21);
            this.guna2ControlBox1.TabIndex = 108;
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
            this.btnClose.Location = new System.Drawing.Point(952, 518);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 40);
            this.btnClose.TabIndex = 106;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.cbShowActiveState.Size = new System.Drawing.Size(152, 27);
            this.cbShowActiveState.StartIndex = 0;
            this.cbShowActiveState.TabIndex = 105;
            this.cbShowActiveState.SelectedIndexChanged += new System.EventHandler(this.cbShowActiveState_SelectedIndexChanged);
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lbRecords.Location = new System.Drawing.Point(87, 518);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(19, 21);
            this.lbRecords.TabIndex = 104;
            this.lbRecords.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.label3.Location = new System.Drawing.Point(12, 518);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 21);
            this.label3.TabIndex = 103;
            this.label3.Text = "Records:  ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.label1.Location = new System.Drawing.Point(12, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 21);
            this.label1.TabIndex = 102;
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
            this.tbxSearch.Location = new System.Drawing.Point(407, 192);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.PlaceholderText = "";
            this.tbxSearch.SelectedText = "";
            this.tbxSearch.Size = new System.Drawing.Size(194, 27);
            this.tbxSearch.TabIndex = 101;
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
            "User ID",
            "Person ID",
            "Full Name",
            "UserName"});
            this.cbFilterBy.Location = new System.Drawing.Point(249, 192);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(152, 27);
            this.cbFilterBy.StartIndex = 0;
            this.cbFilterBy.TabIndex = 100;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.label2.Location = new System.Drawing.Point(446, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 32);
            this.label2.TabIndex = 98;
            this.label2.Text = "Manage Users";
            // 
            // btnAddUser
            // 
            this.btnAddUser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(113)))), ((int)(((byte)(101)))));
            this.btnAddUser.BorderRadius = 10;
            this.btnAddUser.BorderThickness = 2;
            this.btnAddUser.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddUser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Image = global::My_DVLD.Properties.Resources.icons8_add_user_32;
            this.btnAddUser.ImageSize = new System.Drawing.Size(28, 28);
            this.btnAddUser.Location = new System.Drawing.Point(995, 185);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(65, 34);
            this.btnAddUser.TabIndex = 90;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::My_DVLD.Properties.Resources.icons8_users_100;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(446, 14);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(174, 112);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 81;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2BorderlessForm2
            // 
            this.guna2BorderlessForm2.BorderRadius = 16;
            this.guna2BorderlessForm2.ContainerControl = this;
            this.guna2BorderlessForm2.DockForm = false;
            this.guna2BorderlessForm2.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm2.ResizeForm = false;
            this.guna2BorderlessForm2.TransparentWhileDrag = true;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 10;
            this.guna2Elipse2.TargetControl = this.contextMenuStrip1;
            // 
            // frmManageUsers
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(1067, 570);
            this.Controls.Add(this.guna2VScrollBar1);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbShowActiveState);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.dtUsers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.guna2PictureBox1);
            this.Name = "frmManageUsers";
            this.Load += new System.EventHandler(this.frmManageUsers_Load);
            this.Shown += new System.EventHandler(this.frmManageUsers_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dtUsers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm2;
        private Guna.UI2.WinForms.Guna2Button btnAddUser;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cbShowActiveState;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox tbxSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilterBy;
        private Guna.UI2.WinForms.Guna2DataGridView dtUsers;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2VScrollBar guna2VScrollBar1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsShowDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsAddNewUser;
        private System.Windows.Forms.ToolStripMenuItem tsEdit;
        private System.Windows.Forms.ToolStripMenuItem tsDelete;
        private System.Windows.Forms.ToolStripMenuItem tsChangePassword;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsSendEmail;
        private System.Windows.Forms.ToolStripMenuItem tsPhoneCall;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
    }
}