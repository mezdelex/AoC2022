namespace AoC2022.day03;

public record struct Day03
{
    // See http://sticksandstones.kstrom.com/appen.html
    public static int ObtainValueFromAsciiSource(char character) => char.IsLower(character) ? (int)character - 96 : (int)character - 38;

    public static async Task<IEnumerable<string>> ProcessInput()
    {
        string input = await File.ReadAllTextAsync("../../../day03/input.txt");

        return input.Trim().Split("\n");
    }

    public static async Task<int> Part1() => (await ProcessInput())
        .Select(chunk => new string[2] { chunk.Substring(0, chunk.Length / 2), chunk.Substring(chunk.Length / 2) })
        .Select(subChunk => subChunk[0].Intersect(subChunk[1]).SingleOrDefault())
        .Sum(ObtainValueFromAsciiSource);

    public static async Task<int> Part2() => (await ProcessInput())
        .Chunk(3)
        .Select(subChunk => subChunk[0].Intersect(subChunk[1]).Intersect(subChunk[2]).SingleOrDefault())
        .Sum(ObtainValueFromAsciiSource);
}

public record class Day03Tests
{
    [Fact]
    public static async Task Tests()
    {
        Assert.Equal(8515, await Day03.Part1());
        Assert.Equal(2434, await Day03.Part2());
    }
}