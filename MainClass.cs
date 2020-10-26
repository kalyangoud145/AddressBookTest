using System;

namespace AddressBookTest
{
    class MainClass
    {
        static void Main(string[] args)
        {
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
				switch (choose)
				{
					case 1:
						addressBookImpl.AddPerson();
						break;
					case 2:
						addressBookImpl.EditPerson();
						break;
					case 3:
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
