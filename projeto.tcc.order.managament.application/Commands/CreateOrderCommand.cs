using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace projeto.tcc.order.managament.application.Commands
{
    public class CreateOrderCommand : IRequest<bool>
    {

        public Guid UserId { get; set; }
        public Guid AssetId { get; set; }
        public decimal Value { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }

        //public override bool IsValid()
        //{
        //    //ValidationResult = new GetUserByEmailCommandValidation<GetUserByEmailCommand>().Validate(this);

        //    return ValidationResult.IsValid;
        //}
    }
}
