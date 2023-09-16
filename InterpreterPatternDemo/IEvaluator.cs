/******************************************************************************
* Filename    = IEvaluater.cs
*
* Author      = Sneha Bhattacharjee
*
* Product     = InterpreterCurrencyConvertorDemo
* 
* Project     = InterpreterPatternDemo
*
* Description = Interface for expression
*****************************************************************************/

namespace InterpreterPatternDemo
{
    /// <summary>
    /// Exposes an interface for expression interpretation.
    /// </summary>
    public interface IEvaluator
    {
        /// <summary>
        /// Interprets The object on which it is called
        /// </summary>
        /// <returns> Currency value in INR (type: double) </returns>
        public double Interpret();
    }
}
