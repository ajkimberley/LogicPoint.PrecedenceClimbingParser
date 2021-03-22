# LogicPoint.PrecedenceClimbingParser
An operator precedence climbing parser for a simple arithmetic grammar.

This library demonstrates an implementation of the Precedence Climbing algorithm in C# for a basic grammar of arithmetic (supporting positive integers, brackets, addition, subtraction, multiplication, division and exponentiation).
The two main aritlces which inspired and informed this demonstration were [Parsing Expressions by Recursive Descent](https://www.engr.mun.ca/~theo/Misc/exp_parsing.htm) by Theodore Norvell (which is an excellent read for anyone interested how to deal with precedence and associativity in recursive descent parsers) and [Parsing Expressions by Precedence Climbing](https://eli.thegreenplace.net/2012/08/02/parsing-expressions-by-precedence-climbing) by Eli Bendersky (which is an excellent primer and explanation on the precedence climbing algorithm).

I plan to expand this library handle a larger subset of arithmetic grammar (e.g., decimals and negative numbers) and also to eventually provide support for logical grammars. 
