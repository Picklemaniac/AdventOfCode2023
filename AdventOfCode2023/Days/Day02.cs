using System.Text.RegularExpressions;
using AdventOfCode2023.Common;

namespace AdventOfCode2023.Days;

public class Day02 : ISolvable
{   
    private readonly IEnumerable<String> _input = Utils.GetInput(2);

    public void PartOne()
    {
        int possibleSums = 0;
        
        foreach (var line in _input)
        {
            var (maxRed, maxGreen, maxBlue) = GetMaxValues(line);

            if (maxRed <= 12 && maxGreen <= 13 && maxBlue <= 14)
            {
                possibleSums += GetGameId(line);
            }
        }
        Console.WriteLine(possibleSums);
    }

    public void PartTwo()
    {
        int totalPower = 0;
        
        foreach (var line in _input)
        {
            var (maxRed, maxGreen, maxBlue) = GetMaxValues(line);
            totalPower += maxRed * maxGreen * maxBlue;
        }

        Console.WriteLine(totalPower);
    }

    private (int maxRed, int maxGreen, int maxBlue) GetMaxValues(string line)
    {
        int maxRed = 0, maxGreen = 0, maxBlue = 0;

        foreach (var set in GetSets(line))
        {
            var matches = Regex.Matches(set, @"(\d+)\s(red|green|blue)");
            int red = 0, green = 0, blue = 0;
            foreach (Match match in matches)
            {
                int count = int.Parse(match.Groups[1].Value);
                switch (match.Groups[2].Value)
                {
                    case "red": red = count; break;
                    case "green": green = count; break;
                    case "blue": blue = count; break;
                }
            }
                
            maxRed = Math.Max(maxRed, red);
            maxGreen = Math.Max(maxGreen, green);
            maxBlue = Math.Max(maxBlue, blue);
        }
        
        return (maxRed, maxGreen, maxBlue);
    }

    private int GetGameId(string line)
    {
        var match = Regex.Match(line, @"Game (\d+):");
        return int.Parse(match.Groups[1].Value);
    }

    private string[] GetSets(string line)
    {
        var setString = line.Split(":")[1];
        var sets = setString.Split(";");
        return sets;
    }
}