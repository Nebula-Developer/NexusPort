using System.IO;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace NexusPort.System;

public static class RootConfig {
    public static JSON Root = new JSON("NexusConfig.json");

    public static void Init() {
        Root.Write(new JsonArray());
        JsonArray a = new JsonArray();
        a.Add("test");
        JsonArray b = new JsonArray();
        b.Add("test2");

        Root[0] = a;
        Root[1] = b;
        Console.WriteLine(Root);
        Root.Write();
    }
}
