namespace Pressur.Domain.Abstractions.Paginacao
{
    public class Page<TItem>
        where TItem : class
    {
        public bool HasNext { get; set; }
        public IEnumerable<TItem> Itens { get; set; }

        public Page<TItemDestino> ConvertPage<TItemDestino>(IEnumerable<TItemDestino> itensDestino)
            where TItemDestino : class
            => new Page<TItemDestino>(itensDestino, HasNext);

        public Page(IEnumerable<TItem> itens, bool hasNext)
        {
            HasNext = hasNext;
            Itens = itens;
        }

        public Page(IEnumerable<TItem> itens, int maxPageSize)
        {
            HasNext = (itens?.Count() ?? maxPageSize) > maxPageSize;
            Itens = itens?.Take(maxPageSize) ?? new List<TItem>();
        }
    }
}