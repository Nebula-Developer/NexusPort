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
        Nexus.Init();
        Console.WriteLine(RootConfig.RootInt);
    }
}

