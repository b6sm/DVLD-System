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
    public partial class UCPersonal_info : UserControl
    {
        public UCPersonal_info()
        {
            InitializeComponent();
        }

        private void _PutAllItemToolTips()
        {
            toolTip1.SetToolTip(lbEmail, lbEmail.Text);
            toolTip1.SetToolTip(lbName, lbName.Text);
            toolTip1.SetToolTip(lbCountry, lbCountry.Text);
            toolTip1.SetToolTip(lbGender, lbGender.Text);
            toolTip1.SetToolTip(lbNationalNo, lbNationalNo.Text);
            toolTip1.SetToolTip(lbAddress, lbAddress.Text);
            toolTip1.SetToolTip(lbDateOfBirth, lbDateOfBirth.Text);
            toolTip1.SetToolTip(lbPersonID, lbPersonID.Text);
            toolTip1.SetToolTip(lbPhone, lbPhone.Text);

        }

        int _PersonID;

        private void _LoadInfo(ClsPeopleContent Person)
        {
            _PersonID = Person.PersonID;

            string ThirdName = string.IsNullOrWhiteSpace(Person.ThirdName) ? "" : Person.ThirdName + " ";

            lbName.Text =$"{Person.FirstName} {Person.SecondName} {ThirdName}{Person.LastName}";
            lbCountry.Text = Person.CountryName;
            lbGender.Text = (Person.Gender == (short)ClsGlobal.enGender.Male) ? "Male" : "Female";
            lbNationalNo.Text = Person.NationalNo;
            lbAddress.Text = Person.Address;
            lbDateOfBirth.Text = Person.DateOfBirth.ToString("dd/MM/yyyy");
            if (!string.IsNullOrEmpty(Person.Email))
                lbEmail.Text = Person.Email;
            else
            {
                lbEmail.Text = "N/A";

            }
            lbPersonID.Text = Person.PersonID.ToString();
            lbPhone.Text = Person.Phone;
            if (Person.ImagePath != "")
            {
                pbPersonImage.ImageLocation = Person.ImagePath;
            }
            else
            {
                pbPersonImage.ImageLocation = null;
                pbPersonImage.Image = Properties.Resources.icons8_user_image_100;
            }
        }
        public void LoadPersonInfo(int PersonID)
        {
            ClsPeopleContent Person = ClsPeopleContent.FindPerson(PersonID);
            if (Person == null)
            {
                MessageBox.Show("Unkown Error occurated Wile Load Information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LoadInfo(Person);
            _PutAllItemToolTips();

        }

        //private void _LoadInfoByPersonData(ClsPeopleContent Person)
        //{
        //    if (Person == null)
        //    {
        //        MessageBox.Show("Unkown Error occurated Wile Load Information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    _PersonID = Person.PersonID;

        //    string ThirdName = string.IsNullOrWhiteSpace(Person.ThirdName) ? "" : Person.ThirdName + " ";

        //    lbName.Text = $"{Person.FirstName} {Person.SecondName} {ThirdName}{Person.LastName}";

        //    lbCountry.Text = Person.CountryName;
        //    lbGender.Text = (Person.Gender == 1) ? "Male" : "Female";
        //    lbNationalNo.Text = Person.NationalNo;
        //    lbAddress.Text = Person.Address;
        //    lbDateOfBirth.Text = Person.DateOfBirth.ToString("dd/MM/yyyy");
        //    lbEmail.Text = Person.Email;

        //    lbPersonID.Text = _PersonID.ToString();
        //    lbPhone.Text = Person.Phone;
        //    if (Person.ImagePath != "")
        //    {
        //        pbPersonImage.ImageLocation = Person.ImagePath;
        //    }
        //    else
        //    {
        //        pbPersonImage.ImageLocation = null;
        //        pbPersonImage.Image = Properties.Resources.icons8_user_image_100;
        //    }
        //}

        public bool LoadPersonInfoByPersonData(ClsPeopleContent Person)
        {
            
            if (Person == null)
            {
                return false;
            }
            _LoadInfo(Person);
            _PutAllItemToolTips();
            return true;

        }

        public void LoadDefaultValue()
        {
            lbPersonID.Text = "[????]";
            lbName.Text = "[????]";
            lbAddress.Text = "[????]";
            lbCountry.Text = "[????]";
            lbDateOfBirth.Text = "[????]";
            lbEmail.Text = "[????]";
            lbGender.Text = "[????]";
            lbNationalNo.Text = "[????]";
            lbPhone.Text = "[????]";
            pbPersonImage.ImageLocation = null;
            pbPersonImage.Image = Properties.Resources.icons8_user_image_100;

        }


        private void llbEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmAddEditPersonInfo(_PersonID);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
        }
    }
}
