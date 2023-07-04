using System;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Nodes;
using NexusPort.System;

public class TestClass {
    public int test2 { get; set; } = 5;
}

class Program {
    static void Main() {
        JSON testConfig = new JSON("primary.json");
        testConfig.Write(new TestClass());

        testConfig["test"] = 5;
        int? test = testConfig.Get<int>("test");
        Console.WriteLine(test != null ? test : "null");
        Console.WriteLine((testConfig.Get<int>("test") ?? "null").ToString());
    }
}
