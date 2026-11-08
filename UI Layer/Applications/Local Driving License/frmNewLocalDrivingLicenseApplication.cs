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
    public partial class frmNewLocalDrivingLicenseApplication : frmBaseForm
    {
        enum enMode
        {
            AddNew=1,Update=2
        }
        enMode _Mode;
        int _LocalDrivingApplicationID;
        public frmNewLocalDrivingLicenseApplication(int LocalDrivingApplicationID=-1)
        {
            InitializeComponent();
            _LocalDrivingApplicationID = LocalDrivingApplicationID;
            if(LocalDrivingApplicationID==-1)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;

            }
        }

        private bool _AllowNavigation = false;

        private void guna2TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_AllowNavigation)
                e.Cancel = true;
        }

        private bool _IsHasLicenseOnThisClass()
        {
            return ClsLocalDrivingLicenseApplicationsContent.IsPersonHasLocalAplicationForLicenseClass(_Person.PersonID, _LicenseClassID);
        }

        private bool _VerifyingLicenseClassAge()
        {
            _LicenseClass = ClsLicenseClassContent.FindLicenseClassInfoByLicenseClassID(_LicenseClassID);
            if (_LicenseClass == null || _Person == null)
                return false;
            short MinimumAge = _LicenseClass.MinimumAllowedAge;
            DateTime dt = _Person.DateOfBirth;
            DateTime today = DateTime.Today;
            if (dt > today.AddYears(-MinimumAge))
            {
                return false;
            }
            return true;
        }

        ClsApplicationsContent _Application = new ClsApplicationsContent();

        private bool _CreateNewApplication()
        {
            _Application.ApplicantPersonID = _Person.PersonID;
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationStatus = (int)ClsGlobal.enApplicationStatus.New;
            _Application.ApplicationTypeID = ((int)ClsGlobal.enApplicationTypes.NewLocalDrivingLicense);
            _Application.CreatedByUserID = ClsGlobal.CurrentUser.UserID;
            _Application.PaidFees = _ApplicationType.TypeFees;
            _Application.LastStatusDate = DateTime.Now;

            if (_Application.Save())
            {
                return true;
            }
            return false;
        }

        ClsLocalDrivingLicenseApplicationsContent _LDLApplication = new ClsLocalDrivingLicenseApplicationsContent();


        private bool _CreateNewLocalDrivingLicenseApplication()
        {
            _LDLApplication.ApplicationID = _Application.ApplicationID;
            _LDLApplication.LicenseClassID = _LicenseClassID;
            if (_LDLApplication.Save())
            {
                return true;
            }
            return false;
        }

        private bool _SaveData()
        {
            if (!_CreateNewApplication())
                return false;
            if (!_CreateNewLocalDrivingLicenseApplication())
                return false;
            return true;
        }

        private bool _AllowSave()
        {

            if (guna2TabControl1.SelectedTab == tabPage1)
            {
                if(_Mode==enMode.AddNew)
                _LoadData();
                _AllowNavigation = true;
                guna2TabControl1.SelectedTab = tabPage2;
                btnBack.Visible = true;
                btnNextSave.Text = "Save";
                btnNextSave.Visible = true;
                _AllowNavigation = false;
                if(_Mode==enMode.Update&&_LDLApplication.LicenseClassID==(int)cbxClasses.SelectedValue)
                {
                    btnNextSave.Visible = false;
                }
                return false;
            }
            else
            {
                return true;
            }

        }

        private void _MoveToPersonInfoTab()
        {
            if (guna2TabControl1.SelectedTab == tabPage2)
            {
                _AllowNavigation = true;

                btnBack.Visible = false;
                guna2TabControl1.SelectedTab = tabPage1;
                btnNextSave.Text = "Next";
                btnNextSave.Visible = true;
                _AllowNavigation = false;
            }
            else
            {
                btnBack.Visible = true;

            }
        }

        private bool _CheckValidate()
        {
            _LicenseClassID = (int)cbxClasses.SelectedValue;

            if (!_VerifyingLicenseClassAge())
            {
                MessageBox.Show(
                  $"Sorry, you Can't create local driving for this person. The minimum required age is {_LicenseClass.MinimumAllowedAge} years.",
                   "Age Requirement Not Met",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning
                     );
                return false;
            }

            if (_IsHasLicenseOnThisClass())
            {
                MessageBox.Show("This Person Already Has Local Driving License Application On This Class", "Error",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnNextSave_Click(object sender, EventArgs e)
        {
            if (!_AllowSave())
                return;

            if (MessageBox.Show("Are you sure you want to add new Local Driving license Application for this person?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (!_CheckValidate())
                return;
            if(_SaveData())
            {
                MessageBox.Show("Data Save Succesfully", "Succesfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbLDLApplicationID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
                _Mode = enMode.Update;
                lbUpdateOrAddTitle.Text = "Update Local Driving License Application";
                btnNextSave.Visible = false;
                return;
            }
            MessageBox.Show("An Error Occurated While Saving Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _MoveToPersonInfoTab();
        }

        ClsPeopleContent _Person ;

        private void ucFilter1_OnSearchButtonV2(ClsPeopleContent obj)
        {
            if(obj==null)
            {
                MessageBox.Show("No person was found matching the search criteria.",
                                "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            btnNextSave.Visible = true;
            _Person = obj;
            ucPersonal_info1.LoadPersonInfoByPersonData(obj);
        }

        ClsLicenseClassContent _LicenseClass = new ClsLicenseClassContent();
        int _LicenseClassID = -1;

        ClsApplicationTypesContent _ApplicationType = new ClsApplicationTypesContent();
        int _ApplicationTypeID = (int)ClsGlobal.enApplicationTypes.NewLocalDrivingLicense;

        private void _FillLicenseClassInComboBox(DataTable dt)
        {

            cbxClasses.SuspendLayout();

            cbxClasses.DisplayMember = "ClassName";
            cbxClasses.ValueMember = "LicenseClassID";
            cbxClasses.DataSource = dt;
            cbxClasses.SelectedIndex = 2;

            _LicenseClassID = ((int)ClsGlobal.enLicenseClass.Class3);


            cbxClasses.ResumeLayout();
        }

        private void _LoadApplicationData()
        {
            if (_Mode == enMode.AddNew)
            {
                _ApplicationType = ClsApplicationTypesContent.FindApplicationTypeByApplicationTypeID(_ApplicationTypeID);

                lbApplicationFees.Text = _ApplicationType.TypeFees.ToString("0");

                lbApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                lbCreatedByUser.Text = ClsGlobal.CurrentUser.UserName;
                return;
            }

            lbApplicationFees.Text = _Application.PaidFees.ToString("0");
            lbApplicationDate.Text = _Application.ApplicationDate.ToString("dd/MM/yyyy");
            lbCreatedByUser.Text = ClsUserContent.FindUserByUserID(_Application.CreatedByUserID).UserName;

        }

        private void _LoadData()
        {
            DataTable dt = ClsGlobal.dtLicenseClass;
            if (dt == null)
                return;
            _FillLicenseClassInComboBox(dt);

            if (_Mode == enMode.AddNew)
            {
                _LoadApplicationData();

                lbUpdateOrAddTitle.Text = "New Local Driving License Application";
                _LDLApplication = new ClsLocalDrivingLicenseApplicationsContent();
                _Application = new ClsApplicationsContent();
                return;
            }

            _LDLApplication = ClsLocalDrivingLicenseApplicationsContent.FindLocalDrivingApplicationByLocalDrivingApplicationID(_LocalDrivingApplicationID);
            _Application = ClsApplicationsContent.FindApplicationByApplicationID(_LDLApplication.ApplicationID);
            lbUpdateOrAddTitle.Text = "Update Local Driving License Application";
            ucFilter1.FillSearchboxAndFulterByWithPersonID(_Application.ApplicantPersonID);

            lbLDLApplicationID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            cbxClasses.SelectedValue = _LDLApplication.LicenseClassID;
            _LicenseClassID = _LDLApplication.LicenseClassID;
            _LoadApplicationData();


        }

        private void frmNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            ucFilter1.Focus();
            ucFilter1.FocusOnSearchBox();
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void cbxClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_Mode==enMode.Update&&_LDLApplication.LicenseClassID==(int)cbxClasses.SelectedValue&& guna2TabControl1.SelectedTab == tabPage2)
            {
                btnNextSave.Visible = false;
                return;
            }
            if (_Mode==enMode.AddNew&&_Person==null)
            {
                btnNextSave.Visible = false;
                return;

            }
            btnNextSave.Visible = true;

        }
    }
}
