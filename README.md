# Counter Challenge
## Problem Statement
User input of any form is to be split into words based on non-alphabetic delimiters, and displayed in the following format: 

<First Letter><Number of unique characters between the first and the last letters><Last Letter>

Following are examples of the above:
* "Microsoft" -> "M6t"
* "Hello" -> "H2o"

The one exception is a word with a single letter, 
in which the word is kept as is. For example, 
* "a" -> "a"

All non-alphabetic characters have to retain their position in the
resulting string. Therefore, we have that
* "Good morning! It is a new day!" -> "G1d m4g! I0t i0s a n1w d1y!"

## Solution
The solution was implemented using a C# console application written in .NET 6, and with a parsing service injected through Microsoft Dependency Injections. The solution was tested using XUnit. 
