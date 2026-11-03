using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
using System.Data;

namespace Busnise_Layer
{
    public class ClsCountriesContent
    {
        static public DataTable GetAllCountries()
        {
            return ClsCountriesData.GetAllCountries();
        }

    }
}
