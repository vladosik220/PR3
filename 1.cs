using System;

public class Color {
    private int red;
    private int green;
    private int blue;

    public int Red {
        get { return red; }
        set { red = NormalizeColorValue(value); }
    }

    public int Green {
        get { return green; }
        set { green = NormalizeColorValue(value); }
    }

    public int Blue {
        get { return blue; }
        set { blue = NormalizeColorValue(value); }
    }

    public Color() {}

    public Color(int red, int green, int blue) {
        Red = red;
        Green = green;
        Blue = blue;
    }

    public void DisplayColor() {
        Console.WriteLine($"{red}, {green}, {blue}");
    }

    private int NormalizeColorValue(int value) {
        if (value < 0) {
            return 0;
        } else if (value > 255) {
            return 255;
        } else {
            return value;
        }
    }
}
