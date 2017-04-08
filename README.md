# Myob.CodingExercise

The following solution has been devloped to solve the problem of generating payslip information with the correct calculations done for finding an employee's pay period, gross income, income tax, net income and super.
I have approached the problem by utilizing a test driven approach whereby all units of work have been identified ehre possible and asserted for based on the information supplied.

From the requirements which where supplied I identified the smallest problem I could solve and started writing tests around that to help a design emerge.
The order of problems which I had solved were done in the following order:
1. Parsing of the input csv line to an employee object.
2. Finding the appropriate tax bracket for an employee.
3. Calculating the appropriate monthly income tax for an employee.
4. Calculating the property values related to a payslip.
5. Generating a payslip object. 
6. Converting the payslip object to a csv line.

The Following Solution is done in C# with NUnit being used as a testing framework in Visual Studio 2017.
To run the soltion simply open the .sln file in Visual Studio make sure the Myob.CodingExercise project is set as the start-up project and click play.
The initial program has a csv line input supplied in the program.cs and would right the results of the line to the console.


All feedback and advide to improve the solution is appreciated. :)
