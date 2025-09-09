using ChangeCalculator.Models;

namespace ChangeCalculator.Services
{
    public interface IChangeCalculatorService
    {
        ChangeResponse CalculateChange(decimal amount);
    }
}