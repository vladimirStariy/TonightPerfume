namespace TonightPerfume.Domain.Utils
{
    public class PagedList<T>: List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageCount { get; private set; }
        public int TotalPagesCount { get; private set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPagesCount;

        public PagedList(List<T> items, int count, int pageNumber, int pageSize) 
        { 
            TotalPagesCount = count;
            CurrentPage = pageNumber;
            TotalPages = (int)MathF.Ceiling(count / (float)pageSize);

            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
