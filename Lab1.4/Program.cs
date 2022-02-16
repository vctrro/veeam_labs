using System;
using System.Text;

namespace Lab1_4_String_Exception
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\n----- Exercise 1 -----\n");
            string[] strings = { "Salı", "Вторник", "Mardi", "Τρίτη", "Martes", "יום שלישי", "วันอังคาร", "الثلاثاء", "日曜日" };

            foreach (var str in strings)
            {
                var serializedStr = SerializeString(str);
                foreach (var bt in serializedStr)
                {
                    Console.Write(bt + " ");
                }
                Console.WriteLine();

                var deserializedStr = DeserializeString(serializedStr);
                Console.WriteLine(deserializedStr);
            }
        }

        public static byte[] SerializeString(string source)
        {
            return Encoding.Unicode.GetBytes(source);
        }
    
        public static string DeserializeString(byte[] source)
        {
            var deserializedStr = Encoding.Unicode.GetChars(source);
            StringBuilder result = new();
            return result.Append(deserializedStr).ToString();
        }
    }

}

