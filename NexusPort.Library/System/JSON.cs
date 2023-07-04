using System.IO;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace NexusPort.System;

public class JSON {
    public string Path { get; private set; }
    public JsonNode Node { get; private set; }

    public JSON(string path) {
        path = Paths.GetRootPath(path);
        Path = path;
        if (!File.Exists(path)) File.WriteAllText(path, "{}");
        Node = JsonNode.Parse(File.ReadAllText(path)) ?? new JsonObject();
    }

    public override string ToString() {
        return Node.ToJsonString(new JsonSerializerOptions {
            WriteIndented = true
        });
    }

    public void Write<T>(T obj) {
        Node = JsonNode.Parse(JsonSerializer.Serialize(obj)) ?? new JsonObject();
        File.WriteAllText(Path, ToString());
    }

    public void Set(string key, object value) {
        Node[key] = JsonNode.Parse(JsonSerializer.Serialize(value));
        File.WriteAllText(Path, ToString());
    }

    public JsonNode? this[string key] {
        get => Node[key];
        set => this.Set(key, value ?? new JsonObject());
    }

    public dynamic? Get<T>(string key) {
        try {
            return JsonSerializer.Deserialize<T>(Node[key]);
        } catch {
            return null;
        }
    }

    public T? GetT<T>(string key) => Get<T>(key) ?? default(T);
}
