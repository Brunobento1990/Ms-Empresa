using Application.Dtos.EmpresaDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    public class EmpresaController : ControllerBase
    {
        private readonly IAdicionarEmpresaService _adicionarEmpresaService;
        private readonly IEmpresaService _empresaService;
        public EmpresaController(IAdicionarEmpresaService adicionarEmpresaService,
            IEmpresaService empresaService)
        {
            _empresaService = empresaService;
            _adicionarEmpresaService = adicionarEmpresaService;
        }
        [HttpPost("/api/AdicionarEmpresa")]
        public async Task<IActionResult> AdicionarEmpresa([FromBody] EmpresaCreateDto empresaCreateDto)
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

                var empresaViewlModel = await _adicionarEmpresaService.AdicionarEmpresaAsync(empresaCreateDto);

                if (empresaViewlModel is null) return BadRequest("Ocorreu um erro interno ao cadastrar a empresa.");

                return Created("Empresa cadastrada com sucesso !", empresaViewlModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/api/RetornarEmpresaPorId")]
        public async Task<IActionResult> RetornarEmpresaPorId()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                var empresaId = identity?.Claims.FirstOrDefault(c => c.Type == "EmpresaId")?.Value;

                if (empresaId == null) return Unauthorized();

                var empresaViewDto = await _empresaService.GetEmpresaById(Guid.Parse(empresaId));

                return Ok(empresaViewDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
