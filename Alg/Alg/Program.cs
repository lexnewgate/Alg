// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");



IEnumerable<int> GetNums()
{
    yield break;
}

foreach(int i in GetNums())
{
    Console.WriteLine(i);
}
