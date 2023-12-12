// var input2 =
//     @"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
// Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
// Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
// Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
// Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";

const int expectedBlue = 14;
const int expectedRed = 12;
const int expectedGreen = 13;

var input = await File.ReadAllLinesAsync("input.txt");

FirstPart(input);

static void FirstPart(string[] input)
{
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
