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
    public partial class frmReleaseDetainedLicense : frmBaseForm
    {
        public frmReleaseDetainedLicense(int LicenseID=-1)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private bool _ValidateLicense(ClsLicenseContent License)
        {
            
            if (!License.IsDetained)
            {
                MessageBox.Show("License is not Detained; no release action is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucFilterByLicenseID1.Focus();
                ucFilterByLicenseID1.FocusOnTbxSearch();
                return false;
            }
            return true;
        }

        int _PersonID;
        int _LicenseID;
        private void ucFilterByLicenseID1_OnSearchButton(ClsLicenseContent obj)
        {
            if (obj == null || !_ValidateLicense(obj))
            {
                btnReleaseDetainLicense.Visible = false;
                llbShowLicenseHistory.Visible = false;
                llbShowLicenseInfo.Visible = false;
                ucDriverLicenseInfo1.LoadDefaultValue();
                ucDetainLicenseInfo1.LoadDefaultValue();
                return;
            }

            _LicenseID = obj.LicenseID;
            if(!ucDriverLicenseInfo1.LoadData(obj) || !ucDetainLicenseInfo1.LoadData(_LicenseID))
            {
                btnReleaseDetainLicense.Visible = false;
                llbShowLicenseHistory.Visible = false;
                llbShowLicenseInfo.Visible = false;
                ucDriverLicenseInfo1.LoadDefaultValue();
                ucDetainLicenseInfo1.LoadDefaultValue();
                MessageBox.Show("Faild to load detained license info,Try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            _PersonID = ucDriverLicenseInfo1.GetPersonID();

            btnReleaseDetainLicense.Visible = true;
            llbShowLicenseHistory.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowPersonLicenseHistory(_PersonID);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void btnReleaseDetainLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this License?", "Release Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (ucDetainLicenseInfo1.SaveData(_PersonID))
            {
                MessageBox.Show("License released successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ucDetainLicenseInfo1.SetReleaseApplicationID();
                llbShowLicenseInfo.Visible = true;
                btnReleaseDetainLicense.Visible = false;
                return;
            }
            else
            {
                MessageBox.Show("Failed to release driver's license", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void llbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmLicenseInfo(_LicenseID);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            if(_LicenseID!=-1)
            {
                ucFilterByLicenseID1.SetTextOnSearchBox(_LicenseID.ToString());
                ucFilterByLicenseID1.EnableOrDisableSearch(false);
                return;
            }
            else
            {
                ucFilterByLicenseID1.EnableOrDisableSearch(true);
                ucFilterByLicenseID1.Focus();
                ucFilterByLicenseID1.FocusOnTbxSearch();

            }
            
        }
    }
}
