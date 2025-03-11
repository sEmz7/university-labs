using System;
using System.Diagnostics;

namespace lab1
{

    interface IRateAndCopy {
        double Rating { get;}
        object DeepCopy();
    }

    class Program
    {
        static void Main(string[] args)
        {
            //      1

            Edition edition1 = new Edition("ed", new DateTime(2005, 6, 1), 5000);
            Edition edition2 = new Edition("ed", new DateTime(2005, 6, 1), 5000);

            Console.WriteLine("\n" + ReferenceEquals(edition1, edition2));

            Console.WriteLine(edition1.Equals(edition2));

            Console.WriteLine(edition1.GetHashCode());
            Console.WriteLine(edition2.GetHashCode() + "\n");
        
            //      2

            try
            {
                edition1.Copies = -100;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}\n");
            }
            
            //      3

            Magazine magazine = new Magazine("magaz", Frequency.Monthly, new DateTime(2000, 1, 1), 5000);

            magazine.AddEditors(
                new Person("vasya", "pupkin", new DateTime(1985, 4, 10)),
                new Person("jenya", "pdidy", new DateTime(1990, 7, 20))
            );

            magazine.AddArticles(
                new Article(new Person("tolya", "bobik", new DateTime(1982, 5, 15)), "bbbb", 9.5),
                new Article(new Person("leha", "lepeha", new DateTime(1992, 10, 30)), "aaaa", 8.0)
            );

            Console.WriteLine(magazine + "\n");

            //      4

            Console.WriteLine(magazine.EditionData + "\n");

            //      5

            Magazine magazineCopy = magazine.DeepCopy();

            magazine.AddArticles(new Article(new Person("a", "a", new DateTime(2000, 1, 1)), "NAME", 7.5));
            magazine.AddEditors(new Person("b", "b", new DateTime(2000, 1, 1)));

            Console.WriteLine("Ориг Magazine:");
            Console.WriteLine(magazine + "\n");
            Console.WriteLine("Копия Magazine:");
            Console.WriteLine(magazineCopy + "\n");

            //      6

            double ratingThreshold = 8.0;

            foreach (double rating in magazine.ArticlesAboveRating(ratingThreshold))
            {
                Console.WriteLine($"rating: {rating}");
            }

            //      7

            string searchString = "NAME";

            foreach (string articleTitle in magazine.ArticlesContainingTitle(searchString))
            {
                Console.WriteLine("\nНайден\n");
            }
        }
    }
}