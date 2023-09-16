using Microsoft.EntityFrameworkCore;
namespace Task.Application.Common.Models
{
    public class Pagination<T>
    {
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set; }
        public List<T> Items { get; private set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;

        public Pagination(List<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (decimal)pageSize);
            TotalCount = count;
            Items = items;
        }

        public static async Task<Pagination<T>> CreateAsync(IQueryable<T>? source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            List<T> items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new Pagination<T>(items, count, pageNumber, pageSize);
        }
        public static async Task<Pagination<T>> CreateAsync(List<T>? source, int pageNumber, int pageSize)
        {
            var count = source.Count;
            List<T> items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return await System.Threading.Tasks.Task.FromResult(new Pagination<T>(items, count, pageNumber, pageSize));
        }
    }
}
