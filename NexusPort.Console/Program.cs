using System;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Nodes;
using NexusPort.System;

public class TestClass
{
    public int test2 { get; set; } = 5;
}

class Program
{
    static void Main()
    {
        Config testConfig = new Config("primary.json");
        testConfig.Write(default(TestClass));

        TestClass? newTestClass = testConfig.As<TestClass>();
        Console.WriteLine(newTestClass?.test2);
        testConfig.Set("test", "hi");
        Console.WriteLine(testConfig.Get<float>("test") + 0.5f);
    }
}
