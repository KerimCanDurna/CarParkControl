using CarPark.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarPark.Copy.Api.Filters
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)  // action gerçekleşirken araya girecek 
        {
            if (!context.ModelState.IsValid) // ModelState üzerinden bir hata alıp almadığımızı kontrol ediyoruz ve bir hata aldıysak içeri giriyor 
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                // Model state den gelen listenin içinden sadece hata mesajlarını aldık 
                context.Result = new BadRequestObjectResult(CustomResponseDto<NoContenDto>.Fail(400, errors));
            }
        }
    }
}
