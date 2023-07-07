using Application.Dtos.Generic;
using Application.Dtos.ServicosExecutadosDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ServicoExecutadoController : ControllerBase
    {
        private readonly IServicoExecutadoService _servicoExecutadoService;
        private string? _empresaId;

        public ServicoExecutadoController(IServicoExecutadoService servicoExecutadoService)
        {
            _servicoExecutadoService = servicoExecutadoService;
        }

        [HttpGet("/api/PaginacaoServicoExecutado")]
        public async Task<IActionResult> PaginacaoServicoExecutado([FromQuery] int page, string search = "")
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                _empresaId = identity?.Claims.FirstOrDefault(c => c.Type == "EmpresaId")?.Value;

                if (_empresaId == null) return Unauthorized();
                var paginacaoRequest = new PaginacaoRequest(page, Guid.Parse(_empresaId), search);

                var paginacaoResponse = await _servicoExecutadoService.GetPaginacaoAsync(paginacaoRequest);

                if (paginacaoResponse == null) return BadRequest("Ocorreu um erro interno ao listar os serviços executados.");

                return Ok(paginacaoResponse);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/api/AdicionarServicoExecutado")]
        public async Task<IActionResult> AdicionarServicoExecutado([FromBody] ServicoExecutadoCreateDto servicoCreatedDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();
                    var message = string.Join("\n", errors);
                    return BadRequest(message);
                }

                var identity = HttpContext.User.Identity as ClaimsIdentity;
                _empresaId = identity?.Claims.FirstOrDefault(c => c.Type == "EmpresaId")?.Value;

                if (_empresaId == null) return Unauthorized();

                var result = await _servicoExecutadoService.AdicionarServicoExecutadoAsync(servicoCreatedDto, Guid.Parse(_empresaId));

                if (!result) return BadRequest("Ocorreu um erro interno, tente novamente mais tarde.");

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/api/ExcluirServicoExecutado")]
        public async Task<IActionResult> ExcluirServicoExecutado([FromQuery] Guid id)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                _empresaId = identity?.Claims.FirstOrDefault(c => c.Type == "EmpresaId")?.Value;

                if (_empresaId == null) return Unauthorized();

                var result = await _servicoExecutadoService.ExcluirServicoExecutadoAsync(id);

                if (!result) return BadRequest("Não foi possível excluir o registro!");

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
