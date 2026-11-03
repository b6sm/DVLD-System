using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
using System.Data;

namespace Busnise_Layer
{
    public class ClsLicenseContent
    {
        public int LicenseID { set; get; }
        public int ApplicationID { set; get; }
        public int DriverID { set; get; }
        public int LicenseClassID { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }

        public string Notes { set; get; }
        public decimal PaidFees { set; get; }
        public byte IssueReason { set; get; }
        public int CreatedByUserID{ set; get; } 
        public bool IsActive { set; get; }
        public bool IsDetained { set; get; }

        public ClsLicenseContent(int LicenseID,int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate,
                                        DateTime ExpirationDate,string Notes, decimal PaidFees,
                                        byte IssueReason, int CreatedByUserID, bool IsActive,bool IsDetained)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClassID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;

            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
            this.IsActive = IsActive;
            this.IsDetained = IsDetained;
        }

        public ClsLicenseContent()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;

            this.Notes = "";
            this.PaidFees = -1;
            this.IssueReason = 0;
            this.CreatedByUserID = -1;
            this.IsActive = false;
            this.IsDetained = false;
        }

        public static ClsLicenseContent GetLicenseInfoByLicenseID(int LicenseID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClassID = -1, CreatedByUserID = -1;
            byte IssueReason = 0;
            bool IsActive = false, IsDetained=false;
            string Notes = "";
            decimal PaidFees = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;

            if (ClsLicenseData.GetLicenseInfoByLicenseID( LicenseID,ref ApplicationID, ref DriverID, ref LicenseClassID,
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IssueReason, ref CreatedByUserID, ref IsActive,ref IsDetained))
            {
                return new ClsLicenseContent(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate,
                        ExpirationDate, Notes, PaidFees, IssueReason, CreatedByUserID, IsActive, IsDetained);
            }
            else
            {
                return null;
            }


        }

        public static ClsLicenseContent GetActiveLicenseInfoByLicenseID(int LicenseID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClassID = -1, CreatedByUserID = -1;
            byte IssueReason = 0;
            bool IsActive = true, IsDetained=false;
            string Notes = "";
            decimal PaidFees = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;

            if (ClsLicenseData.GetActiveLicenseInfoByLicenseID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID,
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IssueReason, ref CreatedByUserID,ref IsDetained))
            {
                return new ClsLicenseContent(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate,
                        ExpirationDate, Notes, PaidFees, IssueReason, CreatedByUserID, IsActive, IsDetained);
            }
            else
            {
                return null;
            }


        }

        public static ClsLicenseContent GetLicenseInfoByApplicationID(int ApplicationID)
        {
            int LicenseID = -1, DriverID = -1, LicenseClassID = -1, CreatedByUserID = -1;
            byte IssueReason = 0;
            bool IsActive = false, IsDetained=false;
            string Notes = "";
            decimal PaidFees = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;

            if(ClsLicenseData.GetLicenseInfoByApplicationID(ref LicenseID,ApplicationID,ref DriverID,ref LicenseClassID,
                ref IssueDate,ref ExpirationDate,ref Notes,ref PaidFees,ref IssueReason,ref CreatedByUserID,ref IsActive,ref IsDetained))
            {
                return new ClsLicenseContent(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate,
                        ExpirationDate, Notes, PaidFees, IssueReason, CreatedByUserID, IsActive, IsDetained);
            }
            else
            {
                return null;
            }


        }

        public static int GetLicenseIDByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            return ClsLicenseData.GetLicenseIDByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);
        }

        private bool _AddNewLicense()
        {
            this.LicenseID = ClsLicenseData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate,
                 this.ExpirationDate,this.Notes, this.PaidFees, this.IssueReason, this.CreatedByUserID);

            return (this.LicenseID != -1);
        }

        public bool Save()
        {
            return _AddNewLicense();
        }

        public static bool DeActivateLicenseByLicenseID(int LicenseID)
        {
            return ClsLicenseData.DeActivateLicensebyLicenseID(LicenseID);
        }

        public static bool DetainLicesneByLicenseID(int LicenseID)
        {
            return ClsLicenseData.UpdateIsDetainByLicenseID(LicenseID);
        }

        public static bool ReleaseDetainLicesneByLicenseID(int LicenseID)
        {
            return ClsLicenseData.UpdateIsDetainByLicenseID(LicenseID,false);
        }

        public static DataTable GetAllLicenseByDriverID(int DriverID)
        {
            return ClsLicenseData.GetAllLicenseByDriverID(DriverID);
        }

        public static DataTable GetAllLicenseByPersonID(int PersonID)
        {
            return ClsLicenseData.GetAllLicenseByPersonID(PersonID);
        }

        public static bool IsUserConnected(int CreatedByUserID)
        {
            return ClsLicenseData.IsUserExistWithUserID(CreatedByUserID);
        }

    }
}
