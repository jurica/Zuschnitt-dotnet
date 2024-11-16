using System.Text.Json;
using System.Text.Json.Serialization;

namespace Zuschnitt.Models;

public class Project
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = "";

    [JsonIgnore]
    public IEnumerable<Sheet> Sheets
    {
        get
        {
            foreach (var sheet in _sheets) yield return sheet;
        }
    }

    [JsonInclude] internal List<Sheet> _sheets { get; init; } = new();

    [JsonIgnore] private static JsonSerializerOptions _jsonSerializerOptions = new()
    {
        ReferenceHandler = ReferenceHandler.Preserve,
        WriteIndented = true
    };

    public void AddSheet()
    {
        new Sheet()
        {
            Parent = this
        };
    }

    public void DeleteSheet(Sheet sheet)
    {
        _sheets.Remove(sheet);
        if (!_sheets.Any())
        {
            AddSheet();
        }
    }

    public static Project? Deserialize(Stream stream)
    {
        var p = JsonSerializer.Deserialize<Project>(stream, _jsonSerializerOptions);

        return p;
    }

    public byte[] Serialize()
    {
        return JsonSerializer.SerializeToUtf8Bytes(this, _jsonSerializerOptions);
    }
}