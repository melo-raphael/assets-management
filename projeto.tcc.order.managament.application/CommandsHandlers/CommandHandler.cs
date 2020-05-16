using MediatR;
using projeto.tcc.order.managament.application.Commands;
using projeto.tcc.order.managament.domain.Exceptions;
using projeto.tcc.order.managament.domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace projeto.tcc.order.managament.application.CommandsHandlers
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediator _bus;
        private readonly ExceptionNotificationHandler _notifications;

        protected CommandHandler(INotificationHandler<ExceptionNotification> notifications, IMediator bus, IUnitOfWork uow = null)
        {
            _uow = uow;
            _notifications = (ExceptionNotificationHandler)notifications;
            _bus = bus;

        }

        protected void NotifyValidationErrors(Command message)
        {

            foreach (var error in message.GetValidationResult().Errors)
            {
                _bus.Publish(new ExceptionNotification("001", error.ErrorMessage, error.PropertyName));
            }
        }

        public async Task<bool> Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (await _uow.Commit()) return true;

            await _bus.Publish(new ExceptionNotification("002", "We had a problem during saving your data."));
            return false;
        }
    }
}
