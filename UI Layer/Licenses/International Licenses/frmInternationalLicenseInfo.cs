using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_DVLD
{
    public partial class frmInternationalLicenseInfo : frmBaseForm
    {
        int _IntLicenseID;
        public frmInternationalLicenseInfo(int IntLicenseID)
        {
            InitializeComponent();
            _IntLicenseID = IntLicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            if (!ucDriverInternationalLicenseInfo1.LoadData(_IntLicenseID))
            {
                MessageBox.Show("An error occurred While Loading Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }
    }
}
