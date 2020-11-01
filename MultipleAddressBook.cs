using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookTest
{
    class MultipleAddressBook
    {
        /// <summary>
        /// multipleAddressMapper is a data structure used to store All AddressBooks created in the project
        /// which can be accessed with the help of their name
        /// </summary>
        private Dictionary<string, AddressBook> multipleAddressMapper = new Dictionary<string, AddressBook>();
        /// <summary>
        /// multipleBook function asks user about which activity to be done
        /// </summary>
        public void multipleBook()
        {
            Console.WriteLine("Welcome to address book Program!");
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\t\t\t___________________\n"
                       + "\t\t\t|       Menu             |\n"
                       + "\t\t\t|      ------            |\n"
                       + "\t\t\t| 1. New addressbook     |\n"
                       + "\t\t\t| 2. open existing       |\n"
                       + "\t\t\t| 3. EditPerson          |\n"
                       + "\t\t\t| 4. DeletePerson        |\n"
                       + "\t\t\t| 5. Close addressbook   |\n"
                       + "\t\t\t|________________________|");
                int options = Convert.ToInt32(Console.ReadLine());
                switch (options)
                {
                    case 1:
                        AddAddressBook();
                        break;
                    case 2:
                        AddContactsInAddressBook();
                        break;
                    case 3:
                        EditContactsOfAddressBook();
                        break;
                    case 4:
                        DeleteContactsOfAddressBook();
                        break;
                    case 5:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Wrong data received select again");
                        break;
                }
            }
        }
        /// <summary>
        /// AddAddressBook function is called when user want to create new AddressBook
        /// </summary>
        public void AddAddressBook()
        {
            Console.WriteLine("\nEnter Name for the New Address Book");
            string name = Console.ReadLine();
            if (multipleAddressMapper.ContainsKey(name))
            {
                Console.WriteLine("Address Book Already exist with this name");
            }
            else
            {
                AddressBook addressBook = new AddressBook();
                multipleAddressMapper.Add(name, addressBook);
            }
        }
        /// <summary>
        /// AddContactsInAddressBook is called when user ask to enter new contact details in any AddressBook
        /// </summary>
        public void AddContactsInAddressBook()
        {
            Console.WriteLine("\nEnter Name of address book to add new contact");
            string name = Console.ReadLine();
            if (!multipleAddressMapper.ContainsKey(name))
            {
                Console.WriteLine("No address book found with this name");
                Console.WriteLine("Please Enter Valid Name from following names:");
                foreach (KeyValuePair<string, AddressBook> tempPair in multipleAddressMapper)
                {
                    Console.WriteLine(tempPair.Key);
                }
            }
            else
            {
                AddressBook addressBook = multipleAddressMapper[name];
                addressBook.AddContacts();
            }
        }
        /// <summary>
        /// EditDetailsOfAddressBook is called when a user ask to modify Contact details in a AddressBook
        /// </summary>
        public void EditContactsOfAddressBook()
        {
            Console.WriteLine("\nEnter Name of address book to modify contact details");
            string name = Console.ReadLine();
            if (!multipleAddressMapper.ContainsKey(name))
            {
                Console.WriteLine("No address book found with this name");
                Console.WriteLine("Please Enter Valid Name from following names:");
                foreach (KeyValuePair<string, AddressBook> tempPair in multipleAddressMapper)
                {
                    Console.WriteLine(tempPair.Key);
                }
            }
            else
            {
                AddressBook addressBook = multipleAddressMapper[name];
                addressBook.editContact();
            }
        }
        /// <summary>
        /// DeleteContactsOfAddressBook is called when user want to delete a particular contact from a AddressBook
        /// </summary>
        public void DeleteContactsOfAddressBook()
        {
            Console.WriteLine("\nEnter Name of address book to delete contact details");
            string name = Console.ReadLine();
            if (!multipleAddressMapper.ContainsKey(name))
            {
                Console.WriteLine("No address book found with this name");
                Console.WriteLine("Please Enter Valid Name from following names:");
                foreach (KeyValuePair<string, AddressBook> tempPair in multipleAddressMapper)
                {
                    Console.WriteLine(tempPair.Key);
                }
            }
            else
            {
                AddressBook addressBook = multipleAddressMapper[name];
                addressBook.deleteContact();
            }
        }
    }
}
