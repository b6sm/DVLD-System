using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data_Layer;

namespace Busnise_Layer
{
    public class ClsApplicationTypesContent
    {
        public int TypeID { set; get; }
        public string TypeTitle { set; get; }
        public decimal TypeFees { set; get; }

        public ClsApplicationTypesContent()
        {
            this.TypeID = -1;
            this.TypeTitle = "";            
            this.TypeFees = -1;

        }

        public ClsApplicationTypesContent(int TypeID, string TypeTitle, decimal TypeFees)
        {
            this.TypeID = TypeID;
            this.TypeTitle = TypeTitle;
            this.TypeFees = TypeFees;
        }

        public static ClsApplicationTypesContent FindApplicationTypeByApplicationTypeID(int TypeID)
        {
            string TypeTitle = "";
            decimal TypeFees = -1;



            if (ClsApplicationTypesData.GetApplicationTypeByTypeID(TypeID, ref TypeTitle, ref TypeFees))
            {
                return new ClsApplicationTypesContent(TypeID, TypeTitle, TypeFees);
            }
            else
            {
                return null;
            }

        }

        public static DataTable GetAllApplicationTypes()
        {
            return ClsApplicationTypesData.GetAllApplicationTypes();
        }

        public static bool UpdateApplicationTypeFees(int TypeID,decimal TypeFees)
        {
            return ClsApplicationTypesData.UpdateApplicationTypesFees(TypeID,TypeFees);
        }


    }
}
