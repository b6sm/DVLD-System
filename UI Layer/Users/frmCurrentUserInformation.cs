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
    public partial class frmCurrentUserInformation : frmBaseForm
    {
        ClsUserContent _User;
        public frmCurrentUserInformation(ClsUserContent User)
        {
            InitializeComponent();
            _User = User;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void frmCurrentUserInformation_Load(object sender, EventArgs e)
        {
            ucLoginInformation1.LoadData(_User);
            ucPersonal_info1.LoadPersonInfo(_User.PersonID);
        }
    }
}
