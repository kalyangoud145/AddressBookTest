using System;

namespace AddressBookTest
{
    class MainClass
    {
        static void Main(string[] args)
        {
            AddressBookImplementation addressBookImpl = new AddressBookImplementation();
            addressBookImpl.AddPerson();
            addressBookImpl.EditPerson();
        }
    }
}
