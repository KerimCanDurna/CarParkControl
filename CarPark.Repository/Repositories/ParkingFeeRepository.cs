using CarPark.Core.DTOs;
using CarPark.Core.Model;
using CarPark.Core.Services;
using CarPark.CoreCopy.Repositories;
using CarPark.Repository;
using CarPark.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.RepositoryCopy.Repositories
{
    public class ParkingFeeRepository : GenericRepository<Vehicle> , IParkingFeeRepository
    {
        
        private readonly IService<Vehicle> _service;
        private readonly IParkingFeeRepository _parkingFeeRepository;
        public ParkingFeeRepository(AppDbContext appDbContext, IService<Vehicle> service) : base(appDbContext)
        {
            
            _service = service;
        }


        public async Task<Vehicle> ParkingFeeCalculate(Vehicle vehicle)
        {
           

            var checkInDate = vehicle.CheckInDate;
            var checkOutDate = vehicle.CheckOutDate;

            TimeSpan time = (TimeSpan)(checkOutDate - checkInDate);

           
            decimal fee = 0;

            if (vehicle.VehicleClassId == 1)
            {
                // 1. Sınıf araç için ücret katsayısı * time ın saat cinsinden değeri 

                fee = (decimal)time.TotalHours * 3;
            }
            else if (vehicle.VehicleClassId == 2)
            {
                // 2. Sınıf araç için ücret katsayısı * time ın saat cinsinden değeri 

                fee = (decimal)time.TotalHours * 2;
            }
            //3. Sınıf araç için ücret katsayısını 1 Kabul ettim * time ın saat cinsinden değeri 
            else
                fee = (decimal)time.TotalHours * 1;
           
            vehicle.Fee = fee;
            vehicle.LoggedOut = true;
            await _service.UpdateAsync(vehicle);

            return vehicle;
        }

    }
}
