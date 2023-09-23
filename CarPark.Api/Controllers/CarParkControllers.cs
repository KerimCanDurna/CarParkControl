using AutoMapper;
using CarPark.Core.DTOs;
using CarPark.Core.Model;
using CarPark.Core.Services;
using CarPark.CoreCopy.Services;
using CarPark.ServiceCopy.Exceptions;
using CarPark.ServiceCopy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarPark.Api.Controllers
{

    public class CarParkControllers : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Vehicle> _service;



        public CarParkControllers(IMapper mapper, IService<Vehicle> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("[Action]")]
        // Burada otoparka daha önce giriş yapmış bütün araçları çekiyoruz (Çıkış yapanlar dahil )
        public async Task<IActionResult> AllVehiclesList()
        {
            var vehicle = await _service.GetAllAsync();


            var vehicleDtos = _mapper.Map<List<VehicleDTO>>(vehicle.ToList());

            return CreateActionResult(CustomResponseDto<List<VehicleDTO>>.Success(200, vehicleDtos));
        }

        [HttpGet("[Action]")]
        // Burada otopart aktif  araçları çekiyoruz (Çıkış yapanlar dahil DEĞİL )
        public async Task<IActionResult> ActiveVehicleList()
        {
            var vehicle = await _service.GetAllAsync();

            //LoggedOut değeri ile çıkış durumunu kontrol ediyorum.
            //Daha sonra çıkış yapılması halinde ParkingFeeRepository içinde ParkingFeeCalculate metodunda True olarak atayacağız
            var vehicle1 = vehicle.Where(x => x.LoggedOut == false).ToList();


            var vehicleDtos = _mapper.Map<List<VehicleDTO>>(vehicle1.ToList());

            return CreateActionResult(CustomResponseDto<List<VehicleDTO>>.Success(200, vehicleDtos));
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> VehiclesListByClass(int id)
        {
            switch (id)
            {
                case 1:
                    var vehicle2 = await _service.Where(x => x.VehicleClassId == id).Include(x => x.FirstClassVehicle).ToListAsync();
                    var vehicleDtos = _mapper.Map<List<FirstClassVehicleDto>>(vehicle2.ToList());
                    return CreateActionResult(CustomResponseDto<List<FirstClassVehicleDto>>.Success(200, vehicleDtos.ToList()));

                case 2:
                    var vehicle3 = await _service.Where(x => x.VehicleClassId == id).Include(x => x.SecondClassVehicle).ToListAsync();
                    var vehicleDtos1 = _mapper.Map<List<SecondClassVehicleDto>>(vehicle3.ToList());
                    return CreateActionResult(CustomResponseDto<List<SecondClassVehicleDto>>.Success(200, vehicleDtos1));

                case 3:
                    var vehicle4 = await _service.Where(x => x.VehicleClassId == id).ToListAsync();
                    var vehicleDtos2 = _mapper.Map<List<VehicleDTO>>(vehicle4.ToList());
                    return CreateActionResult(CustomResponseDto<List<VehicleDTO>>.Success(200, vehicleDtos2));

                default:
                    throw new ClientSideException("Wrong Class Id");
            }


        }


        // Araç Giriş İşlemleri 


        [HttpPost("[Action]")]
        public async Task<IActionResult> CheckInFirstVehicleClass(FirstClassVehicleDto vehicleDTO)
        {
            // vehicleDTo nesnesinde ClassId kolonunu yanlış değer girişini engellemek için almadım ,
            // bunun yerine her sınıfın ait olduğu giriş işleminde sınıf ataması yaptım 
            var vehicle = _mapper.Map<Vehicle>(vehicleDTO);
            vehicle.VehicleClassId = 1;

            //Burada clienttan gelen PlateNumber değerini otopark içinde varlığını kontrol ediyorum ,
            //varsa loggedOut değeri ile aracın otopark içindeki aktifliğini konrol ederek sonuca göre hata fırlatıyor yada kayıt işlemi yapıyorum 
            var control = await _service.Where(x => x.PlateNumber == vehicle.PlateNumber).SingleOrDefaultAsync();
            if (control != null && control.LoggedOut == false)
            {
                { throw new ClientSideException($"{vehicle.PlateNumber} Vehicle is already Logged In"); }
            }
            await _service.AddAsync(vehicle);




            var vehicleDTOs = _mapper.Map<FirstClassVehicleDto>(vehicle);

            return CreateActionResult(CustomResponseDto<FirstClassVehicleDto>.Success(201, vehicleDTOs));
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> CheckInSecondVehicleClass(SecondClassVehicleDto vehicleDTO)
        {
            // vehicleDTo nesnesinde ClassId kolonunu yanlış değer girişini engellemek için almadım ,
            // bunun yerine her sınıfın ait olduğu giriş işleminde sınıf ataması yaptım 
            var vehicle = _mapper.Map<Vehicle>(vehicleDTO);
            vehicle.VehicleClassId = 2;

            //Burada clienttan gelen PlateNumber değerini otopark içinde varlığını kontrol ediyorum ,
            //varsa loggedOut değeri ile aracın otopark içindeki aktifliğini konrol ederek sonuca göre hata fırlatıyor yada kayıt işlemi yapıyorum 
            var control = await _service.Where(x => x.PlateNumber == vehicle.PlateNumber).SingleOrDefaultAsync();
            if (control != null && control.LoggedOut == false)
            {
                { throw new ClientSideException($"{vehicle.PlateNumber} Vehicle is already Logged In"); }
            }
            await _service.AddAsync(vehicle);

            var vehicleDTOs = _mapper.Map<SecondClassVehicleDto>(vehicle);

            return CreateActionResult(CustomResponseDto<SecondClassVehicleDto>.Success(201, vehicleDTOs));
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> CheckInThirdVehicleClass(VehicleDTO vehicleDTO)
        {
            // vehicleDTo nesnesinde ClassId kolonunu yanlış değer girişini engellemek için almadım ,
            // bunun yerine her sınıfın ait olduğu giriş işleminde sınıf ataması yaptım 
            var vehicle = _mapper.Map<Vehicle>(vehicleDTO);
            vehicle.VehicleClassId = 3;

            //Burada clienttan gelen PlateNumber değerini otopark içinde varlığını kontrol ediyorum ,
            //varsa loggedOut değeri ile aracın otopark içindeki aktifliğini konrol ederek sonuca göre hata fırlatıyor yada kayıt işlemi yapıyorum 
            var control = await _service.Where(x => x.PlateNumber == vehicle.PlateNumber).SingleOrDefaultAsync();
            if (control != null && control.LoggedOut == false)
            {
                { throw new ClientSideException($"{vehicle.PlateNumber} Vehicle is already Logged In"); }
            }
            await _service.AddAsync(vehicle);

            var vehicleDTOs = _mapper.Map<VehicleDTO>(vehicle);

            return CreateActionResult(CustomResponseDto<VehicleDTO>.Success(201, vehicleDTOs));
        }


    }
}
