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

        Window testWindow = new Window(10, 10);

        PointElement point = new PointElement(5, 5, new Pixel('x', new RGB(255, 0, 0), new RGB()));
        testWindow.Elements.Add(point);

        InvertFilter invert = new InvertFilter();
        GrayscaleFilter grayscale = new GrayscaleFilter();

        testWindow.Map.ModifyRange(0, 0, 10, 10, (p, x, y) => {
            return new Pixel('x', new RGB(x * 20, y * 20, (x + y) * 20), new RGB(y * 20, x * 20, (x + y) * 20));
        });

        testWindow.Draw();
        Console.ReadKey(true);
        testWindow.Filters.Add(grayscale);
        testWindow.Draw();
    }
}

