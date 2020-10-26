using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AddressBookTest
{
    /// <summary>
    /// AddressBook implementation class for performing different methods
    /// </summary>
    class AddressBookImplementation
    {
        private Collection<Person> list;
        public AddressBookImplementation()
        {
            this.list = new Collection<Person>();
        }
        /// <summary>
        /// Adds the person to the list
        /// </summary>
        public void AddPerson()
        {
            this.list.Add(AddUser());
            //P is the person object and using list as iterator
            foreach (Person P in list)
            {
                Console.WriteLine(P.ToString());
            }
        }

       //Adding information of person and add it in an object
       //return object of person will give with added information in it
        private Person AddUser()
        {
            Person person = new Person();
            Console.WriteLine(("\n\t\t\tEnter First Name"));
            person.SetFirstName(InputString());
            Console.WriteLine(person.GetFirstName());
            Console.WriteLine("\n\t\t\tEnter Last Name");
            person.SetLastName(InputString());
            Console.WriteLine(person.GetLastName());
            Console.WriteLine("\n\t\t\tEnter city");
            person.SetCity(InputString());
            Console.WriteLine(person.GetCity());
            Console.WriteLine("\n\t\t\tEnter State");
            person.SetState(InputString());
            Console.WriteLine(person.GetState());
            Console.WriteLine("\n\t\t\tEnter ZipCode");
            person.SetZip(InputInteger());
            Console.WriteLine(person.GetZip());
            Console.WriteLine("\n\t\t\tEnter Phone Number");
            person.SetPhoneNumber(InputString());
            Console.WriteLine(person.GetPhoneNumber());
            return person;
        }
        /// <summary>
        /// Editing information of existing Person from list
        /// </summary> 
        static int count = 0;
        public void EditPerson()
        {
            Console.WriteLine("\n\t\t\tEnter last Name of the Peson whose details you want to edit");
            String lastName = InputString();
            foreach (Person P in this.list)
            {
                if (lastName.Equals(P.GetLastName()))
                {
                    count++;
                    Console.WriteLine("\n\t\t\tData found\n");
                    Console.WriteLine("\t\t\t1.To edit Firstname and lastname\n\t\t\t2.To edit city,State and zip\n" + "\t\t\t3. To edit Phone Number\n");
                    int editChoice = (int)InputInteger();
                    switch (editChoice)
                    {
                        case 1:
                            EditAddressBookPerson(P, editChoice);
                            break;
                        case 2:
                            EditAddressBookPerson(P, editChoice);
                            break;
                        case 3:
                            EditAddressBookPerson(P, editChoice);
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
                    P.SetFirstName(InputString());
                    Console.WriteLine("\n\t\t\tEnter the LastName");
                    P.SetLastName(InputString());
                    Console.WriteLine("\n\t\t\tNew Firstname and Lastname are updated");
                    break;
                case 2:
                    Console.WriteLine("\n\t\t\tEnter the state");
                    P.SetState(InputString());
                    Console.WriteLine("\n\t\t\tEnter the city");
                    P.SetCity(InputString());
                    Console.WriteLine("\n\t\t\tEnter the ZipCode");
                    P.SetZip(InputInteger());
                    Console.WriteLine("\n\t\t\tNew city,State and zip are updated");
                    break;
                case 3:
                    Console.WriteLine("\n\t\t\tEnter the new Phone Number");
                    String phoneNumber = InputString();
                    P.SetPhoneNumber(phoneNumber);
                    Console.WriteLine("\n\t\t\tNew Phone Number updated ");
                    break;
            }
        }
        /// <summary>
        /// Deletes the person details based on lastname
        /// </summary>
        public void DeletePerson()
        {
            Console.WriteLine("\n\t\t\tEnter lastname whose data is to be removed");
            string lastName = InputString();
            int count = 0;
            int index = 0;
            Collection<Person> ToRemove = new Collection<Person>();
            //P is the person object and using list as iterator
            foreach (Person P in list)
            {
                if (lastName.Equals(P.GetLastName()))
                {
                    //index gets index value of the person to be deleted
                    index = list.IndexOf(P);
                    Console.WriteLine("\n\t\t\tData found\n\n\t\t\tData Removed");
                    ToRemove.Add(P);
                    count++;
                }
            }
            list.RemoveAt(index);
            //P is the person object and using list as iterator
            foreach (Person P in list)
            {
                Console.WriteLine(P.ToString());
            }
            if (count == 0)
                Console.WriteLine("\n\t\t\tSorry, no such data found");
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
