namespace NexusPort.Graphics;

public class Renderer {
    public List<PixelMap> Maps { get; set; } = new List<PixelMap>();

    public void Draw() {
        for (int i = 0; i < Maps.Count; i++) {
            PixelMap map = Maps[i];
            for (int x = 0; x < map.Width; x++) {
                for (int y = 0; y < map.Height; y++) {
                    Console.SetCursorPosition(map.X + x, map.Y + y);
                    Console.Write(map.Pixels[x, y].ToString());
                }
            }
        }
    }
}