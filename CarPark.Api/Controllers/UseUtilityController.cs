using CarPark.Api.Controllers;
using CarPark.Copy2.Api.Filters;
using CarPark.Core.Model;
using CarPark.CoreCopy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.Copy.Api.Controllers
{
 
    public class UseUtilityController : CustomBaseController
    {
        private readonly IUtilitiesService _UtilitiesService;

        public UseUtilityController(IUtilitiesService utilitiesService)
        {
            _UtilitiesService = utilitiesService;
        }

        [ServiceFilter(typeof(NotFoundFilter<Vehicle>))]
        [HttpGet("[Action]")]
        public async Task<IActionResult> CarWashingUtility(string plateNumber)
        {
            return CreateActionResult(await _UtilitiesService.CarWashingUtility(plateNumber));
        }

        [ServiceFilter(typeof(NotFoundFilter<Vehicle>))]
        [HttpGet("[Action]")]
        public async Task<IActionResult> TireChangingUtility(string plateNumber)
        {
            return CreateActionResult(await _UtilitiesService.TireChangingUtility(plateNumber));
        }
    }
}
