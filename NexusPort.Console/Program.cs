using System;
using System.Text.RegularExpressions;
using System.Text.Json;
using NexusPort.System;

class Program
{
    static void Main()
    {
        Config testConfig = new Config("primary.json");
        testConfig.Set("test", 5);
        Console.WriteLine(testConfig.Get<float>("test") + 0.5f);
    }
}
