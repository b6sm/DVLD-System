using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data_Layer;

namespace Busnise_Layer
{
    public class ClsLicenseClassContent
    {

        public int LicenseClassID { set; get; }
        public string ClassName { set; get; }

        public string ClassDescription { set; get; }
        public short MinimumAllowedAge { set; get; }
        public short DefaultValidityLength { set; get; }
        public decimal ClassFees { set; get; }

        public ClsLicenseClassContent()
        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";

            this.MinimumAllowedAge = -1;
            this.DefaultValidityLength = -1;

            this.ClassFees =-1;
            
        }

        public ClsLicenseClassContent(int LicenseClassID,  string ClassName,  string ClassDescription,
           short MinimumAllowedAge,  short DefaultValidityLength,  decimal ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;

            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;

            this.ClassFees = ClassFees;
        }
        

        public static DataTable GetAllLicenseClass()
        {
            return ClsLicenseClassData.GetAllLicenseClasses();
        }

        public static ClsLicenseClassContent FindLicenseClassInfoByLicenseClassID(int LicenseClassID)
        {
            string ClassName = "", ClassDescription = "";
            sbyte MinimumAllowedAge = -1, DefaultValidityLength=-1;
            decimal ClassFees = -1;
            


            if (ClsLicenseClassData.GetLicenseClassInfoByLicenseClassID( LicenseClassID, ref  ClassName, ref  ClassDescription,
          ref  MinimumAllowedAge, ref  DefaultValidityLength, ref  ClassFees))
            {
                return new ClsLicenseClassContent(LicenseClassID, ClassName, ClassDescription,
                                                  MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else
            {
                return null;
            }

        }

        public static ClsLicenseClassContent GetLicenseClassInfoByLocalDrivingLicenseApp(int LocalDrivingLicenseApplicationID)
        {
            string ClassName = "", ClassDescription = "";
            sbyte MinimumAllowedAge = -1, DefaultValidityLength = -1;
            decimal ClassFees = -1;
            int LicenseClassID = -1;


            if (ClsLicenseClassData.GetLicenseClassInfoByLocalDrivingLicenseAppID(LocalDrivingLicenseApplicationID, ref LicenseClassID, ref ClassName, ref ClassDescription,
          ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {
                return new ClsLicenseClassContent(LicenseClassID, ClassName, ClassDescription,
                                                  MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else
            {
                return null;
            }

        }

    }
}
