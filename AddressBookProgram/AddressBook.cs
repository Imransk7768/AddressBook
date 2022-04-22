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
        public void EditContact()
        {
            foreach (Contacts contact in addressBook)
            {
                Console.WriteLine("Enter FirstName to Edit : ");
                string name = Console.ReadLine();
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
                            Console.WriteLine("enter the address you want to edit :");
                            contact.Address = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("enter the city: ");
                            contact.City = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("enter the state you want to edit :");
                            contact.State = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("enter the email you want to edit :");
                            contact.Email = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("enter the zip you want to edit :");
                            contact.ZipCode = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 7:
                            Console.WriteLine("enter the phone you want to edit :");
                            contact.Mobile = Convert.ToInt64(Console.ReadLine());
                            break;
                        default:
                            Console.WriteLine("Choose the right option : ");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Contact doesn't Exist.");
                }
                Display();
            }

        }
    }
}