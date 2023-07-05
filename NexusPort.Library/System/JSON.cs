using System.IO;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace NexusPort.System;

public class JSON {
    public string Path { get; private set; }
    public JsonNode Node { get; private set; }

    public JSON(string path) {
        // path = Paths.GetRootPath(path);
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

    public void Write() => File.WriteAllText(Path, ToString());
    public void Clear() => Write(new JsonObject());

    public JsonNode? this[string key] {
        get => Node[key];
        set {
            Node[key] = value;
            Write();
        }
    }

    public dynamic? this[string key, Type type] {
        get {
            try {
                return JsonSerializer.Deserialize(Node[key]?.ToString() ?? "", type);
            } catch {
                return null;
            }
        }
    }

    public JsonNode? this[int key] {
        get => Node[key];
        set {
            if (Node is JsonArray a)
                while (a.Count <= key) a.Add(new JsonObject());

            Node[key] = value;
            Write();
        }
    }

    public dynamic? this[int key, Type type] {
        get {
            try {
                return JsonSerializer.Deserialize(Node[key]?.ToString() ?? "", type);
            } catch {
                return null;
            }
        }
    }
}
