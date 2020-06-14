using projeto.tcc.order.managament.domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projeto.tcc.order.managament.domain.Aggregates.OrderAggregate
{
    public class OrderType : Enumeration
    {
        public static OrderType Buy = new OrderType(0, "buy");
        public static OrderType Sell = new OrderType(1, "sell");



        public OrderType(int id, string name) : base(id, name)
        {
        }
        public static IEnumerable<OrderType> List() =>
                    new[] { Buy, Sell };

        public static OrderType FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new Exception($"Possible values for UserStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static OrderType From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new Exception($"Possible values for UserStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
