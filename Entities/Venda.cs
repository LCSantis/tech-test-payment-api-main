using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api_main.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int IdPedido { get; set; }
        public string Itens { get; set; }
    }
}