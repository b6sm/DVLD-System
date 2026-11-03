using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data_Layer
{
    public static class ClsApplicationTypesData
    {
        public static bool GetApplicationTypeByTypeID(int TypeID, ref string TypeTitle, ref decimal TypeFees)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from ApplicationTypes where TypeID=@TypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TypeID", TypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TypeTitle = (string)reader["TypeTitle"];

                    TypeFees = (decimal)reader["TypeFees"];
                    

                }
                else
                {
                    isFound = false;
                }

                reader.Close();

            }
            catch (Exception)
            {
                throw;
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"select AT.TypeID as 'ID',AT.TypeTitle as 'Title',AT.TypeFees as 'Fees' from
                             ApplicationTypes AT";

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

        public static bool UpdateApplicationTypesFees(int TypeID, decimal TypeFees )
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"Update ApplicationTypes
                             SET TypeFees=@TypeFees
                             WHERE TypeID=@TypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TypeID", TypeID);
            command.Parameters.AddWithValue("@TypeFees", TypeFees);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();



            }
            catch (Exception)
            {

                return false;

            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

    }
}
