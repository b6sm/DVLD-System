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
    public partial class UCApplicationIBasicnfo : UserControl
    {
        public UCApplicationIBasicnfo()
        {
            InitializeComponent();
        }

        private bool _LoadApplicationStatus()
        {
            lbStatus.Text = ((ClsGlobal.enApplicationStatus)_Application.ApplicationStatus).ToString();
            return true;
        }

        private bool _LoadPersonInfo()
        {
            _Person = ClsPeopleContent.FindPerson(_Application.ApplicantPersonID);
            if (_Person == null)
                return false;
            if (string.IsNullOrEmpty(_Person.ThirdName))
                lbApplicant.Text = $"{_Person.FirstName} {_Person.SecondName} {_Person.LastName}";
            else
            {
                lbApplicant.Text = $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}";
            }
            return true;

        }

        private bool _LoadApplicationType()
        {
            ClsApplicationTypesContent Type = ClsApplicationTypesContent.FindApplicationTypeByApplicationTypeID(_Application.ApplicationTypeID);
            if(Type == null)
                return false;
            lbType.Text = Type.TypeTitle;
            return true;

        }

        private bool _LoadCreatedByUserInfo()
        {
            ClsUserContent User = ClsUserContent.FindUserByUserID(_Application.CreatedByUserID);
            if (User == null)
                return false;
            lbCreatedBy.Text = User.UserName;
            return true;

        }

        ClsPeopleContent _Person ;
        private bool _LoadData()
        {
            if (!_LoadApplicationType() || !_LoadApplicationStatus() || !_LoadPersonInfo() || !_LoadCreatedByUserInfo())
            {
                return false;
            }
            lbID.Text = _Application.ApplicationID.ToString();
            lbDate.Text = _Application.ApplicationDate.ToString("dd/MM/yyyy");
            lbFees.Text = _Application.PaidFees.ToString("0");
            lbStatusDate.Text = _Application.LastStatusDate.ToString("dd/MM/yyyy");
            return true;
            
        }

        ClsApplicationsContent _Application = new ClsApplicationsContent();
        public bool LoadData(int ApplicationID)
        {
            _Application = ClsApplicationsContent.FindApplicationByApplicationID(ApplicationID);
            if(_Application==null || !_LoadData())
            {
                return false;
            }
            return true;
        }

        public int GetPersonID()
        {
            return _Application.ApplicantPersonID;
        }

        private void llbViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Person.PersonID == -1)
                return;
            Form frm = new frmPersonDetails(_Person.PersonID);
            frm.ShowInTaskbar = true;
            frm.ShowDialog();
            _LoadData();

        }

        ClsDriversContent _Driver;

        int DriverID;

        private bool _SaveDriverData()
        {
            int PersonID = _Person.PersonID;
            if (PersonID == -1)
                return false;
            DriverID = ClsDriversContent.GetDriverIDByPersonID(PersonID);
            if (DriverID != -1)
            {
                return true;
            }

            _Driver = new ClsDriversContent();
            _Driver.PersonID = PersonID;
            _Driver.CreatedDate = DateTime.Now;
            _Driver.CreatedByUserID = ClsGlobal.CurrentUser.UserID;

            if (_Driver.Save())
            {
                DriverID = _Driver.DriverID;
                return true;
            }

            return false;


        }

        ClsLicenseContent _License = new ClsLicenseContent();

        private bool _SaveLicenseData(int LDLAppID,string Notes)
        {
            ClsLicenseClassContent LicenseClass = ClsLicenseClassContent.GetLicenseClassInfoByLocalDrivingLicenseApp(LDLAppID);
            if (LicenseClass == null)
            {
                return false;
            }
            _License.ApplicationID = _Application.ApplicationID;
            _License.DriverID = DriverID;
            _License.LicenseClassID = LicenseClass.LicenseClassID;
            _License.IssueDate = DateTime.Now;
            _License.IssueReason = ((byte)ClsGlobal.enIssueReason.FirstTime);
            _License.ExpirationDate = _License.IssueDate.AddYears(LicenseClass.DefaultValidityLength);
            _License.Notes = Notes;
            _License.PaidFees = LicenseClass.ClassFees;
            _License.CreatedByUserID = ClsGlobal.CurrentUser.UserID;

            if (_License.Save())
            {
                return true;
            }

            return false;
            
        }

        public bool IssueNewLicense(int LDLAppID,string Notes)
        {
            if (_SaveDriverData() && _SaveLicenseData(LDLAppID,Notes))
            {
                return true;
            }

            return false;
        }

        public bool UpdateApplicationStatus()
        {
            return ClsApplicationsContent.UpdateApplicationStatus(_Application.ApplicationID, ((int)ClsGlobal.enApplicationStatus.Completed));
        }



    }
}
