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
    public class VendaController : ControllerBase
    {
        private readonly VendaContext _context;

        public VendaController(VendaContext context)
        {
            _context = context;
        }

        [HttpGet("ObterListaDeVendas")]
        public IActionResult ListaDeVendas()
        {
            var vendaBanco = _context.Venda.ToList();

            return Ok(vendaBanco);
        }

        [HttpPost("CadastrarVenda")]
        public IActionResult CadastrarVenda(Vendas venda)
        {
            _context.Venda.Add(venda);
            _context.SaveChanges();

            return Ok(venda);
        }

        [HttpGet("{id}")]
        public IActionResult ObterVendaPorId(int id)
        {
            var vendaId = _context.Venda.Find(id);

            if(vendaId == null)
                return NotFound();

            return Ok(vendaId);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarStatusVenda(int id, Vendas venda)
        {
            var vendaBanco = _context.Venda.Find(id);

            if(vendaBanco == null)
                return NotFound();

            vendaBanco.Vendedor = venda.Vendedor;
            vendaBanco.Itens = venda.Itens;
            vendaBanco.Status = venda.Status;

            _context.Venda.Update(vendaBanco);
            _context.SaveChanges();

            return Ok(vendaBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarVenda(int id)
        {
            var vendaBanco = _context.Venda.Find(id);

            if(vendaBanco == null)
                return NotFound();

            _context.Venda.Remove(vendaBanco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}