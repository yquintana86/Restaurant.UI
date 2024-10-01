namespace SharedLib.Models.Waiter;

public sealed record WaiterUpdateDto(int Id, string FirstName, string LastName, decimal Salary, DateTime Start);
