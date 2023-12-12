﻿var input = await File.ReadAllLinesAsync("input.txt");

FirstPart(input);
Console.WriteLine();
SecondPart(input);


static void SecondPart(string[] input)
{
    var numbers = new Dictionary<string, int>
    {
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 },
        { "1", 1 },
        { "2", 2 },
        { "3", 3 },
        { "4", 4 },
        { "5", 5 },
        { "6", 6 },
        { "7", 7 },
        { "8", 8 },
        { "9", 9 },
    };

    Console.WriteLine("Second Part");
    Console.WriteLine($"{GetNumber("two1nine")} 29");
    Console.WriteLine($"{GetNumber("eightwothree")} 83");
    Console.WriteLine($"{GetNumber("abcone2threexyz")} 13");
    Console.WriteLine($"{GetNumber("xtwone3four")} 24");
    Console.WriteLine($"{GetNumber("4nineeightseven2")} 42");
    Console.WriteLine($"{GetNumber("zoneight234")} 14");
    Console.WriteLine($"{GetNumber("7pqrstsixteen")} 76");

    var sum = input.Sum(GetNumber);
    Console.WriteLine("Result");
    Console.WriteLine(sum); //54940
    return;

    int GetNumber(string text)
    {
        var min = text.Length;
        var firstNumber = 0;
        var max = -1;
        var lastNumber = 0;
        foreach (var (key, value) in numbers)
        {
            var index = text.IndexOf(key, StringComparison.Ordinal);
            if (index == -1)
            {
                continue;
            }

            if (index < min)
            {
                min = index;
                firstNumber = value;
            }

            index = text.LastIndexOf(key, StringComparison.Ordinal);
            if (index > max)
            {
                max = index;
                lastNumber = value;
            }
        }

        return firstNumber * 10 + lastNumber;
    }
}

static void FirstPart(string[] input)
{
    Console.WriteLine("First Part");
    Console.WriteLine($"{GetNumber("1abc2")} 12");
    Console.WriteLine($"{GetNumber("pqr3stu8vwx")} 38");
    Console.WriteLine($"{GetNumber("a1b2c3d4e5f")} 15");
    Console.WriteLine($"{GetNumber("treb7uchet")} 77");

    var sum = input.Sum(GetNumber);
    Console.WriteLine("Result");
    Console.WriteLine(sum); //54940
    return;

    static int GetNumber(string text)
    {
        var result = new[]
        {
            text.First(char.IsDigit),
            text.Last(char.IsDigit)
        };

        return int.Parse(result);
    }
}