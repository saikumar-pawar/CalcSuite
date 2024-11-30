
Console.WriteLine("********************     Calculator Application      ********************");
bool continueCalculation = true;
do
{
    int number1 = GetNumberFromConsole();
    int number2 = GetNumberFromConsole();
    string operation = GetOperationFromConsole();

    if (IsOperationValid(number1, number2, operation))
    {
        long result = Calculate(number1, number2, operation);
        Console.WriteLine($"{operation} of {number1} and {number2} is {result}");
    }

    Console.Write("To perform another calculation enter [Y or y]: ");
    string? input = Console.ReadLine();
    continueCalculation = !string.IsNullOrWhiteSpace(input) && input.Trim().ToLower() == "y";

    if (!continueCalculation)
    {
        Console.WriteLine("********************     Exited Calculator Application      ********************");
    }
} while (continueCalculation);

static bool IsOperationValid(int number1, int number2, string operation)
{
    if (operation == "division")
    {
        if (number1 == 0 && number2 == 0)
        {
            Console.WriteLine("Result is undefined");
            return false;
        }
        else if (number2 == 0)
        {
            Console.WriteLine("Cannot divide by zero");
            return false;
        }
    }

    return true;
}

static long Calculate(int number1, int number2, string operation)
{
    long result = 0;

    switch (operation)
    {
        case "addition":
            result = number1 + number2;
            break;
        case "subtraction":
            result = number1 - number2;
            break;
        case "multiplication":
            result = number1 * number2;
            break;
        case "division":
            result = number1 / number2;
            break;
    }

    return result;
}

static int GetNumberFromConsole()
{
    while (true)
    {
        Console.Write("Enter a Number: ");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid Value.");
        }
        else
        {
            if (int.TryParse(input, out int number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid Value.");
            }
        }
    }
}

static string GetOperationFromConsole()
{
    string[] validOperations = { "addition", "subtraction", "multiplication", "division" };

    while (true)
    {
        Console.Write("Select a Operation among addition, subtraction, multiplication, and division: ");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid Operation.");
        }
        else
        {
            if (validOperations.Contains(input.Trim().ToLower()))
            {
                return input.Trim();
            }
            else
            {
                Console.WriteLine("Invalid Operation.");
            }
        }
    }
}
