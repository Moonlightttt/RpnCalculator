# RpnCalculator

Reverse Polish Notation (RPN) is a mathematical notation in which every operator follows all of its operands.
Expression written “(3 + 4) * 5” in conventional notation would be written “3 4 + 5 *” in RPN. This provides a
fixed evaluation sequence without the usage of parentheses. More examples are given below.

| RPN Expression |Calculation Result|
|:--------------:|:---:|
|   4 2 3 * +    | 10|
| 27 3 4 5 + * / |1|
| 4 2 * 3 + 1 -  |10|

### Requirements

The request now is to implement a command line based RPN Calculator with detailed requirements listed
below. Some sample input / output are included in appendix.

* The calculator accepts a list of whitespace separated numbers from command line
* Once completed calculation of the list of inputs, it prints its internal calculation buffer as a space
  separated list and waits for next input
* The calculator should recognize these 6 operators: + - * / undo clear and should be easy enough for
  future extension to include new operators, e.g. sqrt
* \+ - * / performs addition, subtraction, multiplication, division operations respectively with 2 operands
* undo cancels previous operation, i.e. restores calculation buffer to previous state by removing operand
  (number) directly or returning first operand of the calculation
* clear cleans everything stored in the calculation buffer
* All numbers should be stored with at least 15 decimal places of precision, but displayed in plain decimal
  format (no engineering format) with 10 decimal places of precision
* The calculator prints a warning message in format below if there are not enough operands to perform
  calculation of an operator
  operator \<operator> (position: \<position>): insufficient operands
* The calculator should continue waiting for next input once it prints warning messages and should only
  be terminated by user (ctrl + c)