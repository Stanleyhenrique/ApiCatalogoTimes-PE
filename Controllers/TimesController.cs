using ExemploApiCatalogoTimes.Exceptions;
using ExemploApiCatalogoTimes.InputModel;
using ExemploApiCatalogoTimes.Services;
using ExemploApiCatalogoTimes.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploApiCatalogoTimesPE.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TimesController : ControllerBase
    {
        private readonly iTimeService _TimeService;

        public TimesController(iTimeService TimeService)
        {
            _TimeService = TimeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var Times = await _TimeService.Obter(pagina, quantidade);

            if (Times.Count() == 0)
                return NoContent();

            return Ok(Times);
        }

        [HttpGet("{idTime:guid}")]
        public async Task<ActionResult<TimeViewModel>> Obter([FromRoute] Guid idTime)
        {
            var Time = await _TimeService.Obter(idTime);

            if (Time == null)
                return NoContent();

            return Ok(Time);
        }
 
        [HttpPost]
        public async Task<ActionResult<TimeViewModel>> InserirTime([FromBody] TimeInputModel TimeInputModel)
        {
            try
            {
                var Time = await _TimeService.Inserir(TimeInputModel);

                return Ok(Time);
            }
            catch (TimeJaCadastradoException ex)
            {
                return UnprocessableEntity("Já existe um Time com este nome neste estado");
            }
        }

    
        [HttpPut("{idTime:guid}")]
        public async Task<ActionResult> AtualizarTime([FromRoute] Guid idTime, [FromBody] TimeInputModel TimeInputModel)
        {
            try
            {
                await _TimeService.Atualizar(idTime, TimeInputModel);

                return Ok();
            }
            catch (TimeNaoCadastradoException ex)
            {
                return NotFound("Não existe este Time");
            }
        }

        [HttpPatch("{idTime:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarTime([FromRoute] Guid idTime, [FromRoute] double preco)
        {
            try
            {
                await _TimeService.Atualizar(idTime, preco);

                return Ok();
            }
            catch (TimeNaoCadastradoException ex)
            {
                return NotFound("Não existe este Time");
            }
        }

  
        [HttpDelete("{idTime:guid}")]
        public async Task<ActionResult> ApagarTime([FromRoute] Guid idTime)
        {
            try
            {
                await _TimeService.Remover(idTime);

                return Ok();
            }
            catch (TimeNaoCadastradoException ex)
            {
                return NotFound("Não existe este Time");
            }
        }

    }
}
