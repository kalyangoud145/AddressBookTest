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
            person.SetFirstName("Ravula");
            Console.WriteLine(person.GetFirstName());
            Console.WriteLine("\n\t\t\tEnter Last Name");
            person.SetLastName("Kalyan");
            Console.WriteLine(person.GetLastName());
            Console.WriteLine("\n\t\t\tEnter city");
            person.SetCity("Nalgonda");
            Console.WriteLine(person.GetCity());
            Console.WriteLine("\n\t\t\tEnter State");
            person.SetState("Telangana");
            Console.WriteLine(person.GetState());
            Console.WriteLine("\n\t\t\tEnter ZipCode");
            person.SetZip(508001);
            Console.WriteLine(person.GetZip());
            Console.WriteLine("\n\t\t\tEnter Phone Number");
            person.SetPhoneNumber("7732063720");
            Console.WriteLine(person.GetPhoneNumber());
            return person;
        }


    }
}
