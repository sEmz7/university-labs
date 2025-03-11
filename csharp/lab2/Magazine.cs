using System;
using System.Collections;
using System.Linq;

namespace lab1
{
     enum Frequency
    {
        Weekly,
        Monthly,
        Yearly
    }
    
    class Magazine : Edition, IRateAndCopy
    {
        private string articleName;
        private Frequency frequency;
        private DateTime dateTime;
        private int magazineAmmount;

        private ArrayList editors;
        private ArrayList articles;

        public Magazine(string _articleName, Frequency _frequency, DateTime _dateTime, int _magazineAmmount)
            : base(_articleName, _dateTime, _magazineAmmount)
        {
            articleName = _articleName;
            frequency = _frequency;
            dateTime = _dateTime;
            magazineAmmount = _magazineAmmount;
            editors = new ArrayList();
            articles = new ArrayList();
        }

        public Magazine() : this("Unknown Magazine", Frequency.Monthly, DateTime.Now, 0) { }

        public ArrayList Editors => editors;
        public ArrayList Articles => articles;

        public double AverageRate
        {
            get
            {
                if (articles.Count > 0)
                {
                    double average = 0;
                    foreach (Article article in articles)
                    {
                        average += article.ArticleRate;
                    }
                    return average / articles.Count;
                }
                return 0;
            }
        }

        public IEnumerable<double> ArticlesAboveRating(double ratingThreshold)
        {
            foreach (Article article in articles)
            {
                if (article.ArticleRate > ratingThreshold)
                {
                    yield return article.ArticleRate;
                }
            }
        }

        public IEnumerable<string> ArticlesContainingTitle(string searchString)
        {
            foreach (Article article in articles)
            {
                if (article.ArticleName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                {
                    yield return article.ArticleName;
                }
            }
        }

        public void AddArticles(params Article[] addingArticles)
        {
            foreach (var article in addingArticles)
            {
                articles.Add(article);
            }
        }

        public void AddEditors(params Person[] addingEditors)
        {
            foreach (var editor in addingEditors)
            {
                editors.Add(editor);
            }
        }

        public override string ToString()
        {
            string editorsList = string.Join(", ", editors.Cast<Person>().Select(e => e.ToShortString()));
            string articlesList = string.Join(", ", articles.Cast<Article>().Select(a => a.ToString()));

            return $"Magazine{{Name= {articleName}, Frequency= {frequency}, ReleaseDate= {dateTime}, Ammount= {magazineAmmount}, Editors=[{editorsList}], Articles=[{articlesList}]}}";
        }

        public virtual string ToShortString()
        {
            return $"Name= {articleName}, Frequency= {frequency}, ReleaseDate= {dateTime}, Ammount= {magazineAmmount}, AverageRate= {AverageRate}";
        }

        public override Magazine DeepCopy()
        {
            Magazine copy = new Magazine(articleName, frequency, dateTime, magazineAmmount);
            copy.editors = new ArrayList(editors.Cast<Person>().Select(e => (Person)e.DeepCopy()).ToList());
            copy.articles = new ArrayList(articles.Cast<Article>().Select(a => (Article)a.DeepCopy()).ToList());
            return copy;
        }

        public double Rating => AverageRate;

        public Edition EditionData
        {
            get => this;
            set
            {
                this.Title = value.Title;
                this.ReleaseDate = value.ReleaseDate;
                this.Copies = value.Copies;
            }
        }

        public static bool operator ==(Magazine m1, Magazine m2)
        {
            if (ReferenceEquals(m1, m2)) return true;
            if (m1 is null || m2 is null) return false;
            return m1.Equals(m2);
        }

        public static bool operator !=(Magazine m1, Magazine m2)
        {
            return !(m1 == m2);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Magazine other)
            {
                return articleName == other.articleName &&
                       frequency == other.frequency &&
                       dateTime == other.dateTime &&
                       magazineAmmount == other.magazineAmmount &&
                       editors.Cast<Person>().SequenceEqual(other.editors.Cast<Person>()) &&
                       articles.Cast<Article>().SequenceEqual(other.articles.Cast<Article>());
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(articleName, frequency, dateTime, magazineAmmount, editors, articles);
        }
    }
}
