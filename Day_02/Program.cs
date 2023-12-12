const int expectedBlue = 14;
const int expectedRed = 12;
const int expectedGreen = 13;

var input = await File.ReadAllLinesAsync("input.txt");

FirstPart(input);

Console.WriteLine();

SecondPart(input);

static void SecondPart(string[] input)
{
    Console.WriteLine("Second Part");
    var sum = input.Sum(GetNumber);
    Console.WriteLine("Result");
    Console.WriteLine(sum); //72513
    return;

    static int GetNumber(string text)
    {
        var gamesParts = text.Split(':');
        var colorParts = gamesParts[1].Split(';');

        var blueMax = 0;
        var redMax = 0;
        var greenMax = 0;

        foreach (var colorPart in colorParts)
        {
            var colors = colorPart.Split(',');
            foreach (var color in colors)
            {
                var colorData = color.Split(' ');
                switch (colorData[2])
                {
                    case "blue":
                        var blue = int.Parse(colorData[1]);
                        if (blue > blueMax)
                        {
                            blueMax = blue;
                        }

                        break;
                    case "green":
                        var green = int.Parse(colorData[1]);
                        if (green > greenMax)
                        {
                            greenMax = green;
                        }

                        break;
                    case "red":
                        var red = int.Parse(colorData[1]);
                        if (red > redMax)
                        {
                            redMax = red;
                        }

                        break;
                }
            }
        }

        return blueMax * greenMax * redMax;
    }
}

static void FirstPart(string[] input)
{
    Console.WriteLine("First Part");
    var sum = input.Sum(GetNumber);
    Console.WriteLine("Result");
    Console.WriteLine(sum); //2162
    return;

    static int GetNumber(string text)
    {
        var valid = true;
        var gamesParts = text.Split(':');
        var colorParts = gamesParts[1].Split(';');

        foreach (var colorPart in colorParts)
        {
            var colors = colorPart.Split(',');
            foreach (var color in colors)
            {
                var blue = 0;
                var red = 0;
                var green = 0;
                var colorData = color.Split(' ');
                switch (colorData[2])
                {
                    case "blue":
                        blue += int.Parse(colorData[1]);
                        break;
                    case "green":
                        green += int.Parse(colorData[1]);
                        break;
                    case "red":
                        red += int.Parse(colorData[1]);
                        break;
                }

                if (blue > expectedBlue || red > expectedRed || green > expectedGreen)
                {
                    valid = false;
                    break;
                }
            }
        }

        if (valid)
        {
            var id = gamesParts[0].Split(' ')[1];
            return int.Parse(id);
        }

        return 0;
    }
}
