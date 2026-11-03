using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Data_Layer
{
    public static class clsPeopleData
    {
        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from People";

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

        public static DataTable GetAllPeopleWithCountries()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"SELECT p1.PersonID,p1.NationalNo,p1.FirstName,p1.SecondName,
                             p1.ThirdName,p1.LastName,p1.DateOfBirth,
                             case when p1.Gender=1 Then 'Male' when p1.Gender=2 then'Female' else 'Unknown' end as Gender,
                             p1.Address,c1.CountryName as Nationality,
                             p1.Phone,p1.Email from People as p1 
                             JOIN Countries as c1 on c1.CountryID=p1.CountryID";

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

        public static bool GetPersonInfoByID(int PersonID,ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName,
            ref string LastName, ref DateTime DateOfBirth,ref short Gender,ref string Address, ref int CountryID,ref string CountryName, ref string Phone,
            ref string Email,ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from People as p1 JOIN Countries as c1 on c1.CountryID=p1.CountryID  where p1.PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    NationalNo = (string)reader["NationalNo"];

                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if(reader["ThirdName"]!=System.DBNull.Value)
                    ThirdName = (string)reader["ThirdName"];
                   

                    LastName = (string)reader["LastName"];

                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                    Gender = (short)reader["Gender"];

                    Address = (string)reader["Address"];

                    CountryID = (int)reader["CountryID"];

                    CountryName = (string)reader["CountryName"];


                    if (reader["Email"] != System.DBNull.Value)
                        Email = (string)reader["Email"];

                    Phone = (string)reader["Phone"];

                    if (reader["ImagePath"] != System.DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];


                }
                else
                {
                    isFound = false;
                }

                reader.Close();

            }
            catch (Exception)
            {
                
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetPersonInfoByNationalNo(ref int PersonID,  string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName,
         ref string LastName, ref DateTime DateOfBirth, ref short Gender, ref string Address, ref int CountryID, ref string CountryName, ref string Phone,
         ref string Email, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from People as p1 JOIN Countries as c1 on c1.CountryID=p1.CountryID  where p1.NationalNo=@NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];

                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != System.DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];


                    LastName = (string)reader["LastName"];

                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                    Gender = (short)reader["Gender"];

                    Address = (string)reader["Address"];

                    CountryID = (int)reader["CountryID"];

                    CountryName = (string)reader["CountryName"];


                    if (reader["Email"] != System.DBNull.Value)
                        Email = (string)reader["Email"];

                    Phone = (string)reader["Phone"];

                    if (reader["ImagePath"] != System.DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];


                }
                else
                {
                    isFound = false;
                }

                reader.Close();

            }
            catch (Exception)
            {

                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static int AddNewPerson(string NationalNo,string FirstName,string SecondName,string ThirdName, string LastName,DateTime DateOfBirth,
                                       short Gender,string Address,int CountryID,string Phone, string Email, string ImagePath)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string Personsquery = @"insert into People (NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gender,Address,Phone,Email,CountryID,ImagePath) 
                             Values (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gender,@Address,@Phone,@Email,@CountryID,@ImagePath)
                             select Scope_Identity();";

            SqlCommand command = new SqlCommand(Personsquery, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            if (!string.IsNullOrWhiteSpace(ThirdName) )
            {
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            }
            else
            {
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            }
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);

            if (!string.IsNullOrWhiteSpace(Email))
            {
                command.Parameters.AddWithValue("@Email", Email);
            }
            else
            {
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            }
            command.Parameters.AddWithValue("@Phone", Phone);


            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            if(!string.IsNullOrWhiteSpace(ImagePath))
            command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }    



            try
            {
                connection.Open();

                object resultForPersons = command.ExecuteScalar();

                if (resultForPersons != null && int.TryParse(resultForPersons.ToString(), out int insertedPersonID))
                {
                    PersonID = insertedPersonID;
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

            return PersonID;
        }

        public static bool UpdatePersonInfo(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
                                            DateTime DateOfBirth,
                                            short Gender, string Address, int CountryID, string Phone, string Email, string ImagePath)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"Update People
                             SET NationalNo = @NationalNo,
                                 FirstName = @FirstName,
                                 SecondName = @SecondName,
                                 ThirdName = @ThirdName,
                                 LastName = @LastName,
                                 DateOfBirth = @DateOfBirth,
                                 Gender = @Gender,
                                 Address = @Address,
                                 Phone = @Phone,
                                 Email = @Email,
                                 
                                 CountryID = @CountryID,
                                 ImagePath = @ImagePath
                             WHERE PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (!string.IsNullOrWhiteSpace(ThirdName))
            {
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            }
            else
            {
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            }

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);


            if (!string.IsNullOrWhiteSpace(Email))
            {
                command.Parameters.AddWithValue("@Email", Email);
            }
            else
            {
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            }

            command.Parameters.AddWithValue("@Phone", Phone);


            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            if (!string.IsNullOrWhiteSpace(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }





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

        public static bool GetPersonInfoByFullName(ref int PersonID,string FullName, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName,
            ref string LastName, ref DateTime DateOfBirth, ref short Gender, ref string Address, ref int CountryID, ref string CountryName, ref string Phone,
            ref string Email, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from People as p1 JOIN Countries as c1 on c1.CountryID=p1.CountryID  where CONCAT_WS(' ',P1.FirstName,P1.SecondName,P1.ThirdName,P1.LastName) like @FullName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FullName", "%" + FullName + "%");

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    PersonID = (int)reader["PersonID"];

                    NationalNo = (string)reader["NationalNo"];

                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != System.DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];


                    LastName = (string)reader["LastName"];

                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                    Gender = (short)reader["Gender"];

                    Address = (string)reader["Address"];

                    CountryID = (int)reader["CountryID"];

                    CountryName = (string)reader["CountryName"];


                    if (reader["Email"] != System.DBNull.Value)
                        Email = (string)reader["Email"];

                    Phone = (string)reader["Phone"];

                    if (reader["ImagePath"] != System.DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];


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

        public static bool GetPersonInfoByPhoneNumber(ref int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName,
    ref string LastName, ref DateTime DateOfBirth, ref short Gender, ref string Address, ref int CountryID, ref string CountryName,  string Phone,
    ref string Email, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from People as p1 JOIN Countries as c1 on c1.CountryID=p1.CountryID  where P1.Phone = @Phone";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Phone", Phone);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    PersonID = (int)reader["PersonID"];

                    NationalNo = (string)reader["NationalNo"];

                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != System.DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];


                    LastName = (string)reader["LastName"];

                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                    Gender = (short)reader["Gender"];

                    Address = (string)reader["Address"];

                    CountryID = (int)reader["CountryID"];

                    CountryName = (string)reader["CountryName"];


                    if (reader["Email"] != System.DBNull.Value)
                        Email = (string)reader["Email"];

                    Phone = (string)reader["Phone"];

                    if (reader["ImagePath"] != System.DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];


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

        public static bool GetPersonInfoByEmail(ref int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName,
ref string LastName, ref DateTime DateOfBirth, ref short Gender, ref string Address, ref int CountryID, ref string CountryName,ref string Phone,
 string Email, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from People as p1 JOIN Countries as c1 on c1.CountryID=p1.CountryID  where P1.Email = @Email";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Email", Email);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    PersonID = (int)reader["PersonID"];

                    NationalNo = (string)reader["NationalNo"];

                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != System.DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];


                    LastName = (string)reader["LastName"];

                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                    Gender = (short)reader["Gender"];

                    Address = (string)reader["Address"];

                    CountryID = (int)reader["CountryID"];

                    CountryName = (string)reader["CountryName"];


                    
                    Phone = (string)reader["Phone"];

                    if (reader["ImagePath"] != System.DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];


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

        public static bool IsTherePersonWithThisNationalNo(string NationalNo)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = "select * from People as p1 where p1.NationalNo=@NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

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

        public static bool DeletePersonByPersonID(int PersonID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string query = @"Delete from People
                             WHERE PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);


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

        public static int GetPersonIDByNationalNo(string NationalNo)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(DataConection.ConnectionString);

            string Personsquery = @"select top 1 PersonID from People  where NationalNo=@NationalNo";

            SqlCommand command = new SqlCommand(Personsquery, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();

                object resultForPersonID = command.ExecuteScalar();

                if (resultForPersonID != null && int.TryParse(resultForPersonID.ToString(), out int insertedPersonID))
                {
                    PersonID = insertedPersonID;
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

            return PersonID;
        }

    }
}
