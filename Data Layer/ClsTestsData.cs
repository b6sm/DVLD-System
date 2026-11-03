using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data_Layer
{
    public static class ClsTestsData
    {
        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Note,int CreatedByUserID)
        {
            int TestID = -1;


            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string Personsquery = @"insert into Tests (TestAppointmentID,TestResult,Note,CreatedByUserID) 
                                    Values (@TestAppointmentID,@TestResult,@Note,@CreatedByUserID)
                                    select Scope_Identity();";

            SqlCommand command = new SqlCommand(Personsquery, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            command.Parameters.AddWithValue("@TestResult", TestResult);
            if(!string.IsNullOrWhiteSpace(Note))
            command.Parameters.AddWithValue("@Note", Note);
            else
            {
                command.Parameters.AddWithValue("@Note", System.DBNull.Value);

            }

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            try
            {
                connection.Open();

                object resultForTest = command.ExecuteScalar();

                if (resultForTest != null && int.TryParse(resultForTest.ToString(), out int insertedTest))
                {
                    TestID = insertedTest;
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

            return TestID;
        }

        public static bool IsUserExistWithUserID(int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select top 1 1 from Tests where CreatedByUserID=@CreatedByUserID";

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

        public static bool IsPassTheTest(int TestTypeID, int LocalDrivingLicenseApplicationID, bool TestResult=true)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"select top 1 1 from Tests T join TestAppointment TP on TP.TestAppointmentID=T.TestAppointmentID
                             where TP.TestTypeID=@TestTypeID and TP.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
                             and T.TestResult=@TestResult";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestResult", TestResult);


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

    }
}
