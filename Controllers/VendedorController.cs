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
    public class VendedorController : ControllerBase
    {
        private readonly VendaContext _context;

        public VendedorController(VendaContext context)
        {
            _context = context;
        }

        [HttpGet("ObterListaDeVendedores")]
        public IActionResult ObterListaVendedores()
        {
            var listaVendedores = _context.Vendedores.ToList();

            return Ok(listaVendedores);
        }

        [HttpPost("CadastroVendedor")]
        public IActionResult CadastroVendedor(Vendedor vendedor)
        {
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();

            return Ok(vendedor);
        }

        [HttpGet("ObterVendedorPorNome")]
        public IActionResult VendedorPorNome(string nome)
        {
            var vendedor = _context.Vendedores.Where(x => x.Nome.Contains(nome));

            return Ok(vendedor);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarVendedor(int id, Vendedor vendedor)
        {
            var vendedorBanco = _context.Vendedores.Find(id);

            if(vendedorBanco == null)
                return NotFound();

            vendedorBanco.Nome = vendedor.Nome;
            vendedorBanco.CPF = vendedor.CPF;
            vendedorBanco.Email= vendedor.Email;
            vendedorBanco.Telefone = vendedor.Telefone;

            _context.Vendedores.Update(vendedorBanco);
            _context.SaveChanges();

            return Ok(vendedorBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarVendedor(int id)
        {
            var vendedorBanco = _context.Vendedores.Find(id);

            if(vendedorBanco == null)
                return NotFound();

            _context.Vendedores.Remove(vendedorBanco);
            _context.SaveChanges();

            return NoContent();
        }

    }
}