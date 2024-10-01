using Restaurant.UI.Client.Models;
namespace SharedLib.Models.Waiter;

public sealed class WaiterViewModel : ISelfValidate
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public decimal Salary { get; set; }
    public string? RoomName { get; set; }
    public DateTime? End { get; set; }
    public DateTime Start { get; set; }
    public string? StartStr
    {
        get
        {
            return Start.ToShortDateString();
        }
        set
        {
            if (DateTime.TryParse(value, out DateTime result))
            {
                Start = result;
                IsStartValidDate = true;
            }
            else
            {
                IsStartValidDate = false;   
            }
        }
    }
    public bool IsStartValidDate { get; set; }
    

    public Dictionary<string, List<string>> Validate()
    {
        var errors = new Dictionary<string, List<string>>();

        if (string.IsNullOrEmpty(FirstName))
            errors.Add(nameof(FirstName), new List<string>() { $"{nameof(FirstName)} is required" });

        if (string.IsNullOrEmpty(LastName))
            errors.Add(nameof(LastName), new List<string>() { $"{nameof(LastName)} is required" });

        if (Salary == 0M)
            errors.Add(nameof(Salary), new List<string>() { $"{nameof(Salary)} must be greater than zero" });

        if (Id > 0)
        {
            if (!IsStartValidDate)
                errors.Add(nameof(Start), new List<string>() { $"Start date should be a valid date format" });

            if (Start.Year < 2020)
                errors.Add(nameof(Start), new List<string>() { $"Start Date should be after year 2020" });

            if (End.HasValue && End <= Start)
                errors.Add(nameof(End), new List<string>() { "End Date must be greater than Start Date" });
        }

        return errors;
    }

    public WaiterInsertDto ToWaiterInsertModel() =>
        new WaiterInsertDto(FirstName, LastName, Salary);

    public WaiterUpdateDto ToWaiterUpdateModel() =>
        new WaiterUpdateDto(Id, FirstName, LastName, Salary, Start);
    

}
