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
    public partial class UCFilter : UserControl
    {
        public UCFilter()
        {
            InitializeComponent();
        }

        int _PersonID=-1;

        private void frmAddEditPersonInfo_DataBack(object sender,int PersonID)
        {
            cbFilterBy.SelectedIndex = 0;
            tbxSearch.Text = PersonID.ToString();
            _PersonID = PersonID;
            _FindPerson();
        }

        public event Action<ClsPeopleContent> OnSearchButton;

        public virtual void SearchSelected(ClsPeopleContent Person)
        {
            Action<ClsPeopleContent> Handler = OnSearchButton;
            if (Handler != null)
            {
                Handler(Person);
            }
        }

        ClsPeopleContent _Person ;

        public void FillSearchboxAndFulterByWithNationalNo(string NationalNo)
        {
            cbFilterBy.SelectedIndex = 1;
            tbxSearch.Text = NationalNo;
            _FindPerson();
            this.Enabled = false;
        }

        public void FillSearchboxAndFulterByWithPersonID(int PersonID)
        {
            cbFilterBy.SelectedIndex = 0;
            tbxSearch.Text = PersonID.ToString();
            _FindPerson();
            guna2GroupBox1.Enabled = false;
        }

        private void tbxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _FindPerson();
            }
        }

        private void _FindPerson()
        {
            _Person = null;
            string FilterBy = cbFilterBy.Text;
            string SearchValue = tbxSearch.Text.Trim();
            if (string.IsNullOrEmpty(SearchValue) || cbFilterBy.SelectedItem == null)
            {
                OnSearchButton(_Person);
                tbxSearch.Focus();
                return;
            }

            switch (FilterBy)
            {
                case "Person ID":
                    if (int.TryParse(SearchValue, out int numricValue))
                    { _Person = ClsPeopleContent.FindPersonByFilterBy(ClsGlobal.enPeopleFilter.PersonID, SearchValue); }
                    break;
                case "Full Name":
                    _Person = ClsPeopleContent.FindPersonByFilterBy(ClsGlobal.enPeopleFilter.FullName, SearchValue);
                    break;
                case "National No":
                    _Person = ClsPeopleContent.FindPersonByFilterBy(ClsGlobal.enPeopleFilter.NationalNo, SearchValue);
                    break;
                case "Phone":
                    _Person = ClsPeopleContent.FindPersonByFilterBy(ClsGlobal.enPeopleFilter.Phone, SearchValue);
                    break;
                case "Email":
                    _Person = ClsPeopleContent.FindPersonByFilterBy(ClsGlobal.enPeopleFilter.Email, SearchValue);
                    break;
                default:
                    break;
            }

            OnSearchButton(_Person);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _FindPerson();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo();
            frm.DataBack += frmAddEditPersonInfo_DataBack;
            frm.ShowDialog();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxSearch.Clear();
            tbxSearch.Focus();
        }
        
        public void FocusOnSearchBox()
        {
            tbxSearch.Select();
        }
    }
}
