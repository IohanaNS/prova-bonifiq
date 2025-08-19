using ProvaPub.Models;

namespace ProvaPub.Services.Payments;

public interface IPageService<T> where T : class
{
    PagedList<T> List(int page);
}
