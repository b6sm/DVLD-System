using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data_Layer;


namespace Busnise_Layer
{
    public class ClsPeopleContent
    {
        public enum enMode
        {
            AddNew = 0, Update = 1
        }
        private enMode _Mode = enMode.AddNew;

        public int PersonID { set; get; }
        public string NationalNo { set; get; }

        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }

        public string Email { set; get; }
        public string Phone { set; get; }

        public DateTime DateOfBirth { set; get; }

        public int CountryID { set; get; }
        public string CountryName { set; get; }


        public string Address { set; get; }
        public short Gender { set; get; }

        public string ImagePath { set; get; }



        public ClsPeopleContent()
        {
            this.NationalNo = "";

            this.Gender = -1;
            this.CountryID = -1;
            this.CountryName = "";

            this.DateOfBirth = DateTime.Now;
            this.Email = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";

            this.LastName = "";
            this.Phone = "";
            this.Address = "";

            this.PersonID = -1;

            this.ImagePath = ImagePath;

            _Mode = enMode.AddNew;
        }

        public ClsPeopleContent(int PersonID, string NationalNo, string FirstName,string SecondName,string ThirdName, string LastName,
                                DateTime DateOfBirth,short Gender,string Address, int CountryID,string CountryName, string Phone,
                                string Email,string ImagePath)
        {
            this.NationalNo = NationalNo;

            this.Gender = Gender;

            this.CountryName = CountryName;
            this.CountryID = CountryID;

            this.DateOfBirth = DateOfBirth;
            this.Email = Email;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;


            this.LastName = LastName;
            this.Phone = Phone;
            this.Address = Address;

            this.PersonID = PersonID;

            this.ImagePath = ImagePath;

            _Mode = enMode.Update;
        }


        public static DataTable GetAllPeople()
        {
            return clsPeopleData.GetAllPeople();
        }

        public static DataTable GetAllPeopleWithCountries()
        {
            
            return clsPeopleData.GetAllPeopleWithCountries();
        }

        public static ClsPeopleContent FindPerson(int PersonID)
        {
            string  NationalNo = "", FirstName = "", SecondName = "", ThirdName = "",
                    LastName = "", Email = "", Phone = "", Address = "", CountryName="", ImagePath="";
            DateTime DateOfBirth = DateTime.Now;
            short Gender = -1;
            int CountryID = -1;
           
            

            if (clsPeopleData.GetPersonInfoByID(PersonID,ref NationalNo, ref FirstName,ref SecondName,ref ThirdName, ref LastName,
                ref DateOfBirth,ref Gender,ref Address, ref CountryID,ref CountryName, ref Phone, ref Email,ref ImagePath))
            {
                return new ClsPeopleContent(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, CountryID, CountryName, Phone, Email, ImagePath);
            }
            else
            {
                return null;
            }

        }

        public static ClsPeopleContent FindPersonByNationalNo(string NationalNo)
        {
            string  FirstName = "", SecondName = "", ThirdName = "",
                    LastName = "", Email = "", Phone = "", Address = "", CountryName = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gender = -1;
            int CountryID = -1,PersonID=-1;



            if (clsPeopleData.GetPersonInfoByNationalNo(ref PersonID,  NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                ref DateOfBirth, ref Gender, ref Address, ref CountryID, ref CountryName, ref Phone, ref Email, ref ImagePath))
            {
                return new ClsPeopleContent(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, CountryID, CountryName, Phone, Email, ImagePath);
            }
            else
            {
                return null;
            }

        }

        private bool _AddNewContact()
        {
            this.PersonID = clsPeopleData.AddNewPerson(this.NationalNo,this.FirstName,this.SecondName,this.ThirdName, this.LastName,
                                                       this.DateOfBirth,
                                                       this.Gender,this.Address,this.CountryID,this.Phone, this.Email,this.ImagePath);

            return (this.PersonID != -1);

        }

        private bool _UpdateContact()
        {
            return clsPeopleData.UpdatePersonInfo(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                                                       this.DateOfBirth,
                                                       this.Gender, this.Address, this.CountryID, this.Phone, this.Email, this.ImagePath);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewContact())
                    {
                        _Mode = enMode.Update;

                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateContact();



            }

            return false;
        }

        public static ClsPeopleContent FindPersonByFilterBy(ClsGlobal.enPeopleFilter FilterBy,string SearchValue)
        {
            string NationalNo="",FirstName = "", SecondName = "", ThirdName = "",
                    LastName = "", Email = "", Phone = "", Address = "", CountryName = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gender = -1;
            int CountryID = -1, PersonID = -1;

            bool isFound = false;
            switch (FilterBy)
            {
                case ClsGlobal.enPeopleFilter.PersonID:
                    if (int.TryParse(SearchValue, out PersonID))
                    {
                        isFound = clsPeopleData.GetPersonInfoByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                  ref DateOfBirth, ref Gender, ref Address, ref CountryID, ref CountryName, ref Phone, ref Email, ref ImagePath);
                    }
                    break;
                case ClsGlobal.enPeopleFilter.FullName:
                    isFound = clsPeopleData.GetPersonInfoByFullName(ref PersonID,SearchValue, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                            ref DateOfBirth, ref Gender, ref Address, ref CountryID, ref CountryName, ref Phone, ref Email, ref ImagePath);
                    break;
                case ClsGlobal.enPeopleFilter.NationalNo:
                    NationalNo = SearchValue;
                    isFound = clsPeopleData.GetPersonInfoByNationalNo(ref PersonID,  NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                ref DateOfBirth, ref Gender, ref Address, ref CountryID, ref CountryName, ref Phone, ref Email, ref ImagePath);
                    break;
                case ClsGlobal.enPeopleFilter.Phone:
                    Phone = SearchValue;
                    isFound = clsPeopleData.GetPersonInfoByPhoneNumber(ref PersonID,ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                ref DateOfBirth, ref Gender, ref Address, ref CountryID, ref CountryName,  Phone, ref Email, ref ImagePath);
                    break;
                case ClsGlobal.enPeopleFilter.Email:
                    Email = SearchValue;
                    isFound = clsPeopleData.GetPersonInfoByEmail(ref PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                ref DateOfBirth, ref Gender, ref Address, ref CountryID, ref CountryName,ref Phone,  Email, ref ImagePath);
                    break;
                default:
                    break;
            }

            return isFound 
                ? new ClsPeopleContent(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, CountryID, CountryName, Phone, Email, ImagePath) 
                : null;
        }

        public static bool IsTherePersonWithThisNationalNo(string NationalNo)
        {
            return clsPeopleData.IsTherePersonWithThisNationalNo(NationalNo);
        }

        private static bool _IsPersonConnectedToAnyRecord(int PersonID)
        {
            if (ClsApplicationsContent.IsPersonConnected(PersonID))
                return true;
            if (ClsDriversContent.IsPersonConnected(PersonID))
                return true;
            if (ClsUserContent.IsPersonConnected(PersonID))
                return true;
           
            return false;
        }

        public static bool DeletePersonByPersonID(int PersonID)
        {
            bool IsConnected = _IsPersonConnectedToAnyRecord(PersonID);

            if (IsConnected)
                return false;

            return clsPeopleData.DeletePersonByPersonID(PersonID);

        }

        public static int GetPersonIDByNationalNo(string NationalNo)
        {
            return clsPeopleData.GetPersonIDByNationalNo(NationalNo);
        }

    }
}
