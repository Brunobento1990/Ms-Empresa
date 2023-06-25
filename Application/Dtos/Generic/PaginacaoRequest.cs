namespace Application.Dtos.Generic
{
    public class PaginacaoRequest
    {
        public PaginacaoRequest(int page, Guid empresaId, string search)
        {
            Page = page;
            EmpresaId = empresaId;
            Search = search;
        }

        public int Page { get; private set; }
        public Guid EmpresaId { get; private set; }
        public string Search { get; private set; }
    
    }
}
