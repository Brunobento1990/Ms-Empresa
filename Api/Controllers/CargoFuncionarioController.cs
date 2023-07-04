using Application.Dtos.CargoFuncionarioDtos;
using Application.Dtos.Generic;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CargoFuncionarioController : ControllerBase
    {
        private readonly ICargoFuncionarioService _cargoFuncionarioService;
        private string? _empresaId;

        public CargoFuncionarioController(ICargoFuncionarioService cargoFuncionarioService)
        {
            _cargoFuncionarioService = cargoFuncionarioService;
        }

        [HttpGet("/api/PaginacaoCargoFuncionario")]
        public async Task<IActionResult> PaginacaoCargoFuncionario([FromQuery] int page, string search = "")
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                _empresaId = identity?.Claims.FirstOrDefault(c => c.Type == "EmpresaId")?.Value;

                if (_empresaId == null) return Unauthorized();
                var paginacaoRequest = new PaginacaoRequest(page, Guid.Parse(_empresaId), search);

                var paginacaoResponse = await _cargoFuncionarioService.GetPaginacaoAsync(paginacaoRequest);

                if (paginacaoResponse == null) return BadRequest("Ocorreu um erro interno ao listar os cargos.");

                return Ok(paginacaoResponse);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/api/AdicionarCargoFuncionario")]
        public async Task<IActionResult> AdicionarCargoFuncionario([FromBody] CargoFuncionarioCreateDto cargoFuncionarioCreateDto)
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

                var result = await _cargoFuncionarioService.AdicionarCargoFuncionarioAsync(cargoFuncionarioCreateDto, Guid.Parse(_empresaId));

                if (!result) return BadRequest("Ocorreu um erro interno, tente novamente mais tarde.");

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/GetCargoFuncionario")]
        public async Task<IActionResult> GetCargoFuncionario([FromQuery] Guid id)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                _empresaId = identity?.Claims.FirstOrDefault(c => c.Type == "EmpresaId")?.Value;

                if (_empresaId == null) return Unauthorized();

                var servicoViewDto = await _cargoFuncionarioService.GetCargoIdAsync(id);

                return Ok(servicoViewDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/api/EditarCargoFuncionario")]
        public async Task<IActionResult> EditarCargoFuncionario([FromBody] CargoFuncionarioEditDto cargoFuncionarioEditDto)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                _empresaId = identity?.Claims.FirstOrDefault(c => c.Type == "EmpresaId")?.Value;

                if (_empresaId == null) return Unauthorized();

                var result = await _cargoFuncionarioService.EditarCargoAsync(cargoFuncionarioEditDto);

                if (!result) return BadRequest();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("/api/ExcluirCargoFuncionario")]
        public async Task<IActionResult> ExcluirCargoFuncionario([FromQuery] Guid id)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                _empresaId = identity?.Claims.FirstOrDefault(c => c.Type == "EmpresaId")?.Value;

                if (_empresaId == null) return Unauthorized();

                var result = await _cargoFuncionarioService.ExcluirCargoAsync(id);

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
