using ProvaPub.Services.enums;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services.Payments;

public class PaymentStrategyFactory
{
    private readonly IEnumerable<IPaymentStrategy> _strategies;

    public PaymentStrategyFactory(IEnumerable<IPaymentStrategy> strategies)
    {
        _strategies = strategies;
    }

    public IPaymentStrategy GetStrategy(PaymentType method)
    {
        var strategy = _strategies.FirstOrDefault(x => x.Type == method);
        return strategy ?? throw new InvalidOperationException($"Método de pagamento {method} não suportado");
    }
}
