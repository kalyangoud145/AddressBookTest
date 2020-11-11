using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program.");
            AddressBook addressBook = new AddressBook();
            int choice, choice2;
            string bookName = "default";
            Console.WriteLine("\t\t\t__________________________________\n"
                       + "\t\t\t|       Menu                      |\n"
                       + "\t\t\t|      ------                     |\n"
                       + "\t\t\t| 1. Work on default AddressBook  |\n"
                       + "\t\t\t| 2. Create New AddressBook       |\n"
                       + "\t\t\t|_________________________________|");
            choice2 = Convert.ToInt32(Console.ReadLine());
            switch (choice2)
            {
                case 1:
                    addressBook.AddAddressBook(bookName);
                    break;
                case 2:
                    Console.WriteLine("Enter Name Of New Addressbook You want to create : ");
                    bookName = Console.ReadLine();
                    addressBook.AddAddressBook(bookName);
                    break;
                default:
                    Console.WriteLine("Invalid Input, Proceeding with default AddressBook");
                    addressBook.AddAddressBook(bookName);
                    break;
            }
            do
            {
                Console.WriteLine($"Working On {bookName} AddressBook\n");
                Console.WriteLine("\t\t\t__________________________________\n"
                      + "\t\t\t|       Menu                      |\n"
                      + "\t\t\t|      ------                     |\n"
                      + "\t\t\t| 1. Add Contact                  |\n"
                      + "\t\t\t| 2. Edit Contact                 |\n"
                      + "\t\t\t| 3. Delete Contact               |\n"
                      + "\t\t\t| 4. View A Contact               |\n"
                      + "\t\t\t| 5. View All Contacts            |\n"
                      + "\t\t\t| 6. Create new address book      |\n"
                      + "\t\t\t| 7. Display address books present|\n"
                      + "\t\t\t| 8. Search by city or state      |\n"
                      + "\t\t\t| 9. Person count by city ,state  |\n"
                      + "\t\t\t| 0.Exit                          |\n"
                      + "\t\t\t|_________________________________|");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter First Name :");
                        string firstName = Console.ReadLine();
                        if (addressBook.ValidateName(firstName) == false)
                        {
                            Console.WriteLine("Entered name is not in valid format enter again");
                            firstName = Console.ReadLine();
                        }
                        Console.WriteLine("Enter Last Name :");
                        string lastName = Console.ReadLine();
                        if (addressBook.ValidateName(lastName) == false)
                        {
                            Console.WriteLine("Entered name is not in valid format enter again");
                            lastName = Console.ReadLine();
                        }
                        Contact temp = new Contact()
                        {
                            FirstName = firstName,
                            LastName = lastName
                        };
                        if (addressBook.CheckDuplicateEntry(temp, bookName))
                        {
                            break;
                        }
                        Console.WriteLine("Enter Address :");
                        string address = Console.ReadLine();
                        Console.WriteLine("Enter City :");
                        string city = Console.ReadLine();
                        Console.WriteLine("Enter State :");
                        string state = Console.ReadLine();
                        Console.WriteLine("Enter Email :");
                        string email = Console.ReadLine();
                        if (addressBook.ValidateEmail(email) == false)
                        {
                            Console.WriteLine("Entered email is not in valid format enter again");
                            email = Console.ReadLine();
                        }
                        Console.WriteLine("Enter Zip :");
                        string zip = Console.ReadLine();
                        if (addressBook.ValidateZip(zip))
                        {
                            Console.WriteLine("Entered email is not in valid format enter again");
                            zip = Console.ReadLine();
                        }
                        Console.WriteLine("Enter Phone Number :");
                        string phoneNumber = Console.ReadLine();
                        if (addressBook.ValidateMobileNumber(phoneNumber) == false)
                        {
                            Console.WriteLine("Entered name is not in valid format enter again");
                            phoneNumber = Console.ReadLine();
                        }
                        addressBook.AddContact(firstName, lastName, address, city, state, email, zip, phoneNumber, bookName);
                        break;
                    case 2:
                        Console.WriteLine("Enter First Name Of Contact To Edit :");
                        string nameToEdit = Console.ReadLine();
                        addressBook.EditContact(nameToEdit, bookName);
                        break;
                    case 3:
                        Console.WriteLine("Enter First Name Of Contact To Delete :");
                        string nameToDelete = Console.ReadLine();
                        addressBook.DeleteContact(nameToDelete, bookName);
                        break;
                    case 4:
                        Console.WriteLine("Enter First Name Of Contact To View :");
                        string nameToView = Console.ReadLine();
                        addressBook.ViewContact(nameToView, bookName);
                        break;
                    case 5:
                        addressBook.ViewContact(bookName);
                        break;
                    case 6:
                        Console.WriteLine("Enter Name For New AddressBook");
                        string newAddressBook = Console.ReadLine();
                        addressBook.AddAddressBook(newAddressBook);
                        Console.WriteLine("Would you like to Switch to " + newAddressBook);
                        Console.WriteLine("1.Yes \n2.No");
                        int c = Convert.ToInt32(Console.ReadLine());
                        if (c == 1)
                        {
                            bookName = newAddressBook;
                        }
                        break;
                    case 7:
                        Console.WriteLine("Enter Name Of AddressBook From Below List");
                        foreach (KeyValuePair<string, AddressBook> item in addressBook.GetAddressBook())
                        {
                            Console.WriteLine(item.Key);
                        }
                        while (true)
                        {
                            bookName = Console.ReadLine();
                            if (addressBook.GetAddressBook().ContainsKey(bookName))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No such AddressBook found. Try Again.");
                            }
                        }
                        break;
                    case 8:
                        Console.WriteLine("Would You Like To \n1.Search by city \n2.Search by state");
                        int opt = Convert.ToInt32(Console.ReadLine());
                        switch (opt)
                        {
                            case 1:
                                Console.WriteLine("Enter name of city :");
                                addressBook.SearchPersonByCity(Console.ReadLine());
                                break;
                            case 2:
                                Console.WriteLine("Enter name of state :");
                                addressBook.SearchPersonByState(Console.ReadLine());
                                break;
                            default:
                                Console.WriteLine("Invalid Input.Enter 1 or 2");
                                break;
                        }
                        break;
                    case 9:
                        addressBook.DisplayCountByCityandState();
                        break;
                    case 0:
                        Console.WriteLine("Thank You For Using Address Book System.");
                        break;
                    default:
                        Console.WriteLine("Invalid Entry. Enter value between 0 to 7");
                        break;
                }
            } while (choice != 0);
        }
    }
}
