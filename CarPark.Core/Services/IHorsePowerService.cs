using CarPark.Core.DTOs;
using CarPark.Core.Model;
using CarPark.Core.Services;
using CarPark.CoreCopy.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.CoreCopy.Services
{
    public interface IHorsePowerService :IService<Vehicle> 
    {
       Task< CustomResponseDto<HorsePowerDto>> HorsePower(string PlateNumber);
    }
}
