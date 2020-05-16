using projeto.tcc.order.managament.domain.SeedWork;

namespace projeto.tcc.order.managament.domain
{
    public class Assets : Entity, IAggregateRoot
    {

        public string Name { get; private set; }
        public string Symbol { get; private set; }
        public string ImageUrl { get; private set; }
        public string Segment { get; private set; }

        protected Assets()
        {

        }

        public Assets(string name, string symbol, string imageUrl, string segment)
        {
            Name = name;
            Symbol = symbol;
            ImageUrl = imageUrl;
            Segment = segment;
        }
    }
}
