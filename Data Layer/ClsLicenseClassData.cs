using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data_Layer
{
    public static class ClsLicenseClassData
    {
        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from LicenseClass";

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

        public static bool GetLicenseClassInfoByLicenseClassID(int LicenseClassID, ref string ClassName, ref string ClassDescription,
          ref sbyte MinimumAllowedAge, ref sbyte DefaultValidityLength,ref decimal ClassFees)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from LicenseClass where LicenseClassID=@LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ClassName = (string)reader["ClassName"];

                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = Convert.ToSByte(reader["MinimumAllowedAge"]);


                    DefaultValidityLength = Convert.ToSByte(reader["DefaultValidityLength"]);

                    ClassFees = Convert.ToDecimal(reader["ClassFees"]);


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

        public static bool GetLicenseClassInfoByLocalDrivingLicenseAppID(int LocalDrivingLicenseApplicationID, ref int LicenseClassID, ref string ClassName, ref string ClassDescription,
                         ref sbyte MinimumAllowedAge, ref sbyte DefaultValidityLength, ref decimal ClassFees)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"select * from LicenseClass LC join LocalDrivingLicenseApplication LDLA on 
                             LDLA.LicenseClassID=LC.LicenseClassID 
                             where LDLA.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    LicenseClassID = (int)reader["LicenseClassID"];
                    ClassName = (string)reader["ClassName"];

                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = Convert.ToSByte(reader["MinimumAllowedAge"]);


                    DefaultValidityLength = Convert.ToSByte(reader["DefaultValidityLength"]);

                    ClassFees = Convert.ToDecimal(reader["ClassFees"]);


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
