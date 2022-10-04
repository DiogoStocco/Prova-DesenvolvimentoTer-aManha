using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/folha")]
     public class FolhaController : ControllerBase{
        private readonly DataContext _context;
        public FolhaController (DataContext context) => _context = context;
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] FolhaPagamento folha){
            _context.Folhas.Add(folha);
            _context.SaveChanges();
            return Created("", folha);
        }
        // GET: /api/folha/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar() => Ok(_context.Folhas.ToList());


        // GET: /api/folha/buscar/{cpf}
        [HttpGet]
        [Route("buscar/{cpf}/{mês}/{ano}")]
        public IActionResult Buscar([FromRoute] string cpf)
        {
            FolhaPagamento folha = _context.Folhas.
               FirstOrDefault(f => f.Cpf.Equals(cpf));
            return folha != null ? Ok(folha) : NotFound();
        }

        // DELETE: /api/folha/deletar/{id}
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            FolhaPagamento folhas = _context.Folhas.Find(id);
            if (folhas != null)
            {
                _context.Folhas.Remove(folhas);
                _context.SaveChanges();
                return Ok(folhas);
            }
            return NotFound();
        }

        // PATCH: /api/folha/alterar
        [HttpPatch]
        [Route("alterar")]
        public IActionResult Alterar([FromBody] FolhaPagamento folha)
        {
            try
            {
                _context.Folhas.Update(folha);
                _context.SaveChanges();
                return Ok(folha);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}