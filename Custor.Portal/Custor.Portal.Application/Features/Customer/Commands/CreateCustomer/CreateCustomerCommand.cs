using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custor.Portal.Application.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public string CompanyName { get; set; }
        public string CompanyNameLocal { get; set; }
        public string CompanyNameAmharic { get; set; }
        public string EnterpriseType { get; set; }
        public string TradeName { get; set; }
        public string TradeNameLocal { get; set; }
        public string TradeNameAmharic { get; set; }
        public DateTime StartDate { get; set; }
        public string PreferredLanguage { get; set; }
    }
}
