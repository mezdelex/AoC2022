namespace AoC2022.day01;

public record struct Day01
{
    public static async Task<IEnumerable<int>> ProcessInput()
    {
        string input = await File.ReadAllTextAsync("./day01/input.txt");

        return input.Trim().Split("\r\n\r\n").Select(chunk => chunk.Split("\r\n").Sum(int.Parse));
    }

    public static async Task<int> Part1() => (await ProcessInput()).Max();

    public static async Task<int> Part2() => (await ProcessInput()).OrderByDescending(value => value).Take(3).Sum();
}