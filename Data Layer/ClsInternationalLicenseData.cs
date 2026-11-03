using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data_Layer
{
    public static class ClsInternationalLicenseData
    {
        public static int AddNewInternationalLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate,
                                 int CreatedByUserID, bool IsActive = true)
        {
            int InternationalLicenseID = -1;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string Personsquery = @"insert into InternationalLicense (ApplicationID,DriverID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive,CreatedByUserID) 
                             Values (@ApplicationID,@DriverID,@IssuedUsingLocalLicenseID,@IssueDate,@ExpirationDate,@IsActive,@CreatedByUserID)
                             select Scope_Identity();";

            SqlCommand command = new SqlCommand(Personsquery, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);

            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);


            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);



            try
            {
                connection.Open();

                object resultForInternationalLicense = command.ExecuteScalar();

                if (resultForInternationalLicense != null && int.TryParse(resultForInternationalLicense.ToString(), out int insertedInternationalLicenseID))
                {
                    InternationalLicenseID = insertedInternationalLicenseID;
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

            return InternationalLicenseID;
        }

        public static bool GetActiveInternationalLicenseInfoByDriverID(ref int InternationalLicenseID,
                               ref int ApplicationID, int DriverID, ref int IssuedUsingLocalLicenseID,
                               ref DateTime IssueDate,ref DateTime ExpirationDate,
                               ref int CreatedByUserID, bool IsActive=true)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from InternationalLicense where DriverID=@DriverID and IsActive=@IsActive";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IsActive", IsActive);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    InternationalLicenseID = (int)reader["InternationalLicenseID"];
                    ApplicationID = (int)reader["ApplicationID"];



                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];

                    IssueDate = (DateTime)reader["IssueDate"];



                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    
                    
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

        public static bool GetInternationalLicenseInfoByDriverID(ref int InternationalLicenseID,
                       ref int ApplicationID, int DriverID, ref int IssuedUsingLocalLicenseID,
                       ref DateTime IssueDate, ref DateTime ExpirationDate,
                       ref int CreatedByUserID,ref bool IsActive )
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from InternationalLicense where DriverID=@DriverID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    InternationalLicenseID = (int)reader["InternationalLicenseID"];
                    ApplicationID = (int)reader["ApplicationID"];



                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];

                    IssueDate = (DateTime)reader["IssueDate"];



                    ExpirationDate = (DateTime)reader["ExpirationDate"];


                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsActive = (bool)reader["IsActive"];


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

        public static DataTable GetAllInternationalLicenseByDriverID(int PersonID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"select IL.InternationalLicenseID as 'Int.License ID',IL.ApplicationID,
                             IL.IssuedUsingLocalLicenseID as 'L.License ID',IL.IssueDate as 'Issue Date',
                             IL.ExpirationDate as 'Expiriation Date',IL.IsActive from
                             InternationalLicense as IL where IL.DriverID=@DriverID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", PersonID);


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

        public static DataTable GetAllInternationalLicense()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"select IL.InternationalLicenseID as 'Int.License ID',IL.ApplicationID as 'Application ID',
                             IL.DriverID as 'Driver ID' ,IL.IssuedUsingLocalLicenseID as 'L.License ID',IL.IssueDate as 'Issue Date',
                             IL.ExpirationDate as 'Expiriation Date',IL.IsActive from
                             InternationalLicense as IL ";

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

        public static bool IsUserExistWithUserID(int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select top 1 1 from InternationalLicense where CreatedByUserID=@CreatedByUserID";

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

        public static DataTable GetAllInternationalLicenseByPersonID(int PersonID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"select IL.InternationalLicenseID as 'Int.License ID',IL.ApplicationID,
                             IL.IssuedUsingLocalLicenseID as 'L.License ID',IL.IssueDate as 'Issue Date',
                             IL.ExpirationDate as 'Expiriation Date',IL.IsActive from
                             InternationalLicense as IL join Drivers D on D.DriverID=IL.DriverID where D.PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);


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

        public static bool IsThereInternationalLicenseForThisDriverID(int DriverID, bool IsActive = true)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select top 1 1 from InternationalLicense where DriverID=@DriverID and IsActive=@IsActive";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IsActive", IsActive);


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

        public static bool GetInternationalLicenseInfoByInternationalLicenseID(int InternationalLicenseID,
               ref int ApplicationID,ref int DriverID, ref int IssuedUsingLocalLicenseID,
               ref DateTime IssueDate, ref DateTime ExpirationDate,
               ref int CreatedByUserID, ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from InternationalLicense where InternationalLicenseID=@InternationalLicenseID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    DriverID = (int)reader["DriverID"];
                    ApplicationID = (int)reader["ApplicationID"];



                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];

                    IssueDate = (DateTime)reader["IssueDate"];



                    ExpirationDate = (DateTime)reader["ExpirationDate"];


                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsActive = (bool)reader["IsActive"];


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
