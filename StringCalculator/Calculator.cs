using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            string delimiter = ",";
            if (string.IsNullOrEmpty(numbers) || string.IsNullOrWhiteSpace(numbers))
                return 0;
            numbers = numbers.Replace(" ", "");

            if (numbers.StartsWith("//"))
            {
                var separatedDelimiterAndValues = numbers.Substring(2).Split("\n", 2);
                delimiter = separatedDelimiterAndValues.First();
                numbers = separatedDelimiterAndValues.Last();
                
            }

            numbers = numbers.Replace("\n", delimiter);
            if (numbers.Contains(delimiter+ delimiter))
                throw new Exception("invalid input");

            
            var valuesAsString = numbers.Split(delimiter);
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
