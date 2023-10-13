var dict = new Dictionary<int, List<string>>()
{
    {1, new List<string>{"Tom", "Tim" } },
    {2, new List<string>{"Tom", "Tim" }},
    {3, new List<string>{"Tom", "Tim" }}
};

dict[1].Add("1");
foreach (var item in dict[1])
{
    Console.WriteLine(item);
}

foreach (var kvp in dict)
{
    Console.WriteLine(kvp);
}

