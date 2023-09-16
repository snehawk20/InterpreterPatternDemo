/******************************************************************************
* Filename    = ConvertCurrency.cs
*
* Author      = Sneha Bhattacharjee
*
* Product     = InterpreterCurrencyConvertorDemo
* 
* Project     = InterpreterPatternDemo
*
* Description = Defines a set of classes for implementing an interpreter pattern to convert different currencies to Rupee.
*****************************************************************************/

namespace InterpreterPatternDemo
{
    /// <summary>
    /// Terminal expression to interpret and return a stored integer value, which is initialized during construction
    /// </summary>
    public class NumberExpression : IEvaluator
    {
        private readonly long _number;

        public NumberExpression(long number)
        {
            _number = number;
        }

        public double  Interpret()
        {
            return _number;
        }
    }

    /// <summary>
    /// Non terminal expression to convert currency from Dollar to INR
    /// as per the exchange rate on 16/09/2023
    /// </summary>
    /// <exception cref="OverflowException">
    /// catches if the value in INR can fit into double
    /// </exception>
    public class DollarToRupee : IEvaluator
    {
        private readonly IEvaluator _value;
        private readonly double _exchange_rate = 83.09;
        public DollarToRupee(IEvaluator value)
        {
            _value = value;
        }
        public double Interpret()
        {
            double inrRate = 0;
            try
            {
                checked
                {
                    inrRate = _value.Interpret() * _exchange_rate;
                }
            }
            catch (OverflowException oex)
            {
                Console.WriteLine("Overflow encountered during conversion to INR");
            }
            return inrRate;
        }
    }

    /// <summary>
    /// Non terminal expression to convert currency from NLC to INR
    /// NLC is Non-Linear Currency (hypothetical case): It has a non linear exchange rate with INR
    /// as per the exchange rate on 16/09/2023
    /// </summary>
    /// <exception cref="OverflowException">
    /// catches if the value in INR can fit into double
    /// </exception>
    public class NLCToRupee : IEvaluator
    {
        private readonly IEvaluator _value;
        private readonly double _exchange_rate = 10.5;
        private readonly double _bias = 13.5;
        public NLCToRupee(IEvaluator value)
        {
            _value = value;
        }
        public double Interpret()
        {
            double inrRate = 0;
            try
            {
                checked
                {
                    inrRate = (_value.Interpret() + _bias) * (_exchange_rate + _bias);
                }
            }
            catch
            {
                Console.WriteLine("Overflow encountered during conversion to INR");
            }
            return inrRate;
        }
    }

    /// <summary>
    /// Non terminal expression to convert currency from Rouble to INR
    /// as per the exchange rate on 16/09/2023
    /// </summary>
    /// <exception cref="OverflowException">
    /// catches if the value in INR can fit into double
    /// </exception>
    public class RoubleToRupee : IEvaluator
    {
        private readonly IEvaluator _value;
        private readonly double _exchange_rate = 0.86;
        public RoubleToRupee(IEvaluator value)
        {
            _value = value;
        }
        public double Interpret()
        {
            double inrRate = 0;
            try
            {
                checked
                {
                    inrRate = _value.Interpret() * _exchange_rate;
                }
            }
            catch
            {
                Console.WriteLine("Overflow encountered during conversion to INR");
            }
            return inrRate;
        }
    }
}