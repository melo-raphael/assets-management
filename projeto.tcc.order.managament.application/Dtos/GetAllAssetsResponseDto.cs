using System;
using System.Collections;
using System.Collections.Generic;

namespace projeto.tcc.order.managament.application.Dtos
{
    public class GetAllAssetsResponseDto
    {
        public Guid Id{ get; set; }
        public string Name { get;  set; }
        public string Symbol { get;  set; }
        public string ImageUrl { get;  set; }

        public GetAllAssetsResponseDto(Guid id, string name, string symbol, string imageUrl)
        {
            Id = id;
            Name = name;
            Symbol = symbol;
            ImageUrl = imageUrl;
        }

    }

}
