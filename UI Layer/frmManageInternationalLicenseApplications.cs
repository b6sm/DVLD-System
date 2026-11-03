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
    public partial class frmManageInternationalLicenseApplications : frmBaseForm
    {
        public frmManageInternationalLicenseApplications()
        {
            InitializeComponent();
        }

        private void _RefreshInternationalLicenseCount()
        {
            lbRecords.Text = dtInternationalLicenseApplications.RowCount.ToString("0");
        }

        private void _RefreshData()
        {

            dtInternationalLicenseApplications.DataSource = ClsInternationalLicenseContent.GetAllInternationalLicense();
            _RefreshInternationalLicenseCount();

        }

        private void frmManageInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            _RefreshData();

            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new DarkColorForContextMenueTrip());
        }

        private void btnIssueInternationalLicense_Click(object sender, EventArgs e)
        {
            Form frm = new frmInterNationalDrivingLicenseApplication();
            frm.ShowInTaskbar=false;
            frm.ShowDialog();
            cbFilterBy.SelectedIndex = 0;
            cbShowActiveState.SelectedIndex = 0;
            tbxSearch.Clear();
            _RefreshData();
        }

        private void _SelectPreviewsRow(int PrivewsRow)
        {
            dtInternationalLicenseApplications.ClearSelection();
            foreach (DataGridViewRow row in dtInternationalLicenseApplications.Rows)
            {

                if (Convert.ToInt32(row.Cells["Int.License ID"].Value) == PrivewsRow)
                {
                    row.Selected = true;

                    dtInternationalLicenseApplications.CurrentCell = row.Cells[0];

                    dtInternationalLicenseApplications.FirstDisplayedScrollingRowIndex = row.Index;


                }

            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsShowLicenseHistory_Click(object sender, EventArgs e)
        {
            int PersonID = ClsDriversContent.GetPersonIDByDriverID((int)dtInternationalLicenseApplications.CurrentRow.Cells["Driver ID"].Value);
            Form frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void tsShowLicenseInfo_Click(object sender, EventArgs e)
        {
            Form frm = new frmInternationalLicenseInfo((int)dtInternationalLicenseApplications.CurrentRow.Cells["Int.License ID"].Value);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void tsShowPersonInfo_Click(object sender, EventArgs e)
        {
            int PersonID = ClsDriversContent.GetPersonIDByDriverID((int)dtInternationalLicenseApplications.CurrentRow.Cells["Driver ID"].Value);
            Form frm = new frmPersonDetails(PersonID);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            int CurrentRowIndex = (int)dtInternationalLicenseApplications.CurrentRow.Cells["Int.License ID"].Value;
            _RefreshData();
            _ApplyFilter();
            _SelectPreviewsRow(CurrentRowIndex);
        }

        enum enActiveState
        {
            All = 0, Active = 1, NotActive = 2
        }

        private void _ApplyFilter()
        {
            DataTable dt = dtInternationalLicenseApplications.DataSource as DataTable;
            if (dt == null)
                return;
            string FilterExpretion = "";

            string SearchValue = tbxSearch.Text.Trim();


            if (!string.IsNullOrEmpty(SearchValue) && cbFilterBy.SelectedItem != null)
            {
                string FilterBy = cbFilterBy.Text;

                if (FilterBy == "Int.License ID" || FilterBy == "Application ID" || FilterBy == "Driver ID" || FilterBy == "L.License ID")
                {
                    if (int.TryParse(SearchValue, out int numricValue))
                        FilterExpretion = $"[{FilterBy}] = {numricValue}";
                    else
                    {
                        FilterExpretion = $"[{FilterBy}] = -1";

                    }

                }
                else
                {
                    SearchValue = SearchValue.Replace("'", "''");
                    FilterExpretion = $"[{FilterBy}] like '%{SearchValue}%'";
                }

            }

            

            if (cbShowActiveState.SelectedItem != null && cbShowActiveState.SelectedIndex != ((int)enActiveState.All))
            {
                bool IsActive = (cbShowActiveState.SelectedIndex == ((int)enActiveState.Active));
                string ReleasedConition = $"[IsActive] = {IsActive}";
                if (string.IsNullOrEmpty(FilterExpretion))
                {
                    FilterExpretion = ReleasedConition;
                }
                else
                {
                    FilterExpretion += $" And {ReleasedConition}";
                }
            }

            dt.DefaultView.RowFilter = FilterExpretion;
            _RefreshInternationalLicenseCount();

        }


        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
            
        }

        private void cbShowActiveState_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxSearch.Clear();
            _ApplyFilter();
            tbxSearch.Focus();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(dtInternationalLicenseApplications.CurrentRow==null||dtInternationalLicenseApplications.CurrentRow.Cells[0].Value==DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
        }
    }
}
