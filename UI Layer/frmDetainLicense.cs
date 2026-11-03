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
    public partial class frmDetainLicense : frmBaseForm
    {
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
        }

        private  void frmDetainLicense_Load(object sender, EventArgs e)
        {
            ucFilterByLicenseID1.Focus();
            ucFilterByLicenseID1.FocusOnTbxSearch();
            ucDetain_License1.LoadDefaultValue();
        }


        private bool _ValidateLicense(ClsLicenseContent License)
        {
            if (!License.IsActive)
            {
                MessageBox.Show("You can't Detain This License Case it's Not Active!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucFilterByLicenseID1.Focus();
                ucFilterByLicenseID1.FocusOnTbxSearch();
                return false;
            }

            if (License.IsDetained)
            {
                MessageBox.Show("You can't Detain This License Case it's already Detained!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucFilterByLicenseID1.Focus();
                ucFilterByLicenseID1.FocusOnTbxSearch();
                return false;
            }

            return true;
        }

        int _PersonID;
        int _LicenseID;
        private void ucFilterByLicenseID1_OnSearchButton(Busnise_Layer.ClsLicenseContent obj)
        {
           
            if (obj == null || !_ValidateLicense(obj))
            {
                btnDetainLicense.Visible = false;
                llbShowLicenseHistory.Visible = false;
                llbShowLicenseInfo.Visible = false;

                ucDriverLicenseInfo1.LoadDefaultValue();
                ucDetain_License1.LoadDefaultValue();
                return;
            }

            _LicenseID = obj.LicenseID;

            if (!ucDriverLicenseInfo1.LoadData(obj)
                || !ucDetain_License1.LoadData(_LicenseID))
            {
                btnDetainLicense.Visible = false;
                llbShowLicenseHistory.Visible = false;
                llbShowLicenseInfo.Visible = false;
                ucDriverLicenseInfo1.LoadDefaultValue();
                ucDetain_License1.LoadDefaultValue();
                MessageBox.Show("Faild to load license/Detain info,Try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _PersonID = ucDriverLicenseInfo1.GetPersonID();

            btnDetainLicense.Visible = true;
            llbShowLicenseHistory.Visible = true;
        }

        private void llbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowPersonLicenseHistory(_PersonID);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            if(!ucDetain_License1.checkIfFineFeesHasNumber())
            {
                return;
            }

            if (MessageBox.Show("Are you sure you want to detain this license?", "Detain Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            

            if (ucDetain_License1.SaveData())
            {
                MessageBox.Show("License detained successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ucDetain_License1.SetDetinID();
                llbShowLicenseInfo.Visible = true;
                btnDetainLicense.Visible = false;
                return;
            }
            else
            {
                MessageBox.Show("Failed to detain driver's license", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void llbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmLicenseInfo(_LicenseID);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
