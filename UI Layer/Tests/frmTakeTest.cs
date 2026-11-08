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
    public partial class frmTakeTest : frmBaseForm
    {
        int _TestAppointmentID ;
        int _LDLAppViewID;
        int _TestTypeID;
        public frmTakeTest(int TestAppointmentID,int TestTypeID,int LDLAppViewID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            _LDLAppViewID = LDLAppViewID;
            _TestTypeID = TestTypeID;

        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            if(!ucScheduleTestInfo1.LoadType(_TestTypeID) || !ucScheduleTestInfo1.LoadData(_TestAppointmentID, _LDLAppViewID))
            {
                MessageBox.Show("An error occurred while Loading Scheduling Info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }

        ClsTestsContent _Test = new ClsTestsContent();
        private bool _SaveData()
        {
            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.CreatedByUserID = ClsGlobal.CurrentUser.UserID;
            _Test.Note = tbxNote.Text;
            _Test.TestResult = (rbPass.Checked == true) ? true : false;

            if (_Test.Save())
            {
                return true;
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save this test result? Once saved, you cannot edit this result or change the appointment.",
                    "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (_SaveData())
            {
                if (!ClsTestAppointmentsContent.LockedTestAppointment(_TestAppointmentID))
                    return;
                MessageBox.Show("Test result has been saved successfully.",
                                "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ucScheduleTestInfo1.FillTestID(_Test.TestID);
                btnSave.Visible = false;
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Failed to save the test result. Please try again.",
                                 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
