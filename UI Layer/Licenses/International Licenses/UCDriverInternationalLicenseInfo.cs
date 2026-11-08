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
    public partial class UCDriverInternationalLicenseInfo : UserControl
    {
        public UCDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        //ClsPeopleContent _Person;
        //ClsInternationalLicenseContent _IntLicense;

        private bool _LoadPersonData(int DriverID)
        {
            int PersonID = ClsDriversContent.GetPersonIDByDriverID(DriverID);
            if (PersonID == -1)
                return false;

            ClsPeopleContent Person = ClsPeopleContent.FindPerson(PersonID);
            if (Person == null)
                return false;

            lbDateOfBirth.Text = Person.DateOfBirth.ToString("dd/MM/yyyy");
            lbNationalNo.Text = Person.NationalNo;
            lbName.Text = (string.IsNullOrEmpty(Person.ThirdName)) ? $"{Person.FirstName} {Person.SecondName} {Person.LastName}"
                          : $"{Person.FirstName} {Person.SecondName} {Person.ThirdName} {Person.LastName}";

            if (Person.ImagePath != "")
            {
                pbImage.ImageLocation = Person.ImagePath;
            }
            else
            {
                pbImage.ImageLocation = null;
                pbImage.Image = Properties.Resources.icons8_user_image_100;
            }
            lbGender.Text = (Person.Gender == ((short)ClsGlobal.enGender.Male)) ? ClsGlobal.enGender.Male.ToString() : ClsGlobal.enGender.Female.ToString();

            return true;
        }

        private bool _LoadData(int IntLicenseID)
        {
            ClsInternationalLicenseContent _IntLicense = 
                ClsInternationalLicenseContent.GetInternationalLicenseInfoByInternationalLicenseID(IntLicenseID);

            if (_IntLicense == null || !_LoadPersonData(_IntLicense.DriverID))
                return false;
            lbIntLicenseID.Text = _IntLicense.InternationalLicenseID.ToString();
            lbApplicationID.Text = _IntLicense.ApplicationID.ToString();
            lbLicenseID.Text = _IntLicense.IssuedUsingLocalLicenseID.ToString();
            lbIsActive.Text = (_IntLicense.IsActive == true) ? "Yes" : "No";
            lbExpirationDate.Text = _IntLicense.ExpirationDate.ToString("dd/MM/yyyy");
            lbIssueDate.Text = _IntLicense.IssueDate.ToString("dd/MM/yyyy");
            lbDriverID.Text = _IntLicense.DriverID.ToString();
            return true;
        }

        public bool LoadData(int IntLicenseID)
        {
            return _LoadData(IntLicenseID);
        }

    }
}
