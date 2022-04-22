using System;

namespace AddressBookProgram
{
    class program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(">>>>>  WelCome To Address-Book Details  <<<<<");
            bool end = true;
            Console.WriteLine("\nSelectNumber\n1. Add Contact\n2. Display\n3. EditContact\n4. DeleteContact\n5. Add Multiple Contacts\n" +
                "6. Add Data in Dictionary\n 7. Edit data in Dictionary\n8. Display Dictionary info\n9. End Of Program");
            Contacts contact = new Contacts();
            AddressBook con = new AddressBook();
            while (end)
            {
                Console.WriteLine("\nChoose Option to Execute Program : ");
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
                        con.EditContact();
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
                        con.displayDictionaryData();
                        break;
                    case 9:
                        end = false;
                        Console.WriteLine("Program Is Ended");
                        break;
                    default:
                        Console.WriteLine("Execution Ends.");
                        break;
                }
            }
        }
    }
}