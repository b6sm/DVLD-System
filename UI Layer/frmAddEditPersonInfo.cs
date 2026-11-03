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
    public partial class frmAddEditPersonInfo : frmBaseForm
    {
        public enum enMode
        {
            AddNew = 0, UpdateMode = 1
        }
        private enMode _Mode;

        ClsPeopleContent _Person;
        int _PersonID;

        public delegate void DataBackEventHandler(Object sender, int PersonID);

        public event DataBackEventHandler DataBack;

        public frmAddEditPersonInfo(int PersonID=-1)
        {
            

            InitializeComponent();
            ucEditPersonInfo1.SuspendLayout();
            _PersonID = PersonID;

            if (_PersonID == -1)
            {
                _Mode = enMode.AddNew;
                btnSave.Visible = false;
            }
            else
            {
                _Mode = enMode.UpdateMode;
                btnSave.Visible = true;
                
            }
            ucEditPersonInfo1.ResumeLayout();

        }

        private void _LoadData()
        {
            if (_Mode == enMode.AddNew)
            {
                lbAddOrEditPerson.Text = "Add New Person";
                ucEditPersonInfo1.FillCountriesInComboBox();
                btnSave.Visible = false;
                _Person = new ClsPeopleContent();
                return;
            }

            _Person = ClsPeopleContent.FindPerson(_PersonID);
            lbAddOrEditPerson.Text = "Edit Person Info";

            if (_Person == null)
            {
                MessageBox.Show("This form will be closed because no Person with ID = " + _PersonID);
                this.Close();

                return;
            }

            ucEditPersonInfo1.LoadData(_Person);


        }

        private void frmAddEditPersonInfo_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void ucEditPersonInfo1_OnTextChange()
        {
            btnSave.Visible = true;
        }

        private void btnNextSave_Click(object sender, EventArgs e)
        {
            if(!ucEditPersonInfo1.CheckDataValidate())
            {
                return;
            }
            guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
            guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            if(guna2MessageDialog1.Show("Are You Sure You Want To Save This Data?","Save Data")==DialogResult.No)
            {
                return;
            }

            if (ucEditPersonInfo1.SaveData())
            {
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;

                guna2MessageDialog1.Caption = "Success";
                guna2MessageDialog1.Text = "Data Save Successfuly";
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                guna2MessageDialog1.Show();
                lbAddOrEditPerson.Text = "Edit Person Info";
                btnSave.Visible = false;
                DataBack?.Invoke(this, ucEditPersonInfo1.ReturnPersonID());

            }
            else
            {
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Caption = "Error";
                guna2MessageDialog1.Text = "Faild To Save Data!!";
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                guna2MessageDialog1.Show();

            }
        }

        private int ReturnPersonID()
        {
            return ucEditPersonInfo1.ReturnPersonID();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
