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
    public partial class frmManageUsers : frmBaseForm
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _RefreshUsersCount()
        {
            lbRecords.Text = dtUsers.RowCount.ToString("0");
        }

        private void _RefreshData()
        {

            dtUsers.DataSource = ClsUserContent.GetAllUsers();
            _RefreshUsersCount();

        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshData();

            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new DarkColorForContextMenueTrip());
            tbxSearch.Select();

        }

        enum enActiveState
        {
            All = 0, Active = 1, NotActive = 2
        }

        private string _FilterByFilterBy()
        {
            string SearchValue = tbxSearch.Text.Trim();

            string FilterExpretion = "";

            if (!string.IsNullOrEmpty(SearchValue) && cbFilterBy.SelectedItem != null)
            {
                string FilterBy = cbFilterBy.Text;

                if (FilterBy == "User ID" || FilterBy == "Person ID")
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
            return FilterExpretion;
        }

        private string _FilterByActiveUsers(string FilterExpretion)
        {
            if (cbShowActiveState.SelectedItem != null && cbShowActiveState.SelectedIndex != ((int)enActiveState.All))
            {
                bool IsActive = (cbShowActiveState.SelectedIndex == ((int)enActiveState.Active));
                string ReleasedConition = $"[Is Active] = {IsActive}";
                if (string.IsNullOrEmpty(FilterExpretion))
                {
                    FilterExpretion = ReleasedConition;
                }
                else
                {
                    FilterExpretion += $" And {ReleasedConition}";
                }
            }
            return FilterExpretion;
        }

        private void _ApplyFilter()
        {
            DataTable dt = dtUsers.DataSource as DataTable;
            if (dt == null)
                return;
            string FilterExpretion = "";

            string SearchValue = tbxSearch.Text.Trim();

            FilterExpretion = _FilterByFilterBy();

            FilterExpretion = _FilterByActiveUsers(FilterExpretion);

            dt.DefaultView.RowFilter = FilterExpretion;
            _RefreshUsersCount();
        }


        private void cbShowActiveState_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
            tbxSearch.Focus();
        }

        private void _SelectPreviewsRow(int PrivewsRow)
        {
            dtUsers.ClearSelection();
            foreach (DataGridViewRow row in dtUsers.Rows)
            {

                if (Convert.ToInt32(row.Cells[0].Value) == PrivewsRow)
                {
                    row.Selected = true;

                    dtUsers.CurrentCell = row.Cells[0];

                    dtUsers.FirstDisplayedScrollingRowIndex = row.Index;


                }

            }
        }


        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxSearch.Clear();
            _ApplyFilter();
            tbxSearch.Focus();

        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddNewUser();
            frm.ShowInTaskbar = false;
            if(frm.ShowDialog() == DialogResult.Cancel)
                return;
            tbxSearch.Clear();
            cbFilterBy.SelectedIndex = 0;
            cbShowActiveState.SelectedIndex = 0;
            _RefreshData();
        }

        private void tsShowDetails_Click(object sender, EventArgs e)
        {
            ClsUserContent User = ClsUserContent.FindUserByUserID((int)dtUsers.CurrentRow.Cells["User ID"].Value);
            Form frm = new frmCurrentUserInformation(User);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            int CurrentRowIndex = (int)dtUsers.CurrentRow.Cells[0].Value;
            _RefreshData();
            _ApplyFilter();
            _SelectPreviewsRow(CurrentRowIndex);

        }

        private void tsAddNewUser_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddNewUser();
            frm.ShowInTaskbar = false;
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;
            tbxSearch.Clear();
            cbFilterBy.SelectedIndex = 0;
            cbShowActiveState.SelectedIndex = 0;
            _RefreshData();
        }

        private void tsChangePassword_Click(object sender, EventArgs e)
        {
            ClsUserContent User = ClsUserContent.FindUserByUserID((int)dtUsers.CurrentRow.Cells["User ID"].Value);
            Form frm = new frmChangeUserPassword(User);
            frm.ShowInTaskbar = false;
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;
            int CurrentRowIndex = (int)dtUsers.CurrentRow.Cells[0].Value;
            _RefreshData();
            _ApplyFilter();
            _SelectPreviewsRow(CurrentRowIndex);
        }

        private void tsEdit_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddNewUser((int)dtUsers.CurrentRow.Cells["User ID"].Value);
            frm.ShowInTaskbar = false;
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;
            int CurrentRowIndex = (int)dtUsers.CurrentRow.Cells[0].Value;
            _RefreshData();
            _ApplyFilter();
            _SelectPreviewsRow(CurrentRowIndex);
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            int UserID = (int)dtUsers.CurrentRow.Cells["User ID"].Value;

            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if(ClsUserContent.DeleteUserByUserID(UserID))
            {
                MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbxSearch.Clear();
                cbFilterBy.SelectedIndex = 0;
                cbShowActiveState.SelectedIndex = 0;
                _RefreshData();
            }
            else
            {
                MessageBox.Show("This user cannot be deleted because they have performed operations or transactions in the system (e.g. issued licenses or created applications).\n\nYou can deactivate (disable) the user instead.",
                        "Delete Prohibited", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void frmManageUsers_Shown(object sender, EventArgs e)
        {
        }

        private void tsSendEmail_Click(object sender, EventArgs e)
        {
            NotAvailableMessage();
        }

        private void tsPhoneCall_Click(object sender, EventArgs e)
        {
            NotAvailableMessage();

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(dtUsers.CurrentRow==null||dtUsers.CurrentRow.Cells[0].Value==DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
        }
    }
}
