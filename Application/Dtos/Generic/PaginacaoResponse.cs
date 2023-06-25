namespace Application.Dtos.Generic
{
    public class PaginacaoResponse<T>
    {
        public PaginacaoResponse(int pageCount, List<T> values)
        {
            PageCount = pageCount;
            Values = values;
        }

        public int PageCount { get; set; }
        public List<T> Values { get; set; }
    }
}
