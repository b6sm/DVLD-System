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
    public partial class UcDetainLicenseInfo : UserControl
    {
        public UcDetainLicenseInfo()
        {
            InitializeComponent();
        }

        private bool _LoadData()
        {
            _DetainLicense = ClsDetainLicenseContent.GetDetainedLicenseByLicenseID(_LicenseID);
            _ApplicatinType = ClsApplicationTypesContent.FindApplicationTypeByApplicationTypeID(((int)ClsGlobal.enApplicationTypes.ReleaseDetainedLicense));
            string UserName = ClsUserContent.GetUserNameByUserID(_DetainLicense.CreatedByUserID);

            if (_DetainLicense == null || _ApplicatinType == null || string.IsNullOrEmpty(UserName))
            {
                return false;
            }
            lbDetainID.Text = _DetainLicense.DetainID.ToString();
            lbLicenseID.Text = _DetainLicense.LicenseID.ToString();
            lbDetainDate.Text = _DetainLicense.DetainDate.ToString("dd/MM/yyyy");
            lbFineFees.Text = _DetainLicense.FineFees.ToString("0");
            lbCreatedBy.Text = UserName;

            lbApplicationFees.Text = _ApplicatinType.TypeFees.ToString("0");
            lbTotalFees.Text = (_ApplicatinType.TypeFees + _DetainLicense.FineFees).ToString("0");
            return true;
        }


        int _LicenseID;
        ClsDetainLicenseContent _DetainLicense;
        ClsApplicationTypesContent _ApplicatinType;
        public bool LoadData(int LicenseID)
        {
            _LicenseID = LicenseID;

            return _LoadData();
        }

        public void LoadDefaultValue()
        {
            _Application = new ClsApplicationsContent();
            _DetainLicense = new ClsDetainLicenseContent();
            _ApplicatinType = new ClsApplicationTypesContent();
            lbApplicationFees.Text = "[????]";
            lbApplicationID.Text = "[????]";
            lbCreatedBy.Text = "[????]";
            lbDetainDate.Text = "[????]";
            lbDetainID.Text = "[????]";
            lbFineFees.Text = "[????]";
            lbLicenseID.Text = "[????]";
            lbTotalFees.Text = "[????]";

        }

        ClsApplicationsContent _Application=new ClsApplicationsContent();

        private bool _SaveApplicationInfo(int PersonID)
        {
            _Application.ApplicantPersonID = PersonID;
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationStatus = ((int)ClsGlobal.enApplicationStatus.Completed);
            _Application.ApplicationTypeID = _ApplicatinType.TypeID;
            _Application.CreatedByUserID = ClsGlobal.CurrentUser.UserID;
            _Application.PaidFees = _ApplicatinType.TypeFees;
            _Application.LastStatusDate = DateTime.Now;

            if(_Application.Save())
            {
                return true;
            }

            return false;
        }

        private bool _SaveReleaseDetainedLicenseInfo()
        {
            _DetainLicense.IsRelease = true;
            _DetainLicense.ReleaseApplicationID = _Application.ApplicationID;
            _DetainLicense.ReleaseByUserID = ClsGlobal.CurrentUser.UserID;
            _DetainLicense.ReleaseDate = DateTime.Now;

            if (_DetainLicense.ReleaseDetainedLicense() && ClsLicenseContent.ReleaseDetainLicesneByLicenseID(_LicenseID))
            {
                return true;
            }            
            return false;
            
        }

        public bool SaveData(int PersonID)
        {

            if (!_SaveApplicationInfo(PersonID) || !_SaveReleaseDetainedLicenseInfo())
            {
                return false;
            }

            return true;
        }

        public void SetReleaseApplicationID()
        {
            lbApplicationID.Text = _Application.ApplicationID.ToString();
        }

    }
}
