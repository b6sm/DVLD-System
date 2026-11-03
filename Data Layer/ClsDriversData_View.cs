using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data_Layer
{
    public static class ClsDriversData_View
    {
        public static DataTable GetAllDrivers_View()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"select DV1.DriverID as 'Driver ID',DV1.PersonID as 'Person ID',DV1.NationalNo as 'National No',
                             DV1.FullName as 'Full Name',DV1.CreatedDate as 'Created Date' ,
                             DV1.NumberOfActiveLicenses as 'Number Of Active Licenses' from 
                             Drivers_View as DV1 ";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                dt.Load(reader);


                reader.Close();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

    }
}
