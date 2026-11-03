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
    public partial class UCInterNationalLicenseApplicationInfo : UserControl
    {

        ClsLicenseContent _LocalLicense;
        public UCInterNationalLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        ClsApplicationTypesContent _AppType;

        private bool _LoadData()
        {
            _AppType = ClsApplicationTypesContent.FindApplicationTypeByApplicationTypeID(((int)ClsGlobal.enApplicationTypes.NewInterNationalLicense));
            if (_AppType == null)
                return false;
            lbCreatedBy.Text = ClsGlobal.CurrentUser.UserName;
            lbApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lbIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lbExpirationDate.Text = DateTime.Now.AddYears(1).ToString("dd/MM/yyyy");
            lbFees.Text = _AppType.TypeFees.ToString("0");
            lbLocalLicenseID.Text = _LocalLicense.LicenseID.ToString();
            return true;

        }

        public bool LoadData(ClsLicenseContent LoaclLicense)
        {
            _LocalLicense = LoaclLicense;

            return _LoadData();
        }

        public void LoadDefaultValue()
        {
            _LocalLicense = null;
            _Application = new ClsApplicationsContent();
            _InternationalLicense = new ClsInternationalLicenseContent();
            lbApplicationDate.Text = "[????]";
            lbCreatedBy.Text = "[????]";
            lbExpirationDate.Text = "[????]";
            lbFees.Text = "[????]";
            lbILAppID.Text = "[????]";
            lbILLicenseID.Text = "[????]";
            lbIssueDate.Text = "[????]";
            lbLocalLicenseID.Text = "[????]";

        }

        ClsApplicationsContent _Application = new ClsApplicationsContent();

        private bool _SaveApplicationData(int PersonID)
        {
            _Application.ApplicantPersonID = PersonID;
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationTypeID = (_AppType.TypeID);
            _Application.ApplicationStatus = ((byte)ClsGlobal.enApplicationStatus.Completed);
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees = _AppType.TypeFees;
            _Application.CreatedByUserID = ClsGlobal.CurrentUser.UserID;

            if (_Application.Save())
            {
                return true;
            }

            return false;            
        }

        ClsInternationalLicenseContent _InternationalLicense = new ClsInternationalLicenseContent();
        private bool _SaveInternationalLicenseData()
        {
            _InternationalLicense.ApplicationID = _Application.ApplicationID;
            _InternationalLicense.DriverID = _LocalLicense.DriverID;
            _InternationalLicense.IssuedUsingLocalLicenseID = _LocalLicense.LicenseID;
            _InternationalLicense.IssueDate = DateTime.Now;
            _InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            _InternationalLicense.CreatedByUserID = ClsGlobal.CurrentUser.UserID;

            if (_InternationalLicense.Save())
            {
                return true;
            }
            return false;
           
        }

        private bool _SaveData(int PersonID)
        {
            if (!_SaveApplicationData(PersonID)||!_SaveInternationalLicenseData())
            {
                return false;
            }
            return true;
        }

        public bool SaveData(int PersonID)
        {
            return _SaveData(PersonID);
        }

        public void SetNewInternationalLicenseID()
        {
            if (_Application.ApplicationID != -1 || _InternationalLicense.InternationalLicenseID != -1)
            {
                lbILAppID.Text = _Application.ApplicationID.ToString();
                lbILLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            }
        }

        public int GetNewInternationalLicenseID()
        {
            return _InternationalLicense.InternationalLicenseID;
        }

    }
}
