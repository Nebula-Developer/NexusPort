using System.IO;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace NexusPort.System;

public static class RootConfig {
    public static JSON Root = new JSON("NexusConfig.json");

    public static JSONBound RootTestValue = new JSONBound("RootValue", typeof(string), Root);

    public static void Init() {
        // Root.Clear();
        Console.WriteLine(RootTestValue + " -> 5");
        if (!RootTestValue) {
            Console.WriteLine("Is null value");
        }
        RootTestValue.Set("test");
        Console.WriteLine(RootTestValue + " -> 10");
        Root.Write();
    }
}
