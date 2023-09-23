using CarPark.Core.DTOs;
using CarPark.Core.Model;
using CarPark.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.CoreCopy.Services
{
    public interface IUtilitiesService : IService<Vehicle>
    {

        Task<CustomResponseDto<VehicleDTO>> CarWashingUtility(string plateNumber);

        Task<CustomResponseDto<VehicleDTO>> TireChangingUtility(string plateNumber);

    }
}
