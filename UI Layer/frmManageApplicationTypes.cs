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
    public partial class frmManageApplicationTypes : frmBaseForm
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _RefreshUsersCount()
        {
            lbRecords.Text = dtApplicationTypes.RowCount.ToString("0");
        }

        private void _RefreshData()
        {
            dtApplicationTypes.DataSource = ClsApplicationTypesContent.GetAllApplicationTypes();
            _RefreshUsersCount();

        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshData();
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new DarkColorForContextMenueTrip());
        }

        private void tsEdit_Click(object sender, EventArgs e)
        {
            Form frm = new frmEditeApplicationType((int)dtApplicationTypes.CurrentRow.Cells["ID"].Value);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            _RefreshData();
        }

        private void dtApplicationTypes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtApplicationTypes.Columns[e.ColumnIndex].Name == "Fees" && e.Value != null)
            {
                e.Value = $"{((decimal)e.Value).ToString("0")}";
                e.FormattingApplied = true;

            }
        }
    }
}

