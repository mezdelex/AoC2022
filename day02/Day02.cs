namespace AoC2022.day02;

public record struct Day02
{
    public static Dictionary<string, int> Part1Conversion = new()
    {
        {"A X", 3},
        {"B Y", 3},
        {"C Z", 3},
        {"A Z", 0},
        {"B X", 0},
        {"C Y", 0},
        {"A Y", 6},
        {"B Z", 6},
        {"C X", 6}
    };

    public static Dictionary<string, int> ChoiceValue = new()
    {
        {"X", 1},
        {"Y", 2},
        {"Z", 3}
    };

    public static Dictionary<string, string> MustUse = new()
    {
        {"A X", "Z"},
        {"A Y", "X"},
        {"A Z", "Y"},
        {"B X", "X"},
        {"B Y", "Y"},
        {"B Z", "Z"},
        {"C X", "Y"},
        {"C Y", "Z"},
        {"C Z", "X"}
    };

    public static Dictionary<string, int> MatchValue = new() {
        {"X", 0},
        {"Y", 3},
        {"Z", 6}
    };

    public static async Task<IEnumerable<string>> ProcessInput()
    {
        string input = await File.ReadAllTextAsync("../../../day02/input.txt");

        return input.Trim().Split(Utils.NEW_LINE);
    }

    public static async Task<int> Part1() => (await ProcessInput())
        .Select(chunk => Part1Conversion[chunk] + ChoiceValue[chunk[2..]])
        .Sum();

    public static async Task<int> Part2() => (await ProcessInput())
        .Select(chunk => MatchValue[chunk[2..]] + ChoiceValue[MustUse[chunk]])
        .Sum();
}

public record class Day02Tests
{
    [Fact]
    public static async Task Tests()
    {
        Assert.Equal(8392, await Day02.Part1());
        Assert.Equal(10116, await Day02.Part2());
    }
}
