using CarPark.Api.Controllers;
using CarPark.Copy2.Api.Filters;
using CarPark.Core.Model;
using CarPark.CoreCopy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.Copy.Api.Controllers
{
   
    public class CheckOutVehiclesController : CustomBaseController
    {
        private readonly IParkingFeeService _parkingFeeService;

        public CheckOutVehiclesController(IParkingFeeService parkingFeeService)
        {
            _parkingFeeService = parkingFeeService;
        }

        [ServiceFilter(typeof(NotFoundFilter<Vehicle>))]
        [HttpGet("[Action]")]
        public async Task<IActionResult> CheckOutVehicleClass(string PlateNumber)
        {
            return CreateActionResult(await _parkingFeeService.ParkingFeeCalculate(PlateNumber));
        }
    }
}
