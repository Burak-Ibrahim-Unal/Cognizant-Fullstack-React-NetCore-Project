using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car : Entity
    {
        //id,location,vehiclesId
        public string Location { get; set; }
        public int VehicleId { get; set; }


        public virtual ICollection<Vehicle> Vehicles { get; set; }


        public Car()
        {
            Vehicles = new HashSet<Vehicle>();

        }

        public Car(int id, int vehicleId, string location) : base(id)
        {
,           Location = location;
            VehicleId = vehicleId;
            Id = id;
        }
    }
}
