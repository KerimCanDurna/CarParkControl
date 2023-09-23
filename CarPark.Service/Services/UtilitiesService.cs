using AutoMapper;
using CarPark.Core.DTOs;
using CarPark.Core.Model;
using CarPark.Core.Repositories;
using CarPark.Core.Services;
using CarPark.Core.UnitOfWorks;
using CarPark.CoreCopy.Repositories;
using CarPark.CoreCopy.Services;
using CarPark.Repository;
using CarPark.Service.Services;
using CarPark.ServiceCopy.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.ServiceCopy.Services
{
    public class UtilitiesService : Service<Vehicle>, IUtilitiesService
    {
        private readonly IUtilitiesRepository _repository;
        private readonly IMapper _mapper;
        private readonly IService<Vehicle> _service;

        public UtilitiesService(IGenericRepository<Vehicle> repository1, IUnitOfWork unitOfWork, IUtilitiesRepository repository, IMapper mapper, Core.Services.IService<Vehicle> service) : base(repository1, unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _service = service;
        }

        public async Task<CustomResponseDto<VehicleDTO>> CarWashingUtility(string plateNumber)
        {

            var utility = _service.Where(x => x.PlateNumber == plateNumber).FirstOrDefault();
            var utilityDto = _mapper.Map<VehicleDTO>(utility);

            if (utility.Utility == 1)
            {
                throw new ClientSideException($"{utility.PlateNumber} Utility already used");
            }
            else if (utility.VehicleClassId == 1)
            {
                _repository.CarWashingUtility(utility);
                return CustomResponseDto<VehicleDTO>.Success(200, "Your vehicle will benefit from the car wash service");
            }
            throw new ClientSideException($"{utility.PlateNumber} Wrong Class Statu");
            

        }

        public async Task<CustomResponseDto<VehicleDTO>> TireChangingUtility(string plateNumber)
        {

            var utility = _service.Where(x => x.PlateNumber == plateNumber).FirstOrDefault();       

            var utilityDto = _mapper.Map<VehicleDTO>(utility);

            if (utility.Utility == 1)
            {
                throw new ClientSideException($"{utility.PlateNumber} Utility already used");
            }

            if (utility.VehicleClassId == 2)
            {
                _repository.TireChangingUtility(utility);
                return CustomResponseDto<VehicleDTO>.Success(200, "Your vehicle tire will be changed");
            }
            throw new ClientSideException($"{utility.PlateNumber} Wrong Class Statu");

        }
    }
}
