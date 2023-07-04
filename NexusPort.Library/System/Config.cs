using System.IO;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace NexusPort.System;

public class Config {
    public string Path { get; private set; }
    public JsonNode Node { get; private set; }

    public Config(string path) {
        path = Paths.GetRootPath(path);
        Path = path;
        if (!File.Exists(path)) File.WriteAllText(path, "{}");
        Node = JsonNode.Parse(File.ReadAllText(path)) ?? new JsonObject();
    }

    public Config(string path, string fallback) {
        path = Paths.GetRootPath(path);
        Path = path;
        if (!File.Exists(path)) File.WriteAllText(path, fallback);
        Node = JsonNode.Parse(File.ReadAllText(path)) ?? new JsonObject();
    }

    public void Set(string key, string value) {
        Node[key] = value;
        Write();
    }

    public void Set<T>(string key, T value) {
        Node[key] = JsonSerializer.Serialize(value);
        Write();
    }

    public string? Get(string key) {
        return Node[key]?.ToString();
    }

    public dynamic? Get<T>(string key) {
        string? v = Node[key]?.ToString();
        if (v == null) return null;
        
        try {
            return JsonSerializer.Deserialize<T>(v);
        } catch {
            // Is not json literal, therefore
            // we can use C#'s built-in type
            // cast.
            try {
                return (T) (object) v;
            } catch { return null; }
        }
    }

    public void Remove(string key) {
        Node[key] = null;
        Write();
    }

    public void Clear() {
        Node = new JsonObject();
        Write();
    }

    public void Write() {
        File.WriteAllText(Path, Node.ToJsonString(
            new JsonSerializerOptions {
                WriteIndented = true
            }
        ));
    }

    public void Write(JsonNode? node) {
        Node = node ?? new JsonObject();
        Write();
    }
    
    public void Write<T>(T? obj) {
        Node = JsonNode.Parse(JsonSerializer.Serialize(obj)) ?? new JsonObject();
        Write();
    }

    public T? As<T>() {
        return JsonSerializer.Deserialize<T>(Node.ToJsonString());
    }

    public override string ToString() {
        return Node.ToJsonString(new JsonSerializerOptions {
            WriteIndented = true
        });
    }
}
