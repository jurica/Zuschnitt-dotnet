namespace Zuschnitt.Models;

public class Column 
{
    public Guid Id { get; set; }
    public string Color { get; set; }
    public string FillColor { get; set; }
    public List<Part> Parts { get; set; }

    public int Height { get => height(); }
    public int Width { get => width(); }

    public Column()
    {
        Id = Guid.NewGuid();
        Color = "black";
        FillColor = "none";
        Parts = new ();
    }

    private int height()
    {
        if (Parts.Count() == 0) return 0;
        return Parts.Sum(p => p.Height);
    }

    private int width()
    {
        if (Parts.Count() == 0) return 0;
        return Parts.Max(p => p.Width);
    }
}
