using System;

namespace AddressBookProgram
{
    class program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(">>>>>  WelCome To Address-Book Details  <<<<<");
            bool end = true;
            Console.WriteLine("\nSelectNumber\n1. Add Contact\n2. Display\n3. Edit Contact \n4. End Of Program");
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