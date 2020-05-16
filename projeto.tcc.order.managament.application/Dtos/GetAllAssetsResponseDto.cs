using System.Collections;
using System.Collections.Generic;

namespace projeto.tcc.order.managament.application.Dtos
{
    public class GetAllAssetsResponseDto
    {
        public string Name { get;  set; }
        public string Symbol { get;  set; }
        public string ImageUrl { get;  set; }
        public string Segment { get;  set; }

        public GetAllAssetsResponseDto(string name, string symbol, string imageUrl, string segment)
        {
            Name = name;
            Symbol = symbol;
            ImageUrl = imageUrl;
            Segment = segment;
        }

    }

}
