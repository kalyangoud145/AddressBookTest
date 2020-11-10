using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AddressBookTest
{
    /// <summary>
    /// AddressBook implementation class for performing different methods
    /// </summary>
    class AddressBook 
    {
        //ContactList for maintaining person details
        public List<Contact> ContactList;
        public AddressBook()
        {
            this.ContactList = new List<Contact>();
        }
        //Add Contact to Address Book
        public void AddContact(Contact contactObj)
        {
            //Checks if any duplicates exists
            if (this.ContactList.Find(e => e.Equals(contactObj)) != null)
                Console.WriteLine("The Contact Already Exists! Try Again.");
            else
                this.ContactList.Add(contactObj);
        }
        //Find Contact Object Index By Mobile Number
        public int FindByPhoneNum(long phoneNumber)
        {
            return this.ContactList.FindIndex(contact => contact.PhoneNumber.Equals(phoneNumber));
        }
        //Find Contact Object Index By FirstName
        public int FindByFirstName(string firstName)
        {
            return this.ContactList.FindIndex(contact => contact.FirstName.Equals(firstName));
        }
        //Delete a Given Contact By Index passed
        public void DeleteContact(int index)
        {
            this.ContactList.RemoveAt(index);
        }
        /// <summary>
        /// Sorts the persons based on the first name
        /// </summary>
        /// <returns></returns>
        public List<Contact> SortByFirstName()
        {
            
            return this.ContactList.OrderBy(contact => contact.FirstName).ToList();
        }
        /// <summary>
        /// Displays all the list
        /// </summary>
        public void Display()
        {
            foreach(Contact contacts in ContactList)
            {
                Console.WriteLine(contacts.ToString());
            }
        }
        /// <summary>
        /// Sorts the persons by city
        /// </summary>
        /// <returns></returns>
        public List<Contact> SortByCity()
        {
            return this.ContactList.OrderBy(contact => contact.City).ToList();
        }
        /// <summary>
        /// Sorts the persons by state
        /// </summary>
        /// <returns></returns>
        public List<Contact> SortByState()
        {
            return this.ContactList.OrderBy(contact => contact.State).ToList();
        }
        /// <summary>
        /// Sorts the persons by zip
        /// </summary>
        /// <returns></returns>
        public List<Contact> SortByZip()
        {
            return this.ContactList.OrderBy(contact => contact.Zip).ToList();
        }
    }
}