using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;

namespace Busnise_Layer
{
    public class ClsTestsContent
    {
        public int TestID { set; get; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { set; get; }
        public string Note { set; get; }
       
        public int CreatedByUserID { set; get; }
       

        public ClsTestsContent()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;

            this.TestResult = false;
            this.Note = "";
            this.CreatedByUserID = -1;

        }

        public ClsTestsContent(int TestID,int TestAppointmentID, bool TestResult, string Note, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;

            this.TestResult = TestResult;
            this.Note = Note;
            this.CreatedByUserID = CreatedByUserID;

        }

        private bool _AddNewContact()
        {
            this.TestID =
                ClsTestsData.AddNewTest(this.TestAppointmentID, this.TestResult,this.Note, this.CreatedByUserID);

            return (this.TestID != -1);

        }

        public bool Save()
        {
            if (_AddNewContact())
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsUserConnected(int CreatedByUserID)
        {
            return ClsTestsData.IsUserExistWithUserID(CreatedByUserID);
        }

        public static bool IsPassTheTest(int TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            return ClsTestsData.IsPassTheTest(TestTypeID,LocalDrivingLicenseApplicationID);
        }

    }
}
