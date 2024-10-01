using SharedLib.Models.Common;

namespace SharedLib.Models.Room;

public class RoomFilterModel : PagingFilter
{
    public string? Name { get; set; }
    public int? WaiterId { get; set; }
}
