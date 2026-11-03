using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Data_Layer
{
    public static class ClsDetainLicenseData
    {

        public static int AddNewDetainLicense(int LicenseID,DateTime DetainDate,decimal FineFees,int CreatedByUserID,bool IsRelease=false)
        {
            int DetainID = -1;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string qurey = @"Insert into DetainedLicense (LicenseID,DetainDate,FineFees,CreatedByUserID,IsRelease)
                            values (@LicenseID,@DetainDate,@FineFees,@CreatedByUserID,@IsRelease)
                            select Scope_Identity();";

            SqlCommand command = new SqlCommand(qurey, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);

            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsRelease", IsRelease);


            try
            {
                connection.Open();

                object ResultForDetained = command.ExecuteScalar();
                
                if(ResultForDetained!=null && int.TryParse(ResultForDetained.ToString(),out int InsertedDetainedID))
                {
                    DetainID = InsertedDetainedID;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }

            return DetainID;

        }

        public static bool ReleaseDetainedLicense(int DetainID, bool IsRelease, DateTime ReleaseDate, int ReleaseByUserID, int ReleaseApplicationID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"Update DetainedLicense
                             SET IsRelease = @IsRelease,
                                 ReleaseDate = @ReleaseDate,
                                 ReleaseByUserID = @ReleaseByUserID,
                                 ReleaseApplicationID = @ReleaseApplicationID
                             WHERE DetainID=@DetainID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@IsRelease", IsRelease);

            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            command.Parameters.AddWithValue("@ReleaseByUserID", ReleaseByUserID);

            
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

            

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

        public static bool GetDetainedLicenseByLicenseID(ref int DetainID,int LicenseID,ref DateTime DetainDate,ref decimal FineFees,
                                                         ref int CreatedByUserID, bool IsRelease = false)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from DetainedLicense where LicenseID=@LicenseID and IsRelease=@IsRelease";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@IsRelease", IsRelease);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    DetainID = (int)reader["DetainID"];

                    DetainDate = (DateTime)reader["DetainDate"];

                    FineFees = (decimal)reader["FineFees"];

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

            string query = "select top 1 1 from DetainedLicense where CreatedByUserID=@CreatedByUserID";

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



    }
}
