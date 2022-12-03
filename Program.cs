using AoC2022.day01;
using AoC2022.day02;
using AoC2022.day03;

namespace AoC2022;

public record struct Program
{
    public static async Task Main()
    {
        Console.WriteLine($"Day01 Part1 -> {await Day01.Part1()}");
        Console.WriteLine($"Day01 Part2 -> {await Day01.Part2()}\n");

        Console.WriteLine($"Day02 Part1 -> {await Day02.Part1()}");
        Console.WriteLine($"Day02 Part2 -> {await Day02.Part2()}\n");

        Console.WriteLine($"Day03 Part1 -> {await Day03.Part1()}");
        Console.WriteLine($"Day03 Part2 -> {await Day03.Part2()}\n");
    }
}