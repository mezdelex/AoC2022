namespace AoC2022.day01;

public record struct Day01
{
    public static async Task<IEnumerable<int>> ProcessInput()
    {
        string input = await File.ReadAllTextAsync("../../../day01/input.txt");

        return input.Trim().Split("\n\n").Select(chunk => chunk.Split("\n").Sum(int.Parse));
    }

    public static async Task<int> Part1() => (await ProcessInput()).Max();

    public static async Task<int> Part2() => (await ProcessInput()).OrderByDescending(value => value).Take(3).Sum();
}

public record class Day01Tests
{
    [Fact]
    public static async Task Tests()
    {
        Assert.Equal(69528, await Day01.Part1());
        Assert.Equal(206152, await Day01.Part2());
    }
}