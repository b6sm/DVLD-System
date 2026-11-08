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
    public partial class frmChangeUserPassword : frmBaseForm
    {
        ClsUserContent _User;
        public frmChangeUserPassword(ClsUserContent User)
        {
            InitializeComponent();
            _User = User;
        }

        private void frmChangeUserPassword_Load(object sender, EventArgs e)
        {
            ucLoginInformation1.LoadData(_User);
            ucPersonal_info1.LoadPersonInfo(_User.PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (IsSaved)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }
            this.DialogResult = DialogResult.Cancel;
        }

        private void tbx_TextChange(object sender, EventArgs e)
        {
            btnSave.Visible = true;

            Guna2TextBox textBox = (Guna2TextBox)sender;

            _SetTextBoxBorderState(textBox, true);

            guna2HtmlToolTip1.Hide(textBox);

        }

        private void _SetTextBoxBorderState(Guna2TextBox textBox,bool IsValid)
        {
            if(!IsValid)
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

        private bool _IsPasswordConfirmed()
        {
            bool IsMatch = (tbxConfirmPassword.Text == tbxNewPassword.Text);
            _SetTextBoxBorderState(tbxConfirmPassword, IsMatch);
            if (!IsMatch)
            {
                guna2HtmlToolTip1.Active = true;
            }

            return IsMatch;

        }

        private bool _IsNewPasswordDiffernet()
        {
            bool IsDifferent = (tbxCurrentPassword.Text != tbxNewPassword.Text);
            _SetTextBoxBorderState(tbxNewPassword, IsDifferent);
            if (!IsDifferent)
            {
                guna2HtmlToolTip1.Active = true;
            }

            return IsDifferent;

        }

        private bool _CheckIfAllDataValidate()
        {
            bool IsValidate = true;
            Guna2TextBox FirstEmptyTextBox = null;

            if (!_ValidateTextBox(tbxCurrentPassword))
            {
                IsValidate = false;
                if (FirstEmptyTextBox == null)
                    FirstEmptyTextBox = tbxCurrentPassword;
            }

            if (!_ValidateTextBox(tbxNewPassword))
            {
                IsValidate = false;
                if (FirstEmptyTextBox == null)
                    FirstEmptyTextBox = tbxNewPassword;
            }

            if (!_ValidateTextBox(tbxConfirmPassword))
            {
                IsValidate = false;
                if (FirstEmptyTextBox == null)
                    FirstEmptyTextBox = tbxConfirmPassword;
            }

            if (!IsValidate)
            {
                if (FirstEmptyTextBox != null)
                {
                    guna2HtmlToolTip1.Show("This field is required!!", FirstEmptyTextBox, 0, -35, 3000);

                    FirstEmptyTextBox.Focus();
                }

                return IsValidate;
            }

            if (!_IsPasswordConfirmed())
            {
                IsValidate = false;

                guna2HtmlToolTip1.Show("Password confirmation does not match!!", tbxConfirmPassword, 0, -35, 3000);
                tbxConfirmPassword.Focus();
                return IsValidate;
            }

            if (!_IsNewPasswordDiffernet())
            {
                IsValidate = false;

                guna2HtmlToolTip1.Show("New password must be different from current password!!", tbxNewPassword, 0, -35, 3000);

                tbxNewPassword.Focus();
                return IsValidate;
            }

            return IsValidate;

        }

        private bool _CheckValidate()
        {
            if (!_CheckIfAllDataValidate())
            {
                return false;
            }

            if(!_User.ValidateUserPassword(tbxCurrentPassword.Text))
            {
                _SetTextBoxBorderState(tbxCurrentPassword,false);
                guna2HtmlToolTip1.Show("Invalid Password!!", tbxCurrentPassword, 0, -35, 3000);
                tbxCurrentPassword.Focus();


                return false;
            }
            return true;
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_CheckValidate())
                return;

            if(MessageBox.Show("Are you sure you want to Change Password For This User ??", "question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (_User.UpdateUserPassword(tbxNewPassword.Text))
            {
                MessageBox.Show("Password Changed Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbxConfirmPassword.Clear();
                tbxCurrentPassword.Clear();
                tbxNewPassword.Clear();
                IsSaved = true;

                btnSave.Visible = false;


            }
            else
            {
                MessageBox.Show("Password Didn't Change!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        bool IsSaved = false;

        private void _TooglePasswordVisibility(Guna2TextBox textBox)
        {
            if(textBox.UseSystemPasswordChar)
            {
                textBox.UseSystemPasswordChar = false;
                textBox.IconRight = Properties.Resources.icons8_eye_24;

            }
            else
            {
                textBox.UseSystemPasswordChar = true;
                textBox.IconRight = Properties.Resources.icons8_closed_eye_24;
            }
        }

        private void tbx_IconRightClick(object sender, EventArgs e)
        {
            _TooglePasswordVisibility((Guna2TextBox)sender);
        }

        private void tbxCurrentPassword_IconRightClick(object sender, EventArgs e)
        {
            _TooglePasswordVisibility((Guna2TextBox)sender);
        }
    }
}
