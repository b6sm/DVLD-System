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
    public partial class UCScheduleTests : UserControl
    {
        public UCScheduleTests()
        {
            InitializeComponent();
            dtDate.MinDate = DateTime.Now;
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

        ClsTestAppointmentsContent _TestAppointment;
        private bool _saveRetakeTestApplication()
        {
            
            if(!_IsRetakeTest()||_RetakeApplication.ApplicationID!=-1)
            {
                return true;
            }

            int PersonID = ClsPeopleContent.GetPersonIDByNationalNo(_LDLAppView.NationalNo);
            if(PersonID==-1)
            {
                return false;
            }
            _RetakeApplication.ApplicationDate = DateTime.Now;
            _RetakeApplication.ApplicationStatus = ((byte)ClsGlobal.enApplicationStatus.Completed);
            _RetakeApplication.ApplicationTypeID = ((int)ClsGlobal.enApplicationTypes.RetakeTest);
            _RetakeApplication.CreatedByUserID = ClsGlobal.CurrentUser.UserID;
            _RetakeApplication.LastStatusDate = DateTime.Now;
            _RetakeApplication.PaidFees = _ApplicationType.TypeFees;
            _RetakeApplication.ApplicantPersonID = PersonID;

            if (_RetakeApplication.Save())
            {
                return true;
            }
            return false;
        }


        private bool _SaveTestAppointment()
        {
            _TestAppointment.TestTypeID = TypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LDLAppView.LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dtDate.Value.AddMinutes(15);
            _TestAppointment.CreatedByUserID = ClsGlobal.CurrentUser.UserID;
            _TestAppointment.PaidFees = Convert.ToDecimal(lbFees.Text);
            if(_IsRetakeTest())
            {
                _TestAppointment.RetakeTestApplicationID = _RetakeApplication.ApplicationID;
            }


            if (_TestAppointment.Save())
            {
                _TestAppointment.AppointmentDate = dtDate.Value;
                return true;
            }
            return false;
        }

        public bool SaveData()
        {
            if(!_saveRetakeTestApplication())
            {
                return false;
            }
            if (_SaveTestAppointment())
            {
                EnableSave = false;
                _Mode = enMode.UpdateMode;
                return true;
            }
            return false;

        }

        ClsTestTypeContent _TestType;
        ClsLocalDrivingLicenseApplications_ViewContent _LDLAppView;
        
        private bool _LoadLocalDrivingLicenseInfo()
        {
            _LDLAppView = ClsLocalDrivingLicenseApplications_ViewContent.GetLocalDrivingLicenseApplications_ViewByLocalDrivingLicenseApplicationID(_LDLAppViewID);
            if (_LDLAppView == null)
            {
                return false;
            }
            lbLDLAppID.Text = _LDLAppView.LocalDrivingLicenseApplicationID.ToString();
            lbDClass.Text = _LDLAppView.ClassName;
            lbName.Text = _LDLAppView.FullName;
            return true;

        }

        private bool _IsRetakeTest()
        {
            return (_Trial > 0);
        }

        ClsApplicationsContent _RetakeApplication;
        ClsApplicationTypesContent _ApplicationType;
        private bool _LoadRetakeTestInfo(int RetakeTestApplicationID=-1)
        {
            if(_IsRetakeTest())
            {
                lbTestAppointments.Text = "Schedule Retake Test";

                if(_Mode==enMode.AddNewMode)
                {
                    _RetakeApplication = new ClsApplicationsContent();
                    _ApplicationType = ClsApplicationTypesContent.FindApplicationTypeByApplicationTypeID(((int)ClsGlobal.enApplicationTypes.RetakeTest));
                    if (_ApplicationType == null)
                    {
                        return false;
                    }
                    lbRAppFees.Text = _ApplicationType.TypeFees.ToString("0");
                    lbTotalFees.Text = (Convert.ToDecimal(lbFees.Text) + Convert.ToDecimal(lbRAppFees.Text)).ToString("0");
                    gbRetakeTest.Visible = true;
                    

                }
                else if (_Mode==enMode.UpdateMode && RetakeTestApplicationID!=-1)
                {
                    _RetakeApplication = ClsApplicationsContent.FindApplicationByApplicationID(RetakeTestApplicationID);
                    if(_RetakeApplication==null)
                    {
                        return false;
                    }
                    lbRTestAppID.Text = _RetakeApplication.ApplicationID.ToString();
                    lbRAppFees.Text = _RetakeApplication.PaidFees.ToString("0");
                    lbTotalFees.Text = (Convert.ToDecimal(lbFees.Text) + Convert.ToDecimal(lbRAppFees.Text)).ToString("0");
                    gbRetakeTest.Visible = true;

                }
                else
                {
                    lbTestAppointments.Text = "Schedule Test";

                    gbRetakeTest.Visible = false;

                }

            }
            else
            {
                lbTestAppointments.Text = "Schedule Test";
                gbRetakeTest.Visible = false;
            }

            return true;

        }

        private bool _LoadUpdateModeInfo()
        {
            _TestAppointment = ClsTestAppointmentsContent.FindTestAppointmentByTestAppointmentID(_TestAppointmentID);
            if (_TestAppointment == null)
            {
                return false;
            }

            lbFees.Text = _TestAppointment.PaidFees.ToString("0");
            if (_TestAppointment.AppointmentDate < DateTime.Now)
            {
                dtDate.MinDate = _TestAppointment.AppointmentDate;
            }
            dtDate.Value = _TestAppointment.AppointmentDate;
            if (_TestAppointment.IsLocked)
            {
                EnableSave = false;
                lbLockedMessage.Visible = true;
                dtDate.Enabled = false;
            }

            if (!_LoadRetakeTestInfo(_TestAppointment.RetakeTestApplicationID))
            {
                return false;
            }
            return true;
        }

        private bool _LoadData()
        {
            if(!_LoadLocalDrivingLicenseInfo())
            {
                return false;
            }

            lbTrial.Text = _Trial.ToString();

            
            if (_Mode == enMode.AddNewMode)
            {
                EnableSave = true;
                _TestAppointment = new ClsTestAppointmentsContent();
                _TestType = ClsTestTypeContent.FindTestTypeByTestTypeID(TypeID);
                if (_TestType == null)
                {
                    return false;
                }
                lbFees.Text = _TestType.TestTypeFees.ToString("0");
                if(!_LoadRetakeTestInfo())
                {
                    return false;
                }
                return true;
            }

            if(!_LoadUpdateModeInfo())
            {
                return false;
            }
            _EnableSaveButtonWhenChangeDateValue();
            return true;

        }

        public bool EnableOrDisableSaveButton()
        {
            return EnableSave;
        }

        bool EnableSave=true;
        int _Trial;
        int _LDLAppViewID;
        enum enMode
        {
            AddNewMode=1,UpdateMode=2
        }
        enMode _Mode = enMode.AddNewMode;
        int _TestAppointmentID;
        public bool LoadData(int LDLAppViewID, int TestAppointmentID = -1)
        {
            _TestAppointmentID = TestAppointmentID;
            if (TestAppointmentID == -1)
            {
                _Mode = enMode.AddNewMode;
            }
            else
            {
                _Mode = enMode.UpdateMode;
            }
            _LDLAppViewID = LDLAppViewID;

            _Trial = ClsTestAppointmentsContent.CountTestTrial(TypeID, _LDLAppViewID);

             return _LoadData();
        }

        private void _EnableSaveButtonWhenChangeDateValue()
        {
            
            if (_TestAppointment != null && dtDate.Value != _TestAppointment.AppointmentDate)
            {
                EnableSave = true;
                return ;
            }
            EnableSave = false;
           
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            
            _EnableSaveButtonWhenChangeDateValue();
            if (OnDateChange != null)
            {
                OnDateChange();
            }
        }

        public event Action OnDateChange;

        protected virtual void DateChange()
        {

            Action Handler = OnDateChange;
            if (Handler != null)
            {
                Handler();
            }

        }

        public void FillRetakeTestID()
        {
            if (_IsRetakeTest())
                lbRTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
        }
    }
}
