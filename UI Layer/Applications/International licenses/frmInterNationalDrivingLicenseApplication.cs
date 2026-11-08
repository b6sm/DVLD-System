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
    public partial class frmInterNationalDrivingLicenseApplication : frmBaseForm
    {
        public frmInterNationalDrivingLicenseApplication()
        {
            InitializeComponent();
        }
        
        private bool _IsLicenseExpired(DateTime ExpirationDate)
        {
            return (ExpirationDate<DateTime.Now);
        }

        private bool _ValidateLicense(ClsLicenseContent License)
        {

            if (ClsInternationalLicenseContent.IsThereInternationalLicenseForThisDriverID(License.DriverID))
            {
                MessageBox.Show("You can't Create International License For This Person Case he Already Has!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucFilterByLicenseID1.Focus();
                ucFilterByLicenseID1.FocusOnTbxSearch();
                return false;
            }


            if (License.IsDetained)
            {
                MessageBox.Show("You can't Create International License For This License Case It's Detained!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucFilterByLicenseID1.Focus();
                ucFilterByLicenseID1.FocusOnTbxSearch();
                return false;
            }

            if (!License.IsActive)
            {
                MessageBox.Show("You can't Create International License For This License Case It's Not Active!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucFilterByLicenseID1.Focus();
                ucFilterByLicenseID1.FocusOnTbxSearch();
                return false;
            }

            if (License.LicenseClassID != ((int)ClsGlobal.enLicenseClass.Class3))
            {
                MessageBox.Show("You can't Create International License For This License Case It's Not Ordenary Driving License Class  !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucFilterByLicenseID1.Focus();
                ucFilterByLicenseID1.FocusOnTbxSearch();
                return false;
            }

            if (_IsLicenseExpired(License.ExpirationDate))
            {
                MessageBox.Show("You can't Create International License for this License Case it expired!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucFilterByLicenseID1.Focus();
                ucFilterByLicenseID1.FocusOnTbxSearch();
                return false;
            }

            return true;
        }

        int _PersonID;
        int _DriverID;
        private void ucFilterByLicenseID1_OnSearchButton(ClsLicenseContent obj)
        {
            if (obj == null || !_ValidateLicense(obj))
            {
                ucDriverLicenseInfo1.LoadDefaultValue();
                ucInterNationalLicenseApplicationInfo1.LoadDefaultValue();

                llbShowLicenseHistory.Visible = false;
                llbShowLicenseInfo.Visible = false;
                btnIssueLicense.Visible = false;
                return;
            }

            if (!ucDriverLicenseInfo1.LoadData(obj) || !ucInterNationalLicenseApplicationInfo1.LoadData(obj))
            {
                llbShowLicenseHistory.Visible = false;
                llbShowLicenseInfo.Visible = false;
                btnIssueLicense.Visible = false;
                ucDriverLicenseInfo1.LoadDefaultValue();
                ucInterNationalLicenseApplicationInfo1.LoadDefaultValue();
                MessageBox.Show("Faild to load license or Application info,Try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _DriverID = obj.DriverID;
            _PersonID = ucDriverLicenseInfo1.GetPersonID();

            btnIssueLicense.Visible = true;
            llbShowLicenseHistory.Visible = true;
        }

        private void llbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowPersonLicenseHistory(_PersonID);
            frm.ShowInTaskbar = false;
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Issue new International Driving License?", "question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (ucInterNationalLicenseApplicationInfo1.SaveData(_PersonID))
            {
                MessageBox.Show("License Issued successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ucInterNationalLicenseApplicationInfo1.SetNewInternationalLicenseID();
                llbShowLicenseInfo.Visible = true;
                btnIssueLicense.Visible = false;
                return;
            }
            else
            {
                MessageBox.Show("Data Dosen't Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmInternationalLicenseInfo(ucInterNationalLicenseApplicationInfo1.GetNewInternationalLicenseID());
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
