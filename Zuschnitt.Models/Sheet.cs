using System.Text.Json.Serialization;

namespace Zuschnitt.Models;

public class Sheet 
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = "";
    public int Width { get; set; } = 2500;
    public int Height { get; set; } = 1250;

    public required Project Parent
    {
        get => _parent;
        init
        {
            _parent = value;
            _parent._sheets.Add(this);
        }
    }
    private Project _parent = null!;
    [JsonIgnore] public IEnumerable<Column> Columns
    {
        get
        {
            foreach (var column in _columns) yield return column;
        }
    }
    [JsonInclude] internal List<Column> _columns { get; init; } = new();
    [JsonIgnore] public bool Highlighted { get; set; } = false;

    public void Copy()
    {
        var copy = new Sheet() { Parent = Parent, Name = $"{Name} copy"};
        _columns.ForEach(c => c.CopyTo(copy));
    }

    public int UsedHeight()
    {
        if (_columns.Count == 0) return 0;
        return _columns.Max(x => x.Height());
    }

    public int UsedWidth()
    {
        if (_columns.Count == 0) return 0;
        return _columns.Sum(x => x.Width());
    }

    public void AddColumn()
    {
        var column = new Column
        {
            Parent = this
        };
    }

    public int ColumnPos(Column column)
    {
        return _columns.IndexOf(column);
    }

    public void Delete()
    {
        _parent.DeleteSheet(this);
    }
}
