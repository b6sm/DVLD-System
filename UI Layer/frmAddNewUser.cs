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
    public partial class frmAddNewUser : frmBaseForm
    {
        public enum enMode
        {
            AddNew = 0, UpdateMode = 1
        }
        private enMode _Mode;

        ClsUserContent _User;

        int _UserID;
        public frmAddNewUser(int UserID=-1)
        {
            InitializeComponent();

            _UserID = UserID;
            if (UserID == -1)
            {
                _Mode = enMode.AddNew;
                
            }
            else
            {
                _Mode = enMode.UpdateMode;
                

            }
        }

        private void _LoadData()
        {
            if (_Mode == enMode.AddNew)
            {
                lbAddEditUser.Text = "Add New User";
                _User = new ClsUserContent();
                return;
            }

            _User = ClsUserContent.FindUserByUserID(_UserID);
            lbAddEditUser.Text = "Edit User Info";
            pnShowPassword.Visible = false;
            pnUserName.Location = new Point(pnUserName.Location.X,122);

            if (_User == null)
            {
                MessageBox.Show("This form will be closed because no User with ID = " + _UserID);
                this.Close();

                return;
            }
            ucFilter1.FillSearchboxAndFulterByWithPersonID(_User.PersonID);

            lbUserID.Text = _User.UserID.ToString();
            tbxUserName.Text = _User.UserName;
            cbxIsActive.Checked = _User.IsActive;

        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            _LoadData();
            ucFilter1.FocusOnSearchBox();
        }

        private bool _AllowNavigation = false;

        private void guna2TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_AllowNavigation)
                e.Cancel = true;
        }

        private bool _AllowSave()
        {
            
            if (guna2TabControl1.SelectedTab == tabPage1)
            {
                _AllowNavigation = true;
                guna2TabControl1.SelectedTab = tabPage2;
                btnBack.Visible = true;
                btnNextSave.Text = "Save";
                btnNextSave.Visible = false;
                _AllowNavigation = false;

                return false;
            }
            else
            {
                return true;
            }

        }

        private void _MoveToPersonInfoTab()
        {
            if (guna2TabControl1.SelectedTab == tabPage2 )
            {
                _AllowNavigation = true;

                btnBack.Visible = false;
                guna2TabControl1.SelectedTab = tabPage1;
                btnNextSave.Text = "Next";
                btnNextSave.Visible = true;
                _AllowNavigation = false;
            }
            else
            {
                btnBack.Visible = true;

            }
        }

        private bool _save()
        {
            _User.PersonID = _PersonID;
            _User.UserName = tbxUserName.Text;
            _User.IsActive = cbxIsActive.Checked;
            
            if (_User.Save(tbxPassword.Text))
            {

                _User = ClsUserContent.FindUserByUserID(_User.UserID);

                lbUserID.Text = _User.UserID.ToString();

                _Mode = enMode.UpdateMode;
                return true;



            }
            else
            {
                return false;
            }


        }

        private void btnNextSave_Click(object sender, EventArgs e)
        {
            if(!_AllowSave())
            {
                return;
            }

            if (!_CheckValidate())
                return;

            string confirmMessage = (_Mode == enMode.AddNew)
                 ? "Are you sure you want to add this new user?"
                 : "Are you sure you want to save the changes for this user?";

            if (MessageBox.Show(confirmMessage, "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (_save())
            {
                MessageBox.Show("Data Saved Succesfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsSaved = true;
                btnNextSave.Visible = false;
                tbxConfirmPassword.Enabled = false;
                tbxPassword.Enabled = false;

            }
            else
            {
                MessageBox.Show("An error occurred while saving the data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        bool IsSaved = false;

        private void btnBack_Click(object sender, EventArgs e)
        {
            _MoveToPersonInfoTab();
        }

        private void tbx_TextChange(object sender, EventArgs e)
        {
            btnNextSave.Visible = true;

            Guna2TextBox textBox = (Guna2TextBox)sender;

            _SetTextBoxBorderState(textBox, true);

            guna2HtmlToolTip1.Hide(textBox);
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

        private bool _IsPasswordConfirmed()
        {
            bool IsMatch = (tbxConfirmPassword.Text == tbxPassword.Text);
            _SetTextBoxBorderState(tbxConfirmPassword, IsMatch);
            if (!IsMatch)
            {
                guna2HtmlToolTip1.Active = true;
            }

            return IsMatch;

        }

        private bool _CheckIfAllDataValidate()
        {
            bool IsValidate = true;
            Guna2TextBox FirstEmptyTextBox = null;

            if (!_ValidateTextBox(tbxUserName))
            {
                IsValidate = false;
                if (FirstEmptyTextBox == null)
                    FirstEmptyTextBox = tbxUserName;
            }

            if (_Mode == enMode.AddNew)
            {
                if (!_ValidateTextBox(tbxPassword))
                {
                    IsValidate = false;
                    if (FirstEmptyTextBox == null)
                        FirstEmptyTextBox = tbxPassword;
                }

                if (!_ValidateTextBox(tbxConfirmPassword))
                {
                    IsValidate = false;
                    if (FirstEmptyTextBox == null)
                        FirstEmptyTextBox = tbxConfirmPassword;
                }
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
            return IsValidate;

        }

        private bool _CheckValidate()
        {
            if (!_CheckIfAllDataValidate())
            {
                return false;
            }

            bool isUsernameChanged = (_Mode == enMode.UpdateMode && tbxUserName.Text.Trim() != _User.UserName);

            if (_Mode == enMode.AddNew || isUsernameChanged)
            {
                if (ClsUserContent.ValidateUserName(tbxUserName.Text))
                {
                    _SetTextBoxBorderState(tbxUserName, false);
                    guna2HtmlToolTip1.Show("UserName Is Already Used!!", tbxUserName, 0, -35, 3000);
                    tbxUserName.Focus();

                    return false;
                }
            }
            return true;
        }
        int _PersonID;

        private bool _IsPersonHasAccount(int PersonID)
        {
            return ClsUserContent.IsPersonConnected(PersonID);
        }
        private void ucFilter1_OnSearchButtonV2(ClsPeopleContent obj)
        {
            if (obj == null || (_IsPersonHasAccount(obj.PersonID) && _Mode == enMode.AddNew))
            {
                string ErrorString = ((obj == null) ? "No person was found matching the search criteria." : "This person already has an account.");
                string ErrorTitle = ((obj == null) ? "Not Found" : "Information");

                MessageBox.Show(ErrorString,
                ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ucPersonal_info1.LoadDefaultValue();
                btnNextSave.Visible = false;

                return;
            }
            _PersonID = obj.PersonID;

            if(!ucPersonal_info1.LoadPersonInfoByPersonData(obj))
            {
                ucPersonal_info1.LoadDefaultValue();

                MessageBox.Show("An error occurred while load data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnNextSave.Visible = true;
        }

        private void cbxIsActive_CheckedChanged(object sender, EventArgs e)
        {
            btnNextSave.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(IsSaved)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }
            this.DialogResult = DialogResult.Cancel;

        }

        private void _TooglePasswordVisibility(Guna2TextBox textBox)
        {
            if (char.IsWhiteSpace(textBox.PasswordChar) || textBox.PasswordChar == '\0')
            {
                textBox.PasswordChar = '●';
                textBox.IconRight = Properties.Resources.icons8_closed_eye_24;

            }
            else
            {
                textBox.PasswordChar = '\0';
                textBox.IconRight = Properties.Resources.icons8_eye_24;
                
            }
        }


        private void tbxPassword_IconRightClick(object sender, EventArgs e)
        {
            _TooglePasswordVisibility((Guna2TextBox)sender);
        }
    }
}
