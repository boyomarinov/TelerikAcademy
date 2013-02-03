using System;
using System.Text;

class Encrypt
{
    static string EncryptText(string text, string cypher)
    {
        StringBuilder encrypted = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            //make sure you cast to char in order not to pass 
            //integer values of encrypted text to the result
            encrypted.Append((char)(text[i] ^ cypher[i % cypher.Length]));
        }
        return encrypted.ToString();
    }

    static void Main()
    {
        string text = "Hello world";
        string cypher = "123";
        string encrypted = EncryptText(text, cypher);
        Console.WriteLine(encrypted);
        Console.WriteLine(EncryptText(encrypted, cypher));
    }
}
