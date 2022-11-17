using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api_main.Entities
{
    public class Vendas
    {
         public int Id { get; set; }
        public string Vendedor { get; set; }
        public string Itens { get; set; }
        public string Status { get; set; }
    }
}