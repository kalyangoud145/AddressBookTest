using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBookTest
{
    public class AddressBook : IContacts
    {
        //Regex patterns for validating the Person details
        public const string REGEX_NAME = "^[A-Z][a-zA-Z]{3,}";
        public const string REGEX_MOBILE_NUMBER = "^[1-9]{1}[0-9]{1,2}[ ][1-9]{1}[0-9]{9}$";
        public const string REGEX_EMAIL = "^[0-9a-zA-Z]{1,}([._+-][0-9a-zA-Z]{0,})*[@][0-9a-zA-Z]{1,}.[a-zA-Z]{2,3}(.[a-zA-Z]{2,3})?$";
        public const string REGEX_ZIP = "^[1-9]{1}[0-9]{2}\\s{0, 1}[0-9]{3}$";
        /// The address book stores contact details 
        public Dictionary<string, Contact> addressBook = new Dictionary<string, Contact>();
        /// The address book dictionary stores address books.
        public Dictionary<string, AddressBook> addressBookDictionary = new Dictionary<string, AddressBook>();
        /// The dictionary to store contact by city
        private Dictionary<Contact, string> cityDictionary = new Dictionary<Contact, string>();
        /// The dictionary to store contact by state
        private Dictionary<Contact, string> stateDictionary = new Dictionary<Contact, string>();
        /// <summary>
        /// Adds the contacts to dictionary
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="address">The address.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="email">The email.</param>
        /// <param name="zip">The zip.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="bookName">Name of the book.</param>
        public void AddContact(string firstName, string lastName, string address, string city, string state, string email, string zip, string phoneNumber, string bookName)
        {
            Contact contact = new Contact
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                City = city,
                State = state,
                Email = email,
                Zip = zip,
                PhoneNumber = phoneNumber
            };
            addressBookDictionary[bookName].addressBook.Add(contact.FirstName , contact);
            Console.WriteLine("\nAdded Succesfully. \n");
        }
        /// <summary>
        /// Display the contacts by book name
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="bookName">Name of the book.</param>
        public void ViewContact(string name, string bookName)
        {
            foreach (KeyValuePair<string, Contact> item in addressBookDictionary[bookName].addressBook)
            {
                if (item.Key.Equals(name))
                {
                    Console.WriteLine("First Name : " + item.Value.FirstName);
                    Console.WriteLine("Last Name : " + item.Value.LastName);
                    Console.WriteLine("Address : " + item.Value.Address);
                    Console.WriteLine("City : " + item.Value.City);
                    Console.WriteLine("State : " + item.Value.State);
                    Console.WriteLine("Email : " + item.Value.Email);
                    Console.WriteLine("Zip : " + item.Value.Zip);
                    Console.WriteLine("Phone Number : " + item.Value.PhoneNumber + "\n");
                }
            }
        }
        /// <summary>
        /// Display all contacts of a particulat address book
        /// </summary>
        /// <param name="bookName">Name of the book.</param>
        public void ViewContact(string bookName)
        {
            foreach (KeyValuePair<string, Contact> item in addressBookDictionary[bookName].addressBook)
            {
                Console.WriteLine("First Name : " + item.Value.FirstName);
                Console.WriteLine("Last Name : " + item.Value.LastName);
                Console.WriteLine("Address : " + item.Value.Address);
                Console.WriteLine("City : " + item.Value.City);
                Console.WriteLine("State : " + item.Value.State);
                Console.WriteLine("Email : " + item.Value.Email);
                Console.WriteLine("Zip : " + item.Value.Zip);
                Console.WriteLine("Phone Number : " + item.Value.PhoneNumber + "\n");
            }
        }
        /// <summary>
        /// Edit the person details
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="bookName">Name of the book.</param>
        public void EditContact(string name, string bookName)
        {
            foreach (KeyValuePair<string, Contact> item in addressBookDictionary[bookName].addressBook)
            {
                if (item.Key.Equals(name))
                {
                    Console.WriteLine("Choose What to Edit \n1.First Name \n2.Last Name \n3.Address \n4.City \n5.State \n6.Email \n7.Zip \n8.Phone Number");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter New First Name :");
                            item.Value.FirstName = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter New Last Name :");
                            item.Value.LastName = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter New Address :");
                            item.Value.Address = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter New City :");
                            item.Value.City = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Enter New State :");
                            item.Value.State = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("Enter New Email :");
                            item.Value.Email = Console.ReadLine();
                            break;
                        case 7:
                            Console.WriteLine("Enter New Zip :");
                            item.Value.Zip = Console.ReadLine();
                            break;
                        case 8:
                            Console.WriteLine("Enter New Phone Number :");
                            item.Value.PhoneNumber = Console.ReadLine();
                            break;
                    }
                    Console.WriteLine("\nEdited Successfully.\n");
                }
            }
        }
        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="bookName">Name of the book.</param>
        public void DeleteContact(string name, string bookName)
        {
            if (addressBookDictionary[bookName].addressBook.ContainsKey(name))
            {
                addressBookDictionary[bookName].addressBook.Remove(name);
                Console.WriteLine("\nDeleted Succesfully.\n");
            }
            else
            {
                Console.WriteLine("\nNot Found, Try Again.\n");
            }
        }
        /// <summary>
        /// Adds the address book.
        /// </summary>
        /// <param name="bookName">Name of the book.</param>
        public void AddAddressBook(string bookName)
        {
            AddressBook addressBook = new AddressBook();
            if (addressBookDictionary.TryAdd(bookName, addressBook))
            {
                Console.WriteLine("AddressBook Created.");
            }
            else
            {
                Console.WriteLine("AddressBook already exists  give new name");
                string newAddressBook = Console.ReadLine();
                AddAddressBook(newAddressBook);
            }

        }
        /// <summary>
        /// Method returns addressBookDictionary
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, AddressBook> GetAddressBook()
        {
            return addressBookDictionary;
        }
        /// <summary>
        /// Gets the list of dictctionary keys.
        /// </summary>
        /// <param name="bookName">Name of the book.</param>
        /// <returns></returns>
        public List<Contact> GetListOfDictctionaryValues(string bookName)
        {
            List<Contact> book = new List<Contact>();
            foreach (var value in addressBookDictionary[bookName].addressBook.Values)
            {
                book.Add(value);
            }
            return book;
        }
        /// <summary>
        /// Gets the list of dictctionary keys.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <returns></returns>
        public List<Contact> GetListOfDictctionaryKeys(Dictionary<Contact, string> d)
        {
            List<Contact> book = new List<Contact>();
            foreach (var value in d.Keys)
            {
                book.Add(value);
            }
            return book;
        }
        /// <summary>
        /// Checks the duplicate entry.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="bookName">Name of the book.</param>
        /// <returns></returns>
        public bool CheckDuplicateEntry(Contact c, string bookName)
        {
            List<Contact> book = GetListOfDictctionaryValues(bookName);
            if (book.Any(b => b.Equals(c)))
            {
                Console.WriteLine("Name already Exists.");
                return true;
            }
            return false;
        }
        /// <summary>
        /// Searches the person by city.
        /// </summary>
        /// <param name="city">The city.</param>
        public void SearchPersonByCity(string city)
        {
            foreach (AddressBook addressbookobj in addressBookDictionary.Values)
            {
                CreateCityDictionary();
                List<Contact> contactList = GetListOfDictctionaryKeys(addressbookobj.cityDictionary);
                foreach (Contact contact in contactList.FindAll(c => c.City.Equals(city)).ToList())
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }
        /// <summary>
        /// Searches the state of the person by.
        /// </summary>
        /// <param name="state">The state.</param>
        public void SearchPersonByState(string state)
        {
            foreach (AddressBook addressbookobj in addressBookDictionary.Values)
            {
                CreateStateDictionary();
                List<Contact> contactList = GetListOfDictctionaryKeys(addressbookobj.stateDictionary);
                foreach (Contact contact in contactList.FindAll(c => c.State.Equals(state)).ToList())
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }
        /// <summary>
        /// Adds contacts data to city dictionary.
        /// </summary>
        public void CreateCityDictionary()
        {
            foreach (AddressBook addressBookObj in addressBookDictionary.Values)
            {
                foreach (Contact contact in addressBookObj.addressBook.Values)
                {
                    addressBookObj.cityDictionary.TryAdd(contact, contact.City);
                }
            }
        }
        /// <summary>
        /// Adds data to State Dictionary
        /// </summary>
        public void CreateStateDictionary()
        {
            foreach (AddressBook addressBookObj in addressBookDictionary.Values)
            {
                foreach (Contact contact in addressBookObj.addressBook.Values)
                {
                    addressBookObj.stateDictionary.TryAdd(contact, contact.State);
                }
            }
        }
        /// <summary>
        /// Displays the state of the contact count by city and state
        /// </summary>
        public void DisplayCountByCityandState()
        {
            CreateCityDictionary();
            CreateStateDictionary();
            Dictionary<string, int> countByCity = new Dictionary<string, int>();
            Dictionary<string, int> countByState = new Dictionary<string, int>();
            foreach (var obj in addressBookDictionary.Values)
            {
                foreach (var person in obj.cityDictionary)
                {
                    countByCity.TryAdd(person.Value, 0);
                    countByCity[person.Value]++;
                }
            }
            Console.WriteLine("City wise count :");
            foreach (var person in countByCity)
            {
                Console.WriteLine(person.Key + ":" + person.Value);
            }
            foreach (var obj in addressBookDictionary.Values)
            {
                foreach (var person in obj.stateDictionary)
                {
                    countByState.TryAdd(person.Value, 0);
                    countByState[person.Value]++;
                }
            }
            Console.WriteLine("State wise count :");
            foreach (var person in countByState)
            {
                Console.WriteLine(person.Key + ":" + person.Value);
            }
        }
        //Methods for User data validation
        public bool ValidateName(string name) => (Regex.IsMatch(name, REGEX_NAME));
        public bool ValidateEmail(string email) => (Regex.IsMatch(email, REGEX_EMAIL));
        public bool ValidateMobileNumber(string mobNumber) => (Regex.IsMatch(mobNumber, REGEX_MOBILE_NUMBER));
        public bool ValidateZip(string zip) => (Regex.IsMatch(zip, REGEX_ZIP));
    }
}