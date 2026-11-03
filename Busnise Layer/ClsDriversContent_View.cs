using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data_Layer;

namespace Busnise_Layer
{
    public class ClsDriversContent_View
    {
        public static DataTable GetAllDrivers_View()
        {
            return ClsDriversData_View.GetAllDrivers_View();
        }
    }
}
