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
    public partial class frmPersonDetails : frmBaseForm
    {
        int _PersonID = -1;

        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            ucPersonal_info1.SuspendLayout();
            _PersonID = PersonID;
            ucPersonal_info1.ResumeLayout();
        }

        private void _LoadData()
        {
            ucPersonal_info1.LoadPersonInfo(_PersonID);
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
