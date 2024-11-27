using System;

class Calculator
{
    static void Main(string[] args)
    {
        bool continueCalculating = true;

        Console.WriteLine("Welcome to the Calculator Application!");
        Console.WriteLine("------------------------------------");

        while (continueCalculating)
        {
            try
            {
                // Get first number
                Console.Write("\nEnter the first number: ");
                double num1 = Convert.ToDouble(Console.ReadLine());

                // Get operation
                Console.Write("Enter the operation (+, -, *, /): ");
                char operation = Console.ReadKey().KeyChar;
                Console.WriteLine();

                // Get second number
                Console.Write("Enter the second number: ");
                double num2 = Convert.ToDouble(Console.ReadLine());

                // Calculate and show result
                double result = PerformCalculation(num1, num2, operation);
                Console.WriteLine($"\nResult: {num1} {operation} {num2} = {result}");

                // Ask if user wants to continue
                Console.Write("\nDo you want to perform another calculation? (y/n): ");
                continueCalculating = Console.ReadLine().ToLower().StartsWith("y");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nError: Please enter valid numbers.");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("\nError: Cannot divide by zero.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn error occurred: {ex.Message}");
            }
        }

        Console.WriteLine("\nThank you for using the Calculator Application!");
    }

    static double PerformCalculation(double num1, double num2, char operation)
    {
        switch (operation)
        {
            case '+':
                return num1 + num2;
            case '-':
                return num1 - num2;
            case '*':
                return num1 * num2;
            case '/':
                if (num2 == 0)
                    throw new DivideByZeroException();
                return num1 / num2;
            default:
                throw new ArgumentException("Invalid operation. Please use +, -, *, or /");
        }
    }
}