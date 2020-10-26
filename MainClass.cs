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
			//Created an object for AddressBookImplementation
			AddressBookImplementation addressBookImpl = new AddressBookImplementation();
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
				//Based on input choice switch will  perform different tasks
				switch (choose)
				{
					case 1:
						//AddPerson method is called
						addressBookImpl.AddPerson();
						break;
					case 2:
						//EditPerson method is called
						addressBookImpl.EditPerson();
						break;
					case 3:
						//DeletePerson method is called
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
