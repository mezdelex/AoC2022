namespace AoC2022.day04;

public record struct Day04
{
    public static async Task<IEnumerable<string[]>> ProcessInput()
    {
        string input = await File.ReadAllTextAsync("../../../day04/input.txt");

        return input
            .Trim()
            .Split(Utils.NEW_LINE)
            .Select(chunk => new Regex("[,-]", RegexOptions.Compiled
                        | RegexOptions.NonBacktracking
                        | RegexOptions.IgnoreCase)
                    .Split(chunk));
    }

    public static async Task<int> Part1() => (await ProcessInput())
        .Select(arr => (int.Parse(arr[0]) >= int.Parse(arr[2]) && int.Parse(arr[1]) <= int.Parse(arr[3]))
            | (int.Parse(arr[0]) <= int.Parse(arr[2]) && int.Parse(arr[1]) >= int.Parse(arr[3]))
            ? 1 : 0)
        .Sum();

    public static async Task<int> Part2() => (await ProcessInput())
        .Select(arr => int.Parse(arr[0]) > int.Parse(arr[3]) | int.Parse(arr[1]) < int.Parse(arr[2])
            ? 0 : 1)
        .Sum();
}

public record class Day04Tests
{
    [Fact]
    public static async Task Tests()
    {
        Assert.Equal(500, await Day04.Part1());
        Assert.Equal(815, await Day04.Part2());
    }
}
