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
    public partial class frmManageDetainedLicense : frmBaseForm
    {
        public frmManageDetainedLicense()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _RefreshDetainLicenseCount()
        {
            lbRecords.Text = dtDetainLicenses.RowCount.ToString();
        }

        private void _RefreshData()
        {

            dtDetainLicenses.DataSource = ClsDetainLicensesContent_View.GetAllDetainLicense_View();
            _RefreshDetainLicenseCount();
            
        }

        private void frmManageDetainedLicense_Load(object sender, EventArgs e)
        {
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new DarkColorForContextMenueTrip());
            _RefreshData();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            Form frm = new frmDetainLicense();
            frm.ShowInTaskbar = false;
            frm.Owner = this;
            frm.ShowDialog();
            cbFilterBy.SelectedIndex = 0;
            tbxSearch.Clear();
            _RefreshData();
        }

        private void btnReleaseDetainLicense_Click(object sender, EventArgs e)
        {
            Form frm = new frmReleaseDetainedLicense();
            frm.ShowInTaskbar = false;
            frm.Owner = this;
            frm.ShowDialog();
            cbFilterBy.SelectedIndex = 0;
            cbShowDetainedOrReleasedLicense.SelectedIndex = 0;
            tbxSearch.Clear();
            _RefreshData();

        }

        private void dtDetainLicenses_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtDetainLicenses.Columns[e.ColumnIndex].Name == "FineFees" && e.Value != null)
            {
                e.Value = $"{((decimal)e.Value).ToString("0")}";
                e.FormattingApplied = true;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dtDetainLicenses.CurrentRow == null || dtDetainLicenses.CurrentRow.Cells[0].Value == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            bool IsRelease = Convert.ToBoolean(dtDetainLicenses.CurrentRow.Cells["IsRelease"].Value);
            switch (IsRelease)
            {
                case true:
                    tsReleaseLicense.Enabled = false;
                    break;
                default:
                    tsReleaseLicense.Enabled = true;
                    break;
            }
        }

        private void _SelectPreviewsRow(int PrivewsRow)
        {
            dtDetainLicenses.ClearSelection();
            foreach (DataGridViewRow row in dtDetainLicenses.Rows)
            {
                
                    if (Convert.ToInt32(row.Cells[0].Value) == PrivewsRow)
                    {
                        row.Selected = true;

                        dtDetainLicenses.CurrentCell = row.Cells[0];

                        dtDetainLicenses.FirstDisplayedScrollingRowIndex = row.Index;

                        
                    }
                
            }
        }

        private void tsReleaseLicense_Click(object sender, EventArgs e)
        {
            Form frm = new frmReleaseDetainedLicense((int)dtDetainLicenses.CurrentRow.Cells["L.ID"].Value);
            frm.ShowInTaskbar = false;
            frm.Owner = this;
            frm.ShowDialog();
            int CurrentRowIndex = (int)dtDetainLicenses.CurrentRow.Cells[0].Value;
            _RefreshData();
            _SelectPreviewsRow(CurrentRowIndex);

        }

        private void _ApplyFilter()
        {
            DataTable dt = dtDetainLicenses.DataSource as DataTable;
            if (dt == null)
                return;
            string FilterExpretion = "";

            string SearchValue = tbxSearch.Text.Trim();


            if (!string.IsNullOrEmpty(SearchValue)&&cbFilterBy.SelectedItem!=null)
            {
                string FilterBy = cbFilterBy.Text;

                if (FilterBy == "D.ID" || FilterBy == "L.ID")
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

            if(cbShowDetainedOrReleasedLicense.SelectedItem!=null&&cbShowDetainedOrReleasedLicense.SelectedIndex!=((int)enShowDetainedOrReleasedLicense.ShowAll))
            {
                bool IsReleased = (cbShowDetainedOrReleasedLicense.SelectedIndex == ((int)enShowDetainedOrReleasedLicense.ShowReleased));
                string ReleasedConition = $"[IsRelease] = {IsReleased}";
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
            _RefreshDetainLicenseCount();

        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {

            _ApplyFilter();
            
        }

        enum enShowDetainedOrReleasedLicense
        {
            ShowAll=0,ShowDetained=1,ShowReleased=2
        }

        private void cbShowDetainedOrReleasedLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
            
        }

        int _PersonID = -1;

        private void tsShowPersonInfo_Click(object sender, EventArgs e)
        {
            _PersonID = ClsPeopleContent.GetPersonIDByNationalNo((string)dtDetainLicenses.CurrentRow.Cells["NationalNo"].Value);
            Form frm = new frmPersonDetails(_PersonID);
            frm.ShowInTaskbar = false;
            frm.Owner = this;
            frm.ShowDialog();
            int CurrentRowIndex = (int)dtDetainLicenses.CurrentRow.Cells["D.ID"].Value;
            _RefreshData();
            _SelectPreviewsRow(CurrentRowIndex);


        }

        private void tsShowLicenseInfo_Click(object sender, EventArgs e)
        {
            Form frm = new frmLicenseInfo((int)dtDetainLicenses.CurrentRow.Cells["L.ID"].Value);
            frm.ShowInTaskbar = false;
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void tsShowLicenseHistory_Click(object sender, EventArgs e)
        {
            _PersonID = ClsPeopleContent.GetPersonIDByNationalNo((string)dtDetainLicenses.CurrentRow.Cells["NationalNo"].Value);
            Form frm = new frmShowPersonLicenseHistory(_PersonID);
            frm.ShowInTaskbar = false;
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxSearch.Clear();
            _ApplyFilter();
            tbxSearch.Focus();

        }
    }
}
