using Zuschnitt.Models;

namespace Test.Zuschnitt.Models;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var p = new Project();
        p.Name = "Test";
        p.AddSheet();
        p.Sheets.First().AddColumn();
        p.Sheets.First().Columns.First().AddPart();
        p.Sheets.First().Columns.First().AddPart();
        var serialized = p.Serialize();
        var stream = new MemoryStream(serialized);
        var deserialized = Project.Deserialize(stream);
        Assert.Pass();
    }
}