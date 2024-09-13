using Restaurant.UI.Client.Models;
using SharedLib.Models.Common;
using SharedLib.Models.Shift;

namespace SharedLib.Models.Waiter;

public class WaiterModel
{
    public int Id { get; set; } 
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public decimal Salary { get; set; }
    public int ShiftId { get; set; }
    public ShiftModel Shift { get; set; } = null!;

    #region Navigation Properties

    ////Waiter - Room reference navigation
    //public Room Room { get; set; } = null!;

    ////Waiter-Table collection reference navigation
    //public ICollection<Table> Tables { get; } = new List<Table>();


    ////Waiter - Reservation Collection reference relationship
    //public ICollection<Reservation> Reservations { get; } = new List<Reservation>();

    #endregion
}

public class WaiterViewModel : ISelfValidate
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public decimal Salary { get; set; }
    public SelectItem SelectedShift { get; set; } = new SelectItem { Id = "", Text = "" };

    public Dictionary<string, List<string>> Validate()
    {
        var errors = new Dictionary<string, List<string>>();

        if(string.IsNullOrEmpty(FirstName))
            errors.Add(nameof(FirstName), new List<string>() { $"{nameof(FirstName)} is required"});

        if (string.IsNullOrEmpty(LastName))
            errors.Add(nameof(LastName), new List<string>() { $"{nameof(LastName)} is required" });

        if (Salary == 0M)
            errors.Add(nameof(Salary), new List<string>() { $"{nameof(Salary)} must be greater than zero" });

        if (string.IsNullOrEmpty(SelectedShift.Id))
            errors.Add(nameof(SelectedShift), new List<string>() { "Waiter must have a shift " });

        return errors;
    }

    public WaiterInsertModel ToWaiterInsertModel()
    {
        if (int.TryParse(SelectedShift.Id, out int value))
        {
            return new WaiterInsertModel
            {
                FirstName = FirstName,
                LastName = LastName,
                Salary = Salary,
                ShiftId = value,
            };
        }
        else
            throw new ArgumentNullException(nameof(SelectedShift));
     }

    public WaiterModel ToWaiterModel()
    {
        if (int.TryParse(SelectedShift.Id, out int value))
        {
            return new WaiterModel
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Salary = Salary,
                ShiftId = value,
            };
        }
        else
            throw new ArgumentNullException(nameof(SelectedShift));
    }
}

public class WaiterInsertModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public decimal Salary { get; set; }
    public int ShiftId { get; set; }
}


