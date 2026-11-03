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
    public partial class frmReplacementForDamagedLicense : frmBaseForm
    {
        public frmReplacementForDamagedLicense()
        {
            InitializeComponent();
        }

        private bool _ValidateLicense(ClsLicenseContent License)
        {

            if (License.IsDetained)
            {
                MessageBox.Show("You can't Replacement This License Case It's  Detained!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucFilterByLicenseID1.Focus();
                ucFilterByLicenseID1.FocusOnTbxSearch();
                return false;
            }

            if (!License.IsActive)
            {
                MessageBox.Show("You can't Replacement This License Case It's Not Active!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucFilterByLicenseID1.Focus();
                ucFilterByLicenseID1.FocusOnTbxSearch();
                return false;
            }
           
            return true;
        }

        int _PersonID;
        private void ucFilterByLicenseID1_OnSearchButton(ClsLicenseContent obj)
        {
            if (obj == null || !_ValidateLicense(obj))
            {
                rbDamagedLicense.Checked = true;
                guna2GroupBox1.Enabled = false;
                btnIssueReplacement.Visible = false;
                llbShowLicensHistory.Visible = false;
                llbShowNewLicenseInfo.Visible = false;

                ucDriverLicenseInfo1.LoadDefaultValue();
                ucApplicationInfoForLicenseReplacement1.LoadDefaultValue();
                return;
            }
            guna2GroupBox1.Enabled = true;

            if (!ucDriverLicenseInfo1.LoadData(obj)
                || !ucApplicationInfoForLicenseReplacement1.LoadData(obj, ((int)ApplicationType) ))
            {
                ucDriverLicenseInfo1.LoadDefaultValue();
                ucApplicationInfoForLicenseReplacement1.LoadDefaultValue();
                MessageBox.Show("Faild to load license/Application info,Try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            _PersonID = ucDriverLicenseInfo1.GetPersonID();

            btnIssueReplacement.Visible = true;
            llbShowLicensHistory.Visible = true;
        }

        ClsGlobal.enApplicationTypes ApplicationType = ClsGlobal.enApplicationTypes.ReplacementForDamagedLicense;
        ClsGlobal.enIssueReason IssueReason = ClsGlobal.enIssueReason.ReplacementForDamaged;

        private void frmReplacementForDamagedLicense_Load(object sender, EventArgs e)
        {
            guna2GroupBox1.Enabled = false;
            if(!ucApplicationInfoForLicenseReplacement1.LoadDefaultValue())
            {
                MessageBox.Show("Faild to load Application info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ucFilterByLicenseID1.FocusOnTbxSearch();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationType = ClsGlobal.enApplicationTypes.ReplacementForLostLicense;
            IssueReason = ClsGlobal.enIssueReason.ReplacementForLost;
            ucApplicationInfoForLicenseReplacement1.ChangeApplicationType(((int)ApplicationType));

        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationType = ClsGlobal.enApplicationTypes.ReplacementForDamagedLicense;
            IssueReason = ClsGlobal.enIssueReason.ReplacementForDamaged;
            ucApplicationInfoForLicenseReplacement1.ChangeApplicationType(((int)ApplicationType));

        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to renew this license", "Confirm Renew", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (ucApplicationInfoForLicenseReplacement1.SaveData(_PersonID,(byte)IssueReason))
            {
                MessageBox.Show("License Renewed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ucApplicationInfoForLicenseReplacement1.SetReplacementLicenseID();
                llbShowNewLicenseInfo.Visible = true;
                btnIssueReplacement.Visible = false;
                return;
            }
            else
            {
                MessageBox.Show("Failed to renew this license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void llbShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            Form frm = new frmLicenseInfo(ucApplicationInfoForLicenseReplacement1.GetLicenseID());
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void llbShowLicensHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowPersonLicenseHistory(_PersonID);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
