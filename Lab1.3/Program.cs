using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Lab1_3_LINQ
{
    class Program
    {
        static void Main()
        {
            Person[] people = new[] {
                new Person("Pit"),
                new Person("Bob"),
                new Person("Tyron"),
                new Person("Mary"),
                new Person("Victor"),
                new Person("Igor"),
                new Person("Max")
            };

            Console.WriteLine("\n----- Exercise 1 -----\n");
            Console.WriteLine(GetAllWithoutFirst3(people, '-'));

            Console.WriteLine("\n----- Exercise 2 -----\n");
            var newPeople = GetAllWithNameLengthGreaterThenIndex(people);
            newPeople.ForEach(np => Console.WriteLine(np.Name));

            Console.WriteLine("\n----- Exercise 3 -----\n");
            GroupWordsByLength("Это что же получается: ходишь, ходишь в школу, а потом бац - вторая смена");

            Console.WriteLine("\n----- Exercise 4 -----\n");
            var dictionary = CreateDictionary("This dog eats too much vegetables after lunch",
                "Эта собака ест слишком много овощей после обеда");
            PrintTranslatedBook("This dog eats too much vegetables after lunch", dictionary, 2);
        }

        public static string GetAllWithoutFirst3(IEnumerable<INamed> source, char delimeter)
        {
            return source
                .Skip(3)
                .Select(named => named.Name)
                .Aggregate((x, y) => x + delimeter + y);
        }

        public static List<INamed> GetAllWithNameLengthGreaterThenIndex(IEnumerable<INamed> source)
        {
            return source
                .Select((named, index) => named.Name.Length > index + 1 ? named : null)
                .Where(n => n != null)
                .ToList();
        }

        public static void GroupWordsByLength(string source)
        {
            var punctMarks = @" .,/'-""=+\><?:;!&)(*~`".ToCharArray();
            var result = source
                .Split(punctMarks)
                .Where(s => s != "")
                .Select(s => s.ToLower())
                .OrderByDescending(s => s.Length)
                .GroupBy(s => s.Length,
                    (length, words) => new
                    {
                        Count = words.Count(),
                        Length = length,
                        Words = words
                    })
                .Select((group, index) => new
                    {
                        GroupId = index+1,
                        group.Count,
                        group.Length,
                        group.Words
                    })
                .OrderByDescending(g => g.Count);

            foreach (var group in result)
            {
                Console.Write("Группа {0}. Длина {1}. Количество {2}.\n", group.GroupId, group.Length, group.Count);
                foreach (var item in group.Words)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static void PrintTranslatedBook(string book, Dictionary<string, string> dictionary, int wordsOnPage)
        {
            var translatedBook =
                from word in book.Split().Select(s => s.ToLower())
                select dictionary[word].ToUpper();

            while (translatedBook.Any())
            {
                Console.WriteLine(translatedBook.Take(wordsOnPage).Aggregate((x, y) => x + " " + y));
                translatedBook = translatedBook.Skip(wordsOnPage);
            }
        }

        public static Dictionary<string, string> CreateDictionary(string from, string to)
        {
            return from
                .ToLower()
                .Split()
                .Zip(to.ToLower()
                        .Split(), (from, to) => new { from, to })
                .ToDictionary(d => d.from, d => d.to);
        }
    }
}
