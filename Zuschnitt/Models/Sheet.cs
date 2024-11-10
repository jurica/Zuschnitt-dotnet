namespace Zuschnitt.Models;

public class Sheet 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public IEnumerable<Column> Columns
    {
        get
        {
            foreach (var column in _columns) yield return column;
        }
    }
    public List<Column> _columns { get; set; }

    public Sheet()
    {
        Id = Guid.NewGuid();
        Name = Id.ToString();
        Width = 2500;
        Height = 1250;
        _columns = new ();
        AddColumn();
    }

    public Sheet(Sheet sheet)
    {
        Id = Guid.NewGuid();
        Name = $"{sheet.Name} copy";
        Width = sheet.Width;
        Height = sheet.Height;
        _columns = new List<Column>();
        sheet._columns.ForEach(c => _columns.Add(new Column(c)));
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
        AddColumn(new Column(this));
    }
    
    public void AddColumn(Column column)
    {
        _columns.Add(column);
    }

    public bool RemoveColumn(Column column)
    {
        return _columns.Remove(column);
    }

    public int ColumnPos(Column column)
    {
        return _columns.IndexOf(column);
    }
}
