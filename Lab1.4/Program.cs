using System;
using System.Linq;
using System.Runtime.ExceptionServices;
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
                    .Select(b => b.ToString("D3"))
                    .Aggregate((x, y) => x + "-" + y);
                Console.Write("Dec: ");
                Console.WriteLine(stringOfBytes);

                var deserializedStr = DeserializeString(serializedStr);
                Console.WriteLine(deserializedStr);
                Console.WriteLine();
            }

            Console.WriteLine("\n----- Exercise 2 -----\n");
            
            Console.WriteLine("Enter a name, then a phone number");
            try
            {
                Person person = Person.CreatePerson(
                    Console.ReadLine(),
                    Console.ReadLine()
                );
            }
            catch (Exception ex)
            {
                ExceptionHandler.PrintException(ex, "Exception in Person after second trow");
            }

            try
            {
                ExceptionDispatchInfo.Throw(ExceptionHandler.LastException);
            }
            catch (Exception ex)
            {
                ExceptionHandler.PrintException(ex, "Exception from Exceptions thrown with DispatchInfo");
            }

            try
            {
                ExceptionHandler.LastDispatchInfos?.Throw();
            }
            catch (Exception ex)
            {
                ExceptionHandler.PrintException(ex, "Exception from DispatchInfos");
            }

            try
            {
                ExceptionDispatchInfo.Throw(ExceptionHandler.LastException);
            }
            catch (Exception ex)
            {
                ExceptionHandler.PrintException(ex, "Exception from Exceptions thrown with DispatchInfo 2");
            }

            try
            {
                throw ExceptionHandler.LastException;
            }
            catch (Exception ex)
            {
                ExceptionHandler.PrintException(ex, "Exception from Exceptions");
            }

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

