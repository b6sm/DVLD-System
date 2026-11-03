using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data_Layer
{
    static public class ClsLocalDrivingLicenseApplications_ViewData
    {
        public static DataTable GetAllLocalDrivingLicenseApplications_View()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from LocalDrivingLicenseApplications_View";

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

        public static bool GetLocalDrivingLicenseApplications_ViewByNationalNo(ref int LocalDrivingLicenseApplicationID,
                                             ref string ClassName, string NationalNo, ref string FullName, ref DateTime ApplicationDate,
                                             ref int PassTestCount, ref string Status)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from LocalDrivingLicenseApplications_View where NationalNo=@NationalNo and Status != 'Cancelled'";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];

                    ClassName = (string)reader["ClassName"];
                    FullName = (string)reader["FullName"];


                    ApplicationDate = (DateTime)reader["ApplicationDate"];

                    PassTestCount = (int)reader["PassTestCount"];

                    Status = (string)reader["Status"];

                    

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

        public static bool GetLocalDrivingLicenseApplications_ViewByLocalDrivingLicenseApp( int LocalDrivingLicenseApplicationID,
                                     ref string ClassName,ref string NationalNo, ref string FullName, ref DateTime ApplicationDate,
                                     ref int PassTestCount, ref string Status)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from LocalDrivingLicenseApplications_View where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    NationalNo = (string)reader["NationalNo"];

                    ClassName = (string)reader["ClassName"];
                    FullName = (string)reader["FullName"];


                    ApplicationDate = (DateTime)reader["ApplicationDate"];

                    PassTestCount = (int)reader["PassTestCount"];

                    Status = (string)reader["Status"];



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
