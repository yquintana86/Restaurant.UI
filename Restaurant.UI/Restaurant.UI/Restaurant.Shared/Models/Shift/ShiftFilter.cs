using SharedLib.Models.Common;

namespace SharedLib.Models.Shift;

public class ShiftFilter : PagingFilter
{   
    public string? Name { get; set; }
    public DateTime? Begin { get; set; }
    public DateTime? End { get; set; }
}

