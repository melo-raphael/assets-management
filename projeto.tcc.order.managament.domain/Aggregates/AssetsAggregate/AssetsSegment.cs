using projeto.tcc.order.managament.domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projeto.tcc.order.managament.domain.Aggregates.AssetsAggregate
{
    public class AssetsSegment : Enumeration
    {
        public static AssetsSegment Telefonia = new AssetsSegment(0, "telefonia");
        public static AssetsSegment Petroleo = new AssetsSegment(1, "petróleo");
        public static AssetsSegment Varejo = new AssetsSegment(2, "varejo");
        public static AssetsSegment Seguro = new AssetsSegment(3, "seguro especializado");



        public AssetsSegment(int id, string name) : base(id, name)
        {
        }
        public static IEnumerable<AssetsSegment> List() =>
                    new[] { Telefonia, Petroleo, Varejo, Seguro };

        public static AssetsSegment FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new Exception($"Possible values for UserStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static AssetsSegment From(int id)
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
