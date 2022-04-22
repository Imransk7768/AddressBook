using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    public class AddressBook
    {
        List<Contacts> addressBook = new List<Contacts>();
        Contacts contact = new Contacts();
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
            addressBook.Add(contact1);
            addressBook.Add(contact2);
        }
        public void CreateContact()
        {
            
            Console.WriteLine("Enter Your First: ");
            contact.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Your Last Name: ");
            contact.LastName = Console.ReadLine();
            Console.WriteLine("Enter Your Address: ");
            contact.Address = Console.ReadLine();
            Console.WriteLine("Enter Your Email Id: ");
            contact.Email = Console.ReadLine();
            Console.WriteLine("Enter Your PhoneNumber: ");
            contact.Mobile = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Your City: ");
            contact.City = Console.ReadLine();
            Console.WriteLine("Enter Your State: ");
            contact.State = Console.ReadLine();
            Console.WriteLine("Enter Your Zip Code: ");
            contact.ZipCode = Convert.ToInt32(Console.ReadLine());
            addressBook.Add(contact);
        }
        public void Display()
        {
            foreach (Contacts contact in addressBook)
            {
                Console.WriteLine("\nFirstName : " + contact.FirstName + "\nLasrName : " + contact.LastName +
                    "\nAddress : " + contact.Address + "\nEmail : " + contact.Email + "\nPhone : " + contact.Mobile +
                    "\nCity :" + contact.City + "\nState : " + contact.State + "\nZipCode : " + contact.ZipCode);
                Console.WriteLine("\n");
            }
        }
    }
}