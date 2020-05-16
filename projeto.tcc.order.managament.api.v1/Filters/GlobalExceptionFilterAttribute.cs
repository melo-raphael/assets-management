using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace projeto.tcc.order.managament.api.v1.Filters
{
    public class GlobalExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public GlobalExceptionFilterAttribute()
        {

        }

        public void OnException(ExceptionContext context)
        {

            context.Result = new BadRequestObjectResult(new
            {
                success = false,
                errors = new[]{
                        new {
                                Code = "188",
                                Message = "Não foi possível realizar a operação",
                                timestamp = DateTime.Now
                        }
                    }
            });


        }
    }
}
