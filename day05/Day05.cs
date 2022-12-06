using System.Text.RegularExpressions;
using AoC2022.shared;

namespace AoC2022.day05;

public record struct Day05
{
    public static async Task<(Stack<char>[], string[])> ProcessInput()
    {
        string input = await File.ReadAllTextAsync("../../../day05/input.txt");

        string[] chunks = new Regex($"{Utils.NEW_LINE}+{Utils.NEW_LINE}|{Utils.NEW_LINE}", RegexOptions.Compiled | RegexOptions.NonBacktracking | RegexOptions.IgnoreCase).Split(input);

        Stack<char>[] stacks = { new(), new(), new(), new(), new(), new(), new(), new(), new() };

        for (int i = 7; i >= 0; --i)
            for (int j = stacks.Length - 1; j >= 0; --j)
                if (chunks[i][1 + j * 4] != ' ')
                    stacks[j].Push(chunks[i][1 + j * 4]);

        return (stacks, chunks);
    }

    public static async Task<string> GetCrates(bool isPart1)
    {
        (Stack<char>[], string[]) pInput = await ProcessInput();

        for (int i = 9; i < pInput.Item2.Length; ++i)
        {
            MatchCollection instructions = Regex.Matches(pInput.Item2[i], $"\\d+", RegexOptions.Compiled | RegexOptions.NonBacktracking | RegexOptions.IgnoreCase);

            if (isPart1)
            {
                for (int j = 0; j < int.Parse(instructions[0].Value); ++j)
                    pInput.Item1[int.Parse(instructions[2].Value) - 1].Push(pInput.Item1[int.Parse(instructions[1].Value) - 1].Pop());
            }
            else
            {
                Stack<char> temp = new();

                for (int j = 0; j < int.Parse(instructions[0].Value); ++j)
                    temp.Push(pInput.Item1[int.Parse(instructions[1].Value) - 1].Pop());

                for (int j = 0; j < int.Parse(instructions[0].Value); ++j)
                    pInput.Item1[int.Parse(instructions[2].Value) - 1].Push(temp.Pop());
            }
        }

        string result = string.Empty;
        foreach (Stack<char> stack in pInput.Item1)
            result += stack.Peek();

        return result;
    }

    public static async Task<string> Part1() => await GetCrates(true);

    public static async Task<string> Part2() => await GetCrates(false);
}

public record class Day05Tests
{
    [Fact]
    public static async Task Tests()
    {
        Assert.Equal("FWSHSPJWM", await Day05.Part1());
        Assert.Equal("PWPWHGFZS", await Day05.Part2());
    }
}