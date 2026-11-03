using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Busnise_Layer;

namespace My_DVLD
{
    public partial class frmEditTestType : frmBaseForm
    {
        int _ID;
        public frmEditTestType(int ID)
        {
            InitializeComponent();
            _ID = ID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        ClsTestTypeContent _TestType;
        private void _LoadData()
        {

            _TestType = ClsTestTypeContent.FindTestTypeByTestTypeID(_ID);
            if (_TestType == null)
            {

                return;
            }

            tbxTitle.Text = _TestType.TestTypeTitle;
            tbxFees.Text = _TestType.TestTypeFees.ToString("0");
            lbID.Text = _TestType.TestTypeID.ToString();
            tbxDescription.Text = _TestType.TestTypeDescraption;


        }

        private void frmEditeApplicationType_Load(object sender, EventArgs e)
        {
            _LoadData();

        }

        private void tbxFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void _SetTextBoxBorderState(Guna2TextBox textBox, bool IsValid)
        {
            if (!IsValid)
            {
                textBox.BorderColor = Color.FromArgb(235, 87, 87);
                textBox.FocusedState.BorderColor = Color.FromArgb(235, 87, 87);
                textBox.HoverState.BorderColor = Color.FromArgb(255, 110, 110);

            }

            else
            {
                textBox.BorderColor = Color.FromArgb(75, 75, 75);
                textBox.FocusedState.BorderColor = Color.FromArgb(140, 140, 140);
                textBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);

            }
        }

        private bool _ValidateTextBox(Guna2TextBox textBox)
        {

            bool IsValid = !string.IsNullOrWhiteSpace(textBox.Text);
            _SetTextBoxBorderState(textBox, IsValid);
            if (!IsValid)
            {
                guna2HtmlToolTip1.Active = true;
            }

            return IsValid;
        }

        private bool _ValidateNumber(Guna2TextBox textBox)
        {

            bool IsValid =  decimal.TryParse(tbxFees.Text.Trim(), out decimal numricValue);
            _SetTextBoxBorderState(textBox, IsValid);
            if (!IsValid)
            {
                guna2HtmlToolTip1.Active = true;
            }

            return IsValid;
        }

        private bool _CheckIfAllDataValidate()
        {
            bool IsValidate = true;
            Guna2TextBox FirstEmptyTextBox = null;

            if (!_ValidateTextBox(tbxFees))
            {
                IsValidate = false;
                if (FirstEmptyTextBox == null)
                    FirstEmptyTextBox = tbxFees;
            }

            if (!_ValidateTextBox(tbxDescription))
            {
                IsValidate = false;
                if (FirstEmptyTextBox == null)
                    FirstEmptyTextBox = tbxDescription;
            }

            if (!IsValidate)
            {
                if (FirstEmptyTextBox != null)
                {
                    guna2HtmlToolTip1.Show("This Field Is Requerd.", FirstEmptyTextBox, 0, -35, 3000);

                    FirstEmptyTextBox.Focus();
                }

                return IsValidate;
            }

            if (!_ValidateNumber(tbxFees))
            {
                IsValidate = false;
                guna2HtmlToolTip1.Show("You Should Enter A Valid Number.", tbxFees, 0, -35, 3000);

                tbxFees.Focus();
            }
            return IsValidate;
        }

        private bool _Save()
        {
            _TestType.TestTypeFees = decimal.Parse(tbxFees.Text.Trim());
            _TestType.TestTypeDescraption = tbxDescription.Text.Trim();

            if(_TestType.UpdateTestTypeData())
            {
                return true;
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_CheckIfAllDataValidate())
                return;

            if (MessageBox.Show("Are you sure you want to save the changes for this Test Type?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (_Save())
            {
                MessageBox.Show("Data Saved Succesfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("An error occurred while saving the data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void tbxFees_TextChanged(object sender, EventArgs e)
        {
            btnSave.Visible = true;

            Guna2TextBox textBox = (Guna2TextBox)sender;

            _SetTextBoxBorderState(textBox, true);

            guna2HtmlToolTip1.Hide(textBox);
        }
    }
}
