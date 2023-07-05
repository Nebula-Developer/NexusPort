namespace NexusPort.Graphics;

public class Pixel {
    public char Char { get; set; }
    public RGB BG { get; set; }
    public RGB FG { get; set; }

    public Pixel(char c, RGB bg, RGB fg) {
        Char = c;
        BG = bg;
        FG = fg;
    }

    public Pixel(RGB bg) {
        Char = ' ';
        BG = bg;
        FG = new RGB();
    }

    public override string ToString() {
        return BG.ToBGEsc() + FG.ToFGEsc() + Char + "\x1b[0m";
    }

    public string ToString(bool reset) {
        return BG.ToBGEsc() + FG.ToFGEsc() + Char + ( reset ? "\x1b[0m" : "" );
    }
}
