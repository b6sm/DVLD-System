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
using Guna.UI2.WinForms;

namespace My_DVLD
{
    public partial class UcDetain_License : UserControl
    {
        public UcDetain_License()
        {
            InitializeComponent();
        }
        int _LicenseID;
        private bool _LoadData()
        {
            lbLicenseID.Text = _LicenseID.ToString();
            tbxFineFees.Enabled = true;
            return true;
        }

        public bool LoadData(int LicenseID)
        {
            _LicenseID = LicenseID;
            return _LoadData();
        }

        private bool _ValidateTextBox(Guna2TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text) || !int.TryParse(tbxFineFees.Text, out int numricValue))
            {
                textBox.BorderColor = Color.FromArgb(235, 87, 87);
                textBox.FocusedState.BorderColor = Color.FromArgb(235, 87, 87);
                textBox.HoverState.BorderColor = Color.FromArgb(255, 110, 110);

                guna2HtmlToolTip1.Active = true;
                return false;
            }
            else
            {
                textBox.BorderColor = Color.FromArgb(75, 75, 75);
                textBox.FocusedState.BorderColor = Color.FromArgb(140, 140, 140);
                textBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);


                return true;
            }

        }

        private bool _CheckIfFeesIsValidate()
        {
            
            if (!_ValidateTextBox(tbxFineFees))
            {                
                    guna2HtmlToolTip1.Show("You should enter a valid number", tbxFineFees, 0, -35);

                    tbxFineFees.Focus();

                return false;
            }
            return true;

        }

        public bool checkIfFineFeesHasNumber()
        {
            return _CheckIfFeesIsValidate();
        }

        ClsDetainLicenseContent _DetainLicense = new ClsDetainLicenseContent();
        private bool _SaveNewDetainLicense()
        {
            if (!decimal.TryParse(tbxFineFees.Text, out decimal FineFees))
            {
                return false;
            }
            _DetainLicense.LicenseID = _LicenseID;
            _DetainLicense.CreatedByUserID = ClsGlobal.CurrentUser.UserID;
            
            _DetainLicense.FineFees = FineFees;
            _DetainLicense.DetainDate = DateTime.Now;

            if (_DetainLicense.Save() && ClsLicenseContent.DetainLicesneByLicenseID(_LicenseID))
            {
                return true;
            }
            return false;
           

        }

        public bool SaveData()
        {
            return _SaveNewDetainLicense();
        }

        public void SetDetinID()
        {
            lbDetainID.Text = _DetainLicense.DetainID.ToString();
        }

        private void tbxFineFees_TextChanged(object sender, EventArgs e)
        {

            tbxFineFees.BorderColor = Color.FromArgb(75, 75, 75);
            tbxFineFees.FocusedState.BorderColor = Color.FromArgb(140, 140, 140);
            tbxFineFees.HoverState.BorderColor = Color.FromArgb(94, 148, 255);


            guna2HtmlToolTip1.Hide(tbxFineFees);
        }

        private void tbxFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && ! char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        
        public void LoadDefaultValue()
        {
            _DetainLicense = new ClsDetainLicenseContent();
            _LicenseID = -1;
            lbDetainID.Text = "[????]";
            lbLicenseID.Text = "[????]";
            lbCreatedBy.Text = ClsGlobal.CurrentUser.UserName;
            lbDetainDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            tbxFineFees.Clear();
            tbxFineFees.Enabled = false;

        }

    }
}
