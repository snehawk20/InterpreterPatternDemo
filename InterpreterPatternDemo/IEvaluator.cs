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
        public double Interpret();
    }
}
