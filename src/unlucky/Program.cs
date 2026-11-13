// Welcome screen
Console.WriteLine("unlucky\nA simple C# Console App project that shows all occurrences of Friday the 13th within a certain range of two dates.");
WaitForInput();
Console.Clear();

// Create Range: First Date
int firstDateYear = AskForIntFromRange("Year of first date of range", 1, 9999);
int firstDateMonth = AskForIntFromRange("Month of first date of range", 1, 12);
DateOnly firstDate = new(firstDateYear, firstDateMonth, 13);
string firstDateFormatted = firstDate.ToString("yyyy-MM");
Console.WriteLine($"First date of range: {firstDateFormatted}");
WaitForInput();
Console.Clear();

// Create Range: Last Date
int lastDateYear = AskForIntFromRange("Year of last date of range", 1, 9999);
int lastDateMonth = AskForIntFromRange("Month of last date of range", 1, 12);
DateOnly lastDate = new(lastDateYear, lastDateMonth, 13);
string lastDateFormatted = lastDate.ToString("yyyy-MM");
Console.WriteLine($"Last date of range: {lastDateFormatted}");
WaitForInput();
Console.Clear();

Console.WriteLine($"Searching from range: {firstDateFormatted} - {lastDateFormatted}");
WaitForInput(2);

// Date searching
int total = 0;
for (DateOnly date = firstDate; date <= lastDate;) // Increases months instead of days to save time
{
    if (date.DayOfWeek == DayOfWeek.Friday) // Checks if Friday
    {
        Console.WriteLine($"{date:yyyy-MM} is Friday 13th");
        total++; // Increments the friday count since it has found a Friday 13th
    }
    date = date.AddMonths(1);
}
Console.WriteLine($"\nSearched withing range of {firstDateFormatted} - {lastDateFormatted} and found {total} total of Friday 13ths.");

// Exit screen
WaitForInput(0, "exit");

static int AskForIntFromRange(string label, int fromInclusive, int toInclusive)
{
    for (; ; )
    {
        Console.Write($"{label} ({fromInclusive} - {toInclusive}): ");
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Invalid. Input cannot be null or empty.");
            WaitForInput();
            Console.Clear();
            continue;
        }
        if (!int.TryParse(input, out int result))
        {
            Console.WriteLine("Invalid. Input must be a number.");
            WaitForInput();
            Console.Clear();
            continue;
        }
        if (!(result >= fromInclusive && result <= toInclusive))
        {
            Console.WriteLine($"Invalid. Input must be {fromInclusive} - {toInclusive}.");
            WaitForInput();
            Console.Clear();
            continue;
        }
        Console.Clear();
        return result;
    }
}

static void WaitForInput(int appendLines = 0, string action = "continue")
{
    Console.Write($"Press any key to {action}... ");
    Console.ReadKey();
    for (int i = 0; i < appendLines; i++)
    {
        Console.WriteLine();
    }
}
