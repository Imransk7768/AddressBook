using System;

namespace AddressBookProgram
{
    class program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine(">>>>>  Welcome to ADDRESS-BOOK Detaiils.");
            AddressBook book = new AddressBook();
            book.AddContacts();
            book.Display();
        }
    }
}