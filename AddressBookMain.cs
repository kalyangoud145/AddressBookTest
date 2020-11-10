using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace AddressBookTest
{
    class AddressBookMain
    {
        //Dictionary for storing multiple addressBooks using name as key
        public static Dictionary<string, AddressBook> AddressBookMap = new Dictionary<string, AddressBook>();
        //CitywiseContactMap to store person data based on his city
        public static Dictionary<Contact, string> CitywiseContactMap = new Dictionary<Contact, string>();
        //StatewiseContactMap to store person data based on state
        public static Dictionary<Contact, string> StatewiseContactMap = new Dictionary<Contact, string>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address Book Program");
            int choice;
            string name;
            do
            {
                Console.WriteLine("\t\t\t__________________________________\n"
                       + "\t\t\t|       Menu                      |\n"
                       + "\t\t\t|      ------                     |\n"
                       + "\t\t\t| 1. New addressbook              |\n"
                       + "\t\t\t| 2. open existing                |\n"
                       + "\t\t\t| 3. View Contact By City or State|\n"
                       + "\t\t\t| 4. Count by city or state       |\n"
                       + "\t\t\t| 5. Exit                         |\n"
                       + "\t\t\t|_________________________________|");
                choice = (int)InputInteger();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the Name of Address Book");
                        name = InputString();
                        AddressBookMap.Add(name, new AddressBook());
                        break;
                    case 2:
                        Console.WriteLine("Enter the Name of Address Book you wish to Work On");
                        name = InputString();
                        AddressBook addressBook = AddressBookMap[name];
                        FillAddressBook(addressBook);
                        break;
                    case 3:
                        ViewPersonByCityOrState();
                        break;
                    case 4:
                        CountPersonByCityOrState();
                        break;
                }
            } while (choice != 5);
        }
        /// <summary>
        /// Adds the contact details 
        /// </summary>
        /// <param name="contact">The contact.</param>
        public static void SetContactDetails(Contact contact)
        {

            Console.WriteLine("Enter the First Name");
            contact.FirstName = InputString();
            Console.WriteLine("Enter the Last Name");
            contact.LastName = InputString();
            Console.WriteLine("Enter the Address");
            contact.Address = InputString();
            Console.WriteLine("Enter the City Name");
            contact.City = Console.ReadLine();
            Console.WriteLine("Enter the State Name");
            contact.State = InputString();
            Console.WriteLine("Enter the zip code");
            contact.Zip = (int)InputInteger();
            Console.WriteLine("Enter the Phone Number");
            contact.PhoneNumber = (long)InputInteger();
            Console.WriteLine("Enter the email address");
            contact.Email = InputString();
            CitywiseContactMap[contact] = contact.City;
            StatewiseContactMap[contact] = contact.State;
        }
        /// <summary>
        /// method for adding, editing, deleting the person details
        /// </summary>
        /// <param name="addressBook">The address book.</param>
        public static void FillAddressBook(AddressBook addressBook)
        {
            int choice;
            do
            {
                Console.WriteLine("\t\t\t__________________________________\n"
                      + "\t\t\t|       Menu                      |\n"
                      + "\t\t\t|      ------                     |\n"
                      + "\t\t\t| 1. Add Contact                  |\n"
                      + "\t\t\t| 2. Edit Contact                 |\n"
                      + "\t\t\t| 3. Delete Contact               |\n"
                      + "\t\t\t| 4. File I/P Operation           |\n"
                      + "\t\t\t| 5. File O/P Operation           |\n"
                      + "\t\t\t| 6. Sort By firstname            |\n"
                      + "\t\t\t| 7. Display all                  |\n"
                      + "\t\t\t| 8. Sort by city or state or zip |\n"
                      + "\t\t\t| 0.Exit                          |\n"
                      + "\t\t\t|_________________________________|");
                choice = (int)InputInteger();
                switch (choice)
                {
                    case 1:
                        Contact contact = new Contact();
                        SetContactDetails(contact);
                        addressBook.AddContact(contact);
                        break;
                    case 2:
                        Console.WriteLine("Enter the Phone Number of Contact you wish to Edit");
                        long phoneNumber = (long)InputInteger();
                        //calls FindByPhoneNum to get index of input phoneNumber
                        int index = addressBook.FindByPhoneNum(phoneNumber);
                        if (index == -1)
                        {
                            Console.WriteLine("No Contact Exists With Following Phone Number");
                            continue;
                        }
                        else
                        {
                            Contact contact2 = new Contact();
                            //Calls SetContactDetails method to add person detals 
                            SetContactDetails(contact2);
                            //Add contact to list
                            addressBook.ContactList[index] = contact2;
                            Console.WriteLine("Contact Updated Successfully");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter the First Name of Contact you wish to delete");
                        string firstName = InputString();
                        //FindByFirstName gets index of person based on first name
                        int index1 = addressBook.FindByFirstName(firstName);
                        if (index1 == -1)
                        {
                            Console.WriteLine("No Contact Exists with Following First Name");
                            continue;
                        }
                        else
                        {
                            //Calls delete contact and deletes details in particular index location 
                            addressBook.DeleteContact(index1);
                            Console.WriteLine("Contact Deleted Successfully");
                        }
                        break;
                    case 4:
                        FileIOOperations fileIOOperations = new FileIOOperations();
                        fileIOOperations.WriteToFile(AddressBookMap);
                        break;
                    case 5:
                        FileIOOperations fileIOOperations1 = new FileIOOperations();
                        fileIOOperations1.ReadFromFile();
                        break;
                    case 6:
                        addressBook.SortByFirstName();
                        break;
                    case 7:
                        addressBook.Display();
                        break;
                    case 8:
                        Console.WriteLine("\t\t\t__________________________________\n"
                     + "\t\t\t|      ------                     |\n"
                     + "\t\t\t| 1. Sort by city                 |\n"
                     + "\t\t\t| 2. Sort by zip                  |\n"
                     + "\t\t\t| 3. Sort by state                |\n"
                     + "\t\t\t|_________________________________|");
                        int option =(int) InputInteger();
                        switch (option)
                        {
                            case 1:
                                addressBook.SortByCity();
                                break;
                            case 2:
                                addressBook.SortByZip();
                                break;
                            default:
                                addressBook.SortByState();
                                break;
                        }
                        break;
                }
            } while (choice != 0);
        }
        /// <summary>
        /// Display person details based on city or state
        /// </summary>
        public static void ViewPersonByCityOrState()
        {
            int choice;
            Console.WriteLine("1.View Person Contact By City \n2.View Person Contact By State");
            choice = (int)InputInteger();
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the City Name");
                    string city = InputString();
                    List<Contact> contactListInGivenCity = new List<Contact>();
                    //Adds person detals of particular person to contactListInGivenCity list
                    foreach (KeyValuePair<Contact, string> kvp in CitywiseContactMap)
                    {
                        if (kvp.Value.Equals(city))
                            contactListInGivenCity.Add(kvp.Key);
                    }
                    //Prints details of person in particular state
                    foreach (Contact contact in contactListInGivenCity)
                    {
                        Console.WriteLine(contact);
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter the State Name");
                    string state = InputString();
                    List<Contact> contactListInGivenState = new List<Contact>();
                    //Adds person detals of particular person to StatewiseContactMap list
                    foreach (KeyValuePair<Contact, string> kvp in StatewiseContactMap)
                    {
                        if (kvp.Value.Equals(state))
                            contactListInGivenState.Add(kvp.Key);
                    }
                    //Prints details of person in particular state
                    foreach (Contact contact in contactListInGivenState)
                    {
                        Console.WriteLine(contact);
                    }
                    break;
            }
        }
        /// <summary>
        /// Method gives the count of persons by city or state
        /// </summary>
        public static void CountPersonByCityOrState()
        {
            int choice;
            Console.WriteLine("1.To count Person Contact By City \n2.To count Person Contact By State");
            choice = (int)InputInteger();
            if (choice == 1)
            {
                int count = 0;
                Console.WriteLine("Enter the city name");
                string city = InputString();
                foreach (KeyValuePair<Contact, string> kvp in CitywiseContactMap)
                {
                    if (kvp.Value.Equals(city))
                        count++;
                }
                System.Console.WriteLine($"{count} contacts in given city");
            }
            else
            {
                int count = 0;
                Console.WriteLine("Enter the State name");
                string state = InputString();
                foreach (KeyValuePair<Contact, string> kvp in StatewiseContactMap)
                {
                    if (kvp.Value.Equals(state))
                        count++;
                }
                System.Console.WriteLine($"{count} contacts in given state");
            }

        }
        /// <summary>
        ///Reads input the string and return that 
        /// </summary>
        /// <returns></returns>
        public static string InputString()
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
        public static long InputInteger()
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
