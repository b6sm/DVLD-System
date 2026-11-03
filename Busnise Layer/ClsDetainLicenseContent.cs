using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;

namespace Busnise_Layer
{
    public class ClsDetainLicenseContent
    {
        public int DetainID { set; get; }
        public int LicenseID { set; get; }
        public DateTime DetainDate { set; get; }
        public decimal FineFees { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsRelease { set; get; }
        public DateTime ReleaseDate { set; get; }
        public int ReleaseByUserID { set; get; }
        public int ReleaseApplicationID { set; get; }

        public ClsDetainLicenseContent(int DetainID, int LicenseID,DateTime DetainDate, decimal FineFees, int CreatedByUserID,
                                       bool IsRelease, DateTime ReleaseDate, int ReleaseByUserID, int ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsRelease = IsRelease;
            this.ReleaseDate = ReleaseDate;
            this.ReleaseByUserID = ReleaseByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;

        }

        public ClsDetainLicenseContent(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID,
                                       bool IsRelease)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsRelease = IsRelease;
            

        }

        public ClsDetainLicenseContent()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = -1;
            this.CreatedByUserID = -1;
            this.IsRelease = false;
            this.ReleaseDate = DateTime.Now;
            this.ReleaseByUserID = -1;
            this.ReleaseApplicationID = -1;

        }

        private bool _AddNewDetainLicense()
        {
            this.DetainID = ClsDetainLicenseData.AddNewDetainLicense(this.LicenseID,this.DetainDate, this.FineFees, this.CreatedByUserID);

            return (this.DetainID != -1);

        }

        public bool Save()
        {
            return _AddNewDetainLicense();
        }

        private bool _ReleaseDetainedLicense()
        {
            return ClsDetainLicenseData.ReleaseDetainedLicense(this.DetainID, this.IsRelease, this.ReleaseDate,
                                                               this.ReleaseByUserID, this.ReleaseApplicationID);
        }

        public bool ReleaseDetainedLicense()
        {
            return _ReleaseDetainedLicense();
        }


        public static ClsDetainLicenseContent GetDetainedLicenseByLicenseID(int LicenseID, bool IsRelease = false)
        {
            int DetainID = -1, CreatedByUserID=-1;
            DateTime DetainDate = DateTime.Now;
            decimal FineFees = -1;
            
            
            if(ClsDetainLicenseData.GetDetainedLicenseByLicenseID(ref DetainID,LicenseID,ref DetainDate,ref FineFees,ref CreatedByUserID))
            {
                return new ClsDetainLicenseContent(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsRelease);
            }
            else
            {
                return null;
            }

        }

        public static bool IsUserConnected(int CreatedByUserID)
        {
            return ClsDetainLicenseData.IsUserExistWithUserID(CreatedByUserID);
        }


    }
}
