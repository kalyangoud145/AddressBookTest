using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookTest
{
    class Utility
    {
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
