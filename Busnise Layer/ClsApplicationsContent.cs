using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data_Layer;

namespace Busnise_Layer
{
    public class ClsApplicationsContent
    {
        public int ApplicationID { set; get; }
        public int ApplicantPersonID { set; get; }

        public DateTime ApplicationDate { set; get; }
        public int ApplicationTypeID { set; get; }
        public byte ApplicationStatus { set; get; }
        public DateTime LastStatusDate { set; get; }

        public Decimal PaidFees { set; get; }
        public int CreatedByUserID { set; get; }

        public ClsApplicationsContent()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = 0;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            _Mode = enMode.AddNewMode;

        }

        public ClsApplicationsContent(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
                                            byte ApplicationStatus,DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
             _Mode = enMode.UpdateMode;

        }

        private bool _AddNewContact()
        {
            this.ApplicationID = ClsApplicationsData.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID,
                                                                       this.ApplicationStatus,this.LastStatusDate, this.PaidFees,this.CreatedByUserID);

            return (this.ApplicationID != -1);

        }

        enum enMode
        {
            AddNewMode=1,UpdateMode=2
        }

        enMode _Mode = enMode.AddNewMode;

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNewMode:
                    if (_AddNewContact())
                    {
                        _Mode = enMode.UpdateMode;

                        return true;
                    }
                     return false;
                case enMode.UpdateMode:
                    return true;
            }

            return false;
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            return ClsApplicationsData.DeleteApplication(ApplicationID);
        }

        public static ClsApplicationsContent FindApplicationByApplicationID(int ApplicationID)
        {
            int ApplicationTypeID = -1;
            decimal PaidFees = -1;
            int ApplicantPersonID = -1, CreatedByUserID=-1;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate=DateTime.Now;
            byte ApplicationStatus = 0;


            if (ClsApplicationsData.GetApplicationByApplicationID(ApplicationID, ref  ApplicantPersonID, ref ApplicationDate,ref ApplicationTypeID,
                     ref ApplicationStatus, ref  LastStatusDate, ref  PaidFees, ref  CreatedByUserID))
            {
                return new ClsApplicationsContent(ApplicationID,  ApplicantPersonID,  ApplicationDate, ApplicationTypeID,
                                             ApplicationStatus,  LastStatusDate,  PaidFees,  CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        public static ClsApplicationsContent FindApplicationByApplicationDate(DateTime ApplicationDate)
        {
            int ApplicationID=-1,ApplicationTypeID = -1;
            decimal PaidFees = -1;
            int ApplicantPersonID = -1, CreatedByUserID = -1;
            DateTime LastStatusDate = DateTime.Now;
            byte ApplicationStatus = 0;


            if (ClsApplicationsData.GetApplicationByApplicationDate(ref ApplicationID, ref ApplicantPersonID, ApplicationDate, ref ApplicationTypeID,
                     ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new ClsApplicationsContent(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                                             ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        public static bool UpdateApplicationStatus(int ApplicationID,byte ApplicationStatus)
        {
            return ClsApplicationsData.UpdateApplicationStatus(ApplicationID, ApplicationStatus);
        }

        public static  bool IsUserConnected(int CreatedByUserID)
        {
            return ClsApplicationsData.IsUserExistWithUserID(CreatedByUserID);
        }

        public static bool IsPersonConnected(int ApplicantPersonID)
        {
            return ClsApplicationsData.IsPersonExistWithPersonID(ApplicantPersonID);
        }

    }
}
