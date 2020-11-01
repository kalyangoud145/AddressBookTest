using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AddressBookTest
{
    /// <summary>
    /// AddressBook implementation class for performing different methods
    /// </summary>
    class AddressBook : AddressBookInterface
    {
        /// <summary>
        /// contactList stores all contacts of one AddressBook
        /// </summary>
        public List<Contacts> contactList = new List<Contacts>();
        /// <summary>
        /// nameToContactMapper is used to access contact details using name of person
        /// </summary>
        public Dictionary<string, Contacts> contactFromDatabase = new Dictionary<string, Contacts>();

        /// <summary>
        /// This function is used to add new Contact in AddressBook
        /// </summary>
        public void AddContacts()
        {
            bool flag = true;
            string first_name;
            while (flag)
            {
                Console.WriteLine("\n\t\t\tEnter First Name of Contact to check duplicate");
                first_name = InputString();
                if (this.contactFromDatabase.ContainsKey(first_name))
                {
                    Console.WriteLine("A contact already exist with this name, try again!\n");
                    AddContacts();
                    return;
                }
                Contacts contact = new Contacts();
                contact.SetFirstName(first_name);
                Console.WriteLine(contact.GetFirstName());
                Console.WriteLine("\n\t\t\tEnter Last Name");
                contact.SetLastName(InputString());
                Console.WriteLine(contact.GetLastName());
                Console.WriteLine("\n\t\t\tEnter city");
                contact.SetCity(InputString());
                Console.WriteLine(contact.GetCity());
                Console.WriteLine("\n\t\t\tEnter State");
                contact.SetState(InputString());
                Console.WriteLine(contact.GetState());
                Console.WriteLine("\n\t\t\tEnter ZipCode");
                contact.SetZip(InputInteger());
                Console.WriteLine(contact.GetZip());
                Console.WriteLine("\n\t\t\tEnter Phone Number");
                contact.SetPhoneNumber(InputString());
                Console.WriteLine(contact.GetPhoneNumber());
                this.contactList.Add(contact);
                this.contactFromDatabase.Add(contact.firstName, contact);
                foreach (Contacts contacts in contactList)
                {
                    Console.WriteLine(contacts.ToString());
                }
                Console.WriteLine("want to add more contacts then press 1 or press other than 1");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    AddContacts();
                }
                else
                {
                    flag = false;
                }
                // Console.WriteLine("\nTo Add a New Contact in other address book Enter YES");
                // string option = Console.ReadLine();
                //if (option != "YES")
                //{
                flag = false;
                // }
            }
        }

        /// <summary>
        /// EditDetails is used to modify contact details of a person using complete name
        /// </summary>
        public void editContact()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nTo modify details, enter the firstname");
                string name = Console.ReadLine();
                if (contactFromDatabase.ContainsKey(name))
                {
                    Contacts contact = contactFromDatabase[name];
                    Console.WriteLine("Enter Latest Details of Contact!");
                    Console.WriteLine("\t\t\t1.To edit Firstname and lastname\n\t\t\t2.To edit city,State and zip\n" + "\t\t\t3. To edit Phone Number\n");
                    int editChoice = (int)InputInteger();
                    switch (editChoice)
                    {
                        case 1:
                            Console.WriteLine("Enter First Name of Contact");
                            string firstName = Console.ReadLine();
                            contact.firstName = firstName;
                            Console.WriteLine("Enter Last Name of Contact");
                            string lastName = Console.ReadLine();
                            contact.lastName = lastName;
                            break;
                        case 2:
                            Console.WriteLine("Enter City");
                            string city = Console.ReadLine();
                            contact.city = city;
                            Console.WriteLine("Enter state");
                            string state = Console.ReadLine();
                            contact.state = state;
                            Console.WriteLine("Enter zip");
                            int zip = Convert.ToInt32(Console.ReadLine());
                            contact.zip = zip;
                            break;
                        case 3:
                            Console.WriteLine("Enter Phone Number");
                            string phoneNumber = Console.ReadLine();
                            contact.phoneNumber = phoneNumber;
                            break;
                    }
                    Console.WriteLine("\nDetails modified successfully with following entries: ");
                    Console.WriteLine("FirstName: " + contact.firstName + "\nLast Name :" + contact.lastName);
                    //  Console.WriteLine("Address: " + contact.address + "\nCity: " + contact.city);
                    Console.WriteLine("State: " + contact.state + "\nZip: " + contact.zip);
                    Console.WriteLine("Phone Number: " + contact.phoneNumber);
                }
                else
                {
                    Console.WriteLine("Entered name did't match with any record!");
                }
                Console.WriteLine("\nTo update more contact details enter YES");
                string option = Console.ReadLine();
                if (option != "YES")
                    flag = false;
            }


        }
        /// <summary>
        /// DeleteContact function is used to delete Contact from AddressBook using full name of the person
        /// </summary>
        public void deleteContact()
        {
            Console.WriteLine("\nTo delete details, enter the firstname");
            string name = Console.ReadLine();
            if (contactFromDatabase.ContainsKey(name))
            {
                contactFromDatabase.Remove(name);
                Console.WriteLine("Contact has been deleted");
            }
        }

        /// <summary>
        ///Reads input the string and return that 
        /// </summary>
        /// <returns></returns>
        public string InputString()
        {
            try
            {
                return Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "";
        }
        /// <summary>
        /// Reads input the integer and return that 
        /// </summary>
        /// <returns></returns>
        public long InputInteger()
        {
            try
            {
                return Convert.ToInt64(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }

    }
}