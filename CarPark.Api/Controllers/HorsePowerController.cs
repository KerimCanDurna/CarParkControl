using AutoMapper;
using CarPark.Api.Controllers;
using CarPark.Copy2.Api.Filters;
using CarPark.Core.DTOs;
using CarPark.Core.Model;
using CarPark.Core.Services;
using CarPark.CoreCopy.Services;
using CarPark.ServiceCopy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.Copy.Api.Controllers
{
   
    public class HorsePowerController : CustomBaseController
    {
       private readonly IHorsePowerService _horsePowerService;
        public HorsePowerController(IMapper mapper, IHorsePowerService service, IHorsePowerService horsePowerService)
        {
            _horsePowerService = horsePowerService;
        }

        [ServiceFilter(typeof(NotFoundFilter<Vehicle>))]
        [HttpGet("[Action]")]
        public async Task<IActionResult> HorsePower(string PlateNumber)
        {
            return CreateActionResult(await _horsePowerService.HorsePower(PlateNumber));
        }

    }
}
