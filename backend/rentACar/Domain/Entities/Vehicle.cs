using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vehicle : Entity
    {
        //id,model,make,year_model,price,licensed,date_added
        public string Make { get; set; }
        public string Model { get; set; }
        public short YearModel { get; set; }
        public double Price { get; set; }
        public bool Licensed { get; set; }
        public DateTime DateAdded { get; set; }


        public Vehicle()
        {

        }

        public Vehicle(int id, string make, string model, short yearModel, double price, bool licensed, DateTime dateAdded) : base(id)
        {
            Id = id;
            Make = make;
            Model = model;
            YearModel = yearModel;
            Price = price;
            Licensed = licensed;
            DateAdded = dateAdded;
        }
    }
}
