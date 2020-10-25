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

        //Editing information of existing Person from list 
        static int count = 0;
        public void EditPerson()
        {
            Console.WriteLine("\n\t\t\tEnter last Name of the Peson whose details you want to edit");
            String lastName = utility.InputString();
            foreach (Person P in this.list)
            {
                if (lastName.Equals(P.GetLastName()))
                {
                    count++;
                    Console.WriteLine("\n\t\t\tData found\n");
                    Console.WriteLine("\t\t\t1.To edit Firstname and lastname\n\t\t\t2.To edit city,State and zip\n" + "\t\t\t3. To edit Phone Number\n");
                    int editChoice = (int)utility.InputInteger();
                    switch (editChoice)
                    {
                        case 1:
                            EditAddressBookPerson(P, 1);
                            break;
                        case 2:
                            EditAddressBookPerson(P, 2);
                            break;
                        case 3:
                            EditAddressBookPerson(P, 3);
                            break;
                        default:
                            Console.WriteLine("\t\t\tSomething went wrong\n" + "\t\t\tTry again later");
                            break;
                    }
                }
            }
            if (count == 0)
                Console.WriteLine("\n\t\t\tData not found");
        }

        //Editing of Firstname, lastname, state, city, zip  and phone number
		// P is the person object
		// i is the case for editing address or phone number
        private void EditAddressBookPerson(Person P, int i)
        {
            switch (i)
            {
                case 1:
                    Console.WriteLine("\n\t\t\tEnter the FirstName");
                    P.SetFirstName(utility.InputString());
                    Console.WriteLine("\n\t\t\tEnter the LastName");
                    P.SetLastName(utility.InputString());
                    Console.WriteLine("\n\t\t\tNew Firstname and Lastname are updated");
                    break;
                case 2:
                    Console.WriteLine("\n\t\t\tEnter the state");
                    P.SetState(utility.InputString());
                    Console.WriteLine("\n\t\t\tEnter the city");
                    P.SetCity(utility.InputString());
                    Console.WriteLine("\n\t\t\tEnter the ZipCode");
                    P.SetZip(utility.InputInteger());
                    Console.WriteLine("\n\t\t\tNew city,State and zip are updated");
                    break;
                case 3:
                    Console.WriteLine("\n\t\t\tEnter the new Phone Number");
                    String phoneNumber = utility.InputString();
                    P.SetPhoneNumber(phoneNumber);
                    Console.WriteLine("\n\t\t\tNew Phone Number updated ");
                    break;
            }
        }


    }
}
