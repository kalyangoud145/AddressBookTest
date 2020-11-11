﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookTest
{
    /// <summary>
    /// Interface for implementing addressbook
    /// </summary>
    interface IContacts
    {
        public void AddContact(string firstName, string lastName, string address, string city, string state, string email, string zip, string phoneNumber, string bookName);
        public void ViewContact(string name, string bookName);
        public void EditContact(string name, string bookName);
        public void DeleteContact(string name, string bookName);
        public void AddAddressBook(string bookName);
    }
}
