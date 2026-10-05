using System;
using System.Collections.Generic;
using System.Text;

namespace HotelConsoleApp.Model
{
    public class Customer
    {
        //Properties
        public int Id
        { get; set; }

        public string Name
        { get; set; }

        public string Phone
        { get; set; }

        //Constructors

        public Customer()
        {
            Id = 0;
            Name = "";
            Phone = "";

        }

        public Customer(int id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }

        public override string ToString()
        {
            return $" ID: {Id} \n" +
                $"Name: {Name} \n" +
                  $"Phone number: {Phone}";
        }


    }
}
