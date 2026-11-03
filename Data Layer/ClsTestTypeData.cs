using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data_Layer
{
    public static class ClsTestTypeData
    {
        public static bool GetTestTypeByTestTypeID(int TestTypeID, ref string TestTypeTitle,ref string TestTypeDescraption, ref decimal TestTypeFees)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from TestType where TestTypeID=@TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TestTypeTitle = (string)reader["TestTypeTitle"];

                    TestTypeDescraption = (string)reader["TestTypeDescraption"];


                    TestTypeFees = (decimal)reader["TestTypeFees"];


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

        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"select TT.TestTypeID as 'ID',TT.TestTypeTitle as 'Title',TT.TestTypeDescraption as 'Descraption',
                             TT.TestTypeFees as 'Fees' from
                             TestType TT";

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

        public static bool UpdateTestTypeData(int TestTypeID, string TestTypeDescraption, decimal TestTypeFees)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"Update TestType
                             SET TestTypeFees=@TestTypeFees,TestTypeDescraption=@TestTypeDescraption
                             WHERE TestTypeID=@TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
            command.Parameters.AddWithValue("@TestTypeDescraption", TestTypeDescraption);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();



            }
            catch (Exception)
            {
                throw;
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
