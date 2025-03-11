using System;

namespace lab1
{

    
    class Edition
    {
        protected string title;
        protected DateTime releaseDate;
        protected int copies;

        public Edition(string title, DateTime releaseDate, int copies)
        {
            this.title = title;
            this.releaseDate = releaseDate;
            Copies = copies;
        }

        public Edition() : this("Unknown Edition", DateTime.Now, 0) { }

        public string Title
        {
            get => title;
            set => title = value;
        }

        public DateTime ReleaseDate
        {
            get => releaseDate;
            set => releaseDate = value;
        }

        public int Copies
        {
            get => copies;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Тираж не может быть отрицательным. Допустимые значения: 0 и выше.");
                }
                copies = value;
            }
        }

        public virtual object DeepCopy()
        {
            return new Edition(title, releaseDate, copies);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Edition other)
            {
                return title == other.title &&
                       releaseDate == other.releaseDate &&
                       copies == other.copies;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(title, releaseDate, copies);
        }

        public override string ToString()
        {
            return $"Edition{{Title= {title}, ReleaseDate= {releaseDate.ToShortDateString()}, Copies= {copies}}}";
        }

        public static bool operator ==(Edition? e1, Edition? e2)
        {
            if (ReferenceEquals(e1, e2)) return true;
            if (e1 is null || e2 is null) return false;
            return e1.Equals(e2);
        }

        public static bool operator !=(Edition? e1, Edition? e2)
        {
            return !(e1 == e2);
        }
    }
}
