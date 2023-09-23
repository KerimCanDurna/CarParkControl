using AutoMapper;
using CarPark.Core.DTOs;
using CarPark.Core.Model;
using CarPark.Core.Repositories;
using CarPark.Core.Services;
using CarPark.Core.UnitOfWorks;
using CarPark.CoreCopy.DTOs;
using CarPark.CoreCopy.Repositories;
using CarPark.CoreCopy.Services;
using CarPark.Service.Services;
using CarPark.ServiceCopy.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.ServiceCopy.Services
{
    public class ParkingFeeService : Service<Vehicle>, IParkingFeeService
    {
        private readonly IParkingFeeRepository _parkingFeeRepository;
        private readonly IMapper _mapper;
        private readonly IService<Vehicle> _service;


        public ParkingFeeService(IGenericRepository<Vehicle> repository, IUnitOfWork unitOfWork, IParkingFeeRepository parkingFeeRepository, IMapper mapper, IService<Vehicle> service) : base(repository, unitOfWork)
        {
            _parkingFeeRepository = parkingFeeRepository;
            _mapper = mapper;
            _service = service;
        }

        public async Task<CustomResponseDto<UpdateVehicleDto>> ParkingFeeCalculate(string PlateNumber)
        {
            

            var vehicle = _service.Where(x => x.PlateNumber == PlateNumber).FirstOrDefault();
            if (vehicle.LoggedOut) { throw new ClientSideException($"{vehicle.PlateNumber} Vehicle is already Exit"); }
           
            vehicle.CheckOutDate = DateTime.Now;
           
            await _parkingFeeRepository.ParkingFeeCalculate(vehicle);

            var vehicleDto = _mapper.Map<UpdateVehicleDto>(vehicle);


            return CustomResponseDto<UpdateVehicleDto>.Success(200, vehicleDto);
        }
    }

}
