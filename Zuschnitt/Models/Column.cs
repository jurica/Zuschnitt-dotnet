using System.Text.Json.Serialization;

namespace Zuschnitt.Models;

public class Column 
{
    public Guid Id { get; set; }
    public IEnumerable<Part> Parts
    {
        get
        {
            foreach (var part in _parts) yield return part;
        }
    }
    private readonly List<Part> _parts = new();
    private Sheet Parent { get; set; }
    [JsonIgnore] public bool Highlighted { get; set; }

    public Column(Sheet parent)
    {
        Id = Guid.NewGuid();
        Parent = parent;
        AddPart();
    }
    
    public Column(Column column)
    {
        Id = Guid.NewGuid();
        Parent = column.Parent;
        column._parts.ForEach(p => p.CopyTo(this));
    }

    public int Height()
    {
        int result = 0;
        if (_parts.Any()) result = _parts.Sum(p => p.Height);
        return result;
    }

    public int Width()
    {
        int result = 0;
        if (_parts.Any()) result = _parts.Max(p => p.Width);
        return result;
    }

    public void Reassign(Sheet newSheet)
    {
        if (newSheet.Columns.Contains(this)) return;

        Parent.RemoveColumn(this);
        Parent = newSheet;
        Parent.AddColumn(this);
    }

    public void Delete()
    {
        Parent.RemoveColumn(this);
    }

    public void AddPart()
    {
        new Part(this);
    }
    
    public void AddPart(Part part)
    {
        _parts.Add(part); 
    }

    public bool RemovePart(Part part)
    {
        return _parts.Remove(part);
    }

    public int Pos()
    {
        return Parent.ColumnPos(this);
    }
}
