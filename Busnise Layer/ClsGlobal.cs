using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using Data_Layer;
using System.Security.Cryptography;

namespace Busnise_Layer
{
    public static class ClsGlobal
    {
        public static DataTable dtCountries;

        public static DataTable dtLicenseClass;

        public enum enGender
        {
            Male=1,Female=2
        }

        public enum enApplicationStatus
        {
            New=1,Canceled=2,Completed=3
        }

        public enum enApplicationTypes
        {
            NewLocalDrivingLicense = 1, RenewDrivingLicenseService = 2, ReplacementForLostLicense = 3,
            ReplacementForDamagedLicense=4,ReleaseDetainedLicense=5,NewInterNationalLicense=6,RetakeTest=7
        }

        public enum enTestType
        {
            VisionTest = 1, WrittenTest = 2, StreetTest = 3
        }

        public static ClsUserContent CurrentUser=null;

        public enum enIssueReason
        {
            FirstTime=1,RenewLicense=2,ReplacementForDamaged=3,ReplacementForLost=4
        }

        public enum enLicenseClass
        {

            Class1 = 1, Class2 = 2, Class3 = 3, Class4 = 4, Class5 = 5, Class6 = 6
        }

        public enum enPeopleFilter
        {
            PersonID=1,FullName=2,NationalNo=3,Phone=4,Email=5
        }

        private static string _EncryptData(string PlainText)
        {
            byte[] DataToEncrypt = Encoding.UTF8.GetBytes(PlainText);
            byte[] EncryptedData = ProtectedData.Protect(DataToEncrypt, null, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(EncryptedData);
        }

        public static string EncryptData(string PlainText)
        {
            return _EncryptData(PlainText);
        }

        private static string _DecryptData(string EncryptedText)
        {
            byte[] DataToDecrypt = Convert.FromBase64String(EncryptedText);
            byte[] DecryptedData = ProtectedData.Unprotect(DataToDecrypt, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(DecryptedData);
        }

        public static string DecryptData(string PlainText)
        {
            return _DecryptData(PlainText);
        }

        public static string ComputeHash(string rawData)
        {
            // استخدام SHA-256 لتوليد الهاش
            SHA256 sha256Hash = SHA256.Create();
            
                // تحويل النص إلى Bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // تحويل البايتات إلى مصفوفة نصية Hexadecimal (64 حرف)
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            
        }

    }

}
