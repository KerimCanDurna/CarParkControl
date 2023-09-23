using AutoMapper;
using CarPark.Core.DTOs;
using CarPark.Core.Model;
using CarPark.CoreCopy.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Service.Mapping
{
    public class MapProfile :Profile
    {
        public MapProfile()
        {
            CreateMap<Vehicle,VehicleDTO>().ReverseMap();
            CreateMap<Vehicle,FirstClassVehicleDto>().ReverseMap();
            CreateMap<Vehicle,SecondClassVehicleDto>().ReverseMap();
            CreateMap<Vehicle,UpdateVehicleDto>().ReverseMap();
            CreateMap<Vehicle,HorsePowerDto>().ReverseMap();

        }
    }
}
