using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBookTest
{
    /// <summary>
    /// Class for file input and output operations
    /// </summary>
    class FileIOOperations
    {
        private string filePath = @"C:\Users\Ravula\source\repos\AddressBookTest\test.txt";
        public void WriteToFile(Dictionary<string, AddressBook> AddressBookMap)
        {
            using StreamWriter writer = new StreamWriter(filePath, true);
            foreach (AddressBook addressBookobj in AddressBookMap.Values)
            {
                foreach (Contact contact in addressBookobj.ContactList)
                {
                    writer.WriteLine(contact.ToString());
                }
            }
            Console.WriteLine("\nSuccessfully added to Text file.");
            writer.Close();
        }
        public void ReadFromFile()
        {
            Console.WriteLine("Below are Contents of Text File");
            string lines = File.ReadAllText(filePath);
            Console.WriteLine(lines);
        }
    }
}
