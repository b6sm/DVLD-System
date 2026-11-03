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
    public partial class frmIssueDrivingLicenseForTheFirstTime : frmBaseForm
    {
        int _LDLAppID;
        public frmIssueDrivingLicenseForTheFirstTime(int LDLAppID)
        {
            InitializeComponent();
            _LDLAppID = LDLAppID;
        }
        int _ApplicationID;
        private void frmIssueDrivingLicenseForTheFirstTime_Load(object sender, EventArgs e)
        {
            _ApplicationID = ClsLocalDrivingLicenseApplicationsContent.GetApplicationIDByLocalDrivingApplicationID(_LDLAppID);

            if (_ApplicationID == -1 || !ucApplicationIBasicnfo1.LoadData(_ApplicationID) || !ucDrivingLicenseApplicationInfo1.LoadData(_LDLAppID))
            {
                MessageBox.Show("An error occurred while loading data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue a driving license for this application?",
                                "Confirm Issue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (ucApplicationIBasicnfo1.IssueNewLicense(_LDLAppID,tbxNotes.Text.Trim()))
            {
               
                MessageBox.Show("License Issued Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ucApplicationIBasicnfo1.UpdateApplicationStatus();
                btnIssueLicense.Visible = false;
                ucDrivingLicenseApplicationInfo1.EnableShowLicenseInfoLabel();
                return;
            }
            else
            {
                MessageBox.Show("An Error Occured While issuing the License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
