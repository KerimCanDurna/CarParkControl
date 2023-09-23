using CarPark.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.CoreCopy.DTOs
{
    public class UpdateVehicleDto 
    {
        public string PlateNumber { get; set; }
        public decimal Fee { get; set; }
    }
}
