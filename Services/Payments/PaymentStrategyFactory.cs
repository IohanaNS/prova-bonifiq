using ProvaPub.Services.enums;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services.Payments;

public class PaymentStrategyFactory
{
    private readonly Dictionary<PaymentType, IPaymentStrategy> _strategies;

    public PaymentStrategyFactory(IEnumerable<IPaymentStrategy> strategies)
    {
        _strategies = strategies.ToDictionary(m => m.Type);
    }

    public IPaymentStrategy GetStrategy(PaymentType method)
    {
        if (!_strategies.TryGetValue(method, out var strategy))
            throw new InvalidOperationException($"Método de pagamento {method} não suportado");

        return strategy;
    }
}
