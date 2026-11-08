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
    public partial class UcDrivingLicenseApplicationInfo : UserControl
    {
        public UcDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }
        private void _LoadData()
        {
            lbDLAppID.Text = _LDLAppView.LocalDrivingLicenseApplicationID.ToString();
            lbAppliedForLicense.Text = _LDLAppView.ClassName;
            lbPassedTests.Text = _LDLAppView.PassTestCount.ToString() + "/3";
            llbShowLicenseInfo.Enabled = (_LDLAppView.Status == ClsGlobal.enApplicationStatus.Completed.ToString());
        }

        public void EnableShowLicenseInfoLabel()
        {
            llbShowLicenseInfo.Enabled = true;
        }
        ClsLocalDrivingLicenseApplications_ViewContent _LDLAppView;
        public bool LoadData(int LDLAppViewID)
        {
            _LDLAppView = ClsLocalDrivingLicenseApplications_ViewContent.GetLocalDrivingLicenseApplications_ViewByLocalDrivingLicenseApplicationID(LDLAppViewID);
            if (_LDLAppView == null)
            {
                return false;
            }
            _LoadData();
            return true;
        }

        private void llbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int LicenseID = ClsLicenseContent.GetLicenseIDByLocalDrivingLicenseApplicationID(_LDLAppView.LocalDrivingLicenseApplicationID);
            if (LicenseID == -1)
                return;
            Form frm = new frmLicenseInfo(LicenseID);
            frm.ShowDialog();
        }
    }
}
