using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace My_DVLD
{
    public partial class frmBaseForm : Form
    {
       


        public frmBaseForm()
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            InitializeComponent();

           
        }

        private void frmBaseForm_Load(object sender, EventArgs e)
        {
           
        }

        public void NotAvailableMessage()
        {
            MessageBox.Show("This Feather Not Available Yet", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
