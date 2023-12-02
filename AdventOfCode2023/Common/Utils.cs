namespace AdventOfCode2023.Common;

public class Utils
{
    public static IEnumerable<String> GetInput(int day)
    {
        var filePath = $"Resources/day{day}.txt";
        foreach (var line in File.ReadLines(filePath))
        {
            yield return line;
        }
    }
}