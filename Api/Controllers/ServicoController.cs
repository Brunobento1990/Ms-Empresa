using Application.Dtos.Generic;
using Application.Dtos.ServicoDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoService _servicoService;
        private string? _empresaId;
        public ServicoController(IServicoService servicoService)
        {
            _servicoService = servicoService;
            _empresaId = string.Empty;
        }

        [HttpGet("/api/PaginacaoServico")]
        public async Task<IActionResult> PaginacaoServico([FromQuery] int page, string search = "")
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                _empresaId = identity?.Claims.FirstOrDefault(c => c.Type == "EmpresaId")?.Value;

                if (_empresaId == null) return Unauthorized();

                var paginacaoRequest = new PaginacaoRequest(page, Guid.Parse(_empresaId), search);

                var paginacaoResponse = await _servicoService.GetPaginacaoAsync(paginacaoRequest);

                if (paginacaoResponse == null) return BadRequest("Ocorreu um erro interno ao listar os serviços.");

                return Ok(paginacaoResponse);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/api/AdicionarServico")]
        public async Task<IActionResult> AdicionarServico([FromBody] ServicoCreatedDto servicoCreatedDto)
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

                var result = await _servicoService.AdicionarServicoAsync(servicoCreatedDto, Guid.Parse(_empresaId));

                if (!result) return BadRequest("Ocorreu um erro interno, tente novamente mais tarde.");

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/api/GetServico")]
        public async Task<IActionResult> GetServico([FromQuery] Guid id)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                _empresaId = identity?.Claims.FirstOrDefault(c => c.Type == "EmpresaId")?.Value;

                if (_empresaId == null) return Unauthorized();

                var servicoViewDto = await _servicoService.GetServicoViewAsync(id);

                return Ok(servicoViewDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("/api/EditarServico")]
        public async Task<IActionResult> EditarServico([FromBody] ServicoEditDto servicoEditDto)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                _empresaId = identity?.Claims.FirstOrDefault(c => c.Type == "EmpresaId")?.Value;

                if (_empresaId == null) return Unauthorized();

                var result = await _servicoService.EditarServicoAsync(servicoEditDto);

                if (!result) return BadRequest();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("/api/ExcluirServico")]
        public async Task<IActionResult> ExcluirServico([FromQuery] Guid id)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                _empresaId = identity?.Claims.FirstOrDefault(c => c.Type == "EmpresaId")?.Value;

                if (_empresaId == null) return Unauthorized();

                var result = await _servicoService.ExcluirServicoAsync(id);

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
