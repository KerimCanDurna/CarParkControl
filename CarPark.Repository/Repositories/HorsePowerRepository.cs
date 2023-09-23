using CarPark.Core.Model;
using CarPark.CoreCopy.Repositories;
using CarPark.Repository;
using CarPark.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.RepositoryCopy.Repositories
{
    public class HorsePowerRepository : GenericRepository<Vehicle>, IHorsePowerRepository
    {
        
        public HorsePowerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            
        }

        public int HorsePowerCalculate(Vehicle vehicle)
        {
            var constent = 1341;
            var HorsePower = vehicle.EnginePower* constent;

            return HorsePower;
        }

        public int HorsePowerCalculate()
        {
            throw new NotImplementedException();
        }
    }
}
