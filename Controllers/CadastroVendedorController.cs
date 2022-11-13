using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api_main.Context;
using tech_test_payment_api_main.Entities;

namespace tech_test_payment_api_main.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroVendedorController : ControllerBase
    {
        private readonly VendaContext _context;

        public CadastroVendedorController(VendaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CadastroVendedor(Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();

            return Ok(vendedor);
        }
    }
}