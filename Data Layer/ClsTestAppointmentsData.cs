using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data_Layer
{
    public static class ClsTestAppointmentsData
    {
        public static DataTable GetAllAppointmentsByTestTypeIDAndLocoalDrivingLicenseApplicationID(int TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"SELECT TestAppointmentID,AppointmentDate,PaidFees,IsLocked from TestAppointment 
                             where TestTypeID=@TestTypeID and LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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

        public static bool IsThereAnyScheduleTestUnLocked(int TestTypeID, int LocalDrivingLicenseApplicationID,bool IsLocked=false)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"SELECT top 1 1 from TestAppointment where TestTypeID=@TestTypeID 
                             and LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and IsLocked=@IsLocked";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);



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
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID,DateTime AppointmentDate,decimal PaidFees,
                   int CreatedByUserID,int RetakeTestApplicationID, bool IsLocked = false)
        {
            int TestAppointmentID = -1;


            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string Personsquery = @"insert into TestAppointment (TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,IsLocked,CreatedByUserID,RetakeTestApplicationID) 
                                    Values (@TestTypeID,@LocalDrivingLicenseApplicationID,@AppointmentDate,@PaidFees,@IsLocked,@CreatedByUserID,@RetakeTestApplicationID)
                                    select Scope_Identity();";

            SqlCommand command = new SqlCommand(Personsquery, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            if (RetakeTestApplicationID != -1)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);

            }

            try
            {
                connection.Open();

                object resultForTestAppointment = command.ExecuteScalar();

                if (resultForTestAppointment != null && int.TryParse(resultForTestAppointment.ToString(), out int insertedTestAppointment))
                {
                    TestAppointmentID = insertedTestAppointment;
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

            return TestAppointmentID;
        }

        public static bool LockedTestAppointment(int TestAppointmentID, bool IsLocked=true)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"Update TestAppointment
                             SET IsLocked=@IsLocked
                             WHERE TestAppointmentID=@TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

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

        public static bool UpdateTestAppointmentScheduleDate(int TestAppointmentID, DateTime AppointmentDate)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"Update TestAppointment
                             SET AppointmentDate=@AppointmentDate
                             WHERE TestAppointmentID=@TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);

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

        public static bool GetTestAppointmentByTestAppointmentID(int TestAppointmentID,ref int TestTypeID,ref int LocalDrivingLicenseApplicationID,
                   ref DateTime AppointmentDate,ref decimal PaidFees,
                    ref int CreatedByUserID,ref bool IsLocked ,ref int RetakeTestApplicationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from TestAppointment where TestAppointmentID=@TestAppointmentID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    TestTypeID = (int)reader["TestTypeID"];

                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];

                    AppointmentDate = (DateTime)reader["AppointmentDate"];

                    PaidFees = (decimal)reader["PaidFees"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                    if (reader["RetakeTestApplicationID"] != System.DBNull.Value)
                        RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
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

            string query = "select top 1 1 from TestAppointment where CreatedByUserID=@CreatedByUserID";

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

        public static bool IsLocalDrivingLicenseApplicationExistWithLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select top 1 1 from TestAppointment where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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

        public static int CountTestTrails(int TestTypeID, int LocalDrivingLicenseApplicationID, bool IsLocked = true)
        {
            int Trials = 0;


            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string Personsquery = @"select count(1) from TestAppointment where TestTypeID=@TestTypeID and 
                                    LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and
                                    IsLocked=@IsLocked";

            SqlCommand command = new SqlCommand(Personsquery, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);


            try
            {
                connection.Open();

                object resultForTrials = command.ExecuteScalar();

                if (resultForTrials != null && int.TryParse(resultForTrials.ToString(), out int insertedTrials))
                {
                    Trials = insertedTrials;
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

            return Trials;
        }

        public static DateTime GetAppointmentDate(int TestAppointmentID)
        {
            DateTime AppointmentDate = DateTime.Now;


            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string Personsquery = @"select AppointmentDate from TestAppointment where TestAppointmentID=@TestAppointmentID";

            SqlCommand command = new SqlCommand(Personsquery, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);


            try
            {
                connection.Open();

                object resultForAppointmentDate = command.ExecuteScalar();

                if (resultForAppointmentDate != null && DateTime.TryParse(resultForAppointmentDate.ToString(), out DateTime insertedAppointmentDate))
                {
                    AppointmentDate = insertedAppointmentDate;
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

            return AppointmentDate;
        }

    }
}
