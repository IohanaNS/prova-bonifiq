using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services.Payments;

namespace ProvaPub.Services;

public class PageService<T> : IPageService<T> where T : class
{
    protected readonly TestDbContext _ctx;
    private const int DefaultPageSize = 10;

    public PageService(TestDbContext ctx)
    {
        _ctx = ctx;
    }

    public PagedList<T> List(int page)
    {
        var totalCount = _ctx.Set<T>().Count();
        var totalPages = (int)Math.Ceiling(totalCount / (double)DefaultPageSize);

        var items = _ctx.Set<T>()
            .OrderBy(e => EF.Property<object>(e, "Id"))
            .Skip((page - 1) * DefaultPageSize)
            .Take(DefaultPageSize)
            .ToList();

        return new PagedList<T>
        {
            HasNext = (page < totalPages && items.Count > 0),
            TotalCount = totalCount,
            Result = items
        };
    }
}
