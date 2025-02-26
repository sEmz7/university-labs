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
    }
}

