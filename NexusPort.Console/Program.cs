using System;

namespace NexusPort;

public static class Program {
    public static void Main(String[] args) {
        while (true) {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            Console.WriteLine("Key: " + keyInfo.Key);
            Console.WriteLine("Alt: " + keyInfo.Modifiers.HasFlag(ConsoleModifiers.Alt));
            Console.WriteLine("Ctrl: " + keyInfo.Modifiers.HasFlag(ConsoleModifiers.Control));
            Console.WriteLine("Shift: " + keyInfo.Modifiers.HasFlag(ConsoleModifiers.Shift));
            Console.WriteLine("KeyChar: " + keyInfo.KeyChar + " (" + (int)keyInfo.KeyChar + ")");
        }
    }
}
