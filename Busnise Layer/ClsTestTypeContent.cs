using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data_Layer;

namespace Busnise_Layer
{
    public class ClsTestTypeContent
    {
        public int TestTypeID { set; get; }
        public string TestTypeTitle { set; get; }
        public string TestTypeDescraption { set; get; }
        public decimal TestTypeFees { set; get; }

        public ClsTestTypeContent()
        {
            this.TestTypeID = -1;
            this.TestTypeTitle = "";
            this.TestTypeDescraption = "";
            this.TestTypeFees = -1;

        }

        public ClsTestTypeContent(int TestTypeID, string TestTypeTitle,string TestTypeDescraption, decimal TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescraption = TestTypeDescraption;
            this.TestTypeFees = TestTypeFees;
        }

        public static ClsTestTypeContent FindTestTypeByTestTypeID(int TestTypeID)
        {
            string TestTypeTitle = "", TestTypeDescraption="";
            decimal TestTypeFees = -1;



            if (ClsTestTypeData.GetTestTypeByTestTypeID(TestTypeID, ref TestTypeTitle, ref TestTypeDescraption, ref TestTypeFees))
            {
                return new ClsTestTypeContent(TestTypeID, TestTypeTitle,TestTypeDescraption, TestTypeFees);
            }
            else
            {
                return null;
            }

        }

        public static DataTable GetAllTestTypes()
        {
            return ClsTestTypeData.GetAllTestTypes();
        }

        public bool UpdateTestTypeData()
        {
            return ClsTestTypeData.UpdateTestTypeData(this.TestTypeID, this.TestTypeDescraption,this.TestTypeFees);
        }


    }
}
