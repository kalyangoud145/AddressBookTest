using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace AddressBookTest
{
    /// <summary>
    /// Main class where all methods are called
    /// </summary>
    class MainClass
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// Defines the entry point of the application.
            /// Calls StartProgram function
            /// </summary>
            /// <param name="args">The arguments.</param>
            MultipleAddressBook multipleAddressBook = new MultipleAddressBook();
            multipleAddressBook.multipleBook();
        }
    }
}