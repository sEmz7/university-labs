using System;
using System.Diagnostics;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Magazine magazine = new Magazine("name", Frequency.Monthly, new DateTime(2025, 02, 12), 10);
            Console.WriteLine(magazine);

            Console.WriteLine("\n" + magazine[Frequency.Monthly]);
            Console.WriteLine(magazine[Frequency.Weekly]);
            Console.WriteLine(magazine[Frequency.Yearly]);

            magazine.Name = "test";
            magazine.Frequency = Frequency.Yearly;
            magazine.DateTime = new DateTime(2077, 7, 17);
            magazine.Ammount = 777;
            Console.WriteLine("\n" + magazine);

            Article[] articles = new Article[] { new Article(new Person("sem", "sem", new DateTime(2005, 10, 07)), "artname1", 10.0) };
            magazine.addArticles(articles);
            Console.WriteLine("\n" + magazine);



            Article[] singleCheck = new Article[1000000];
            for(int i = 0; i < 1000000; i++)
            {
                singleCheck[i] = new Article();
            }


            Article[,] doubleCheck = new Article[1000, 1000];
            for (int i = 0; i < 1000; i++)
            {
                for(int j = 0; j < 1000; j++)
                {
                    doubleCheck[i, j] = new Article();
                }
            }

            Article[][] stepCheck = new Article[1000][];
            for (int i = 0; i < 1000; i++)
            {
                stepCheck[i] = new Article[1000];
                for(int j = 0; j < 1000; j++)
                {
                    stepCheck[i][j] = new Article();
                }
            }

            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                singleCheck[i].ArticleName = "newname";
            }
            watch.Stop();
            Console.WriteLine("\nОдномерный[1000000] = " + watch.ElapsedMilliseconds + " ms");


            watch.Restart();
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    doubleCheck[i, j].ArticleName = "newName";
                }
            }
            watch.Stop();
            Console.WriteLine("Двумерный[1000,1000] = " + watch.ElapsedMilliseconds + " ms");

            watch.Restart();
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    stepCheck[i][j].ArticleName = "namenew";
                }
            }
            watch.Stop();

            Console.WriteLine("Ступенчатый[1000][] = " + watch.ElapsedMilliseconds + " ms");
        }
    }
}
