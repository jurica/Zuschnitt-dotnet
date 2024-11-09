namespace Zuschnitt.Models;

public class Sheet 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string Color { get; set; }
    public string FillColor { get; set; }
    public List<Column> Columns { get; set; }

    public Sheet()
    {
        Id = Guid.NewGuid();
        Name = Id.ToString();
        Width = 1250;
        Height = 2500;
        Color = "black";
        FillColor = "lightgrey";
        Columns = new ();
    }

    public Sheet(Sheet sheet)
    {
        Id = Guid.NewGuid();
        Name = $"{sheet.Name} copy";
        Width = sheet.Width;
        Height = sheet.Height;
        Color = sheet.Color;
        FillColor = sheet.FillColor;
        Columns = new List<Column>();
        sheet.Columns.ForEach(c => Columns.Add(new Column(c)));
    }

    public int UsedHeight()
    {
        if (Columns.Count == 0) return 0;
        return Columns.Max(x => x.Height());
    }

    public int UsedWidth()
    {
        if (Columns.Count == 0) return 0;
        return Columns.Sum(x => x.Width());
    }
}
