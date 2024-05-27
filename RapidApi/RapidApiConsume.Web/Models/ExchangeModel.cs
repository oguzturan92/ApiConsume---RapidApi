using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidApiConsume.Web.Models
{
    public class ExchangeModel
    {
        public string base_currency { get; set; }
        public string base_currency_date { get; set; }
        public Exchange_rates[] exchange_rates { get; set; }
        public class Exchange_rates
        {
            public string exchange_rate_buy { get; set; }
            public string currency { get; set; }
        }
    }
}