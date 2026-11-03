using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data_Layer;

namespace Busnise_Layer
{
    public class ClsTestAppointmentsContent
    {
        public int TestAppointmentID { set; get; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { set; get; }
        public DateTime AppointmentDate { set; get; }
        public decimal PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsLocked { set; get; }
        public int RetakeTestApplicationID { set; get; }


        public ClsTestAppointmentsContent()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;

            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationID = -1;
            _Mode = enMode.AddNewMode;
        }

        public ClsTestAppointmentsContent(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,
                   DateTime AppointmentDate, decimal PaidFees,
                   int CreatedByUserID,int RetakeTestApplicationID, bool IsLocked )
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;

            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            _Mode = enMode.UpdateMode;
        }

        enum enMode
        { AddNewMode = 1, UpdateMode = 2 }
        enMode _Mode = enMode.AddNewMode;

        private bool _AddNewContact()
        {
            this.TestAppointmentID =
                ClsTestAppointmentsData.AddNewTestAppointment(this.TestTypeID,this.LocalDrivingLicenseApplicationID,
                                                               this.AppointmentDate,this.PaidFees,this.CreatedByUserID,this.RetakeTestApplicationID);

            return (this.TestAppointmentID != -1);

        }

        public  bool _UpdateTestAppointmentScheduleDate()
        {
            return ClsTestAppointmentsData.UpdateTestAppointmentScheduleDate(this.TestAppointmentID,this.AppointmentDate);
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
                    return false;
                case enMode.UpdateMode:
                    return _UpdateTestAppointmentScheduleDate();
            }

            return false;
        }
        public static DataTable GetAllAppointmentsByTestTypeID(int TestTypeID,int LocalDrivingLicenseApplicationID)
        {
            return ClsTestAppointmentsData.GetAllAppointmentsByTestTypeIDAndLocoalDrivingLicenseApplicationID(TestTypeID, LocalDrivingLicenseApplicationID);
        }

        public static bool IsThereAnyScheduleTestUncomplited(int TestTypeID,int LocalDrivingLicenseApplicatinID)
        {
            return ClsTestAppointmentsData.IsThereAnyScheduleTestUnLocked(TestTypeID, LocalDrivingLicenseApplicatinID);
        }

        public static ClsTestAppointmentsContent FindTestAppointmentByTestAppointmentID(int TestAppointmentID)
        {
            
            decimal PaidFees = -1;
            int TestTypeID = -1, LocalDrivingLicenseApplicationID = -1, CreatedByUserID=-1;
            DateTime AppointmentDate = DateTime.Now;
            bool IsLocked=false;
            int RetakeTestApplicationID = -1;

            if (ClsTestAppointmentsData.GetTestAppointmentByTestAppointmentID(TestAppointmentID, ref TestTypeID,
                ref LocalDrivingLicenseApplicationID, ref AppointmentDate,ref PaidFees,ref CreatedByUserID,ref IsLocked,ref RetakeTestApplicationID))
            {
                return new ClsTestAppointmentsContent(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate,PaidFees,CreatedByUserID, RetakeTestApplicationID, IsLocked);
            }
            else
            {
                return null;
            }

        }

        public static bool LockedTestAppointment(int TestAppointmentID)
        {
            return ClsTestAppointmentsData.LockedTestAppointment(TestAppointmentID);
        }

        public static bool IsUserConnected(int CreatedByUserID)
        {
            return ClsTestAppointmentsData.IsUserExistWithUserID(CreatedByUserID);
        }

        public static bool IsLocalDrivingLicenseApplicationConnected(int LocalDrivingLicenseApplicationID)
        {
            return ClsTestAppointmentsData.IsLocalDrivingLicenseApplicationExistWithLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);
        }

        public static int CountTestTrial(int TestTypeID,int LocalDrivingLicenseApplicationID)
        {
            return ClsTestAppointmentsData.CountTestTrails(TestTypeID, LocalDrivingLicenseApplicationID);
        }

        public static DateTime GetAppointmentDate(int TestAppointmentID)
        {
            return ClsTestAppointmentsData.GetAppointmentDate(TestAppointmentID);
        }

    }
}
