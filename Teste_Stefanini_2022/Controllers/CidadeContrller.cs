using Application.Interfaces;
using Domain.Entities;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Infrastructure;

namespace Api.Controllers
{
    [ApiController]
    [Route("v1/cidade")]
    public class CidadeController : ControllerBase
    {
        private readonly INterfaceCidade _service;
        public CidadeController(INterfaceCidade service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cidade>>> Get()
        {
            var model = await _service.GetAll();
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model.ToList());
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Cidade>> GetById(int Id)
        {
            var model = await _service.GetById(Id);
            if (model == null)
            {
                return NotFound("Pessoa não encontrada pelo id informado");
            }
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cidade model)
        {
            if (model == null)
            {
                return BadRequest("pessoa é null");
            }
            await _service.Add(model);
            return CreatedAtAction(nameof(Get), new { Id = model.Id }, model);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Cidade model)
        {
            if (model.Id == 0)
            {
                return BadRequest($"O código da pessoa não pode ser zero.");
            }
            try
            {
                var pessoa = await _service.GetById(model.Id);
                pessoa = model;
                await _service.Update(pessoa);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok("Atualização realizada com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cidade>> Delete(int id)
        {
            var model = await _service.GetById(id);
            if (model == null)
            {
                return NotFound($"Pessoa com id {id} não foi encontrado");
            }
            await _service.Delete(model);
            return Ok(model);
        }



        //[HttpPost]
        //[Route("")]
        //public async Task<ActionResult<Pessoa>> Post(
        //    [FromServices] DataContext context,
        //    [FromBody]Pessoa model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Pessoa.Add(model);
        //        await context.SaveChangesAsync();
        //        return model;
        //    }
        //    else
        //    {
        //        return BadRequest(model);
        //    }
        //}

    }
}
