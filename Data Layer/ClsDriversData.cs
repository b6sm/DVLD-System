using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data_Layer
{
    public static class ClsDriversData
    {
        public static int AddNewDriver(int PersonID, DateTime CreatedDate,
           int CreatedByUserID)
        {
            int DriverID = -1;


            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string Personsquery = @"insert into Drivers (PersonID,CreatedDate,CreatedByUserID) 
                                    Values (@PersonID,@CreatedDate,@CreatedByUserID)
                                    select Scope_Identity();";

            SqlCommand command = new SqlCommand(Personsquery, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
           
            try
            {
                connection.Open();

                object resultForDriver = command.ExecuteScalar();

                if (resultForDriver != null && int.TryParse(resultForDriver.ToString(), out int insertedDriver))
                {
                    DriverID = insertedDriver;
                }




            }
            catch (Exception es)
            {

                throw es;

            }
            finally
            {
                connection.Close();
            }

            return DriverID;
        }

        public static bool GetDriverByPersonID(ref int DriverID,int PersonID,ref DateTime CreatedDate,ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from Drivers where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    DriverID = (int)reader["DriverID"];

                    CreatedDate = (DateTime)reader["CreatedDate"];
                    

                    CreatedByUserID = (int)reader["CreatedByUserID"];


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

        public static bool GetDriverByDriverID( int DriverID,ref int PersonID, ref DateTime CreatedDate, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from Drivers where DriverID=@DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];

                    CreatedDate = (DateTime)reader["CreatedDate"];


                    CreatedByUserID = (int)reader["CreatedByUserID"];


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

        public static bool IsUserExistWithUserID(int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select top 1 1 from Drivers where CreatedByUserID=@CreatedByUserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;


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

        public static bool IsPersonExistWithPersonID(int PersonID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select top 1 1 from Drivers where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;


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

        public static int GetDriverIDByPersonID(int PersonID)
        {
            int DriverID = -1;


            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string Personsquery = @"select top 1 DriverID from Drivers where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(Personsquery, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                object resultForDriver = command.ExecuteScalar();

                if (resultForDriver != null && int.TryParse(resultForDriver.ToString(), out int insertedDriver))
                {
                    DriverID = insertedDriver;
                }

            }
            catch (Exception es)
            {

                throw es;

            }
            finally
            {
                connection.Close();
            }

            return DriverID;
        }

        public static int GetPersonIDByDriverID(int DriverID)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string Personsquery = @"select top 1 PersonID from Drivers where DriverID=@DriverID";

            SqlCommand command = new SqlCommand(Personsquery, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                object resultForPersonID = command.ExecuteScalar();

                if (resultForPersonID != null && int.TryParse(resultForPersonID.ToString(), out int insertedPersonID))
                {
                    PersonID = insertedPersonID;
                }

            }
            catch (Exception es)
            {

                throw es;

            }
            finally
            {
                connection.Close();
            }

            return PersonID;
        }

    }
}
