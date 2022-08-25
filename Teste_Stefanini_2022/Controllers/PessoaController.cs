using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("v1/pessoas")]
    public class PessoaController : ControllerBase
    {
        private readonly INterfacePessoa _service;
        public PessoaController(INterfacePessoa service)
        {
            _service = service;
        }
        /// <summary>
        /// Retorna um Ienumerable de pessoas adicionadas.
        /// </summary>
        /// <returns>Retorna um IEnumerable de pessoas cadastradas no banco na memoria</returns>
        [HttpGet]
        //[Route("Get")]
        public async Task<ActionResult<IEnumerable<Pessoa>>> Get()
        {
            var pessoas = await _service.GetAll();
            if (pessoas == null)
            {
                return BadRequest();
            }
            return Ok(pessoas.ToList());
        }


        /// <summary>
        /// Obtem uma pessoa especifica consultando pelo Id
        /// </summary>
        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Pessoa>> GetById(int Id)
        {
            var pessoas = await _service.GetById(Id);
            if (pessoas == null)
            {
                return NotFound("Pessoa não encontrada pelo id informado");
            }
            return Ok(pessoas);
        }

        /// <summary>
        /// Adiciona uma pessoa ao banco na memoria
        /// </summary> 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pessoa pessoas)
        {
            if (pessoas == null)
            {
                return BadRequest("pessoa é null");
            }
            await _service.Add(pessoas);
            return CreatedAtAction(nameof(Get), new { Id = pessoas.Id }, pessoas);
        }

        /// <summary>
        /// Edita uma pessoa especifica consultando pelo Id
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Pessoa pessoas)
        {
            if (pessoas.Id==0)
            {
                return BadRequest($"O código da pessoa não pode ser zero.");
            }
            try
            {
                var pessoa = await _service.GetById(pessoas.Id);
                pessoa = pessoas;
                await _service.Update(pessoa);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok("Atualização realizada com sucesso");
        }

        /// <summary>
        /// Deleta uma pessoa especifica consultando pelo Id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pessoa>> Delete(int id)
        {
            var pessoa = await _service.GetById(id);
            if (pessoa == null)
            {
                return NotFound($"Pessoa com id {id} não foi encontrado");
            }
            await _service.Delete(pessoa);
            return Ok(pessoa);
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
