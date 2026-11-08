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
using System.IO;

namespace My_DVLD
{
    public partial class UCEditPersonInfo : UserControl
    {
        public UCEditPersonInfo()
        {
          
            InitializeComponent();

            dtBirthDay.Value = DateTime.Now;
        }

        private void _FillCountriesInComboBox()
        {
            DataTable dtCountries = ClsGlobal.dtCountries;

            cbxCountries.SuspendLayout();

            cbxCountries.DisplayMember = "CountryName";
            cbxCountries.ValueMember = "CountryID";
            cbxCountries.DataSource = dtCountries;

            cbxCountries.SelectedValue = 169;
            cbxCountries.ResumeLayout();


        }

        public void FillCountriesInComboBox()
        {
            _FillCountriesInComboBox();
        }

        ClsPeopleContent _Person=new ClsPeopleContent();
        private void _LoadData(ClsPeopleContent Person)
        {

            _Person = Person;
            this.SuspendLayout();
            _FillCountriesInComboBox();


            lbPersonID.Text = Person.PersonID.ToString();
            tbxAddress.Text = Person.Address;
            
            tbxFirstName.Text = Person.FirstName;
            
            tbxSecondName.Text = Person.SecondName;
            tbxThirdName.Text = Person.ThirdName;
            tbxLastName.Text = Person.LastName;

            tbxPhone.Text = Person.Phone;
            tbxNationalNo.Text = Person.NationalNo;
            tbxEmail.Text = Person.Email;
            rdMale.Checked = (Person.Gender == ((short)ClsGlobal.enGender.Male)) ? true : false;
            rdFemale.Checked = (Person.Gender == ((short)ClsGlobal.enGender.Female)) ? true : false;


            dtBirthDay.Value = Person.DateOfBirth;

            if(!string.IsNullOrWhiteSpace(Person.ImagePath))
            {
                pbPersonImage.ImageLocation = Person.ImagePath;

                lbRemoveImage.Visible = true;
                openFileDialog1.FileName = pbPersonImage.ImageLocation;

            }
            

            cbxCountries.SelectedValue = Person.CountryID;


            this.ResumeLayout();
        }

        public void LoadData(ClsPeopleContent Person)
        {
            _LoadData(Person);
        }

        private  void UCEditPersonInfo_Load(object sender, EventArgs e)
        {
           

        }

        public event Action OnTextChange;

        protected virtual void TextChange()
        {
           
                Action Handler = OnTextChange;
                if (Handler != null)
                {
                    Handler();
                }
            
        }

        private void _ShowSaveButton()
        {
            
                if (OnTextChange != null)
                {
                    OnTextChange();
                }

        }

        private void tbx_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox textBox = (Guna2TextBox)sender;

            _SetTextBoxBorderState(textBox, true);

            guna2HtmlToolTip1.Hide(textBox);
            _ShowSaveButton();


        }

        private void cbxCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ShowSaveButton();
        }

        private void dtBirthDay_ValueChanged(object sender, EventArgs e)
        {
            guna2HtmlToolTip1.SetToolTip(dtBirthDay, "");
            dtBirthDay.BorderColor = Color.FromArgb(75, 75, 75);
            _ShowSaveButton();


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
            bool IsValid = !string.IsNullOrWhiteSpace(textBox.Text.Trim());
            _SetTextBoxBorderState(textBox, IsValid);
            if (!IsValid)
            {
                guna2HtmlToolTip1.Active = true;
            }

            return IsValid;

        }

        private bool _IsNationalNoChanged()
        {
            bool isNationalNoChanged = (_Person!= new ClsPeopleContent() && tbxNationalNo.Text.Trim() != _Person.NationalNo);

            if (_Person == new ClsPeopleContent() || isNationalNoChanged)
            {
                if (ClsPeopleContent.IsTherePersonWithThisNationalNo(tbxNationalNo.Text.Trim()))
                {
                    return false;
                }
            }
            return true;
        }
        //Guid g = Guid.NewGuid();
        private bool _ValidateDate()
        {
            DateTime dt = dtBirthDay.Value;
            DateTime today = DateTime.Today;
            if (dt > today.AddYears(-18))
            {
                dtBirthDay.BorderColor = Color.FromArgb(235, 87, 87);
                return false;
            }
            else
            {
                dtBirthDay.BorderColor = Color.FromArgb(75,75,75);
                return true;
            }
        }

        private bool _CheckIfAllDataValidate()
        {
            bool IsValidate = true;
            Guna2TextBox FirstEmptyTextBox = null;

            if (!_IsNationalNoChanged())
            {
                IsValidate = false;
                guna2HtmlToolTip1.Show("The national no already exists", tbxNationalNo, 0, -35);
                tbxNationalNo.Focus();
                return IsValidate;

            }

            if (!_ValidateTextBox(tbxFirstName))
            {
                IsValidate = false;
                if (FirstEmptyTextBox == null)
                    FirstEmptyTextBox = tbxFirstName;
            }

            if (!_ValidateTextBox(tbxSecondName))
            {
                IsValidate = false;
                if (FirstEmptyTextBox == null)
                    FirstEmptyTextBox = tbxSecondName;
            }

            if (!_ValidateTextBox(tbxLastName))
            {
                IsValidate = false;
                if (FirstEmptyTextBox == null)
                    FirstEmptyTextBox = tbxLastName;
            }

            if (!_ValidateTextBox(tbxNationalNo))
            {
                IsValidate = false;
                if (FirstEmptyTextBox == null)
                    FirstEmptyTextBox = tbxNationalNo;
            }

            

            if (!_ValidateTextBox(tbxPhone))
            {
                IsValidate = false;
                if (FirstEmptyTextBox == null)
                    FirstEmptyTextBox = tbxPhone;
            }

            if (!_ValidateTextBox(tbxAddress))
            {
                IsValidate = false;
                if (FirstEmptyTextBox == null)
                    FirstEmptyTextBox = tbxAddress;
            }
            if (!_ValidateDate())
            {
                IsValidate = false;
                guna2HtmlToolTip1.SetToolTip(dtBirthDay, "You Must Be Over 18");
                if (FirstEmptyTextBox == null)
                    dtBirthDay.Focus();

            }

            if (!IsValidate)
            {
                if (FirstEmptyTextBox != null)
                {
                    guna2HtmlToolTip1.Show("This field is required", FirstEmptyTextBox, 0, -35);

                    FirstEmptyTextBox.Focus();
                }

                return IsValidate;
            }
            return IsValidate;

        }

        private void _HandleCopyImages()
        {

            Guid NewFileName = Guid.NewGuid();

            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                OldImage = _Person.ImagePath;

            }

            if (!string.IsNullOrEmpty(pbPersonImage.ImageLocation))
            {
                string FolderPath = @"C:\MyDVLDPictures\";
                if(!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }
                string FileExtention = Path.GetExtension(pbPersonImage.ImageLocation);

                string FileDestense = FolderPath + NewFileName + FileExtention;
                File.Copy(pbPersonImage.ImageLocation, FileDestense);
                pbPersonImage.ImageLocation = FileDestense;
            }

        }

        string OldImage;
        private void _HandleRemoveOldImage()
        {
            if (!string.IsNullOrEmpty(OldImage))
            {
                if (File.Exists(OldImage)) File.Delete(OldImage);

            }
        }

        private bool _save()
        {
            if (cbxCountries.SelectedValue == null && !int.TryParse(cbxCountries.SelectedValue.ToString(), out int CountryID))
            {
                return false;

            }
            _HandleCopyImages();
            _Person.FirstName = tbxFirstName.Text.Trim();
            _Person.SecondName = tbxSecondName.Text.Trim();
            _Person.ThirdName = tbxThirdName.Text.Trim();

            _Person.LastName = tbxLastName.Text.Trim();
            _Person.Phone = tbxPhone.Text.Trim();
            _Person.Email = tbxEmail.Text.Trim();
            _Person.NationalNo = tbxNationalNo.Text.Trim();
            _Person.Address = tbxAddress.Text.Trim();
            _Person.CountryID = (int)cbxCountries.SelectedValue;
            _Person.DateOfBirth = dtBirthDay.Value.Date;
            _Person.Gender = (rdMale.Checked == true) ? (short)ClsGlobal.enGender.Male : (short)ClsGlobal.enGender.Female;
            if (!string.IsNullOrWhiteSpace(pbPersonImage.ImageLocation))
            {
                _Person.ImagePath = pbPersonImage.ImageLocation;
            }
            else
            {
                _Person.ImagePath = null;

            }




            if (_Person.Save())
            {

                _Person = ClsPeopleContent.FindPerson(_Person.PersonID);
                _HandleRemoveOldImage();
                _LoadData(_Person);
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool CheckDataValidate()
        {
            return _CheckIfAllDataValidate();
        }

        public bool SaveData()
        {
            //if (!_CheckIfAllDataValidate())
            //{
            //    return false;
            //}
            //else if (_save())
            //{
            //    return true;
            //}
            //return false;
            return _save();
            
        }

        public int ReturnPersonID()
        {
            return _Person.PersonID;
        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {
            _ShowSaveButton();
        }

        private void lbSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            
            openFileDialog1.Filter = "Image Files|*.jpg;*jpeg;*.png;*.bmp;*.gif";
            openFileDialog1.Title = "Select Profile Image";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                //Guid NewFileName = Guid.NewGuid();
                //string FileExtention = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf('.'));
                //string FileDestense= @"E:\MyDVLDPhotos\" + NewFileName + FileExtention;
                //File.Copy(openFileDialog1.FileName,FileDestense) ;
                pbPersonImage.ImageLocation = openFileDialog1.FileName;

                if (pbPersonImage.ImageLocation != "")
                {
                    lbRemoveImage.Visible = true;
                }
            }
            _ShowSaveButton();


        }

        private void lbRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            pbPersonImage.ImageLocation = null;
            pbPersonImage.Image = Properties.Resources.icons8_user_image_100;
            lbRemoveImage.Visible = false;
            _ShowSaveButton();

        }
    }
}
