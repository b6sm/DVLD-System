using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data_Layer;

namespace Busnise_Layer
{
    public class ClsDetainLicensesContent_View
    {
        public static DataTable GetAllDetainLicense_View()
        {
            return ClsDetainLicensesData_View.GetAllDetainLicense_View();
        }

        public static DataTable GetAllDetainLicense_ViewByIsRelease(bool IsRelease)
        {
            return ClsDetainLicensesData_View.GetAllDetainLicense_ViewByIsRelease(IsRelease);
        }
    }
}
