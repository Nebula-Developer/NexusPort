namespace NexusPort.Graphics;

public class PixelMap {
    public Pixel[,] Pixels { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public PixelMap(int width, int height) {
        Width = width;
        Height = height;
        Pixels = new Pixel[width, height];
    }

    public PixelMap(int width, int height, int x, int y) {
        Width = width;
        Height = height;
        Pixels = new Pixel[width, height];
        X = x;
        Y = y;
    }

    public void Clear(Pixel p) {
        for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
                Pixels[x, y] = p;
    }

    public void Clear() => Clear(new Pixel(' ', new RGB(), new RGB()));

    public void ModifyRange(int x, int y, int endX, int endY, Pixel p) {
        for (int i = x; i < endX; i++)
            for (int j = y; j < endY; j++)
                Pixels[i, j] = p;
    }

    public void ModifyRange(int x, int y, int endX, int endY, Func<Pixel, int, int, Pixel> modifier) {
        for (int i = x; i < endX; i++)
            for (int j = y; j < endY; j++)
                Pixels[i, j] = modifier(Pixels[i, j], i, j);
    }

    public void ModifyRingRange(int x, int y, int endX, int endY, Pixel p) {
        for (int i = x; i < endX; i++) {
            Pixels[i, y] = p;
            Pixels[i, endY] = p;
        }

        for (int j = y; j < endY; j++) {
            Pixels[x, j] = p;
            Pixels[endX, j] = p;
        }
    }

    public void ModifyRingRange(int x, int y, int endX, int endY, Func<Pixel, int, int, Pixel> modifier) {
        for (int i = x; i < endX; i++) {
            Pixels[i, y] = modifier(Pixels[i, y], i, y);
            Pixels[i, endY] = modifier(Pixels[i, endY], i, endY);
        }

        for (int j = y; j < endY; j++) {
            Pixels[x, j] = modifier(Pixels[x, j], x, j);
            Pixels[endX, j] = modifier(Pixels[endX, j], endX, j);
        }
    }
}
