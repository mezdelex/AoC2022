using AoC2022.day1;

namespace AoC2022;

public record struct Program
{
    public static async Task Main()
    {
        Console.WriteLine($"Day01 Part1 -> {await Day01.Part1()}");
        Console.WriteLine($"Day01 Part2 -> {await Day01.Part2()}");
    }
}