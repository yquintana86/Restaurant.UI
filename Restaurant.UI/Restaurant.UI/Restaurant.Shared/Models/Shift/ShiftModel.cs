using Restaurant.UI.Client.Models;
using System.ComponentModel.DataAnnotations;

namespace SharedLib.Models.Shift;

public class ShiftModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime Begin { get; set; }
    public DateTime End { get; set; }
}

public class ShiftInsertModel
{
    public string Name { get; set; } = null!;
    public DateTime Begin { get; set; }
    public DateTime End { get; set; }
}

public class ShiftViewModel : ISelfValidate
{
    public int Id { get; set; }
    public DateTime Begin { get; set; }
    public DateTime End { get; set; }

    public TimeSpan ShiftDuration
    {
        get
        {
            var a = End - Begin;
            return a;
        }
    }

    [Required]
    public string Name { get; set; } = null!;

    public string BeginStr
    {
        set
        {
            if (DateTime.TryParse(value, out DateTime result))
                Begin = result;
        }

        get
        {
            return Begin.ToString("hh:mm:t");
        }
    }

    public string EndStr
    {
        set
        {
            if (DateTime.TryParse(value, out DateTime result))
                End = result;
        }

        get
        {
            return End.ToString("hh:mm:t");
        }
    }

    public ShiftModel ToShiftModel()
    {
        return new ShiftModel
        {
            Id = this.Id,
            Name = this.Name,
            Begin = this.Begin,
            End = this.End
        };
    }

    public ShiftInsertModel ToShiftInsertmodel()
    {
        return new ShiftInsertModel
        {
            Name = this.Name,
            Begin = this.Begin,
            End = this.End
        };
    }

    public Dictionary<string, List<string>> Validate()
    {
        var errors = new Dictionary<string, List<string>>();

        if (string.IsNullOrWhiteSpace(Name))
            errors.Add(nameof(Name), new List<string>() { $" {nameof(Name)} is required" });

        if(Begin == End)
            errors.Add(nameof(Begin), new List<string>() { $"{nameof(Begin)} cannot have the same value as {nameof(End)}" });

        return errors;
    }
}



