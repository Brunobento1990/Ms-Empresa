using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Auth
{
    public class AuthCustom : AuthorizeAttribute, IAuthorizationFilter
    {
        private string _action;

        public AuthCustom(string action)
        {
            _action = action;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var permissaoAdicionar = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Adicionar")?.Value;
            var permissaoEditar = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Editar")?.Value;
            var permissaoExcluir = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Excluir")?.Value;
            var permissaoAdicionarEmpresa = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Master")?.Value;

            if(permissaoAdicionar == null || permissaoEditar == null || permissaoExcluir == null || permissaoAdicionarEmpresa == null)
                context.Result = new UnauthorizedResult();

            if (permissaoAdicionar != "TRUE" && _action == "Adicionar") context.Result = new UnauthorizedResult();
            if (permissaoEditar != "TRUE" && _action == "Editar") context.Result = new UnauthorizedResult();
            if (permissaoExcluir != "TRUE" && _action == "Excluir") context.Result = new UnauthorizedResult();
            if (permissaoAdicionarEmpresa != "TRUE" && _action == "AdicionarEmpresa") context.Result = new UnauthorizedResult();
        }
    }
}
