using CarPark.Core.Model;
using CarPark.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.CoreCopy.Repositories
{
    public interface IHorsePowerRepository :IGenericRepository<Vehicle>
    {
        int HorsePowerCalculate(Vehicle vehicle);
    }
}
