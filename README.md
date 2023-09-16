# InterpreterPatternDemo

## Overview
Interpreter is a behavorial design pattern. The intent is; given a language to define a representation for its grammar along with an interpreter that uses the representation to interpret sentences in the language.

## Design
I have demonstrated this design pattern using a currency converter that converts three currencies to INR.

1. Dollar
2. NLC (Non-Linear currency): a hypothetical currency that follows a non linear relationship with INR
3. Rouble

The tokens in the string must be space separated and only integer inputs are allowed.
#### Features
1. Lowercase and uppercase currency names are supported
2. Overflow exception is handled
3. Invalid input exception is handled

## Classes and Interfaces
* ``IEvaluator`` : Exposes an interface for interpretation
* ``Interpreter`` : Evaluates the currency value to INR from input strings
* ``NumberExpression`` : Terminal rule for input currency value
* ``DollarToRupee`` : Non-terminal rule to interpret and return the value in INR
* ``NLCToRupee`` : Non-terminal rule to interpret and return the value in INR
* ``RoubleToRupee`` : Non-terminal rule to interpret and return the value in INR
* ``ConversionTests`` : Unit Test module

## Class Diagram
![Class Diagram](https://github.com/snehawk20/InterpreterPatternDemo/blob/master/Images/ClassDiagram.jpeg)
## Environment
The project builds and runs with Visual Studio Community 2022 when the required workloads are installed.