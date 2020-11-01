using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookTest
{
    /// <summary>
    /// Interface for Addperson,Editperson,Deleteperson
    /// </summary>
    interface AddressBookInterface
    {
        public void AddContacts();
        public void editContact();
        public void deleteContact();
    }
}
