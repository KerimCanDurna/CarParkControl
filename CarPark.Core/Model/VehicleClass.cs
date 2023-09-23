using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Core.Model
{
    public class VehicleClass
    {

        public int Id { get; set; }
        public string ClassName { get; set; }
        public int PriceCoefficient { get; set; }


       
        //navigation prop
        public ICollection<Vehicle> Vehicles { get; set; }

    }
}
