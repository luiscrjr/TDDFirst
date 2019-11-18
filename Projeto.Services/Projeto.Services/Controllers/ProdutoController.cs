using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Services.Models;

namespace Projeto.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ProdutoCadastroModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest();

            return Ok();
        }

        [HttpPut]
        public IActionResult Put(ProdutoEdicaoModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

        [HttpGet()]
        [ProducesResponseType(typeof(List<ProdutoConsultaModel>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<ProdutoConsultaModel>), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok();
        }
    }
}