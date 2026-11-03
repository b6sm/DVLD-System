using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data_Layer
{
    public static class ClsUserData
    {
        public static bool GetUserByUserID(int UserID, ref int PersonID, ref string UserName,ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from Users where UserID=@UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];

                    UserName = (string)reader["UserName"];

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

        public static bool ValidateUserByUserIDAndPassword(int UserID, string Password)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from Users where UserID=@UserID and Password=@Password";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Password", Password);


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

        public static bool ValidateUserName(string UserName)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from Users where UserName=@UserName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
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

        public static bool UpdateUserPassword(int UserID, string Password )
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"Update Users
                             SET Password=@Password
                             WHERE UserID=@UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Password", Password);

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

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"select U1.UserID as 'User ID',U1.PersonID as 'Person ID',
                                    CONCAT_WS(' ',P1.FirstName,P1.SecondName,P1.ThirdName,P1.LastName)as 'Full Name',
                                    U1.UserName,U1.IsActive as 'Is Active' 
                                    from Users U1 join People P1 on P1.PersonID=U1.PersonID";

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

        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            int UserID = -1;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string Personsquery = @"insert into Users (PersonID,UserName,Password,IsActive) 
                             Values (@PersonID,@UserName,@Password,@IsActive)
                             select Scope_Identity();";

            SqlCommand command = new SqlCommand(Personsquery, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            
            command.Parameters.AddWithValue("@IsActive", IsActive);
            
            try
            {
                connection.Open();

                object resultForUsers = command.ExecuteScalar();

                if (resultForUsers != null && int.TryParse(resultForUsers.ToString(), out int insertedUserID))
                {
                    UserID = insertedUserID;
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

            return UserID;
        }

        public static bool UpdateUserInfo(int UserID, string UserName, bool IsActive)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"Update Users
                             SET UserName = @UserName,
                                 IsActive = @IsActive
                             WHERE UserID=@UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            
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

        public static bool DeleteUserByUserID(int UserID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"Delete from Users
                             WHERE UserID=@UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);


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

        public static bool IsPersonExistWithPersonID(int PersonID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select top 1 1 from Users where PersonID=@PersonID";

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

        public static string GetUserNameByUserID(int UserID)
        {
            string UserName = "";

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string Personsquery = @"select top 1 UserName from Users  where UserID=@UserID";

            SqlCommand command = new SqlCommand(Personsquery, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                object resultForUserName = command.ExecuteScalar();

                if (resultForUserName != null )
                {
                    UserName = resultForUserName.ToString();
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

            return UserName;
        }

        public static bool GetUserDataByUsernameAndPassword(string UserName,string Password, ref int UserID, ref int PersonID,  ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from Users where UserName=@UserName and Password=@Password";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    UserID = (int)reader["UserID"];

                    PersonID = (int)reader["PersonID"];

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
