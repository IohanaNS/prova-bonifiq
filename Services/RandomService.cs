using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services;

public class RandomService : IRandomService
{
    private readonly TestDbContext _ctx;
    private readonly Random _random;
    public RandomService(TestDbContext ctx)
    {
        _ctx = ctx;
        _random = new Random();
    }
    public int GetRandom()
    {
        var number = _random.Next(100);
        var numberToBeSaved = new RandomNumber() { Number = number };
        _ctx.Numbers.Add(numberToBeSaved);
        try
        {
            _ctx.SaveChanges();
        }
        catch (Exception)
        {
            _ctx.Entry(numberToBeSaved).State = EntityState.Detached;
        }
        return number;
    }
}
