using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers) || string.IsNullOrWhiteSpace(numbers))
                return 0;
            numbers = numbers.Replace(" ", "");
            numbers = numbers.Replace("\n", ",");
            if (numbers.Contains(",,"))
                throw new Exception("invalid input");

            
            var valuesAsString = numbers.Split(',');
            var valuesAsInteger = valuesAsString.Select(v =>
            {
                var result = 0;
                int.TryParse(v, out result);
                return result;
            });

            return valuesAsInteger.Sum();
        }
    }
}
