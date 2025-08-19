using ProvaPub.Models;
using ProvaPub.Services.enums;

namespace ProvaPub.Services.Interfaces;

public interface IOrderService
{
    Task<Order> InsertOrder(Order order);
    Task<Order> PayOrder(PaymentType paymentMethod, decimal paymentValue, int customerId);
}