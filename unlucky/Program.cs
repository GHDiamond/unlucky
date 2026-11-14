/* Color Code:
 * Yellow: Special
 * White: Info
 * Blue: Prompt
 * Green: Success
 * Red: Error
 * DarkBlue: Wait
 */

// Welcome screen
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("-= unlucky =-");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("A simple C# Console App project that shows all occurrences of Friday the 13th within a certain range of two dates.");
WaitForInput();
Console.Clear();

// Create Range: First Date
Console.ForegroundColor = ConsoleColor.Blue;
int startYear = AskForInt("[PROMPT] Year of first date of range", 1, 9999);
int startMonth = AskForInt("[PROMPT] Month of first date of range", 1, 12);
DateOnly start = new(startYear, startMonth, 13);
string startFormatted = start.ToString("yyyy-MM");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"[SUCCESS] First date of range: {startFormatted}");
WaitForInput();
Console.Clear();

// Create Range: Last Date
Console.ForegroundColor = ConsoleColor.Blue;
int endYear = AskForInt("[PROMPT] Year of last date of range", 1, 9999);
int endMonth = AskForInt("[PROMPT] Month of last date of range", 1, 12);
DateOnly end = new(endYear, endMonth, 13);
string endFormatted = end.ToString("yyyy-MM");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"[SUCCESS] Last date of range: {endFormatted}");
WaitForInput();
Console.Clear();

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine($"Searching from range: {startFormatted} - {endFormatted}");
WaitForInput(2);

// Date searching
int total = 0;
Console.ForegroundColor = ConsoleColor.White;
for (DateOnly date = start; date <= end;) // Increases months instead of days to save time
{
    if (date.DayOfWeek == DayOfWeek.Friday) // Checks if Friday
    {
        Console.WriteLine($"{date:yyyy-MM}");

        total++; // Increments the friday count since it has found a Friday 13th
    }
    date = date.AddMonths(1);
}
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"\n[SUCCESS] Searched withing range of {startFormatted} - {endFormatted} and found {total} total of Friday 13ths.");

// Exit screen
WaitForInput(0, "exit");

static int AskForInt(string label, int fromInclusive, int toInclusive)
{
    for (; ; )
    {
        Console.Write($"{label} ({fromInclusive} - {toInclusive}): ");
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR] Input cannot be null or empty.");
            WaitForInput();
            Console.Clear();
            continue;
        }
        if (!int.TryParse(input, out int result))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR] Input must be a number.");
            WaitForInput();
            Console.Clear();
            continue;
        }
        if (!(result >= fromInclusive && result <= toInclusive))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] Input must be {fromInclusive} - {toInclusive}.");
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
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.Write($"[WAIT] Press any key to {action}... ");
    Console.ReadKey();
    for (int i = 0; i < appendLines; i++)
    {
        Console.WriteLine();
    }
}
public class Search
{
    public string Label { get; set; } = "";
    public DateTime TimeStamp { get; set; }
    public DateOnly Start { get; set; }
    public DateOnly End { get; set; }
    public List<DateOnly> Results { get; set; } = [];
}