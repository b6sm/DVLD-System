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
    public partial class frmEditeApplicationType : frmBaseForm
    {
        int _ID;
        public frmEditeApplicationType(int ID)
        {
            InitializeComponent();
            _ID = ID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        ClsApplicationTypesContent _AppType;
        private void _LoadData()
        {

            _AppType = ClsApplicationTypesContent.FindApplicationTypeByApplicationTypeID(_ID);
            if (_AppType == null)
            {

                return;
            }

            tbxTitle.Text = _AppType.TypeTitle;
            tbxFees.Text = _AppType.TypeFees.ToString("0");
            lbID.Text = _AppType.TypeID.ToString();

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

        private bool _ValidateFees(Guna2TextBox textBox)
        {

            bool IsValid = !string.IsNullOrWhiteSpace(textBox.Text)&& decimal.TryParse(tbxFees.Text.Trim(), out decimal numricValue);
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

            if (!_ValidateFees(tbxFees))
            {
                IsValidate = false;
                if (FirstEmptyTextBox == null)
                    FirstEmptyTextBox = tbxFees;
            }
            if (!IsValidate)
            {
                if (FirstEmptyTextBox != null)
                {
                    guna2HtmlToolTip1.Show("You Should Enter A Valid Number.", FirstEmptyTextBox, 0, -35, 3000);

                    FirstEmptyTextBox.Focus();
                }

                return IsValidate;
            }
            return IsValidate;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_CheckIfAllDataValidate())
                return;

            if (MessageBox.Show("Are you sure you want to save the changes for this Application Type?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (ClsApplicationTypesContent.UpdateApplicationTypeFees(_AppType.TypeID, decimal.Parse(tbxFees.Text.Trim())))
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
