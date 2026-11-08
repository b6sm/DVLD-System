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
    public partial class UCFilterByLicenseID : UserControl
    {
        public UCFilterByLicenseID()
        {
            InitializeComponent();
        }

        private void tbxSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _FindLicense();
            }

        }

        public event Action<ClsLicenseContent> OnSearchButton;

        public virtual void SearchSelected(ClsLicenseContent License)
        {

            Action<ClsLicenseContent> Handler = OnSearchButton;
            if (Handler != null)
            {
                Handler(License);
            }

        }


        ClsLicenseContent _License;

        private void _FindLicense()
        {
            _License = null;
            string SearchValue = tbxSearchText.Text.Trim();
            if (string.IsNullOrWhiteSpace(SearchValue) || !int.TryParse(SearchValue, out int numricValue))
            {
                OnSearchButton(null);

                tbxSearchText.Focus();
                return;
            }
            
            
            _License = ClsLicenseContent.GetLicenseInfoByLicenseID(numricValue);
            if (_License != null)
            {
                OnSearchButton(_License);
                return;
            }
            
            MessageBox.Show("No license found with ID: " + numricValue, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            OnSearchButton(_License);
            tbxSearchText.Focus();
            
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _FindLicense();
            
        }

        public void FocusOnTbxSearch()
        {
            tbxSearchText.Select();
        }

        private void UCFilterByLicenseID_Load(object sender, EventArgs e)
        {
            
        }

        public void SetTextOnSearchBox(string LicenseID)
        {
            tbxSearchText.Text = LicenseID;
            btnSearch_Click(btnSearch, new EventArgs());
        }

        public void EnableOrDisableSearch(bool EnableSearch)
        {
            guna2GroupBox1.Enabled = EnableSearch;
            
        }
    }
}
