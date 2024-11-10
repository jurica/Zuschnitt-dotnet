using System.Text.Json.Serialization;

namespace Zuschnitt.Models;

public class Column 
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required Sheet Parent
    {
        get => _parent;
        init
        {
            _parent = value;
            _parent._columns.Add(this);
        }
    }
    private Sheet _parent;
    [JsonIgnore] public IEnumerable<Part> Parts
    {
        get
        {
            foreach (var part in _parts) yield return part;
        }
    }
    [JsonInclude] internal List<Part> _parts = new();
    [JsonIgnore] public bool Highlighted { get; set; }

    public void Copy()
    {
        var copy = new Column() { Parent = this.Parent };
        _parts.ForEach(p => p.CopyTo(copy));
    }
    
    public void CopyTo(Sheet sheet)
    {
        var copy = new Column() { Parent = sheet };
        _parts.ForEach(p => p.CopyTo(copy));
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

        Parent._columns.Remove(this);
        _parent = newSheet;
        Parent._columns.Add(this);
    }

    public void Delete()
    {
        Parent._columns.Remove(this);
    }

    public void AddPart()
    {
        var part = new Part()
        {
            Parent = this
        };
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
