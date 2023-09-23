using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Core.DTOs
{
    public class VehicleDTO
    {

        
        public string ModelName { get; set; }
        public string PlateNumber { get; set; }
        public int ModelYear { get; set; }
        public string Color { get; set; }
        public DateTime CheckInDate { get; set; }
         public int EnginePower { get; set; } 
    

    }
}
