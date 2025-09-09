using ChangeCalculator.Models;

namespace ChangeCalculator.Services
{
    public class ChangeCalculatorService : IChangeCalculatorService
    {
        private readonly Dictionary<string, decimal> _denominations = new()
        {
            { "R200", 200.00m },
            { "R100", 100.00m },
            { "R50", 50.00m },
            { "R20", 20.00m },
            { "R10", 10.00m },
            { "R5", 5.00m },
            { "R2", 2.00m },
            { "R1", 1.00m },
            { "50c", 0.50m },
            { "20c", 0.20m },
            { "10c", 0.10m }
        };

        public ChangeResponse CalculateChange(decimal amount)
        {
            var response = new ChangeResponse();
            var remainingAmount = Math.Round(amount, 2);

            // Calculate R200 notes
            response.R200 = (int)(remainingAmount / _denominations["R200"]);
            remainingAmount -= response.R200 * _denominations["R200"];
            remainingAmount = Math.Round(remainingAmount, 2);

            // Calculate R100 notes
            response.R100 = (int)(remainingAmount / _denominations["R100"]);
            remainingAmount -= response.R100 * _denominations["R100"];
            remainingAmount = Math.Round(remainingAmount, 2);

            // Calculate R50 notes
            response.R50 = (int)(remainingAmount / _denominations["R50"]);
            remainingAmount -= response.R50 * _denominations["R50"];
            remainingAmount = Math.Round(remainingAmount, 2);

            // Calculate R20 notes
            response.R20 = (int)(remainingAmount / _denominations["R20"]);
            remainingAmount -= response.R20 * _denominations["R20"];
            remainingAmount = Math.Round(remainingAmount, 2);

            // Calculate R10 notes
            response.R10 = (int)(remainingAmount / _denominations["R10"]);
            remainingAmount -= response.R10 * _denominations["R10"];
            remainingAmount = Math.Round(remainingAmount, 2);

            // Calculate R5 coins
            response.R5 = (int)(remainingAmount / _denominations["R5"]);
            remainingAmount -= response.R5 * _denominations["R5"];
            remainingAmount = Math.Round(remainingAmount, 2);

            // Calculate R2 coins
            response.R2 = (int)(remainingAmount / _denominations["R2"]);
            remainingAmount -= response.R2 * _denominations["R2"];
            remainingAmount = Math.Round(remainingAmount, 2);

            // Calculate R1 coins
            response.R1 = (int)(remainingAmount / _denominations["R1"]);
            remainingAmount -= response.R1 * _denominations["R1"];
            remainingAmount = Math.Round(remainingAmount, 2);

            // Calculate 50c coins
            response.Fifty_Cents = (int)(remainingAmount / _denominations["50c"]);
            remainingAmount -= response.Fifty_Cents * _denominations["50c"];
            remainingAmount = Math.Round(remainingAmount, 2);

            // Calculate 20c coins
            response.Twenty_Cents = (int)(remainingAmount / _denominations["20c"]);
            remainingAmount -= response.Twenty_Cents * _denominations["20c"];
            remainingAmount = Math.Round(remainingAmount, 2);

            // Calculate 10c coins
            response.Ten_Cents = (int)(remainingAmount / _denominations["10c"]);

            return response;
        }
    }
}