using ProvaPub.Services.enums;

namespace ProvaPub.Services.Interfaces;

public interface IPaymentStrategy
{
    PaymentType Type { get; }
    Task Pay(decimal amount, int customerId);
}
