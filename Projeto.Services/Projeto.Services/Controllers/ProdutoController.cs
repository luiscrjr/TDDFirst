using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Services.Models;
using Projeto.Services.Repositories;

namespace Projeto.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ProdutoCadastroModel model,
            [FromServices] IMapper mapper, [FromServices] ProdutoRepository repository)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest();

            var produto = mapper.Map<Produto>(model);

            repository.Add(produto);

            return Ok(produto);
        }

        [HttpPut]
        public IActionResult Put(ProdutoEdicaoModel model,
            [FromServices] IMapper mapper, [FromServices] ProdutoRepository repository)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest();

            var produto = mapper.Map<Produto>(model);
            repository.Modify(produto);

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id, [FromServices] ProdutoRepository repository)
        {
            var produto = repository.Remove(Guid.Parse(id));
            return Ok(produto);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(List<ProdutoConsultaModel>), StatusCodes.Status200OK)]
        public IActionResult GetAll([FromServices] IMapper mapper, [FromServices] ProdutoRepository repository)
        {
            var model = mapper.Map<List<ProdutoConsultaModel>>(repository.GetAll());

            if (model != null && model.Count > 0)
                return Ok(model);
            else
                return NoContent();

            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<ProdutoConsultaModel>), StatusCodes.Status200OK)]
        public IActionResult GetById(string id, [FromServices] IMapper mapper, [FromServices] ProdutoRepository repository)
        {
            var model = mapper.Map<ProdutoConsultaModel>(repository.GetById(Guid.Parse(id)));

            if (model != null)
                return Ok(model);
            else
                return NoContent();
        }
    }
}