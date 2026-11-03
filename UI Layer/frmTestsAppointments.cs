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
    public partial class frmTestsAppointments : frmBaseForm
    {
       

        int _TestTypeID;
        int _LDLAppID;

        public frmTestsAppointments(int TestTypeID ,int LDLAppID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
            _LDLAppID = LDLAppID;          
        }

        public void _RefreshTestAppointments()
        {
            dtTestAppointments.DataSource = ClsTestAppointmentsContent.GetAllAppointmentsByTestTypeID(_TestTypeID, _LDLAppID);
            _RefreshTestAppointmentsCount();
        }

        private void _RefreshTestAppointmentsCount()
        {
            lbRecords.Text = dtTestAppointments.RowCount.ToString();
        }

        private bool _LoadTestType()
        {
            switch ((ClsGlobal.enTestType)_TestTypeID)
            {
                case ClsGlobal.enTestType.VisionTest:
                    lbTestAppointments.Text = "Vision Test Appointments";
                    pbTestAppointments.Image = Properties.Resources.eye__1_;
                    break;
                case ClsGlobal.enTestType.WrittenTest:
                    lbTestAppointments.Text = "Written Test Appointments";
                    pbTestAppointments.Image = Properties.Resources.copy_writing__1_;
                    break;
                case ClsGlobal.enTestType.StreetTest:
                    lbTestAppointments.Text = "Street Test Appointments";
                    pbTestAppointments.Image = Properties.Resources.test__1_;
                    break;
                default:
                    return false;
            }

            return true;

        }
        int _ApplicationID;
        private void frmTestsAppointments_Load(object sender, EventArgs e)
        {

            contextMenuStrip1.Renderer =new ToolStripProfessionalRenderer(new DarkColorForContextMenueTrip());
            _ApplicationID = ClsLocalDrivingLicenseApplicationsContent.GetApplicationIDByLocalDrivingApplicationID(_LDLAppID);

            if (!_LoadTestType()||_ApplicationID == -1 || !ucApplicationIBasicnfo1.LoadData(_ApplicationID) || !ucDrivingLicenseApplicationInfo1.LoadData(_LDLAppID))
            {
                MessageBox.Show("An error occurred while loading data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            _RefreshTestAppointments();

        }

        private bool _IsThereAnyScheduleTestUnLocked(ref string Message)
        {
            Message = "You cannot schedule this test because you already have an active appointment.";
            return ClsTestAppointmentsContent.IsThereAnyScheduleTestUncomplited(_TestTypeID, _LDLAppID);
        }
        
        private bool _IsPassTheTest(ref string Message)
        {
            Message = "This applicant has already passed this test. You cannot schedule another appointment for the same test.";
            return ClsTestsContent.IsPassTheTest(_TestTypeID, _LDLAppID);
        }

        private void btnScheduleTest_Click(object sender, EventArgs e)
        {
            string Message="";
            if(_IsThereAnyScheduleTestUnLocked(ref Message) || _IsPassTheTest(ref Message))
            {
                MessageBox.Show(Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Form frm = new frmScheduleTest(_TestTypeID, _LDLAppID);
            frm.ShowDialog();
            _RefreshTestAppointments();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dtTestAppointments.CurrentRow == null || dtTestAppointments.CurrentRow.Cells[0].Value == DBNull.Value)
            {
                e.Cancel = true;
                return;
            }
            bool IsLocked = Convert.ToBoolean(dtTestAppointments.CurrentRow.Cells["IsLocked"].Value);
            switch (IsLocked)
            {
                case true :
                    tsTakeTest.Enabled = false;
                    break;
                default:
                    tsTakeTest.Enabled = true;
                    tsEditAppointments.Enabled = true;
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtTestAppointments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtTestAppointments.Columns[e.ColumnIndex].Name == "PaidFees" && e.Value != null)
            {
                e.Value = $"{((decimal)e.Value).ToString("0")}";
                e.FormattingApplied = true;
            }
        }

        private bool _ValidateTestAppointmentDate(int TestAppointmentID)
        {
            bool IsLocked = Convert.ToBoolean(dtTestAppointments.CurrentRow.Cells["IsLocked"].Value);
            if (IsLocked)
                return true;

            DateTime AppointmentDate = ClsTestAppointmentsContent.GetAppointmentDate(TestAppointmentID);
            if(AppointmentDate<DateTime.Now)
            {
                return false;
            }
            return true;
        }

        private void _LockedTestAppointment(int TestAppointmentID)
        {
            ClsTestAppointmentsContent.LockedTestAppointment(TestAppointmentID);
        }

        private void tsEditAppointments_Click(object sender, EventArgs e)
        {
            if (dtTestAppointments.CurrentRow == null ||
                dtTestAppointments.CurrentRow.Cells["TestAppointmentID"].Value == DBNull.Value)
            {
                return;
            }
            int TestAppointmentID = Convert.ToInt32(dtTestAppointments.CurrentRow.Cells["TestAppointmentID"].Value);

            if(!_ValidateTestAppointmentDate(TestAppointmentID))
            {
                MessageBox.Show("This test appointment has expired and will be locked. You must schedule a new appointment.",
                "Appointment Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _LockedTestAppointment(TestAppointmentID);
                _RefreshTestAppointments();
                return;
            }

            Form frm = new frmScheduleTest(_TestTypeID, _LDLAppID,TestAppointmentID);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            _RefreshTestAppointments();
        }

        private void tsTakeTest_Click(object sender, EventArgs e)
        {
            if (dtTestAppointments.CurrentRow == null ||
                dtTestAppointments.CurrentRow.Cells["TestAppointmentID"].Value == DBNull.Value)
            {
                return;
            }
            int TestAppointmentID = Convert.ToInt32(dtTestAppointments.CurrentRow.Cells["TestAppointmentID"].Value);

            if (!_ValidateTestAppointmentDate(TestAppointmentID))
            {
                MessageBox.Show("This test appointment has expired and will be locked. You must schedule a new appointment.",
                "Appointment Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _LockedTestAppointment(TestAppointmentID);
                _RefreshTestAppointments();
                return;
            }
            Form frm = new frmTakeTest(TestAppointmentID,_TestTypeID,_LDLAppID);
            frm.ShowInTaskbar = false;
            frm.ShowDialog();
            _RefreshTestAppointments();
        }
    }
}
