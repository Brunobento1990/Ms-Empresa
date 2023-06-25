using Domain.Validations;

namespace Domain.Entities
{
    public sealed class EnderecoEmpresa : BaseEntity
    {
        public string Cep { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Numero { get; private set; }
        public Guid EmpresaId { get; set; }
        public Empresa Empresa { get; set; } = null!;

        public EnderecoEmpresa(string cep, 
            string rua, 
            string bairro, 
            string cidade, 
            string estado, 
            string numero)
        {
            const string messageError = "É obrigatório informar";

            Validation.ValidationString(cep, $"{messageError} o cep da empresa.");
            Validation.ValidationString(rua, $"{messageError} a rua da empresa.");
            Validation.ValidationString(bairro, $"{messageError} o bairro da empresa.");
            Validation.ValidationString(cidade, $"{messageError} a cidade da empresa.");
            Validation.ValidationString(estado, $"{messageError} o estado da empresa.");
            Validation.ValidationString(numero, $"{messageError} o número da empresa.");

            Cep = cep;
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Numero = numero;
        }
    }   
}
