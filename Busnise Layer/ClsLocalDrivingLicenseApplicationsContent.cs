using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data_Layer;

namespace Busnise_Layer
{
    public class ClsLocalDrivingLicenseApplicationsContent
    {
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ApplicationID { set; get; }
        public int LicenseClassID { set; get; }

        enum enMode
        {
            AddNewMode=1,UpdateMode=2
        }

        enMode _Mode = enMode.AddNewMode;

        public ClsLocalDrivingLicenseApplicationsContent()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.ApplicationID = -1;
            this.LicenseClassID = -1;
             _Mode = enMode.AddNewMode;


        }

        public ClsLocalDrivingLicenseApplicationsContent(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
             _Mode = enMode.UpdateMode;

        }

        private bool _AddNewContact()
        {
            this.LocalDrivingLicenseApplicationID = 
                ClsLocalDrivingLicenseApplicationsData.AddNewLocalDrivingLicenseApplication(this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);

        }

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
                    else
                    {
                        return false;
                    }

                case enMode.UpdateMode:
                    return _UpdateContact();
            }

            return false;
        }

        private bool _UpdateContact()
        {
            return ClsLocalDrivingLicenseApplicationsData.UpdateLocalDrivingLicenseLicenseClass(this.LocalDrivingLicenseApplicationID, this.LicenseClassID);
        }


        public static ClsLocalDrivingLicenseApplicationsContent FindLocalDrivingApplicationByLocalDrivingApplicationID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1;
            int LicenseClassID = -1;



            if (ClsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationByLocalDrivingLicenseApplicationID(
                LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID))
            {
                return new ClsLocalDrivingLicenseApplicationsContent(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
            }
            else
            {
                return null;
            }

        }

        public static bool IsPersonHasLocalAplicationForLicenseClass(int PersonID,int LicenseClassID,byte Status=((byte)ClsGlobal.enApplicationStatus.Canceled))
        {
            return ClsLocalDrivingLicenseApplicationsData.IsPersonHasLocalLicenseApplicationForLicenseClass(PersonID, LicenseClassID, Status);
        }

        private static bool _IsLocalDrivingLicenseApplicationConnectedToAnyRecord(int LocalDrivingLicenseApplicationID)
        {
            if (ClsTestAppointmentsContent.IsLocalDrivingLicenseApplicationConnected(LocalDrivingLicenseApplicationID))
                return true;

            return false;
        }

        public static bool DeleteLocalDrivingLicenseApplicationByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            bool IsConnected = _IsLocalDrivingLicenseApplicationConnectedToAnyRecord(LocalDrivingLicenseApplicationID);

            if (IsConnected)
                return false;

            return ClsLocalDrivingLicenseApplicationsData.DeleteLocalDrivingLicenseApplicationrByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);

        }

        public static int GetApplicationIDByLocalDrivingApplicationID(int LocalDrivingLicenseApplicationID)
        {
            return ClsLocalDrivingLicenseApplicationsData.GetApplicationIDByLocalDrivingLicenseID(LocalDrivingLicenseApplicationID);
        }


    }
}
