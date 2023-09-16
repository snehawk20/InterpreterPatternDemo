/******************************************************************************
* Filename    = Interpreter.cs
*
* Author      = Sneha Bhattacharjee
*
* Product     = InterpreterCurrencyConvertorDemo
* 
* Project     = InterpreterPatternDemo
*
* Description = Defines a class to parse an input string to the value and its currency and invoke other classes for the conversion.
*****************************************************************************/

namespace InterpreterPatternDemo
{
    /// <summary>
    /// Converts an input string into tokens and identifies the value and currency
    /// Performs check for supported currencies
    /// </summary>
    public static class Interpreter
    {
        public static double Convert(string expression)
        {
            // Split the input string based on spaces
            string[] tokens = expression.Split(' ');
            long value = 0;
            string currency = "a";
            
            // Throw an exception if the input format is not followed
            if (tokens.Length != 2)
            {
                throw new Exception("Invalid input");
            }

            if (tokens.Length == 2)
            {
                // Try to parse the numerical component in the tokens
                // Ensure that a reverse input ($ 34) is also handled
                bool success = Int64.TryParse(tokens[0], out value);
                if (success)
                {
                    currency = tokens[1];
                }
                else
                {
                    success = Int64.TryParse(tokens[1], out value);
                    if (success)
                    {
                        currency = tokens[0];
                    }
                }
                // Convert the currency to lowercase
                currency = currency.ToLower();
            }

            // Use the interface and invoke the right conversion class
            IEvaluator rupeeValue = new NumberExpression(0);
            if (currency == "dollar" || currency == "dollars" || currency == "$")
            {
                rupeeValue = new DollarToRupee(new NumberExpression(value));
            }
            else if (currency == "nlc")
            {
                rupeeValue = new NLCToRupee(new NumberExpression(value));
            }
            else if (currency == "rouble" || currency == "roubles")
            {
                rupeeValue = new RoubleToRupee(new NumberExpression(value));
            }
            // Throw an exception if currency is unknown
            else
            {
                throw new Exception("Unsupported Currency");
            }
            return rupeeValue.Interpret();
        }
    }
}