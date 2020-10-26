using System;

namespace AddressBookTest
{
	/// <summary>
	/// Main class where all methods are called
	/// </summary>
    class MainClass
    {
        static void Main(string[] args)
        {
			//Created object of AddressBookImplementation
			AddressBookImplementation addressBookImpl = new AddressBookImplementation();
			//menu for performing different tasks
			int i = 0;
			while (i == 0)
			{
				Console.WriteLine("\t\t\t___________________\n"
						+ "\t\t\t|       Menu             |\n"
						+ "\t\t\t|      ------            |\n"
						+ "\t\t\t| 1. AddPerson           |\n"
						+ "\t\t\t| 2. EditPerson          |\n"
						+ "\t\t\t| 3. DeletePerson        |\n"
						+ "\t\t\t| 4. Close addressbook   |\n"
						+ "\t\t\t|________________________|");
				int choose = (int)addressBookImpl.InputInteger();
				switch (choose)
				{
					case 1:
						//Calls AddPerson method
						addressBookImpl.AddPerson();
						break;
					case 2:
						//calls EditPerson method
						addressBookImpl.EditPerson();
						break;
					case 3:
						//calls DeletePerson method
						addressBookImpl.DeletePerson();
						break;
					case 4:
						Console.WriteLine("Closing the address book");
						i = 1;
						break;
					default:
						Console.WriteLine("Wrong data received select again");
						break;
				}


			}
		}
    }
}
