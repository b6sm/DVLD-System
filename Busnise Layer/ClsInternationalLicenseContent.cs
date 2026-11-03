using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
using System.Data;

namespace Busnise_Layer
{
    public class ClsInternationalLicenseContent
    {
        public int InternationalLicenseID { set; get; }
        public int ApplicationID { set; get; }
        public int DriverID { set; get; }
        public int IssuedUsingLocalLicenseID { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsActive { set; get; }
        

        public ClsInternationalLicenseContent(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate,
                                        DateTime ExpirationDate, int CreatedByUserID, bool IsActive)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.CreatedByUserID = CreatedByUserID;
            this.IsActive = IsActive;
            
        }

        public ClsInternationalLicenseContent()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.CreatedByUserID = -1;
            this.IsActive = false;
            
        }


        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = ClsInternationalLicenseData.AddNewInternationalLicense(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate,
                 this.ExpirationDate, this.CreatedByUserID);

            return (this.InternationalLicenseID != -1);
        }

        public bool Save()
        {
            return _AddNewInternationalLicense();
        }

        public static ClsInternationalLicenseContent GetActiveInternationalLicenseInfoByDriverID(int DriverID)
        {
            int ApplicationID = -1, InternationalLicenseID = -1, IssuedUsingLocalLicenseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;

            if (ClsInternationalLicenseData.GetActiveInternationalLicenseInfoByDriverID(ref InternationalLicenseID,
                               ref  ApplicationID,  DriverID, ref  IssuedUsingLocalLicenseID,
                               ref  IssueDate, ref  ExpirationDate,
                               ref  CreatedByUserID))
            {
                return new ClsInternationalLicenseContent(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                        IssueDate,ExpirationDate, CreatedByUserID, true);
            }
            else
            {
                return null;
            }


        }

        public static ClsInternationalLicenseContent GetInternationalLicenseInfoByDriverID(int DriverID)
        {
            int ApplicationID = -1, InternationalLicenseID = -1, IssuedUsingLocalLicenseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = false;

            if (ClsInternationalLicenseData.GetInternationalLicenseInfoByDriverID(ref InternationalLicenseID,
                               ref ApplicationID, DriverID, ref IssuedUsingLocalLicenseID,
                               ref IssueDate, ref ExpirationDate,
                               ref CreatedByUserID,ref IsActive))
            {
                return new ClsInternationalLicenseContent(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                        IssueDate, ExpirationDate, CreatedByUserID, IsActive);
            }
            else
            {
                return null;
            }


        }

        public static DataTable GetAllInternationalLicenseByDriverID(int DriverID)
        {
            return ClsInternationalLicenseData.GetAllInternationalLicenseByDriverID(DriverID);
        }

        public static DataTable GetAllInternationalLicenseByPersonID(int PersonID)
        {
            return ClsInternationalLicenseData.GetAllInternationalLicenseByPersonID(PersonID);
        }

        public static DataTable GetAllInternationalLicense()
        {
            return ClsInternationalLicenseData.GetAllInternationalLicense();
        }

        public static bool IsUserConnected(int CreatedByUserID)
        {
            return ClsInternationalLicenseData.IsUserExistWithUserID(CreatedByUserID);
        }

        public static bool IsThereInternationalLicenseForThisDriverID(int DriverID)
        {
            return ClsInternationalLicenseData.IsThereInternationalLicenseForThisDriverID(DriverID);
        }

        public static ClsInternationalLicenseContent GetInternationalLicenseInfoByInternationalLicenseID(int InternationalLicenseID)
        {
            int ApplicationID = -1, IssuedUsingLocalLicenseID = -1, CreatedByUserID = -1, DriverID=-1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = false;

            if (ClsInternationalLicenseData.GetInternationalLicenseInfoByInternationalLicenseID(InternationalLicenseID,
                               ref ApplicationID,ref DriverID, ref IssuedUsingLocalLicenseID,
                               ref IssueDate, ref ExpirationDate,
                               ref CreatedByUserID, ref IsActive))
            {
                return new ClsInternationalLicenseContent(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                        IssueDate, ExpirationDate, CreatedByUserID, IsActive);
            }
            else
            {
                return null;
            }


        }

    }
}
