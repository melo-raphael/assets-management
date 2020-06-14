using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace projeto.tcc.order.managament.application.EventHandlers
{
    public abstract class EventHandler<T> : INotificationHandler<T> where T : INotification
    {  
        public abstract Task Handle(T notification, CancellationToken cancellationToken);

    }
}
