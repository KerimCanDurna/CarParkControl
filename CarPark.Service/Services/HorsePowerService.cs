using AutoMapper;
using CarPark.Core.DTOs;
using CarPark.Core.Model;
using CarPark.Core.Repositories;
using CarPark.Core.Services;
using CarPark.Core.UnitOfWorks;
using CarPark.CoreCopy.DTOs;
using CarPark.CoreCopy.Repositories;
using CarPark.CoreCopy.Services;
using CarPark.Repository.UnitOfWork;
using CarPark.Service.Services;
using CarPark.ServiceCopy.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.ServiceCopy.Services
{
    public class HorsePowerService : Service<Vehicle>, IHorsePowerService
    {
        private readonly IMapper _mapper;
        private readonly IService<Vehicle> _service;
        private readonly IHorsePowerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public HorsePowerService(IGenericRepository<Vehicle> repository1, IUnitOfWork unitOfWork, IMapper mapper, IService<Vehicle> service, IHorsePowerRepository repository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _service = service;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<HorsePowerDto>> HorsePower(string PlateNumber)
        {
            var vehicle = _service.Where(x=> x.PlateNumber == PlateNumber).FirstOrDefault();
           

            var vehicle1= _repository.HorsePowerCalculate(vehicle);
            vehicle.HorsePower = vehicle1;
            _unitOfWork.Commit();            
            var vehicleDto = _mapper.Map<HorsePowerDto>(vehicle);

            return CustomResponseDto<HorsePowerDto>.Success(200, vehicleDto);
        }
    }
}
