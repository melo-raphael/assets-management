using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace projeto.tcc.order.managament.domain.Events
{
    public abstract class Event : INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
