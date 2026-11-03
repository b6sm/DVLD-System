using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Busnise_Layer;

namespace My_DVLD
{
    public partial class Form1 : frmBaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageApplicationTypes();

            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageDrivers();
           
            frm.ShowDialog();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManagePeople();
           
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageUsers();
           
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmCurrentUserInformation(ClsGlobal.CurrentUser);
            
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmChangeUserPassword(ClsGlobal.CurrentUser);
            
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuStrip1.Renderer = new FormMain();

            ClsGlobal.dtCountries = ClsCountriesContent.GetAllCountries();
            ClsGlobal.dtLicenseClass = ClsLicenseClassContent.GetAllLicenseClass();

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Form frm = new frmDetainLicense();
           
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmNewLocalDrivingLicenseApplication();
           
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmLocaldrivingLicenseApplication();
            
            frm.ShowDialog();
        }

        private void replacmentForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmReplacementForDamagedLicense();
            
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmInterNationalDrivingLicenseApplication();
            
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmRenewLicenseApplication();
           
            frm.ShowDialog();
        }

        private void tsReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            Form frm = new frmReleaseDetainedLicense();
           
            frm.ShowDialog();
        
        }

        


        private void tsManageDetainedLicenses_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageDetainedLicense();

            frm.ShowDialog();


        }

        private void internationalLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageInternationalLicenseApplications();

            frm.ShowDialog();
        }

        private void tsManageTestTypes_Click(object sender, EventArgs e)
        {
            Form frm = new frmManageTestTypes();

            frm.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Environment.Exit(0);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_CLOSE = 0x0010;
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            // عند استلام أمر الإغلاق من شريط المهام أو النظام
            if (this.DialogResult != DialogResult.OK && (m.Msg == WM_CLOSE || (m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_CLOSE)))
            {
                // ينهي الـ Process بالكامل فوراً ويتجاوز حظر الـ ShowDialog
                Environment.Exit(0);
                return;
            }

            base.WndProc(ref m);
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmLocaldrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }
    }
}
