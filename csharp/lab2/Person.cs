using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{

    
    class Person
    {
        private string _name;
        private string _lastname;
        private DateTime _dateTime;

        public Person(string name, string lastname, DateTime dateTime)
        {
            _name = name;
            _lastname = lastname;
            _dateTime = dateTime;

        }
        public Person()
        {
            _name = "semzz";
            _lastname = "premovskiy";
            _dateTime = new DateTime(2005, 10, 07);
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
            }
        }

        public DateTime Birth
        {
            get
            {
                return _dateTime;
            }
            set
            {
                _dateTime = new DateTime(value.Year, value.Month, value.Day);
            }
        }

        public int Year
        {
            get
            {
                return _dateTime.Year;
            }
            set
            {
                _dateTime.AddYears(value - _dateTime.Year);
            }
        }

        public override string ToString()
        {
            return "Person{name= " + _name + ", lastname= " + _lastname + ", dateTime= " + _dateTime + "}";
        }

        public virtual string ToShortString()
        {
            return _name + " " + _lastname;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Person other)
            {
                return _name == other._name &&
                       _lastname == other._lastname &&
                       _dateTime == other._dateTime;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_name, _lastname, _dateTime);
        }

        public static bool operator ==(Person p1, Person p2)
        {
            if (ReferenceEquals(p1, p2)) return true;
            if (p1 is null || p2 is null) return false;
            return p1.Equals(p2);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }

         public virtual object DeepCopy()
        {
            return new Person(_name, _lastname, new DateTime(_dateTime.Year, _dateTime.Month, _dateTime.Day));
        }
    }
}
