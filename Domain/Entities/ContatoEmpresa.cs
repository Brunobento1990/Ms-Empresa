using Domain.Validations;

namespace Domain.Entities
{
    public sealed class ContatoEmpresa : BaseEntity
    {

        public string? Ddd { get; private set; }
        public string? Telefone { get; private set; }
        public string? Email { get; private set; }
        public Guid EmpresaId { get; set; }
        public Empresa Empresa { get; set; } = null!;

        public ContatoEmpresa(string? ddd, string? telefone, string? email)
        {
            const string messageError = "É obrigatório informar";

            Validation.ValidationString($"{telefone}{email}", $"{messageError} o telefone ou o email da empresa.");
            
            Ddd = ddd;
            Telefone = telefone;
            Email = email;
        }
    }
}
