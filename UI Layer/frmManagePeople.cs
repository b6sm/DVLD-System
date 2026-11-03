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
using System.IO;

namespace My_DVLD
{
    public partial class frmManagePeople : frmBaseForm
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void _RefreshPeopleCount()
        {
            lbRecords.Text = dtPeople.RowCount.ToString();
            UpdateScrollBarBounds();

        }

        private void _RefreshData()
        {
            dtPeople.DataSource = ClsPeopleContent.GetAllPeopleWithCountries();

            _RefreshPeopleCount();

        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new DarkColorForContextMenueTrip());

            _RefreshData();
            dtPeople.MouseWheel += dtPeople_MouseWheel;

        }

        private void _ApplyFilter()
        {
            DataTable dt = dtPeople.DataSource as DataTable;
            if (dt == null)
                return;
            string FilterExpretion = "";

            string SearchValue = tbxSearch.Text.Trim();


            if (!string.IsNullOrEmpty(SearchValue) && cbFilterBy.SelectedItem != null &&cbFilterBy.Text!="Gender")
            {
                string FilterBy = cbFilterBy.Text;

                if ( FilterBy == "PersonID")
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
            _RefreshPeopleCount();

        }

        private void _ApplyGenderFilter()
        {

            DataTable dt = dtPeople.DataSource as DataTable;
            if (dt == null)
                return;
            string FilterExpretion = "";

            if (cbGender.SelectedItem != null && cbFilterBy.Text == "Gender" && (cbGender.Text == ClsGlobal.enGender.Male.ToString() || cbGender.Text == ClsGlobal.enGender.Female.ToString()))
            {
                tbxSearch.Clear();
                string SelectedGender = cbGender.SelectedItem.ToString();
                string ReleasedConition = $"[Gender] = '{SelectedGender}'";

                FilterExpretion = $"{ReleasedConition}";

            }

            dt.DefaultView.RowFilter = FilterExpretion;
            _RefreshPeopleCount();
            UpdateScrollBarBounds();

        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyGenderFilter();
        }

        private void _ShowOrHideGenderComboBoxOrTextBoxSearch()
        {
            DataTable dt = dtPeople.DataSource as DataTable;

            if (cbFilterBy.SelectedItem == null || dt == null)
                return;


            if (cbFilterBy.Text == "Gender")
            {
                cbGender.SelectedIndex = 0;
                tbxSearch.Visible = false;
                cbGender.Visible = true;

            }
            else
            {
                tbxSearch.Clear();

                tbxSearch.Visible = true;
                cbGender.Visible = false;
                tbxSearch.Focus();
            }
            _RefreshPeopleCount();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
            _ShowOrHideGenderComboBoxOrTextBoxSearch();
        }

        private void tsSendEmail_Click(object sender, EventArgs e)
        {
            NotAvailableMessage();
        }

        private void tsPhoneCall_Click(object sender, EventArgs e)
        {
            NotAvailableMessage();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _SelectPreviewsRow(int PrivewsRow)
        {
            dtPeople.ClearSelection();
            foreach (DataGridViewRow row in dtPeople.Rows)
            {

                if (Convert.ToInt32(row.Cells[0].Value) == PrivewsRow)
                {
                    row.Selected = true;

                    dtPeople.CurrentCell = row.Cells[0];

                    dtPeople.FirstDisplayedScrollingRowIndex = row.Index;


                }

            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditPersonInfo();
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            cbFilterBy.SelectedIndex = 0;
            tbxSearch.Clear();
            _RefreshData();

        }

        private void dtPeople_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form frm = new frmAddEditPersonInfo((int)dtPeople.CurrentRow.Cells[0].Value);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            int CurrentRowIndex = (int)dtPeople.CurrentRow.Cells[0].Value;
            _RefreshData();
            _ApplyFilter();
            _ApplyGenderFilter();
            _SelectPreviewsRow(CurrentRowIndex);

        }

        private void tsShowDetails_Click(object sender, EventArgs e)
        {
            Form frm = new frmPersonDetails((int)dtPeople.CurrentRow.Cells[0].Value);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            int CurrentRowIndex = (int)dtPeople.CurrentRow.Cells[0].Value;
            _RefreshData();
            _ApplyFilter();
            _ApplyGenderFilter();
            _SelectPreviewsRow(CurrentRowIndex);

        }

        private void tsEdit_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditPersonInfo((int)dtPeople.CurrentRow.Cells[0].Value);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            int CurrentRowIndex = (int)dtPeople.CurrentRow.Cells[0].Value;
            _RefreshData();
            _ApplyFilter();
            _ApplyGenderFilter();
            _SelectPreviewsRow(CurrentRowIndex);

        }

        private void UpdateScrollBarBounds()
        {
            dtPeople.ScrollBars = ScrollBars.None;
            // 1. حساب عدد الصفوف الكلية والصفوف التي تظهر كاملاً داخل المساحة
            int totalRows = dtPeople.RowCount;

            if (totalRows == 0)
            {
                guna2VScrollBar1.Visible = false;
                return;
            }

            // حساب كم صف باين بالكامل داخل الـ DataGridView (من غير الكسر)
            int visibleRows = dtPeople.DisplayedRowCount(true);

            // 2. إذا البيانات تملأ المساحة وزيادة
            if (totalRows > visibleRows)
            {
                guna2VScrollBar1.Visible = true;

                guna2VScrollBar1.Minimum = 0;

                // القيمة القصوى الدقيقة لمنع السكرول من إنه ينزل في المساحة الفاضية
                int maxScroll = totalRows - visibleRows;

                guna2VScrollBar1.Maximum = maxScroll > 0 ? maxScroll : 0;

                // المزامنة الدقيقة
                if (dtPeople.FirstDisplayedScrollingRowIndex >= 0)
                {
                    int currentIndex = dtPeople.FirstDisplayedScrollingRowIndex;
                    guna2VScrollBar1.Value = Math.Min(currentIndex, guna2VScrollBar1.Maximum);
                }
            }
            else
            {
                // إذا الصفوف قليلة وما في حاجة للسكرول
                guna2VScrollBar1.Visible = false;
            }
        }

        private void dtPeople_Scroll_1(object sender, ScrollEventArgs e)
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
            if (guna2VScrollBar1.Value >= 0 && guna2VScrollBar1.Value < dtPeople.RowCount)
            {
                // توجيه الجدول ليتحرك بناءً على قيمة أداة Guna
                dtPeople.FirstDisplayedScrollingRowIndex = guna2VScrollBar1.Value;
            }
        }

        private void dtPeople_MouseWheel(object sender, MouseEventArgs e)
        {
            if (dtPeople.RowCount == 0) return;

            int currentIndex = dtPeople.FirstDisplayedScrollingRowIndex;
            if (currentIndex < 0) currentIndex = 0;

            // e.Delta > 0 تعني السكرول للأعلى، e.Delta < 0 تعني السكرول للأسفل
            if (e.Delta > 0)
            {
                // التحرك للأعلى صف واحد
                if (currentIndex > 0)
                {
                    dtPeople.FirstDisplayedScrollingRowIndex = currentIndex - 1;
                }
            }
            else if (e.Delta < 0)
            {
                // التحرك للأسفل صف واحد (مع مراعاة الحد الأقصى)
                int visibleRows = dtPeople.DisplayedRowCount(true);
                int maxIndex = dtPeople.RowCount - visibleRows;

                if (maxIndex > 0 && currentIndex < maxIndex)
                {
                    dtPeople.FirstDisplayedScrollingRowIndex = currentIndex + 1;
                }
            }

            // مزامنة أداة Guna2VScrollBar مع الحركة الجديدة
            if (guna2VScrollBar1.Visible && dtPeople.FirstDisplayedScrollingRowIndex >= 0)
            {
                guna2VScrollBar1.Value = Math.Min(dtPeople.FirstDisplayedScrollingRowIndex, guna2VScrollBar1.Maximum);
            }

   // إلغاء الحدث الأصلي لمنع التداخل
   ((HandledMouseEventArgs)e).Handled = true;
        }

        private bool _DeletePerson()
        {
            int PersonID = (int)dtPeople.CurrentRow.Cells["PersonID"].Value;
            ClsPeopleContent Person = ClsPeopleContent.FindPerson(PersonID);
            
            if (Person == null)
                return false;

            if(ClsPeopleContent.DeletePersonByPersonID(PersonID))
            {
                if (!string.IsNullOrEmpty(Person.ImagePath))
                {
                    if (File.Exists(Person.ImagePath)) File.Delete(Person.ImagePath);

                }
                return true;
            }
            return false;

        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Are you sure you want to delete this Person?", "Confirm Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (_DeletePerson())
            {
                MessageBox.Show("Person deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbFilterBy.SelectedIndex = 0;
                tbxSearch.Clear();
                _RefreshData();
            }
            else
            {
                MessageBox.Show("Cannot delete this person because they have related data linked to them in the system.",
                                "Action Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
