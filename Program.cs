do
{
    int input = ReadNumber("Enter a first value.");
    
    int operation = ReadOperation();

    int input2 = ReadNumber("Enter a second value.");

    try
    {
        int result = Calculate(input, input2, operation);
        PrintResult(result);
    }
    catch (DivideByZeroException ex)
    {
        Console.WriteLine($"Division by zero is not allowed. Please enter a non-zero value for the second number.");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Invalid operation selected. Please choose a valid operation.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    AskToContinue();
} while (true);


int Calculate(int input, int input2, int operation)
{
    switch (operation)
    {
        case 1:
            return input + input2;
        case 2:
            return input - input2;
        case 3:
            return input * input2;
        case 4:
            if (input2 != 0)
            {
                return input / input2;
            }
            else
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }
        default:
            throw new InvalidOperationException("Invalid operation selected.");
    }
}

char ReadOperation()
{
    Console.WriteLine("Choose an operation: +, -, *, /");
    string operation = Console.ReadLine();
    return operation;
}

int ReadNumber(string prompt)
{
    Console.WriteLine(prompt);
    return int.Parse(Console.ReadLine());
}

void PrintResult(int result)
{
    Console.WriteLine($"The result is: {result}");
}

void AskToContinue()
{
    Console.WriteLine("Do you want to perform another calculation? (y/n)");
    string response = Console.ReadLine();
    if (response.ToLower() != "y")
    {
        Environment.Exit(0);
    }
}