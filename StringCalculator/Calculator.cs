using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            string delimiter = ",";
            string containsNegativeValues = "";

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

            foreach (var v in valuesAsInteger)
            {
                if (v < 0)
                    containsNegativeValues += v + " ";
            }

            if (! string.IsNullOrEmpty(containsNegativeValues))
                throw new Exception("negatives not allowed :" + containsNegativeValues);

            return valuesAsInteger.Sum();
        }
    }
}
