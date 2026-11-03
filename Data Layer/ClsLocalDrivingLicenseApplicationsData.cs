using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data_Layer
{
    public static class ClsLocalDrivingLicenseApplicationsData
    {
        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID,  int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationID = -1;
            

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string Personsquery = @"insert into LocalDrivingLicenseApplication (ApplicationID,LicenseClassID) 
                                    Values (@ApplicationID,@LicenseClassID)
                                    select Scope_Identity();";

            SqlCommand command = new SqlCommand(Personsquery, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
           
            try
            {
                connection.Open();

                object resultForLocalDrivingApplications = command.ExecuteScalar();

                if (resultForLocalDrivingApplications != null && int.TryParse(resultForLocalDrivingApplications.ToString(), out int insertedLocalDrivingLiceseApplicationID))
                {
                    LocalDrivingLicenseApplicationID = insertedLocalDrivingLiceseApplicationID;
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

            return LocalDrivingLicenseApplicationID;
        }

        public static bool GetLocalDrivingLicenseApplicationByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from LocalDrivingLicenseApplication where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationID = (int)reader["ApplicationID"];

                    LicenseClassID = (int)reader["LicenseClassID"];


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

        public static bool IsPersonHasLocalLicenseApplicationForLicenseClass(int ApplicantPersonID, int LicenseClassID,byte ApplicationStatus)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"select top 1 1 from LocalDrivingLicenseApplication LDLA join
                             Applications Ap1 on Ap1.ApplicationID=LDLA.ApplicationID
                             where Ap1.ApplicantPersonID=@ApplicantPersonID and Ap1.ApplicationStatus != @ApplicationStatus and LDLA.LicenseClassID=@LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);



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

        public static bool UpdateLocalDrivingLicenseLicenseClass(int LocalDrivingLicenseApplicationID, int LicenseClassID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"Update LocalDrivingLicenseApplication
                             SET LicenseClassID = @LicenseClassID
                             WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


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

        public static bool DeleteLocalDrivingLicenseApplicationrByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"Delete from LocalDrivingLicenseApplication
                             WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


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

        public static int GetApplicationIDByLocalDrivingLicenseID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string Personsquery = @"select top 1 ApplicationID from LocalDrivingLicenseApplication LDLA where LDLA.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(Personsquery, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                object resultForApplicationID = command.ExecuteScalar();

                if (resultForApplicationID != null && int.TryParse(resultForApplicationID.ToString(), out int insertedApplicationID))
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


    }
}
