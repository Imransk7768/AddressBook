﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;

namespace AddressBookProgram
{
    public class AddressBook
    {
        public SqlConnection connect;
        List<Contacts> addressBook = new List<Contacts>();
        Dictionary<string, List<Contacts>> dictName = new Dictionary<string, List<Contacts>>();
        Contacts contact = new Contacts();

        const string filePath = @"H:\Assignments\AddressBook\AddressBookProgram\ContactBook.txt";
        const string IMPORT_CSV = @"H:\Assignments\AddressBook\AddressBookProgram\AddressBook.csv";
        const string EXPORT_CSV = @"H:\Assignments\AddressBook\AddressBookProgram\AddressBookExport.csv";
        const string EXPORT_JSON = @"H:\Assignments\AddressBook\AddressBookProgram\EXPORT_JSON.json";

        public void Connection()
        {
            string connectingString = "Data Source=(localdb)\\MSSQLLocaldb;Initial Catalog=AddressBookServiceDB";
            connect = new SqlConnection(connectingString);
        }
        public AddressBook()
        {
            Contacts contact1 = new Contacts()
            {
                FirstName = "Shaik",
                LastName = "Rehan",
                Address = "Lp Nagar",
                Email = "rehansk000@gmail.com",
                Mobile = 9012345678,
                City = "vijayawada",
                State = "AP",
                ZipCode = 500324
            };
            Contacts contact2 = new Contacts()
            {
                FirstName = "Rama",
                LastName = "Raju",
                Address = "Moti nagar",
                Email = "aramaraju99@gmail.com",
                Mobile = 9001234567,
                City = "kurnool",
                State = "Ap",
                ZipCode = 523432
            };
            Contacts contact3 = new Contacts()
            {
                FirstName = "Ramesh",
                LastName = "Sharma",
                Address = "SR nagar",
                Email = "ramesh123@gmail.com",
                Mobile = 9001234566,
                City = "kurnool",
                State = "AP",
                ZipCode = 523433
            };
            addressBook.Add(contact1);
            addressBook.Add(contact2);
            addressBook.Add(contact3);
        }
        public void CreateContact()
        {

            Console.Write("Enter Your First: ");
            contact.FirstName = Console.ReadLine();
            Console.Write("Enter Your Last Name: ");
            contact.LastName = Console.ReadLine();
            Console.Write("Enter Your Address: ");
            contact.Address = Console.ReadLine();
            Console.Write("Enter Your Email Id: ");
            contact.Email = Console.ReadLine();
            Console.Write("Enter Your PhoneNumber: ");
            contact.Mobile = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter Your City: ");
            contact.City = Console.ReadLine();
            Console.Write("Enter Your State: ");
            contact.State = Console.ReadLine();
            Console.Write("Enter Your Zip Code: ");
            contact.ZipCode = Convert.ToInt32(Console.ReadLine());
            addressBook.Add(contact);
        }
        public void CheckDuplicateContact(string firstName)
        {
            foreach (Contacts contact in addressBook)
            {
                if (contact.FirstName == firstName)
                {
                    Console.WriteLine("Name is Already Present, Please Enter Different Name.\n");
                    Console.WriteLine("Enter New Contact Details.");
                    CreateContact();
                }
                else
                {
                    Display();
                }
            }
        }
        public void addContact(Contacts contact)
        {
            addressBook.Add(contact);
        }
        public void Display()
        {
            Console.WriteLine(">>>>>>  AddressBook List  <<<<<<");
            foreach (Contacts contact in addressBook)
            {
                Console.WriteLine("\nFirstName : " + contact.FirstName + "\nLasrName : " + contact.LastName +
                    "\nAddress : " + contact.Address + "\nEmail : " + contact.Email + "\nPhone : " + contact.Mobile +
                    "\nCity :" + contact.City + "\nState : " + contact.State + "\nZipCode : " + contact.ZipCode);
                Console.WriteLine("\n");
            }
        }
        public void EditContact(string name)
        {
            foreach (var contact in addressBook)
            {
                //Console.WriteLine("Enter FirstName to Edit : ");
                //string name = Console.ReadLine();
                if (contact.FirstName.Equals(name))
                {
                    Console.WriteLine("Edit a Contact Of \n1. LastName\n2. Address\n3. Email\n4. PhoneNumber\n5. City\n6. State\n7. ZipCode\n");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("enter the last name you want to edit : ");
                            contact.LastName = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("enter the address you want to edit : ");
                            contact.Address = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("enter the city: ");
                            contact.City = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("enter the state you want to edit : ");
                            contact.State = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("enter the email you want to edit : ");
                            contact.Email = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("enter the zip you want to edit : ");
                            contact.ZipCode = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 7:
                            Console.WriteLine("enter the phone you want to edit : ");
                            contact.Mobile = Convert.ToInt64(Console.ReadLine());
                            break;
                        default:
                            Console.WriteLine("Choose the right option : ");
                            break;
                    }
                }
                /*else
                {
                    Console.WriteLine("Contact doesn't Exist.");
                }*/
            }
            Display();
        }
        public void DeleteContact()
        {
            Contacts delete = new Contacts();
            Console.WriteLine("To Delete Contact List Enter Contact FirstName here : ");
            string name = Console.ReadLine();
            foreach (Contacts contact in addressBook)
            {
                if (contact.FirstName.Equals(name))
                {
                    delete = contact;
                }
            }
            addressBook.Remove(delete);
            Display();
        }
        public void AddMultipleContacts()
        {
            Console.WriteLine("Enter The Number Of Contacts To Be Added: ");
            int numCon = Convert.ToInt32(Console.ReadLine());

            while (numCon > 0)
            {
                CreateContact();
                numCon--;
            }
            Display();
        }
        public void AddDictionary(string name)
        {
            if (dictName == null)
            {
                dictName.Add(name, addressBook);
            }
            if (NameExists(name) == false)
            {
                dictName.Add(name, addressBook);
            }
            Display();
        }
        public void displayDictionaryData(string name)
        {
            foreach (var data in dictName)
            {
                if (data.Key.Equals(name))
                {
                    addressBook = data.Value;
                }
                Console.WriteLine(dictName);
            }
        }
        public void EditingDictionary(string name, string contactName)
        {
            foreach (var data in dictName)
            {
                if (data.Key.Equals(name))
                {
                    addressBook = data.Value;
                }
            }
            EditContact(contactName);
            Display();
        }
        public bool NameExists(string name)
        {
            foreach (var data in dictName.Keys)
            {
                if (data.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }
        public void SearchPersonCity(string cityName)
        {
            Console.Write("Contact Details Search by City '{0}' : ", cityName);
            foreach (var data in addressBook)
            {
                if (data.City.Contains(cityName))
                {
                    Console.WriteLine(data.FirstName + ", " + data.LastName + ", " + data.Email + ", " + data.Mobile +
                        ", " + data.City + ", " + data.State + ", " + data.ZipCode);
                }
            }
        }
        public void ViewPersonByCity()
        {
            Console.Write("View By City/State : ");
            string cityNames = Console.ReadLine();
            var obj = addressBook.FindAll(x => x.City == cityNames || x.State == cityNames);
            if (obj.Count > 0)
            {
                foreach (var data in obj)
                {
                    Console.WriteLine(data.FirstName + ", " + data.City + ", " + data.State);
                }
            }
            else
            {
                Console.WriteLine("Enter City/State Name That Present in List.");
            }
        }
        public void CountByCity()
        {
            int count = 0;
            Console.Write("Count By City|State : ");
            string cityNames = Console.ReadLine();
            var obj = addressBook.FindAll(x => x.City == cityNames || x.State == cityNames);
            if (obj.Count > 0)
            {
                foreach (var data in obj)
                {
                    count++;
                }
                Console.Write("Total Person are :", +obj.Count);
                Console.Write(count);
            }
            else
            {
                Console.WriteLine("Enter City/State Name That Present in List.;");
            }
        }
        public void SortNameByAlphabeticalOrder()
        {
            List<string> SortedByAlphabet = new List<string>();
            foreach (Contacts contact in addressBook)
            {
                string name = contact.FirstName.ToString();
                SortedByAlphabet.Add(name);
            }
            SortedByAlphabet.Sort();
            foreach (string name in SortedByAlphabet)
            {
                Console.WriteLine(name);
            }
        }
        public void SortNameByCityStateZip()
        {
            List<string> SortedByZip = new List<string>();
            foreach (Contacts contact in addressBook)
            {
                string data1 = null;
                if (data1 == contact.City.ToString() || data1 == contact.City || data1 == contact.State)
                    SortedByZip.Add(data1);
            }
            SortedByZip.Sort();
            foreach (var data in addressBook)
            {
                Console.WriteLine(data.FirstName + ", " + data.LastName + ", " + data.City + ", " + data.State + ", " + data.ZipCode);
            }
        }
        public void ReadingFileIO()
        {
            if (File.Exists(filePath))
            {
                StreamReader read = new StreamReader(filePath);
                try
                {
                    string s = "";
                    while ((s = read.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void ReadAndWriteDataFromCSV()
        {
            using (var reader = new StreamReader(IMPORT_CSV))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Contacts>().ToList();
                    Console.WriteLine("After Reading CSV File");
                    foreach (var data in records)
                    {
                        Console.WriteLine(data.FirstName + ", " + data.LastName + ", " + data.Email + ", " + data.Mobile +
                        ", " + data.City + ", " + data.State + ", " + data.ZipCode);
                    }
                    using (var writer = new StreamWriter(EXPORT_CSV))
                    {
                        using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            csvExport.WriteRecords(records);
                        }
                    }
                }
            }
        }
        public void ReadAndWriteDataFromCSVJson()
        {
            using (var reader = new StreamReader(IMPORT_CSV))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Contacts>().ToList();
                    Console.WriteLine("After Reading CSV File");
                    foreach (var data in records)
                    {
                        Console.WriteLine(data.FirstName + ", " + data.LastName + ", " + data.Email + ", " + data.Mobile +
                       ", " + data.City + ", " + data.State + ", " + data.ZipCode);
                    }
                    JsonSerializer serializer = new JsonSerializer();
                    using (var writter = new StreamWriter(EXPORT_JSON))
                    {
                        using (var writer = new JsonTextWriter(writter))
                        {
                            serializer.Serialize(writer, records);
                        }
                    }
                }
            }
        }
        public void RetriveEntriesFromDB()
        {
            Connection();
            SqlCommand command = new SqlCommand("spGetAllEntries", connect);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            connect.Open();
            adapter.Fill(dataTable);
            connect.Close();
            foreach (DataRow data in dataTable.Rows)
            {
                Console.WriteLine(data["FirstName"] + ", " + data["LastName"] + ", " + data["Address"] + ", " + data["Mobile"] + ", " + data["Email"] 
                    + ", " + data["City"] + ", " + data["State"] + ", " + data["ZipCode"] );
            }
        }
        public void Update_EmpDetails(Contacts cont)
        {
            try
            {
                Connection();
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@zipCode", cont.zipCode);
                cmd.Parameters.AddWithValue("@City", cont.City);
                cmd.Parameters.AddWithValue("@FitName", cont.FirstName);
                connect.Open();
                int result = cmd.ExecuteNonQuery();
                connect.Close();
                if (result != 0)
                {
                    Console.WriteLine("Updated Sucessfull");
                }
                else
                {
                    Console.WriteLine("Update Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}