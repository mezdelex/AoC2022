namespace AoC2022.day07;

public record struct Day07
{
    private record class Item
    {
        public bool isFolder { get; set; }
        public int Size { get; set; }
        public string? ItemName { get; set; }
        public string? Path { get; set; }
    }

    private static async Task<IEnumerable<Item?>> ProcessInput()
    {
        string input = await File.ReadAllTextAsync("../../../day07/input.txt");

        Stack<string> currentPath = new();

        IEnumerable<Item?> items = input.Split(Utils.NEW_LINE)
            .Where(chunk => !chunk.Contains("$ ls") && !chunk.Contains("dir"))
            .Select<string, Item?>(chunk =>
            {
                if (chunk.Contains(".."))
                {
                    currentPath.Pop();
                    return null;
                }

                if (chunk.Contains("$ cd"))
                {
                    string folderName = chunk.Split(" ")[2];
                    currentPath.Push(folderName);

                    return new()
                    {
                        isFolder = true,
                        ItemName = folderName,
                        Path = currentPath.Aggregate("", (acc, path) => path + "/" + acc),
                        Size = 0
                    };
                }
                else
                {
                    string[] file = chunk.Split(" ");

                    return new()
                    {
                        isFolder = false,
                        ItemName = file[1],
                        Path = currentPath.Aggregate("", (acc, path) => path + "/" + acc),
                        Size = int.Parse(file[0])
                    };
                }
            }).Where(item => item != null).ToList();

        items.Where(item => item!.isFolder)
                .ToList()
                .ForEach(item => item!.Size = items.Where(_item => _item!.Path!.Contains(item.Path!) && !_item.isFolder).Sum(item => item!.Size));

        return items;
    }

    public static async Task<int> Part1() => (await ProcessInput()).Where(item => item!.Size < 100000 && item.isFolder).Sum(item => item!.Size);

    public static async Task<int> Part2()
    {
        IEnumerable<Item?> items = (await ProcessInput());
        int? size = items.SingleOrDefault(item => item?.ItemName == "/" && item.isFolder)?.Size;

        return items.Where(item => item!.isFolder && item.Size > 30000000 - (70000000 - size)).Min(item => item!.Size);
    }
}

public record class Day07Tests
{
    [Fact]
    public static async Task Tests()
    {
        Assert.Equal(1667443, await Day07.Part1());
        Assert.Equal(8998590, await Day07.Part2());
    }
}
