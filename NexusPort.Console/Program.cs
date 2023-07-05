using System;
using NexusPort.System;
using NexusPort.Graphics;

public static class Program {
    public static void Main() {
        Nexus.Init();
        RootConfig.Initializer.Value = 0; // Will call initializer as the class is being used

        // PixelMap map = new PixelMap(20, 10);
        // map.Clear(new Pixel('x', new RGB(255, 0, 0), new RGB()));

        // Renderer renderer = new Renderer();
        // renderer.Maps.Add(map);

        // renderer.Draw();
        // Console.ReadLine();

        // map.ModifyRange(0, 0, 20, 10, (p, x, y) => {
        //     return new Pixel('_', new RGB(0, x * 10, y * 20), new RGB());
        // });

        // renderer.Draw();

        // Console.ReadKey(true);

        int width = Console.WindowWidth;
        int height = Console.WindowHeight;

        Window testWindow = new Window(width, height);

        // PointElement point = new PointElement(width / 2, height / 2, new Pixel('x', new RGB(255, 0, 0), new RGB()));
        // testWindow.Elements.Add(point);

        InvertFilter invert = new InvertFilter();
        GrayscaleFilter grayscale = new GrayscaleFilter();

        // testWindow.Map.ModifyRange(0, 0, width, height, (p, x, y) => {
        //     return new Pixel('x', new RGB(x * 255 / width, y * 255 / height, 0), new RGB());
        // });

        testWindow.Draw();
        Console.ReadKey(true);
        testWindow.Filters.Add(grayscale);
        testWindow.Draw();
    }
}

