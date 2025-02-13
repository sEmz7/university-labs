using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{

    enum Frequency
    {
        Weekly,
        Monthly,
        Yearly
    }

    class Magazine
    {
        private string articleName;
        private Frequency frequency;
        private DateTime dateTime;
        private int magazineAmmount;
        private Article[] arrayOfArticles;

        public Magazine(string _articleName, Frequency _frequency, DateTime _dateTime, int _magazineAmmount)
        {
            articleName = _articleName;
            frequency = _frequency;
            dateTime = _dateTime;
            magazineAmmount = _magazineAmmount;
            arrayOfArticles = new Article[0];
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

        public Frequency Frequency
        {
            get
            {
                return frequency;
            }
            set
            {
                frequency = value;
            }
        }

        public DateTime DateTime
        {
            get
            {
                return dateTime;
            }
            set
            {
                dateTime = value;
            }
        }

        public int Ammount
        {
            get
            {
                return magazineAmmount;
            }
            set
            {
                magazineAmmount = value;
            }
        }

        public Article[] ArrayOfArticles
        {
            get
            {
                return arrayOfArticles;
            }
            set
            {
                arrayOfArticles = value;
            }
        }

        public double AverageRate
        {
            get
            {
                if(arrayOfArticles.Length != 0)
                {
                    double average = 0;
                    for (int i = 0; i < arrayOfArticles.Length; i++)
                    {
                        average += arrayOfArticles[i].Rate;
                    }
                    return (average / arrayOfArticles.Length);
                } else
                {
                    return 0;
                }
                
            }
        }

        public bool this [Frequency f]
        {
            get
            {
                return frequency == f;
            }
        }

        public void addArticles(params Article[] addingArticles)
        {
            arrayOfArticles = arrayOfArticles.Concat(addingArticles).ToArray();
        }

        public override string ToString()
        {
            string result = "Magazine{articleName= " + articleName + ", frequency= " + frequency +
                ", dateTime= " + dateTime + ", magazineAmmount= " + magazineAmmount + ", arrayOfArticles={ ";

            for(int i = 0; i < arrayOfArticles.Length; i++)
            {
                result += arrayOfArticles[i];
                result += ", ";
            }

            return result + "}";
        }

        public virtual string ToShortString()
        {
            return "articleName= " + articleName + ", frequency= " + frequency +
                ", dateTime= " + dateTime + ", magazineAmmount= " + magazineAmmount + ", averageRate= " + AverageRate;
        }
    }
}
