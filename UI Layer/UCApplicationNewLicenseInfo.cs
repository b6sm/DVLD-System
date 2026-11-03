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
    public partial class UCApplicationNewLicenseInfo : UserControl
    {
        public UCApplicationNewLicenseInfo()
        {
            InitializeComponent();
        }

        private bool _LoadOldLicenseData()
        {
            tbxNotes.Enabled = true;

            _LicenseClass = ClsLicenseClassContent.FindLicenseClassInfoByLicenseClassID(_OldLicense.LicenseClassID);
            if (_LicenseClass == null)
                return false;
            lbOldLicenseID.Text = _OldLicense.LicenseID.ToString();
            lbLicenseFees.Text = _LicenseClass.ClassFees.ToString("0");
            lbTootalFees.Text = (_LicenseClass.ClassFees + _AppType.TypeFees).ToString("0");
            lbExpirationDate.Text = DateTime.Now.AddYears((short)_LicenseClass.DefaultValidityLength).ToString("dd/MM/yyyy");
            return true;
        }

        ClsLicenseContent _OldLicense;
        ClsLicenseClassContent _LicenseClass;

        public bool LoadOldLicenseData(ClsLicenseContent OldLicense )
        {
            _OldLicense = OldLicense;
            return _LoadOldLicenseData();
        }

        public bool LoadDefaultValue()
        {
            _LicenseClass = null;
            _OldLicense = null;
            _Application = new ClsApplicationsContent();
            _RenewLicense = new ClsLicenseContent();
            _AppType = ClsApplicationTypesContent.FindApplicationTypeByApplicationTypeID(((int)ClsGlobal.enApplicationTypes.RenewDrivingLicenseService));
            if (_AppType == null)
                return false;
            lbRLAppID.Text = "[????]";
            lbLicenseFees.Text = "[????]";
            tbxNotes.Enabled = false;
            tbxNotes.Clear();
            lbRenewedLicenseID.Text = "[????]";
            lbOldLicenseID.Text = "[????]";
            lbExpirationDate.Text = "[????]";
            lbTootalFees.Text = "[????]";

            lbApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lbIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lbApplicationFees.Text = _AppType.TypeFees.ToString("0");
            lbCreaetedBy.Text = ClsGlobal.CurrentUser.UserName;
            return true;

        }

        ClsApplicationTypesContent _AppType;

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
        ClsLicenseContent _RenewLicense = new ClsLicenseContent();

        private bool _SaveReplacementLicenseData()
        {
            _RenewLicense.ApplicationID = _Application.ApplicationID;
            _RenewLicense.DriverID = _OldLicense.DriverID;
            _RenewLicense.LicenseClassID = _OldLicense.LicenseClassID;
            _RenewLicense.IssueDate = DateTime.Now;
            _RenewLicense.IssueReason = ((byte)ClsGlobal.enIssueReason.RenewLicense);
            _RenewLicense.ExpirationDate = _RenewLicense.IssueDate.AddYears(_LicenseClass.DefaultValidityLength);
            _RenewLicense.Notes = tbxNotes.Text;
            _RenewLicense.PaidFees = _LicenseClass.ClassFees;
            _RenewLicense.CreatedByUserID = ClsGlobal.CurrentUser.UserID;

            if (_RenewLicense.Save())
            {
                return true;
            }

            return false;
            
        }

        private bool _SaveData(int PersonID)
        {
            if (!_SaveApplicationData(PersonID))
            {
                return false;
            }

            if (!_SaveReplacementLicenseData())
            {
                return false;
            }

            ClsLicenseContent.DeActivateLicenseByLicenseID(_OldLicense.LicenseID);

            return true;
        }

        public bool SaveData(int PersonID)
        {
            return _SaveData(PersonID);
        }

        public void SetNewLicenseID()
        {
            if (_Application.ApplicationID != -1 || _RenewLicense.LicenseID != -1)
            {
                lbRLAppID.Text = _Application.ApplicationID.ToString();
                lbRenewedLicenseID.Text = _RenewLicense.LicenseID.ToString();
            }
        }

        public int GetLicenseID()
        {
            return _RenewLicense.LicenseID;
        }

    }
}
