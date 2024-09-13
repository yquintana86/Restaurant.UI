using SharedLib.Models.Common;

namespace SharedLib.Models.Waiter;

public sealed class WaiterFilter : PagingFilter
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public decimal? SalaryFrom { get; set; }
    public decimal? SalaryTo { get; set; }
    public int? ShiftId { get; set; }
}


