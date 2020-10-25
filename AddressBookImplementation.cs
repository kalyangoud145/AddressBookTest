using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AddressBookTest
{
    class AddressBookImplementation
    {
        private Collection<Person> list;
        Utility utility = new Utility();

        public AddressBookImplementation()
        {
            this.list = new Collection<Person>();
        }

        public void AddPerson()
        {
            this.list.Add(AddUser());
            foreach (Person Q in list)
            {
                Console.WriteLine(Q.ToString());
            }
        }

       //Adding information of person and add it in an object
       //return object of person will give with added information in it
         
        private Person AddUser()
        {
            Person person = new Person();
            Console.WriteLine(("\n\t\t\tEnter First Name"));
            person.SetFirstName(utility.InputString());
            Console.WriteLine(person.GetFirstName());
            Console.WriteLine("\n\t\t\tEnter Last Name");
            person.SetLastName(utility.InputString());
            Console.WriteLine(person.GetLastName());
            Console.WriteLine("\n\t\t\tEnter city");
            person.SetCity(utility.InputString());
            Console.WriteLine(person.GetCity());
            Console.WriteLine("\n\t\t\tEnter State");
            person.SetState(utility.InputString());
            Console.WriteLine(person.GetState());
            Console.WriteLine("\n\t\t\tEnter ZipCode");
            person.SetZip(utility.InputInteger());
            Console.WriteLine(person.GetZip());
            Console.WriteLine("\n\t\t\tEnter Phone Number");
            person.SetPhoneNumber(utility.InputString());
            Console.WriteLine(person.GetPhoneNumber());
            return person;
        }


    }
}
