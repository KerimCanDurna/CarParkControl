using CarPark.Core.DTOs;
using CarPark.Core.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using CarPark.Core.Model;

namespace CarPark.Copy2.Api.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : Vehicle
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {


            var PlateNumberValue = context.ActionArguments.Values.FirstOrDefault();

            if (PlateNumberValue == null)
            {
                await next.Invoke();
                return;
            }

            var plateNumber = (string)PlateNumberValue;
            var anyEntity = await _service.AnyAsync(x => x.PlateNumber == plateNumber);
            if (anyEntity)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContenDto>.Fail(404, $"{typeof(T).Name}({plateNumber}) not found"));




        }
    }
}
