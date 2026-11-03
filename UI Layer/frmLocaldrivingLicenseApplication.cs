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
    public partial class frmLocaldrivingLicenseApplication : frmBaseForm
    {
        public frmLocaldrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void _RefreshLocalDrivingLicenseApplicationsCount()
        {
            lbRecords.Text = dtLocalDrivingLicenseApplications.RowCount.ToString();
            UpdateScrollBarBounds();

        }

        private void _RefreshData()
        {
            dtLocalDrivingLicenseApplications.DataSource = ClsLocalDrivingLicenseApplications_ViewContent.GetAllGetAllLocalDrivingLicenseApplications_View();
            
            _RefreshLocalDrivingLicenseApplicationsCount();
        }

        private void frmLocaldrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new DarkColorForContextMenueTrip());
            _RefreshData();
            tbxSearch.Select();
            dtLocalDrivingLicenseApplications.MouseWheel += dtLocalDrivingLicenseApplications_MouseWheel;
        }

        private void _ApplyFilter()
        {
            DataTable dt = dtLocalDrivingLicenseApplications.DataSource as DataTable;
            if (dt == null)
                return;
            string FilterExpretion = "";

            string SearchValue = tbxSearch.Text.Trim();


            if (!string.IsNullOrEmpty(SearchValue) && cbFilterBy.SelectedItem != null )
            {
                string FilterBy = cbFilterBy.Text;

                if (FilterBy == "L.D.L.AppID")
                {
                    if (int.TryParse(SearchValue, out int numricValue))
                        FilterExpretion = $"[LocalDrivingLicenseApplicationID] = {numricValue}";
                    else
                    {
                        FilterExpretion = $"[LocalDrivingLicenseApplicationID] = -1";

                    }

                }
                else
                {
                    SearchValue = SearchValue.Replace("'", "''");
                    FilterExpretion = $"[{FilterBy}] like '%{SearchValue}%'";
                }

            }

            dt.DefaultView.RowFilter = FilterExpretion;
            _RefreshLocalDrivingLicenseApplicationsCount();

        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
            
        }

        private void btnAddNewLocalDrivingLicense_Click(object sender, EventArgs e)
        {
            Form frm = new frmNewLocalDrivingLicenseApplication();
            frm.ShowDialog();
            _RefreshData();
        }

        private void _EnableDisableContextMenueStripItemsByStatus()
        {
            string StatusValue = dtLocalDrivingLicenseApplications.CurrentRow.Cells["Status"].Value.ToString();
            bool IsNew = (StatusValue == ClsGlobal.enApplicationStatus.New.ToString());
            bool IsCompleted = (StatusValue == ClsGlobal.enApplicationStatus.Completed.ToString());

            tsCancelApplication.Enabled = IsNew;
            tsDeleteApplication.Enabled = IsNew;
            tsEditApplication.Enabled = IsNew;

            if (!IsNew)
            {
                tsIssueDrivingLicense.Enabled = false;
                tsSechduleTests.Enabled = false;
            }
            if (IsCompleted)
            {
                tsShowLicense.Enabled = true;
            }

        }

        private void _EnableDisableContextMenueStripItemsByPassTestCount()
        {
            int PassTestCount = Convert.ToInt32(dtLocalDrivingLicenseApplications.CurrentRow.Cells["PassTestCount"].Value);
            switch (PassTestCount)
            {
                case 0:
                    tsVisionTest.Enabled = true;
                    tsWrittenTest.Enabled = false;
                    tsSreetTest.Enabled = false;
                    tsShowLicense.Enabled = false;
                    tsIssueDrivingLicense.Enabled = false;
                    tsSechduleTests.Enabled = true;
                    break;
                case 1:
                    tsWrittenTest.Enabled = true;
                    tsVisionTest.Enabled = false;
                    tsSreetTest.Enabled = false;
                    tsShowLicense.Enabled = false;
                    tsIssueDrivingLicense.Enabled = false;
                    tsSechduleTests.Enabled = true;
                    break;
                case 2:
                    tsSreetTest.Enabled = true;
                    tsVisionTest.Enabled = false;
                    tsWrittenTest.Enabled = false;
                    tsShowLicense.Enabled = false;
                    tsIssueDrivingLicense.Enabled = false;
                    tsSechduleTests.Enabled = true;
                    break;
                case 3:
                    tsSechduleTests.Enabled = false;
                    tsIssueDrivingLicense.Enabled = true;
                    break;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dtLocalDrivingLicenseApplications.CurrentRow == null||dtLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value==DBNull.Value)
            {
                e.Cancel = true;
                return;
            }

            _EnableDisableContextMenueStripItemsByPassTestCount();
            _EnableDisableContextMenueStripItemsByStatus();


        }

        private void tsIssueDrivingLicense_Click(object sender, EventArgs e)
        {
            if (dtLocalDrivingLicenseApplications.CurrentRow == null ||
                dtLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value == DBNull.Value)
            {
                return;
            }
            int LocalDrivingLicenseApplicationID = (int)dtLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value;

            Form frm = new frmIssueDrivingLicenseForTheFirstTime(LocalDrivingLicenseApplicationID);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            _RefreshData();
        }

        private void tsShowLicense_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dtLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value;
            int LicenseID = ClsLicenseContent.GetLicenseIDByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);
            if (LicenseID != -1)
            {
                Form frm = new frmLicenseInfo(LicenseID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("There is no license for this local driving license application ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tsSreetTest_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dtLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value;

            Form frm = new frmTestsAppointments((int)ClsGlobal.enTestType.StreetTest, LocalDrivingLicenseApplicationID);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            int CurrentRowIndex = (int)dtLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            _RefreshData();
            _ApplyFilter();
            _SelectPreviewsRow(CurrentRowIndex);
        }

        private void tsWrittenTest_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dtLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value;

            Form frm = new frmTestsAppointments((int)ClsGlobal.enTestType.WrittenTest, LocalDrivingLicenseApplicationID);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            int CurrentRowIndex = (int)dtLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            _RefreshData();
            _ApplyFilter();
            _SelectPreviewsRow(CurrentRowIndex);

        }

        private void tsVisionTest_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dtLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value;

            Form frm = new frmTestsAppointments((int)ClsGlobal.enTestType.VisionTest, LocalDrivingLicenseApplicationID);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            int CurrentRowIndex = (int)dtLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            _RefreshData();
            _ApplyFilter();
            _SelectPreviewsRow(CurrentRowIndex);
        }

        private void _SelectPreviewsRow(int PrivewsRow)
        {
            dtLocalDrivingLicenseApplications.ClearSelection();
            foreach (DataGridViewRow row in dtLocalDrivingLicenseApplications.Rows)
            {

                if (Convert.ToInt32(row.Cells[0].Value) == PrivewsRow)
                {
                    row.Selected = true;

                    dtLocalDrivingLicenseApplications.CurrentCell = row.Cells[0];

                    dtLocalDrivingLicenseApplications.FirstDisplayedScrollingRowIndex = row.Index;


                }

            }
        }

        private void tsPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            string NationalNo = dtLocalDrivingLicenseApplications.CurrentRow.Cells["NationalNo"].Value.ToString();

            int PersonID = ClsPeopleContent.GetPersonIDByNationalNo(NationalNo);

            Form frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            
            
        }

        private void tsApplicationDetails_Click(object sender, EventArgs e)
        {
           
            int LocalDrivingLicenseApplicationID = Convert.ToInt32(dtLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
            Form frm = new frmLocalDrivingLicenseApplicationInfo(LocalDrivingLicenseApplicationID);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            int CurrentRowIndex = (int)dtLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            _RefreshData();
            _ApplyFilter();
            _SelectPreviewsRow(CurrentRowIndex);
        }

        private void tsEditApplication_Click(object sender, EventArgs e)
        {
           
            int LocalDrivingLicenseApplicationID = Convert.ToInt32(dtLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
            Form frm = new frmNewLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            int CurrentRowIndex = (int)dtLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            _RefreshData();
            _ApplyFilter();
            _SelectPreviewsRow(CurrentRowIndex);
        }

        private bool _DeleteLocalDrivingLicenseApplication()
        {
            int LocalDrivingLicenseApplicationID = Convert.ToInt32(dtLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);
            int ApplicationID = ClsLocalDrivingLicenseApplicationsContent.GetApplicationIDByLocalDrivingApplicationID(LocalDrivingLicenseApplicationID);

            if (ApplicationID == -1)
            {
                return false;
            }
            if (ClsLocalDrivingLicenseApplicationsContent.DeleteLocalDrivingLicenseApplicationByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID))
            {
                return ClsApplicationsContent.DeleteApplication(ApplicationID);
            }
            return false;
        }

        private void tsDeleteApplication_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Application?", "Confirm Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (_DeleteLocalDrivingLicenseApplication())
            {
                MessageBox.Show("Application deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbFilterBy.SelectedIndex = 0;
                tbxSearch.Clear();
                _RefreshData();
            }
            else
            {
                MessageBox.Show("Cannot delete this Application because it have related data linked to it in the system.",
                                "Action Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private bool _CancelApplication()
        {
            int LocalDrivingLicenseApplicationID = (int)dtLocalDrivingLicenseApplications.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value;
            int ApplicationID = ClsLocalDrivingLicenseApplicationsContent.GetApplicationIDByLocalDrivingApplicationID(LocalDrivingLicenseApplicationID);
            if (ApplicationID == -1)
            {
                return false;
            }
            return ClsApplicationsContent.UpdateApplicationStatus(ApplicationID, ((int)ClsGlobal.enApplicationStatus.Canceled));
            
        }

        private void tsCancelApplication_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Cancel this Application?", "Confirm Cancel",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (_CancelApplication())
            {
                MessageBox.Show("Application Canceld successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int CurrentRowIndex = (int)dtLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
                _RefreshData();
                _SelectPreviewsRow(CurrentRowIndex);
            }
            else
            {
                MessageBox.Show("An Error Occurated While Cancel the application.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtLocalDrivingLicenseApplications_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtLocalDrivingLicenseApplications.Columns[e.ColumnIndex].Name == "PassTestCount" && e.Value != null)
            {
                e.Value = $"{e.Value} / 3";
                e.FormattingApplied = true;

            }

            dtLocalDrivingLicenseApplications.Columns["LocalDrivingLicenseApplicationID"].HeaderText = "L.D.L.AppID";
            dtLocalDrivingLicenseApplications.Columns["ClassName"].HeaderText = "Class Name";
            dtLocalDrivingLicenseApplications.Columns["NationalNo"].HeaderText = "National No";
            dtLocalDrivingLicenseApplications.Columns["FullName"].HeaderText = "Full Name";
            dtLocalDrivingLicenseApplications.Columns["ApplicationDate"].HeaderText = "Application Date";
            dtLocalDrivingLicenseApplications.Columns["PassTestCount"].HeaderText = "Pass Test Count";

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxSearch.Clear();
            tbxSearch.Focus();
            _ApplyFilter();
        }

        private void UpdateScrollBarBounds()
        {
            dtLocalDrivingLicenseApplications.ScrollBars = ScrollBars.None;
            int totalRows = dtLocalDrivingLicenseApplications.RowCount;

            if (totalRows == 0)
            {
                guna2VScrollBar1.Visible = false;
                return;
            }

            int visibleRows = dtLocalDrivingLicenseApplications.DisplayedRowCount(true);

            if (totalRows > visibleRows)
            {
                guna2VScrollBar1.Visible = true;

                guna2VScrollBar1.Minimum = 0;

                int maxScroll = totalRows - visibleRows;

                guna2VScrollBar1.Maximum = maxScroll > 0 ? maxScroll : 0;

                if (dtLocalDrivingLicenseApplications.FirstDisplayedScrollingRowIndex >= 0)
                {
                    int currentIndex = dtLocalDrivingLicenseApplications.FirstDisplayedScrollingRowIndex;
                    guna2VScrollBar1.Value = Math.Min(currentIndex, guna2VScrollBar1.Maximum);
                }
            }
            else
            {
                guna2VScrollBar1.Visible = false;
            }
        }
        
        private void dtLocalDrivingLicenseApplications_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                // نقل موقع السكرول الأساسي إلى أداة Guna
                if (e.NewValue >= guna2VScrollBar1.Minimum && e.NewValue <= guna2VScrollBar1.Maximum)
                {
                    guna2VScrollBar1.Value = e.NewValue;
                }
            }
        }

        private void guna2VScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            if (guna2VScrollBar1.Value >= 0 && guna2VScrollBar1.Value < dtLocalDrivingLicenseApplications.RowCount)
            {
                dtLocalDrivingLicenseApplications.FirstDisplayedScrollingRowIndex = guna2VScrollBar1.Value;
            }
        }

        private void dtLocalDrivingLicenseApplications_MouseWheel(object sender, MouseEventArgs e)
        {
            if (dtLocalDrivingLicenseApplications.RowCount == 0) return;

            int currentIndex = dtLocalDrivingLicenseApplications.FirstDisplayedScrollingRowIndex;
            if (currentIndex < 0) currentIndex = 0;

            // e.Delta > 0 تعني السكرول للأعلى، e.Delta < 0 تعني السكرول للأسفل
            if (e.Delta > 0)
            {
                // التحرك للأعلى صف واحد
                if (currentIndex > 0)
                {
                    dtLocalDrivingLicenseApplications.FirstDisplayedScrollingRowIndex = currentIndex - 1;
                }
            }
            else if (e.Delta < 0)
            {
                // التحرك للأسفل صف واحد (مع مراعاة الحد الأقصى)
                int visibleRows = dtLocalDrivingLicenseApplications.DisplayedRowCount(true);
                int maxIndex = dtLocalDrivingLicenseApplications.RowCount - visibleRows;

                if (maxIndex > 0 && currentIndex < maxIndex)
                {
                    dtLocalDrivingLicenseApplications.FirstDisplayedScrollingRowIndex = currentIndex + 1;
                }
            }

            // مزامنة أداة Guna2VScrollBar مع الحركة الجديدة
            if (guna2VScrollBar1.Visible && dtLocalDrivingLicenseApplications.FirstDisplayedScrollingRowIndex >= 0)
            {
                guna2VScrollBar1.Value = Math.Min(dtLocalDrivingLicenseApplications.FirstDisplayedScrollingRowIndex, guna2VScrollBar1.Maximum);
            }

   // إلغاء الحدث الأصلي لمنع التداخل
   ((HandledMouseEventArgs)e).Handled = true;
        }

    }
}
