using System;
using System.Text.RegularExpressions;
using System.Text.Json;
using NexusPort.System;

public class TestClass
{
    public int test2 { get; set; } = 5;
}

class Program
{
    static void Main()
    {
        Config testConfig = new Config("primary.json", JsonSerializer.Serialize(new TestClass()));
        Console.WriteLine(JsonSerializer.Serialize(new TestClass()));
        testConfig.Set("test", 5);
        Console.WriteLine(testConfig.Get<float>("test") + 0.5f);
    }
}
