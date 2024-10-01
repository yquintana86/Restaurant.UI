namespace SharedLib.Models.Waiter;


public sealed record WaiterDto(int Id, string FirstName, string LastName, decimal Salary, DateTime Start, DateTime? End, string? RoomName);
