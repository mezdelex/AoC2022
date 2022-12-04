using System.Text.RegularExpressions;
using AoC2022.shared;

namespace AoC2022.day04;

public record struct Day04
{
    public static async Task<IEnumerable<string[]>> ProcessInput()
    {
        string input = await File.ReadAllTextAsync("../../../day04/input.txt");

        return input.Split(Utils.NEW_LINE).Select(chunk => new Regex("[,-]").Split(chunk));
    }

    public static async Task<int> Part1() => (await ProcessInput())
        .Select(arr => (int.Parse(arr[0]) >= int.Parse(arr[2]) && int.Parse(arr[1]) <= int.Parse(arr[3]))
            | (int.Parse(arr[0]) <= int.Parse(arr[2]) && int.Parse(arr[1]) >= int.Parse(arr[3]))
            ? 1 : 0)
        .Sum();

    public static async Task<int> Part2() => (await ProcessInput())
        .Select(arr => (int.Parse(arr[0]) <= int.Parse(arr[2]) && int.Parse(arr[1]) >= int.Parse(arr[2]))
            | (int.Parse(arr[2]) <= int.Parse(arr[0]) && int.Parse(arr[3]) >= int.Parse(arr[0]))
            | (int.Parse(arr[1]) >= int.Parse(arr[3]) && int.Parse(arr[0]) <= int.Parse(arr[3]))
            | (int.Parse(arr[3]) >= int.Parse(arr[1]) && int.Parse(arr[2]) <= int.Parse(arr[1]))
            ? 1 : 0)
        .Sum();
}

public record class Day04Tests
{
    [Fact]
    public static async Task Tests()
    {
        Assert.Equal(await Day04.Part1(), 500);
        Assert.Equal(await Day04.Part2(), 815);
    }
}