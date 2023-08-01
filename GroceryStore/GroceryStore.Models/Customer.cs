using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        private char sex;
        public char Sex
        {
            get { return sex; }
            set { sex = char.ToUpper(value); }
        }
        public bool hasDiscountCard { get; set; }

        private float personalDiscount;

        public float PersonalDicount
        {
            get
            {
                return (hasDiscountCard) ? personalDiscount : 0f;
            }
            set
            {
            }
        }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public string[] Cart = new string[100];

        public Customer(string FirstName, string LastName, int Age, char Sex, bool hasDiscountCard, float personalDiscount=0.0f)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.Sex = Sex;
            this.hasDiscountCard = hasDiscountCard;
            this.PersonalDicount = personalDiscount;
        }
    }
}
