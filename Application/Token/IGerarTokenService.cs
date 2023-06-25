using Domain.Entities;

namespace Application.Token
{
    public interface IGerarTokenService
    {
        string GetToken(Funcionario funcionario);
    }
}
