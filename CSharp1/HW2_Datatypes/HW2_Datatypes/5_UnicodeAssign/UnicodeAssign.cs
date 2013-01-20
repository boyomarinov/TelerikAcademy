using System;

    class UnicodeAssign
    {
        static void Main()
        {
            string hexRappresentation = "0x48";
            char unicodeVar = Convert.ToChar(Convert.ToInt32(hexRappresentation, 16));
            Console.WriteLine("{0} -> {1}", hexRappresentation, unicodeVar);
            //Console.WriteLine((char)72);
        }
    }

