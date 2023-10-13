var dict = new Dictionary<int, object>()
{
    {1, "Tom"}
};

dict[1] = 100;

foreach (var kvp in dict)
{
    Console.WriteLine(kvp);
}

