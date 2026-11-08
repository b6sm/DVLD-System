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
    public partial class UCLoginInformation : UserControl
    {
        public UCLoginInformation()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            lbUserID.Text = _User.UserID.ToString();
            lbUserName.Text = _User.UserName;
            lbIsActive.Text = (_User.IsActive) ? "Yes" : "No";
        }


        ClsUserContent _User;
        public void LoadData(ClsUserContent User)
        {
            _User = User;
            _LoadData();
        }

    }
}
