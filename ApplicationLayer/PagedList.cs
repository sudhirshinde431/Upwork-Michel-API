using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public class PagedList<T>
    {
        private PagedList(List<T> items, int page, int pageSize, int totalCount)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        public List<T> Items { get; }

        public int Page { get; }

        public int PageSize { get; }

        public int TotalCount { get; }

        public bool HasNextPage => (Page == 0) ? false : Page * PageSize < TotalCount;

        public bool HasPreviousPage => (Page == 0) ? false : Page > 1;

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> query, int page, int pageSize)
        {
            if (pageSize == 0 && page == 0)
            {

                var totalCount = await query.CountAsync();
                var items = await query.ToListAsync();
                page = 1;
                pageSize = totalCount;
                return new(items, page, pageSize, totalCount);

            }
            else
            {
                var totalCount = await query.CountAsync();
                var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

                return new(items, page, pageSize, totalCount);
            }

        }
    }
}
