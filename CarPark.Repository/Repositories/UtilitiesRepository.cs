using CarPark.Core.Model;
using CarPark.Core.Services;
using CarPark.CoreCopy.Repositories;
using CarPark.CoreCopy.Services;
using CarPark.Repository;
using CarPark.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.RepositoryCopy.Repositories
{
    public class UtilitiesRepository : GenericRepository<Vehicle>, IUtilitiesRepository
    {
        private readonly IService<Vehicle> _UtilitiesService;

        public UtilitiesRepository(AppDbContext appDbContext, IService<Vehicle> utilitiesService) : base(appDbContext)
        {
            _UtilitiesService = utilitiesService;
        }

        public async Task<Vehicle> CarWashingUtility(Vehicle vehicle)
        {

            
                vehicle.Utility = 1;

                _UtilitiesService.UpdateAsync(vehicle);
            
               

            return vehicle;

        }

        public async Task<Vehicle> TireChangingUtility(Vehicle vehicle)
        {

           vehicle.Utility = 1;

           _UtilitiesService.UpdateAsync(vehicle);



            return  vehicle;
        }
    }
}
