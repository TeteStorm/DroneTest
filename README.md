# Drone Code Test

Implement an algorithm for the position control of a drone in a Cartesian plane (X, Y).

 

The starting point of the drone is "(0, 0)" for each run of the Evaluate method when running each unit test.

 

The input string can contain the following N, S, L, and O characters representing North, South, East, and West, respectively.

These characters may be randomly present in the input string. An input string "NNNLLL" will result in an end position "(3, 3)", just as a string "NLNLNL" will result in "(3, 3)".

 

If the character X is present, it will cancel the previous operation. If there is more than one consecutive X character, it will cancel more than one action in the amount X is present.

An input string "NNNXLLLXX" will result in an end position "(1, 2)" since the string could be simplified to "NNL".

 

In addition, a number may be present after the character of the operation, representing the "step" that the operation must accumulate.

This number must be between 1 and 2147483647.

It should be noted that operation 'X' does not support 'step' option and should be considered invalid.

- An input string "NNX2" should be considered invalid.

-An input string "N123LSX" will result in an end position "(1, 123)" because the string can be simplified to "N123L".

-An input string "NLS3X" will result in an end position "(1, 1)" since the string can be simplified to "NL".

 

If the input string is invalid or has some other problem, the result should be "(999, 999)".

 

COMMENTS:

- Perform an implementation with code standards for "production" environment.

- Comment the code explaining what is relevant to the solution of the problem.

- Add unit tests to achieve relevant test coverage.
