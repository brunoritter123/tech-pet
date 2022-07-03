namespace TechPet.Domain.Abstractions.Paginacao
{
    public class Page<TItem>
        where TItem : class
    {
        public bool HasNext { get; set; }
        public IEnumerable<TItem> Items { get; set; }

        public Page(IEnumerable<TItem> items, bool hasNext)
        {
            HasNext = hasNext;
            Items = items;
        }

        public Page(IEnumerable<TItem> items, int maxPageSize)
        {
            HasNext = (items?.Count() ?? maxPageSize) > maxPageSize;
            Items = items?.Take(maxPageSize) ?? new List<TItem>();
        }
    }
}