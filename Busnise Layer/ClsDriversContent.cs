using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;

namespace Busnise_Layer
{
    public class ClsDriversContent
    {
        public int DriverID { set; get; }
        public int PersonID { set; get; }
        public DateTime CreatedDate { set; get; }
        public int CreatedByUserID { set; get; }

        public ClsDriversContent()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedDate = DateTime.Now;
            this.CreatedByUserID = -1;
        }

        public ClsDriversContent(int DriverID,int PersonID,DateTime CreatedDate,int CreatedByUserID)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedDate = CreatedDate;
            this.CreatedByUserID = CreatedByUserID;
        }

        public static ClsDriversContent FindIsThereAnyDriverWithPersonID(int PersonID)
        {
            int DriverID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if(ClsDriversData.GetDriverByPersonID(ref DriverID,PersonID,ref CreatedDate,ref CreatedByUserID))
            {
                return new ClsDriversContent(DriverID, PersonID, CreatedDate, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        public static ClsDriversContent FindIsThereAnyDriverWithDriverID(int DriverID)
        {
            int PersonID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (ClsDriversData.GetDriverByDriverID( DriverID,ref PersonID, ref CreatedDate, ref CreatedByUserID))
            {
                return new ClsDriversContent(DriverID, PersonID, CreatedDate, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewDriver()
        {
            this.DriverID = ClsDriversData.AddNewDriver(this.PersonID, this.CreatedDate, this.CreatedByUserID);

            return (this.DriverID != -1);

        }

        public bool Save()
        {
            return _AddNewDriver();
        }

        public static bool IsUserConnected(int CreatedByUserID)
        {
            return ClsDriversData.IsUserExistWithUserID(CreatedByUserID);
        }

        public static bool IsPersonConnected(int PersonID)
        {
            return ClsDriversData.IsPersonExistWithPersonID(PersonID);
        }

        public static int GetDriverIDByPersonID(int PersonID)
        {
            return ClsDriversData.GetDriverIDByPersonID(PersonID);
        }

        public static int GetPersonIDByDriverID(int DriverID)
        {
            return ClsDriversData.GetPersonIDByDriverID(DriverID);
        }
    }
}
