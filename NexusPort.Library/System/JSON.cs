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
                if (type == typeof(string)) return Node[key]?.ToString();
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
                while (a.Count <= key) a.Add(null);

            Node[key] = value;
            Write();
        }
    }

    public dynamic? this[int key, Type type] {
        get {
            try {
                if (type == typeof(string)) return Node[key]?.ToString();
                return JsonSerializer.Deserialize(Node[key]?.ToString() ?? "", type);
            } catch {
                return null;
            }
        }
    }
}

public class JSONBound {
    public dynamic Key { get; set; }
    public Type Type { get; set; }
    public JSON JSON { get; set; }

    public JSONBound(string key, Type type, JSON json) {
        Key = key;
        Type = type;
        JSON = json;
    }

    public JSONBound(int key, Type type, JSON json) {
        Key = key;
        Type = type;
        JSON = json;
    }

    public dynamic? Value {
        get => JSON[Key, Type];
        set => JSON[Key] = value;
    }

    public override string ToString() => Value?.ToString() ?? "null";
    public static bool operator !(JSONBound bound) => bound.Value == null;

    public void Set(dynamic value) => Value = value;
}
