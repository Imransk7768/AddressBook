﻿using System;

namespace AddressBookProgram
{
    class program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(">>>>>  WelCome To Address-Book Details  <<<<<");
            bool end = true;
            Console.WriteLine("\nSelectNumber\n1. Add Contact\n2. Display\n3. EditContact\n4. DeleteContact\n5. Add Multiple Contacts\n" +
                "6. Add Data in Dictionary\n7. Edit data in Dictionary\n8. Display Dictionary info\n9. Duplicate Contact Check\n10. Search Through City\n" +
                "11. View By City/State\n12. Count By City\n13. Sort Name By Alphabet\n14. Sort Name By City/State/Zip" +
                "\n15. ReadUsingIO\n16. Read & Write Data From CsvFile\n17.ReadWrite data from Json File\n18. Retrieve All Entries");
            Contacts contact = new Contacts();
            AddressBook con = new AddressBook();
            while (end)
            {
                Console.Write("\nChoose Option to Execute Program : ");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        con.CreateContact();
                        break;
                    case 2:
                        con.Display();
                        break;
                    case 3:
                        string name = Console.ReadLine();
                        con.EditContact(name);
                        break;
                    case 4:
                        con.DeleteContact();
                        break;
                    case 5:
                        con.AddMultipleContacts();
                        break;
                    case 6:
                        Console.Write("Enter the Name for Adding data in Dictionary : ");
                        string dictionaryName = Console.ReadLine();
                        con.AddDictionary(dictionaryName);
                        break;
                    case 7:
                        Console.Write("Enter the Name for Editing data in Dictionary : ");
                        string dictName = Console.ReadLine();
                        string contactName = Console.ReadLine();
                        con.EditingDictionary(dictName, contactName);
                        break;
                    case 8:
                        Console.Write("Enter the Name for Display data in Dictionary : ");
                        string dictionary = Console.ReadLine();
                        con.displayDictionaryData(dictionary);
                        break;
                    case 9:
                        Console.Write("Enter the FirstName for Check Duplicate Contact in Dictionary : ");
                        string firstName = Console.ReadLine();
                        con.CheckDuplicateContact(firstName);
                        break;
                    case 10:
                        Console.Write("Search Contact through City: ");
                        string cityName = Console.ReadLine();
                        con.SearchPersonCity(cityName);
                        break;
                    case 11:
                        con.ViewPersonByCity();
                        break;
                    case 12:
                        con.CountByCity();
                        break;
                    case 13:
                        con.SortNameByAlphabeticalOrder();
                        break;
                    case 14:
                        con.SortNameByCityStateZip();
                        break;
                    case 15:
                        con.ReadingFileIO();
                        break;
                    case 16:
                        con.ReadAndWriteDataFromCSV();
                        break;
                    case 17:
                        con.ReadAndWriteDataFromCSVJson();
                        break;
                    case 18:
                        con.RetriveEntriesFromDB();
                        break;
                    case 19:
                        Contacts update = new Contacts();
                        update.City = "Vizag";
                        update.zipCode = "523314";
                        update.FirstName = "Rehan";
                        con.Update_EmpDetails(update);
                        break;
                    default:
                        end = false;
                        Console.WriteLine("Program Is Ended");
                        break;
                }
            }
        }
    }
}