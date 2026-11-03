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
    public partial class frmLocalDrivingLicenseApplicationInfo : frmBaseForm
    {
        int _LDLAppID;
        public frmLocalDrivingLicenseApplicationInfo(int LDLAppID)
        {
            InitializeComponent();
            _LDLAppID = LDLAppID;

        }


        private void frmLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            int ApplicationID = ClsLocalDrivingLicenseApplicationsContent.GetApplicationIDByLocalDrivingApplicationID(_LDLAppID);

            if (ApplicationID == -1 || !ucApplicationIBasicnfo1.LoadData(ApplicationID) || !ucDrivingLicenseApplicationInfo1.LoadData(_LDLAppID))
            {
                MessageBox.Show("An error occurred while loading data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
