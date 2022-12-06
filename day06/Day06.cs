namespace AoC2022.day06;

public record struct Day06
{
    public static async Task<string> ProcessInput() => await File.ReadAllTextAsync("../../../day06/input.txt");

    public static async Task<int> GetMarker(int secuence)
    {
        string input = await ProcessInput();

        return Enumerable.Range(secuence, input.Length).Where(i => input[(i - secuence)..i].Distinct().Count() == secuence).FirstOrDefault();
    }

    public static async Task<int> Part1() => await GetMarker(4);

    public static async Task<int> Part2() => await GetMarker(14);
}

public record class Day06Tests
{
    [Fact]
    public static async Task Tests()
    {
        Assert.Equal(1238, await Day06.Part1());
        Assert.Equal(3037, await Day06.Part2());
    }
}