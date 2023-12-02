using System.IO.IsolatedStorage;
using System.Text.RegularExpressions;
using AdventOfCode2023.Common;

namespace AdventOfCode2023.Days;

public class Day01 : ISolvable
{
    private readonly IEnumerable<String> _input = Utils.GetInput(1);
    
    private readonly Dictionary<string, string> _validNumbers = new()
    {
        { "one", "o1e" },
        { "two", "t2o" },
        { "three", "t3e" },
        { "four", "f4r" },
        { "five", "f5e" },
        { "six", "s6x" },
        { "seven", "s7n" },
        { "eight", "e8t" },
        { "nine", "n9e" }
    };
    
    public void partOne()
    {
        var total = _input.Sum(CombineFirstAndLast);
        Console.Write(total);
    }

    public void partTwo()
    {
        var total = _input
            .Select(ReplaceWithValidNumbers)
            .Sum(CombineFirstAndLast);
        Console.Write(total);
    }

    private static int CombineFirstAndLast(string line)
    {
        var digits = line.Where(char.IsDigit).ToList(); 
        if (digits.Count == 0) return 0;

        var first = digits.First() - '0';
        var last = digits.Last() - '0';

        var result = first.ToString() + last.ToString();

        return int.Parse(result);
    }
    
    private string ReplaceWithValidNumbers(string line)
    {
        foreach (var pair in _validNumbers)
        {
            line = Regex.Replace(line, pair.Key, pair.Value, RegexOptions.IgnoreCase);
        }
        
        return line;
    }
}