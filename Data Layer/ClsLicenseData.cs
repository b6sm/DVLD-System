using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data_Layer
{
    public static class ClsLicenseData
    {

        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate,DateTime ExpirationDate,
                                        string Notes, decimal PaidFees,
                                        byte IssueReason, int CreatedByUserID, bool IsActive = true,bool IsDetained=false)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string Personsquery = @"insert into License (ApplicationID,DriverID,LicenseClassID,IssueDate,ExpirationDate,Notes,PaidFees,IsActive,IssueReason,CreatedByUserID,IsDetained) 
                             Values (@ApplicationID,@DriverID,@LicenseClassID,@IssueDate,@ExpirationDate,@Notes,@PaidFees,@IsActive,@IssueReason,@CreatedByUserID,@IsDetained)
                             select Scope_Identity();";

            SqlCommand command = new SqlCommand(Personsquery, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
           
            command.Parameters.AddWithValue("@IssueDate", IssueDate);

            
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsDetained", IsDetained);



            if (!string.IsNullOrWhiteSpace(Notes))
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);

            }
            command.Parameters.AddWithValue("@IsActive", IsActive);


            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            


            try
            {
                connection.Open();

                object resultForLicense = command.ExecuteScalar();

                if (resultForLicense != null && int.TryParse(resultForLicense.ToString(), out int insertedLicenseID))
                {
                    LicenseID = insertedLicenseID;
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

            return LicenseID;
        }

        public static bool GetLicenseInfoByApplicationID(ref int LicenseID,int ApplicationID,ref int DriverID,ref int LicenseClassID,ref DateTime IssueDate,
                                       ref DateTime ExpirationDate,
                                       ref string Notes,ref decimal PaidFees,
                                       ref byte IssueReason,ref int CreatedByUserID,ref bool IsActive,ref bool IsDetained )
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from License where ApplicationID=@ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    LicenseID = (int)reader["LicenseID"];
                    DriverID = (int)reader["DriverID"];


                    LicenseClassID = (int)reader["LicenseClassID"];

                    IssueDate = (DateTime)reader["IssueDate"];



                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    if (reader["Notes"] != System.DBNull.Value)
                        Notes = (string)reader["Notes"];



                    PaidFees = (decimal)reader["PaidFees"];
                    IssueReason = (byte)reader["IssueReason"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    IsActive = (bool)reader["IsActive"];
                    IsDetained = (bool)reader["IsDetained"];


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

        public static bool GetActiveLicenseInfoByLicenseID( int LicenseID,ref int ApplicationID, ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate,
                               ref DateTime ExpirationDate,
                               ref string Notes, ref decimal PaidFees,
                               ref byte IssueReason, ref int CreatedByUserID,ref bool IsDetained,  bool IsActive=true)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from License where LicenseID=@LicenseID and IsActive=@IsActive";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@IsActive", IsActive);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];


                    LicenseClassID = (int)reader["LicenseClassID"];

                    IssueDate = (DateTime)reader["IssueDate"];



                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    if (reader["Notes"] != System.DBNull.Value)
                        Notes = (string)reader["Notes"];



                    PaidFees = (decimal)reader["PaidFees"];
                    IssueReason = (byte)reader["IssueReason"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsDetained = (bool)reader["IsDetained"];




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


        public static bool GetLicenseInfoByLicenseID( int LicenseID,ref int ApplicationID, ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate,
                               ref DateTime ExpirationDate,
                               ref string Notes, ref decimal PaidFees,
                               ref byte IssueReason, ref int CreatedByUserID, ref bool IsActive,ref bool IsDetained)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from License where LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];


                    LicenseClassID = (int)reader["LicenseClassID"];

                    IssueDate = (DateTime)reader["IssueDate"];



                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    if (reader["Notes"] != System.DBNull.Value)
                        Notes = (string)reader["Notes"];



                    PaidFees = (decimal)reader["PaidFees"];
                    IssueReason = (byte)reader["IssueReason"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    IsActive = (bool)reader["IsActive"];
                    IsDetained = (bool)reader["IsDetained"];

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

        public static bool DeActivateLicensebyLicenseID(int LicenseID,bool IsActive=false)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"Update License
                             SET IsActive=@IsActive
                             WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@IsActive", IsActive);

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

        public static bool UpdateIsDetainByLicenseID(int LicenseID, bool IsDetained = true)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"Update License
                             SET IsDetained=@IsDetained
                             WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@IsDetained", IsDetained);

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


        public static DataTable GetAllLicenseByDriverID(int DriverID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"select L1.LicenseID,L1.ApplicationID,LC.ClassName,L1.IssueDate,L1.ExpirationDate,l1.IsActive from
                             License L1 join LicenseClass as LC on LC.LicenseClassID=L1.LicenseClassID where L1.DriverID=@DriverID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);


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

            string query = "select top 1 1 from License where CreatedByUserID=@CreatedByUserID";

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

        public static int GetLicenseIDByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string Personsquery = @"select top 1 LicenseID from License L 
                        JOIN LocalDrivingLicenseApplication LDLA ON L.ApplicationID = LDLA.ApplicationID
                        WHERE LDLA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID ";

            SqlCommand command = new SqlCommand(Personsquery, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            
            try
            {
                connection.Open();

                object resultForLicense = command.ExecuteScalar();

                if (resultForLicense != null && int.TryParse(resultForLicense.ToString(), out int insertedLicenseID))
                {
                    LicenseID = insertedLicenseID;
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

            return LicenseID;
        }

        public static DataTable GetAllLicenseByPersonID(int PersonID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"select L1.LicenseID,L1.ApplicationID,LC.ClassName,L1.IssueDate,L1.ExpirationDate,l1.IsActive from
                             License L1 join LicenseClass as LC on LC.LicenseClassID=L1.LicenseClassID join Drivers D on D.DriverID=L1.DriverID where D.PersonID=@PersonID";

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

    }
}
