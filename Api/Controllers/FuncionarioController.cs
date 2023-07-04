using Application.Dtos.FuncionarioDtos;
using Application.Dtos.Generic;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;
        private string? _empresaId;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpPost("/api/AdicionarFuncionario")]
        public async Task<IActionResult> AdicionarFuncionario([FromBody]
        FuncionarioCreateDto funcionarioCreateDto)
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

                var funcionarioView = await _funcionarioService.AdicionarFuncionarioAsync(funcionarioCreateDto, Guid.Parse(_empresaId));

                if (funcionarioView == null) return BadRequest("Ocorreu um erro interno, tente novamente mais tarde.");

                return Created("Funcionario cadastrado com sucesso.", funcionarioView);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("/api/EditarFuncionario")]
        public async Task<IActionResult> EditarFuncionario([FromBody] FuncionarioEditDto funcionarioEditDto)
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
                //var funcionarioView = await _funcionarioService.EditarFuncionarioAsync(funcionarioEditDto, Guid.Parse(_empresaId));

                //if (funcionarioView == null) return BadRequest("");

                return Ok("Funcionario editado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/PaginacaoFuncionario")]
        public async Task<IActionResult> PaginacaoFuncionario([FromQuery] int page, string search = "")
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                _empresaId = identity?.Claims.FirstOrDefault(c => c.Type == "EmpresaId")?.Value;

                if (_empresaId == null) return Unauthorized();
                var paginacaoRequest = new PaginacaoRequest(page, Guid.Parse(_empresaId), search);

                var paginacaoResponse = await _funcionarioService.GetPaginacaoAsync(paginacaoRequest);

                if (paginacaoResponse == null) return BadRequest("Ocorreu um erro interno ao listar os funcionarios.");

                return Ok(paginacaoResponse);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
