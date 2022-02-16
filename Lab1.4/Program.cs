using System;
using System.Linq;
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
                Console.Write("Hex: ");
                Console.WriteLine(BitConverter.ToString(serializedStr));
                var stringOfBytes = serializedStr
                    .Select(b => b.ToString("000"))
                    .Aggregate((x, y) => x + "-" + y);
                Console.Write("Dec: ");
                Console.WriteLine(stringOfBytes);

                var deserializedStr = DeserializeString(serializedStr);
                Console.WriteLine(deserializedStr);
                Console.WriteLine();
            }

            Console.WriteLine("\n----- Exercise 2 -----\n");
        }

        public static byte[] SerializeString(string source)
        {
            return Encoding.Unicode.GetBytes(source);
        }
    
        public static string DeserializeString(byte[] source)
        {
            return Encoding.Unicode.GetString(source);

            //var deserializedChrs = Encoding.Unicode.GetChars(source);
            //StringBuilder result = new(deserializedStr.Length + 1);
            //return result.Append(deserializedChrs).ToString();
        }
    }

}

