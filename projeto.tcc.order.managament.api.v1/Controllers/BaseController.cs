using MediatR;
using Microsoft.AspNetCore.Mvc;
using projeto.tcc.order.managament.api.v1.Filters;
using projeto.tcc.order.managament.domain.Exceptions;
using System.Collections.Generic;

namespace projeto.tcc.order.managament.api.v1.Controllers
{
    [Route("order/managament/[controller]")]
    [ServiceFilter(typeof(GlobalExceptionFilterAttribute))]

    public class BaseController : Controller
    {
        private readonly ExceptionNotificationHandler _notifications;

        protected IEnumerable<ExceptionNotification> Notifications => _notifications.GetNotifications();

        protected BaseController(INotificationHandler<ExceptionNotification> notifications)
        {
            _notifications = (ExceptionNotificationHandler)notifications;
        }
        protected bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }

        protected new IActionResult Response(int statusCode, object result = null)
        {
            if (IsValidOperation())
            {
                return StatusCode(statusCode, new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications()
            });
        }
    }
}
