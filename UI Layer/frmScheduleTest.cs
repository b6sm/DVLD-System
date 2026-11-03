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
    public partial class frmScheduleTest : frmBaseForm
    {
        int _TestAppointmentID;
        int _LDLAppViewID;
        int _TestTypeID;
        public frmScheduleTest(int TestTypeID,int LDLAppViewID,int TestAppointmentID=-1)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
            _LDLAppViewID = LDLAppViewID;
            _TestAppointmentID = TestAppointmentID;
        }

        private void btnNextSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to schedule this test appointment?",
                                "Confirm Scheduling", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            if (ucScheduleTests1.SaveData())
            {

                MessageBox.Show("Test appointment scheduled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ucScheduleTests1.FillRetakeTestID();
                btnSave.Visible=ucScheduleTests1.EnableOrDisableSaveButton();
            }
            else
            {
                MessageBox.Show("An error occurred while scheduling a test appointment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {

            if (!ucScheduleTests1.LoadType(_TestTypeID) || !ucScheduleTests1.LoadData(_LDLAppViewID, _TestAppointmentID))
            {
                MessageBox.Show("An error occurred while Loading Scheduling Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            btnSave.Visible = ucScheduleTests1.EnableOrDisableSaveButton();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucScheduleTests1_OnDateChange()
        {
            btnSave.Visible = ucScheduleTests1.EnableOrDisableSaveButton();
        }
    }
}
