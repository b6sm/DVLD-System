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
    public partial class frmShowPersonLicenseHistory : frmBaseForm
    {
        int _PersonID;
        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void ucFilter1_OnSearchButtonV2(Busnise_Layer.ClsPeopleContent obj)
        {
            if (obj == null)
                return;
            ucPersonal_info1.LoadPersonInfoByPersonData(obj);
            
        }

        private void _RefreshLicenseCount()
        {
            lbRecords.Text = dtLocalLicenses.RowCount.ToString();
            lbInternationalRecords.Text = dtInterNationalLicense.RowCount.ToString();
        }

        private void _LoadAllLocalLicense()
        {
            
            if (_PersonID == -1)
                return;
            ucFilter1.FillSearchboxAndFulterByWithPersonID(_PersonID);
            dtLocalLicenses.DataSource = ClsLicenseContent.GetAllLicenseByPersonID(_PersonID);
            dtInterNationalLicense.DataSource = ClsInternationalLicenseContent.GetAllInternationalLicenseByPersonID(_PersonID);
            _RefreshLicenseCount();
        }

        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            
            _LoadAllLocalLicense();

            cmsLocalLicenses.Renderer = new ToolStripProfessionalRenderer(new DarkColorForContextMenueTrip());
            cmsInternationalLicenses.Renderer = new ToolStripProfessionalRenderer(new DarkColorForContextMenueTrip());
        }

        private void tsShowLicenseInfo_Click(object sender, EventArgs e)
        {
            Form frm = new frmLicenseInfo((int)dtLocalLicenses.CurrentRow.Cells[0].Value);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsShowInterNationalLicense_Click(object sender, EventArgs e)
        {
            Form frm = new frmInternationalLicenseInfo((int)dtInterNationalLicense.CurrentRow.Cells["Int.License ID"].Value);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void cmsLocalLicenses_Opening(object sender, CancelEventArgs e)
        {
            if (dtLocalLicenses.CurrentRow == null || dtLocalLicenses.CurrentRow.Cells[0].Value == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
        }

        private void cmsInternationalLicenses_Opening(object sender, CancelEventArgs e)
        {
            if (dtInterNationalLicense.CurrentRow == null || dtInterNationalLicense.CurrentRow.Cells["Int.License ID"].Value == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
        }
    }
}
