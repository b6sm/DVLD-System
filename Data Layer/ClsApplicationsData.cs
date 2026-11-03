using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data_Layer
{
    public static class ClsApplicationsData
    {
        public static int AddNewApplication(int ApplicantPersonID,DateTime ApplicationDate,int ApplicationTypeID,
                                            byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees,int CreatedByUserID)
        {
            int ApplicationID = -1;
            
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string Personsquery = @"insert into Applications (ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,
                                                              LastStatusDate,PaidFees,CreatedByUserID) 
                                    Values (@ApplicantPersonID,@ApplicationDate,@ApplicationTypeID,@ApplicationStatus,
                                            @LastStatusDate,@PaidFees,@CreatedByUserID)
                                    select Scope_Identity();";

            SqlCommand command = new SqlCommand(Personsquery, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);

            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
           
           
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
           
           
           
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);

           
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            
            try
            {
                connection.Open();

                object resultForApplications = command.ExecuteScalar();

                if (resultForApplications != null && int.TryParse(resultForApplications.ToString(), out int insertedApplicationID))
                {
                    ApplicationID = insertedApplicationID;
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

            return ApplicationID;
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            int rowsAffected = 0;


            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"delete from Applications 
                                where ApplicationID=@ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception es)
            {
                throw es;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool GetApplicationByApplicationID(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate,ref int ApplicationTypeID,
            ref byte ApplicationStatus, ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from Applications where ApplicationID=@ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicantPersonID = (int)reader["ApplicantPersonID"];

                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];

                    ApplicationStatus = (byte)reader["ApplicationStatus"];


                    LastStatusDate = (DateTime)reader["LastStatusDate"];

                    PaidFees = (decimal)reader["PaidFees"];

                   

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

        public static bool GetApplicationByApplicationDate(ref int ApplicationID, ref int ApplicantPersonID,  DateTime ApplicationDate, ref int ApplicationTypeID,
            ref byte ApplicationStatus, ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from Applications where ApplicationDate=@ApplicationDate";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    ApplicantPersonID = (int)reader["ApplicantPersonID"];


                    ApplicationTypeID = (int)reader["ApplicationTypeID"];

                    ApplicationStatus = (byte)reader["ApplicationStatus"];



                    LastStatusDate = (DateTime)reader["LastStatusDate"];

                    PaidFees = (decimal)reader["PaidFees"];



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

        public static bool UpdateApplicationStatus(int ApplicationID,byte ApplicationStatus)
        {
            int rowsAffected = 0;
            DateTime LastStatusDate = DateTime.Now;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"Update Applications
                             SET ApplicationStatus=@ApplicationStatus,
                                 LastStatusDate=@LastStatusDate
                             WHERE ApplicationID=@ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);

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

        public static bool IsUserExistWithUserID( int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select top 1 1 from Applications where CreatedByUserID=@CreatedByUserID";

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

        public static bool IsPersonExistWithPersonID(int ApplicantPersonID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select top 1 1 from Applications where ApplicantPersonID=@ApplicantPersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);

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
