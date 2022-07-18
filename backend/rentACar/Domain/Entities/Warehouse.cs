using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Warehouse : Entity
    {
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int CarId { get; set; }


        public virtual ICollection<Car> Cars { get; set; }



        public virtual Location? Location { get; set; }


        public Warehouse()
        {
            Cars = new HashSet<Car>();

        }

        public Warehouse(int id, int locationId, int carId, string name) : base(id)
        {
            Id = id;
            Name = name;
            LocationId = locationId;
            CarId = carId;
        }
    }
}
