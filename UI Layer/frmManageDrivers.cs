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
    public partial class frmManageDrivers : frmBaseForm
    {
        public frmManageDrivers()
        {
            InitializeComponent();
        }

        private void _RefreshDriverssCount()
        {
            lbRecords.Text = dtDrivers.RowCount.ToString("0");
        }

        private void _RefreshData()
        {
            dtDrivers.DataSource = ClsDriversContent_View.GetAllDrivers_View();
            _RefreshDriverssCount();

        }


        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _RefreshData();
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new DarkColorForContextMenueTrip());
           
            tbxSearch.Focus();
        }

        private void _ApplyFilter()
        {
            DataTable dt = dtDrivers.DataSource as DataTable;
            if (dt == null)
                return;
            string FilterExpretion = "";

            string SearchValue = tbxSearch.Text.Trim();


            if (!string.IsNullOrEmpty(SearchValue) && cbFilterBy.SelectedItem != null)
            {
                string FilterBy = cbFilterBy.Text;

                if (FilterBy == "Driver ID" || FilterBy == "Person ID")
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

            dt.DefaultView.RowFilter = FilterExpretion;
            _RefreshDriverssCount();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void tsShowDetails_Click(object sender, EventArgs e)
        {
            Form frm = new frmPersonDetails((int)dtDrivers.CurrentRow.Cells["Person ID"].Value);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            int CurrentRowIndex = (int)dtDrivers.CurrentRow.Cells[0].Value;
            _RefreshData();
            _ApplyFilter();
            _SelectPreviewsRow(CurrentRowIndex);
        }

        private void tsShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonLicenseHistory((int)dtDrivers.CurrentRow.Cells["Person ID"].Value);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }

        private void tsIssueInternationalDriver_Click(object sender, EventArgs e)
        {
            if (ClsInternationalLicenseContent.IsThereInternationalLicenseForThisDriverID((int)dtDrivers.CurrentRow.Cells["Driver ID"].Value))
            {
                MessageBox.Show("This driver already has International license.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            Form frm = new frmInterNationalDrivingLicenseApplication();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            int CurrentRowIndex = (int)dtDrivers.CurrentRow.Cells[0].Value;
            _RefreshData();
            _ApplyFilter();
            _SelectPreviewsRow(CurrentRowIndex);

        }

        private void _SelectPreviewsRow(int PrivewsRow)
        {
            dtDrivers.ClearSelection();
            foreach (DataGridViewRow row in dtDrivers.Rows)
            {

                if (Convert.ToInt32(row.Cells[0].Value) == PrivewsRow)
                {
                    row.Selected = true;

                    dtDrivers.CurrentCell = row.Cells[0];

                    dtDrivers.FirstDisplayedScrollingRowIndex = row.Index;


                }

            }
        }


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dtDrivers.CurrentRow == null || dtDrivers.CurrentRow.Cells[0].Value == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
