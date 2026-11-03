using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Busnise_Layer;

namespace My_DVLD
{
    public partial class UCScheduleTestInfo : UserControl
    {
        public UCScheduleTestInfo()
        {
            InitializeComponent();
        }

        int TypeID;

        public bool LoadType(int TestTypeID)
        {
            TypeID = TestTypeID;
            switch ((ClsGlobal.enTestType)TestTypeID)
            {
                case ClsGlobal.enTestType.VisionTest:
                    pbTestAppointments.Image = Properties.Resources.eye__1_;
                    guna2GroupBox1.Text = "Vision Test";
                    break;
                case ClsGlobal.enTestType.WrittenTest:
                    pbTestAppointments.Image = Properties.Resources.copy_writing__1_;
                    guna2GroupBox1.Text = "Written Test";
                    break;
                case ClsGlobal.enTestType.StreetTest:
                    pbTestAppointments.Image = Properties.Resources.test__1_;
                    guna2GroupBox1.Text = "Street Test";
                    break;
                default:
                    return false;
            }
            return true;
        }

        private bool _LoadData(int TestAppointmentID, int Trial, int LDLAppViewID)
        {
            ClsLocalDrivingLicenseApplications_ViewContent LDLAppView = 
            ClsLocalDrivingLicenseApplications_ViewContent.GetLocalDrivingLicenseApplications_ViewByLocalDrivingLicenseApplicationID(LDLAppViewID);
            ClsTestAppointmentsContent TestAppointment = ClsTestAppointmentsContent.FindTestAppointmentByTestAppointmentID(TestAppointmentID);
            if (LDLAppView == null || TestAppointment == null)
            {
                return false;
            }
            lbLDLAppID.Text = TestAppointment.LocalDrivingLicenseApplicationID.ToString();
            lbDClass.Text = LDLAppView.ClassName;
            lbName.Text = LDLAppView.FullName;
            lbTrial.Text = Trial.ToString();
            lbDate.Text = TestAppointment.AppointmentDate.ToString("dd/MM/yyyy");
            lbFees.Text = TestAppointment.PaidFees.ToString("0");
            return true;
            
        }

        int _Trial;

        public bool LoadData(int TestAppointmentID,int LDLAppViewID)
        {
            _Trial = ClsTestAppointmentsContent.CountTestTrial(TypeID, LDLAppViewID);

            return _LoadData(TestAppointmentID, _Trial, LDLAppViewID);
        }

        public void FillTestID(int TestID)
        {
            lbTestID.Text = TestID.ToString();
        }

    }
}
