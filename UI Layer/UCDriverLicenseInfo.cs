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
    public partial class UCDriverLicenseInfo : UserControl
    {
        public UCDriverLicenseInfo()
        {
            InitializeComponent();
        }

        private bool _SetIssueReason(byte IssueReason)
        {
            switch ((ClsGlobal.enIssueReason)IssueReason)
            {
                case ClsGlobal.enIssueReason.FirstTime:
                    lbIssueReason.Text = "First Time";
                    break;
                case ClsGlobal.enIssueReason.RenewLicense:
                    lbIssueReason.Text = "Renew";

                    break;
                case ClsGlobal.enIssueReason.ReplacementForDamaged:
                    lbIssueReason.Text = "Replacement For Damaged";

                    break;
                case ClsGlobal.enIssueReason.ReplacementForLost:
                    lbIssueReason.Text = "Replacement For Lost";

                    break;
                default:
                    lbIssueReason.Text = "Unkown";
                    return false;
            }
            return true;
        }

        ClsPeopleContent _Person;

        private bool _LoadLicenseClassInfo(int LicenseClassID)
        {
            ClsLicenseClassContent LicenseClass = ClsLicenseClassContent.FindLicenseClassInfoByLicenseClassID(LicenseClassID);
            if (LicenseClass == null)
                return false;
            lbClass.Text = LicenseClass.ClassName;
            return true;
        }

        private bool _LoadPersonInfo(int DriverID)
        {
            int PersonID = ClsDriversContent.GetPersonIDByDriverID(DriverID);
            if (PersonID == -1)
                return false;
            _Person = ClsPeopleContent.FindPerson(PersonID);
            if (_Person == null)
                return false;
            lbDateOfBirth.Text = _Person.DateOfBirth.ToString("dd/MM/yyyy");
            lbNationalNo.Text = _Person.NationalNo;
            lbName.Text = (string.IsNullOrEmpty(_Person.ThirdName)) ? $"{_Person.FirstName} {_Person.SecondName} {_Person.LastName}"
                          : $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";
            if (_Person.ImagePath != "")
            {
                pbImage.ImageLocation = _Person.ImagePath;
            }
            else
            {
                pbImage.ImageLocation = null;
                pbImage.Image = Properties.Resources.icons8_user_image_100;
            }
            lbGender.Text = (_Person.Gender == ((short)ClsGlobal.enGender.Male)) ? ClsGlobal.enGender.Male.ToString() : ClsGlobal.enGender.Female.ToString();
            return true;


        }
        private bool _LoadData(int LicenseID)
        {
            if (_License == null)
            {
                _License = ClsLicenseContent.GetLicenseInfoByLicenseID(LicenseID);
                if (_License == null)
                    return false;

            }
            
            if (!_LoadLicenseClassInfo(_License.LicenseClassID) || !_LoadPersonInfo(_License.DriverID)
                || !_SetIssueReason(_License.IssueReason))
                return false;

            lbLicenseID.Text = _License.LicenseID.ToString();

            lbDriverID.Text = _License.DriverID.ToString();
            lbExpireDate.Text = _License.ExpirationDate.ToString("dd/MM/yyyy");
            lbIssueDate.Text = _License.IssueDate.ToString("dd/MM/yyyy");
            lbIsActive.Text = (_License.IsActive == true) ? "Yes" : "No";
            lbIsDetained.Text = (_License.IsDetained == true) ? "Yes" : "No";

            lbNotes.Text = (!string.IsNullOrEmpty(_License.Notes)) ? _License.Notes : "No Notes";
            
            return true;

        }

        public bool LoadData(int LicenseID)
        {
            return _LoadData(LicenseID);
        }

        ClsLicenseContent _License;
        public bool LoadData(ClsLicenseContent License)
        {
            _License = License;
            if (_License == null)
                return false;
            return _LoadData(_License.LicenseID);
        }

        public void LoadDefaultValue()
        {
            _Person = null;
            _License = null;
            lbClass.Text = "[????]";
            lbName.Text = "[????]";
            lbLicenseID.Text = "[????]";
            lbNationalNo.Text = "[????]";
            lbGender.Text = "[????]";
            lbIssueDate.Text = "[????]";
            lbIssueReason.Text = "[????]";
            lbNotes.Text = "[????]";
            lbIsActive.Text = "[????]";
            lbDateOfBirth.Text = "[????]";
            lbDriverID.Text = "[????]";
            lbExpireDate.Text = "[????]";
            lbIsDetained.Text = "[????]";
            pbImage.ImageLocation = null;
            pbImage.Image = Properties.Resources.icons8_user_image_100;

        }


        public int GetPersonID()
        {
            return _Person.PersonID;
        }
    }
}
