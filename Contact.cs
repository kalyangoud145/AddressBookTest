using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookTest
{
    class Contact
    {
        /// <summary>
        /// Gets or sets the person details
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            Contact contact = obj as Contact;
            if (obj == null)
                return false;
            return this.PhoneNumber.Equals(contact.PhoneNumber);
        }
        //Prints the Person details
        public override string ToString()
        {
            return $"Name : {FirstName} {LastName} \nAddress : {Address} \nCity : {City} \nState : {State} \nZip : {Zip} \nPhone : {PhoneNumber} \nEmail : {Email}";
        }
    }
}
