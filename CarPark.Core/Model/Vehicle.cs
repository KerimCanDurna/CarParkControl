using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Core.Model
{
    public  class Vehicle
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string PlateNumber { get; set; }
        public int ModelYear { get; set; }
        public int EnginePower { get; set; }
        public int HorsePower { get; set; }
        public string Color { get; set; }
        
        public decimal Fee { get; set; }

        public int Utility { get; set; }
        public Boolean LoggedOut { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int VehicleClassId { get; set; } // Araç sınıfı (1, 2,3)




        public VehicleClass VehicleClasses { get; set; }
        public FirstClassVehicle FirstClassVehicle { get; set; }
        public SecondClassVehicle SecondClassVehicle { get; set; }


    }

    
}
