using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{

    class Article : IRateAndCopy
    {
        public Person Person1{get;set;}
        public string ArticleName{get;set;}
        public double ArticleRate{get;set;}

        public Article(Person _person, string _articleName, double _articleRate)
        {
            Person1 = _person;
            ArticleName = _articleName;
            ArticleRate = _articleRate;
        }

        public Article() : this(new Person("buyer", "default", new DateTime(2025, 02, 12)), "default", 0.0) { }


        public override string ToString()
        {
            return "Article{Person= " + Person1 + "articleName= " + ArticleName + ", articleRate=" + ArticleRate;
        }

        public double Rating => ArticleRate;

        public virtual object DeepCopy()
        {
            return new Article(new Person(Person1.Name, Person1.LastName, Person1.Birth), ArticleName, ArticleRate);
        }

    }
}