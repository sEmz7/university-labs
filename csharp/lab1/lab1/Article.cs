using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    
    class Article
    {
        private Person person;
        private string articleName;
        private double articleRate;

        public Article(Person _person, string _articleName, double _articleRate)
        {
            person = _person;
            articleName = _articleName;
            articleRate = _articleRate;
        }

        public Article() : this(new Person("buyer", "default", new DateTime(2025, 02, 12)), "default", 0.0) { }


        public Person Person
        {
            get
            {
                return person;
            }
            set
            {
                person = value;
            }
        }
        public string Name
        {
            get
            {
                return articleName;
            }
            set
            {
                articleName = value;
            }
        }

        public double Rate
        {
            get
            {
                return articleRate;
            }
            set
            {
                articleRate = value;
            }
        }

        public override string ToString()
        {
            return "Article{Person= " + person + "articleName= " + articleName + ", articleRate=" + articleRate;
        }

    }
}
