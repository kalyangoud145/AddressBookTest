using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookTest
{
    class Person
    {
        public string firstName;
        public string lastName;
        public string city;
        public string state;
        public long zip;
        public string phoneNumber;

        public void SetFirstName(String firstName)
        {
            this.firstName = firstName;
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public void SetLastName(String lastName)
        {
            this.lastName = lastName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public void SetCity(String city)
        {
            this.city = city;
        }

        public string GetCity()
        {
            return city;
        }

        public void SetState(String state)
        {
            this.state = state;
        }

        public string GetState()
        {
            return state;
        }

        public void SetZip(long zip)
        {
            this.zip = zip;
        }


        public long GetZip()
        {
            return zip;
        }

        public void SetPhoneNumber(String phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public string GetPhoneNumber()
        {
            return phoneNumber;
        }

        override
        public string ToString()
        {
            return "\n\t\t\tPerson \n\t\t\t\tFirst Name : " + firstName + "\n\t\t\t\tLast Name  : " + lastName + "\n\t\t\t\tCity:  " + city + "\n\t\t\t\tState  : " + state + "\n\t\t\t\tzip  : " + zip + "\n\t\t\t\tPhone Number : "
                    + phoneNumber + "\n\n";
        }
    }
}
