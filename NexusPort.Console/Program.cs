using System;
using NexusPort.System;

public static class Program {
    public static void Main() {
        Nexus.Init();
        RootConfig.Initializer.Value = 0; // Will call initializer as the class is being used
    }
}

