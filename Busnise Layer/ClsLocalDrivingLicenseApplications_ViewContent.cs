using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data_Layer;

namespace Busnise_Layer
{
    public class ClsLocalDrivingLicenseApplications_ViewContent
    {
        public int LocalDrivingLicenseApplicationID { set; get; }
        public string ClassName { set; get; }

        public string NationalNo { set; get; }
        public string FullName { set; get; }
        public DateTime ApplicationDate { set; get; }
        public int PassTestCount { set; get; }

        public string Status { set; get; }

        public ClsLocalDrivingLicenseApplications_ViewContent()
        {
            this.LocalDrivingLicenseApplicationID = -1;

            this.ClassName = "";
            this.NationalNo = "";
            this.FullName = "";

            this.ApplicationDate = DateTime.Now;
            this.PassTestCount = -1;
            this.Status = "";
           
        }

        public ClsLocalDrivingLicenseApplications_ViewContent(int LocalDrivingLicenseApplicationID, string ClassName, string NationalNo,
                                                              string FullName,
                                                                DateTime ApplicationDate, int PassTestCount, string Status)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            this.ClassName = ClassName;
            this.NationalNo = NationalNo;
            this.FullName = FullName;

            this.ApplicationDate = ApplicationDate;
            this.PassTestCount = PassTestCount;
            this.Status = Status;
        }




        public static DataTable GetAllGetAllLocalDrivingLicenseApplications_View()
        {
            return ClsLocalDrivingLicenseApplications_ViewData.GetAllLocalDrivingLicenseApplications_View();
        }



        public static ClsLocalDrivingLicenseApplications_ViewContent GetLocalDrivingLicenseApplications_ViewByNationalNo(string NationalNo)
        {
            string ClassName = "", FullName = "", Status = "";
            DateTime ApplicationDate = DateTime.Now;
            int PassTestCount = -1;
            int LocalDrivingLicenseApplicationID = -1;



            if (ClsLocalDrivingLicenseApplications_ViewData.GetLocalDrivingLicenseApplications_ViewByNationalNo(ref LocalDrivingLicenseApplicationID,
                ref ClassName,  NationalNo, ref FullName, ref ApplicationDate, ref PassTestCount,
                ref Status))
            {
                return new ClsLocalDrivingLicenseApplications_ViewContent(LocalDrivingLicenseApplicationID, ClassName, NationalNo,
                                                                          FullName, ApplicationDate, PassTestCount, Status);
            }
            else
            {
                return null;
            }

        }

        public static ClsLocalDrivingLicenseApplications_ViewContent GetLocalDrivingLicenseApplications_ViewByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            string ClassName = "", FullName = "", Status = "";
            DateTime ApplicationDate = DateTime.Now;
            int PassTestCount = -1;
            string NationalNo  = "";



            if (ClsLocalDrivingLicenseApplications_ViewData.GetLocalDrivingLicenseApplications_ViewByLocalDrivingLicenseApp( LocalDrivingLicenseApplicationID,
                ref ClassName,ref NationalNo, ref FullName, ref ApplicationDate, ref PassTestCount,
                ref Status))
            {
                return new ClsLocalDrivingLicenseApplications_ViewContent(LocalDrivingLicenseApplicationID, ClassName, NationalNo,
                                                                          FullName, ApplicationDate, PassTestCount, Status);
            }
            else
            {
                return null;
            }

        }


    }
}
