using ProvaPub.Models;
using ProvaPub.Services.Payments;

namespace ProvaPub.Services.Interfaces;

public interface ICustomerService : IPageService<Customer>
{
    Task<bool> CanPurchase(int customerId, decimal purchaseValue);
}
