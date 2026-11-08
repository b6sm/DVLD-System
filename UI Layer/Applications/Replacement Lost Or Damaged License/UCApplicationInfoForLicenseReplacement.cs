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
    public partial class UCApplicationInfoForLicenseReplacement : UserControl
    {
        public UCApplicationInfoForLicenseReplacement()
        {
            InitializeComponent();
        }
        decimal PaidFees = 0;
        ClsApplicationTypesContent _AppType;
        private bool _LoadData()
        {
             _AppType = ClsApplicationTypesContent.FindApplicationTypeByApplicationTypeID(_ApplicationTypeID);
            if (_AppType == null)
                return false;

            lbAppFees.Text = _AppType.TypeFees.ToString("0");
            
            lbOldLicenseID.Text = _OldLicense.LicenseID.ToString();
            return true;
        }

        public bool LoadDefaultValue()
        {
            _OldLicense = null;
            _ReplacementLicense = new ClsLicenseContent();
            _Application = new ClsApplicationsContent();
            _AppType = ClsApplicationTypesContent.FindApplicationTypeByApplicationTypeID(((int)ClsGlobal.enApplicationTypes.ReplacementForDamagedLicense));
            if (_AppType == null)
                return false;

            lbAppDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lbAppFees.Text = _AppType.TypeFees.ToString("0");
            PaidFees = _AppType.TypeFees;
            lbCreatedBy.Text = ClsGlobal.CurrentUser.UserName;
            lbOldLicenseID.Text = "[????]";
            lbReplacedLicenseID.Text = "[????]";
            lbLRAppID.Text = "[????]";
            return true;
        }

        public decimal ReturnPaidFees()
        {
            return PaidFees;
        }

        ClsLicenseContent _OldLicense;
        int _ApplicationTypeID;
        public bool LoadData(ClsLicenseContent OldLicense, int ApplicationTypeID)
        {
            _ApplicationTypeID = ApplicationTypeID;
            _OldLicense = OldLicense;
            return _LoadData();
        }

        public bool ChangeApplicationType(int ApplicationTypeID)
        {
            _ApplicationTypeID = ApplicationTypeID;
            _AppType = ClsApplicationTypesContent.FindApplicationTypeByApplicationTypeID(_ApplicationTypeID);
            if (_AppType == null)
                return false;
            lbAppFees.Text = _AppType.TypeFees.ToString("0");
            return true;
        }

        public void SetReplacementLicenseID()
        {
            if (_Application.ApplicationID != -1 || _ReplacementLicense.LicenseID != -1)
            {
                lbReplacedLicenseID.Text = _ReplacementLicense.LicenseID.ToString();
                lbLRAppID.Text = _Application.ApplicationID.ToString();
            }
        }

        ClsApplicationsContent _Application = new ClsApplicationsContent();

        private bool _SaveApplicationData(int PersonID)
        {
            _Application.ApplicantPersonID = PersonID;
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationTypeID = (_ApplicationTypeID);
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
        ClsLicenseContent _ReplacementLicense = new ClsLicenseContent();

        private bool _SaveReplacementLicenseData(byte IssueReason)
        {
            _ReplacementLicense.ApplicationID = _Application.ApplicationID;
            _ReplacementLicense.DriverID = _OldLicense.DriverID;
            _ReplacementLicense.LicenseClassID = _OldLicense.LicenseClassID;
            _ReplacementLicense.IssueDate = DateTime.Now;
            _ReplacementLicense.IssueReason = IssueReason;
            _ReplacementLicense.ExpirationDate = _OldLicense.ExpirationDate;
            _ReplacementLicense.Notes = _OldLicense.Notes;
            _ReplacementLicense.PaidFees = 0;
            _ReplacementLicense.CreatedByUserID = ClsGlobal.CurrentUser.UserID;


            if (_ReplacementLicense.Save())
            {
                return true;
            }

            return false;

        }

        private bool _SaveData(int PersonID,byte IssueReason)
        {
            if (!_SaveApplicationData(PersonID))
            {
                return false;
            }

            if (!_SaveReplacementLicenseData(IssueReason))
            {
                return false;
            }

            ClsLicenseContent.DeActivateLicenseByLicenseID(_OldLicense.LicenseID);

            return true;
        }

        public bool SaveData(int PersonID,Byte IssueReason)
        {
            return _SaveData(PersonID, IssueReason);
        }

        public int GetLicenseID()
        {
            return _ReplacementLicense.LicenseID;
        }
    }
}
