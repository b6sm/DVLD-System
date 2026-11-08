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
    public partial class frmRenewLicenseApplication : frmBaseForm
    {
        public frmRenewLicenseApplication()
        {
            InitializeComponent();
        }

        int _PersonID;

        private bool _IsLicenseExpireed(DateTime ExpirationDate)
        {
            return (ExpirationDate>DateTime.Now);
        }

        private bool _ValidateLicense(ClsLicenseContent License)
        {
            if (!License.IsActive)
            {
                MessageBox.Show("You can't Renew This License Case it's Not Active!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucFilterByLicenseID1.FocusOnTbxSearch();
                return false;
            }

            if (License.IsDetained)
            {
                MessageBox.Show("You can't Renew This License Case it's Detained!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucFilterByLicenseID1.FocusOnTbxSearch();
                return false;
            }

            if (_IsLicenseExpireed(License.ExpirationDate))
            {
                MessageBox.Show("You can't Renew This License Case it Dosen't expired yet!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucFilterByLicenseID1.FocusOnTbxSearch();
                return false;
            }
            return true;
        }

        private void ucFilterByLicenseID1_OnSearchButton(ClsLicenseContent obj)
        {

            if (obj == null || !_ValidateLicense(obj))
            {
                ucDriverLicenseInfo1.LoadDefaultValue();
                ucApplicationNewLicenseInfo1.LoadDefaultValue();
                btnRenewLicense.Visible = false;
                return;
            }

            if (!ucDriverLicenseInfo1.LoadData(obj) || !ucApplicationNewLicenseInfo1.LoadOldLicenseData(obj))
            {
                llbShowLicenseHistory.Visible = false;
                llbShowNewLicense.Visible = false;
                btnRenewLicense.Visible = false;
                ucDriverLicenseInfo1.LoadDefaultValue();
                ucApplicationNewLicenseInfo1.LoadDefaultValue();
                MessageBox.Show("Faild to load license/Application info,Try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            _PersonID = ucDriverLicenseInfo1.GetPersonID();

            llbShowLicenseHistory.Visible = true;
            btnRenewLicense.Visible = true;
            
        }

        private void llbShowNewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmLicenseInfo(ucApplicationNewLicenseInfo1.GetLicenseID());
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void llbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowPersonLicenseHistory(_PersonID);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void frmRenewLicenseApplication_Load(object sender, EventArgs e)
        {
            ucFilterByLicenseID1.FocusOnTbxSearch();
            if(!ucApplicationNewLicenseInfo1.LoadDefaultValue())
            {
                MessageBox.Show("An error occurred while loading data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to renew this license", "Confirm Renew", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (ucApplicationNewLicenseInfo1.SaveData(_PersonID))
            {
                MessageBox.Show("License Renewed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ucApplicationNewLicenseInfo1.SetNewLicenseID();
                llbShowNewLicense.Visible = true;
                btnRenewLicense.Visible = false;
                return;
            }
            else
            {
                MessageBox.Show("Failed to renew this license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
