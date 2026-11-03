using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data_Layer;

namespace Busnise_Layer
{
    public class ClsUserContent
    {
        public int UserID { set; get; }
        public int PersonID { set; get; }
        public string UserName { set; get; }


        public bool IsActive { set; get; }

        public ClsUserContent()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.IsActive = false;

            _Mode = enMode.AddNew;

        }

        public ClsUserContent(int UserID, int PersonID, string UserName,bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.IsActive = IsActive;

            _Mode = enMode.Update;
        }

        public static ClsUserContent FindUserByUserID(int UserID)
        {
            string UserName = "";
            int PersonID = -1;
            bool IsActive = false;



            if (ClsUserData.GetUserByUserID(UserID, ref PersonID, ref UserName,ref IsActive))
            {
                return new ClsUserContent(UserID, PersonID, UserName,IsActive);
            }
            else
            {
                return null;
            }

        }

        public bool ValidateUserPassword(string Password)
        {
            string hashedPassword = ClsGlobal.ComputeHash(Password);
            return ClsUserData.ValidateUserByUserIDAndPassword(this.UserID, hashedPassword);
        }

        public static bool ValidateUserName(string UserName)
        {
            return ClsUserData.ValidateUserName(UserName);
        }

        public bool UpdateUserPassword(string Password)
        {
            string hashedPassword = ClsGlobal.ComputeHash(Password);
            return ClsUserData.UpdateUserPassword(this.UserID, hashedPassword);
        }

        public static DataTable GetAllUsers()
        {
            return ClsUserData.GetAllUsers();
        }

        public enum enMode
        {
            AddNew = 0, Update = 1
        }

        private enMode _Mode = enMode.AddNew;


        private bool _AddNewContact(string Password)
        {
            string hashedPassword = ClsGlobal.ComputeHash(Password);
            this.UserID = ClsUserData.AddNewUser(this.PersonID,this.UserName, hashedPassword, this.IsActive);

            return (this.UserID != -1);

        }

        private bool _UpdateContact()
        {
            return ClsUserData.UpdateUserInfo(this.UserID,this.UserName,this.IsActive);
        }

        public bool Save(string Password)
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewContact(Password))
                    {
                        _Mode = enMode.Update;

                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateContact();
            }

            return false;
        }

        private static bool _IsUserConnectedToAnyRecord(int UserID)
        {
            if (ClsApplicationsContent.IsUserConnected(UserID))
                return true;
            if (ClsDetainLicenseContent.IsUserConnected(UserID))
                return true;
            if (ClsDriversContent.IsUserConnected(UserID))
                return true;
            if (ClsInternationalLicenseContent.IsUserConnected(UserID))
                return true;
            if (ClsLicenseContent.IsUserConnected(UserID))
                return true;
            if (ClsTestAppointmentsContent.IsUserConnected(UserID))
                return true;
            if (ClsTestsContent.IsUserConnected(UserID))
                return true;

            return false;
        }

        public static bool DeleteUserByUserID(int UserID)
        {
            bool IsConnected = _IsUserConnectedToAnyRecord(UserID);

            if (IsConnected)
                return false;

            return ClsUserData.DeleteUserByUserID(UserID);

        }

        public static bool IsPersonConnected(int PersonID)
        {
            return ClsUserData.IsPersonExistWithPersonID(PersonID);
        }

        public static string GetUserNameByUserID(int UserID)
        {
            return ClsUserData.GetUserNameByUserID(UserID);
        }

        public static ClsUserContent GetUserDataByUsernameAndPassword(string UserName,string Password)
        {
            int PersonID = -1, UserID=-1;
            bool IsActive = false;
            string hashedPassword = ClsGlobal.ComputeHash(Password);

            if (ClsUserData.GetUserDataByUsernameAndPassword(UserName, hashedPassword, ref UserID, ref PersonID,  ref IsActive))
            {
                return new ClsUserContent(UserID, PersonID, UserName, IsActive);
            }
            else
            {
                return null;
            }

        }


    }
}
