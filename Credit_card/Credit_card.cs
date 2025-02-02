using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit_Card
{
    public class expiration_date
    {
        public int month {  get; set; }
        public int year { get; set; }

        public expiration_date(int month, int year)
        {
            this.month = month;
            this.year = year;
        }

        public void print_date()
        {
            Console.WriteLine($"{month}m/{year}y");
        }
    }
    
    internal class Credit_card
    {
        public string name { get; set; }
        public long number { get; set; }
        
        public int CVV { get; set; }
        public expiration_date Expiration_Date { get; set; }
        public int current_cash { get; set; }

        public Credit_card() { }
        public Credit_card(string name, long number, int cVV, int month, int year,int current_cash)
        {
            setName(name);
            setNumber(number);
            setCVV(cVV);
            this.Expiration_Date = setExpirationDate(month, year);
            this.current_cash = current_cash;

        }

        public void setName(string name)
        {
            if (!IsStringWithoutNumbers(name))
            {
                throw new ArgumentException("Name can't contain numbers!");
            }
            else
            {
                this.name = name;
            }
        }
        public void setNumber(long number)
        {
            if (countoff(number) < 16 || countoff(number) > 16)
            {
                throw new Exception("Card number can't contain less or more  than 16 numbers!");
            }
            else
            {
                this.number = number;
            }
        }

        public void setCVV(int CVV)
        {
            if (CVV < 100 || CVV > 999)
            {
                throw new Exception("CVV can't be more than 999 and less than 100");
            }
            else
            {
                this.CVV = CVV;
            }
        }
        public expiration_date setExpirationDate(int month, int year)
        {
            DateTime checker = DateTime.Now;
            if(month < 1 || month > 12)
            {
                throw new Exception("Month can't be more than 12 and less than 1");
            }
            else if(year < checker.Year)
            {
                throw new Exception("Oops, seems like your card expired or you wrote wrong year :)");
            }
            else
            {
                return new expiration_date(month, year);
            }
        }
        public void print()
        {
            Console.Write($"Card\nowner`s name: {name}\ncard`s number: {number}\nExpiration date: ");
            Expiration_Date.print_date();
            Console.WriteLine($"Current cash: {current_cash}");
        }

        public void add_cash(int cash)
        {
            if(cash < 0)
            {
                throw new Exception("You can't add minus!");
            }
            else
            {
                this.current_cash += cash;
            }
        }

        

        public bool IsStringWithoutNumbers(string input)
        {
            return input.All(c => !char.IsDigit(c));
        }

        public int countoff(long number)
        {
            int counter = 0;
            string number_str = number.ToString();
            foreach(char cha in number_str)
            {
                counter++;
            }
            return counter;
        }

        
    }
}
