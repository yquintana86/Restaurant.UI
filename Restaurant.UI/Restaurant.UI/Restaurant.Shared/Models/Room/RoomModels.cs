using Restaurant.UI.Client.Models;
using SharedLib.Models.Common;

namespace SharedLib.Models.Room;

public class RoomFilter : PagingFilter
{
    public string? Name { get; set; }
    public int? WaiterId { get; set; }
}

public class RoomInsertModel
{
    public string Name { get; set; } = null!;
    public int WaiterId { get; set; }
    public string? Theme { get; set; }
    public string? Description { get; set; }
}

public class RoomModel : RoomInsertModel
{
    public int Id { get; set; }
}

public class RoomViewModel : RoomModel, ISelfValidate
{
    public string WaiterName { get; set; } = null!;

    public Dictionary<string, List<string>> Validate()
    {
        Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        if (string.IsNullOrWhiteSpace(Name))
            errors.Add(nameof(Name), new List<string>() { "A room name is required" });

        if (WaiterId == 0)
            errors.Add(nameof(Waiter), new List<string>() { "A responsable is required for the room" });

        return errors;
    }

    public RoomInsertModel ToRoomInsertModel()
    {
        return new RoomInsertModel
        {
            Name = Name,
            WaiterId = WaiterId,
            Theme = Theme,
            Description = Description,
        };
    }

    public RoomModel ToRoomModel()
    {
        return new RoomModel
        {
            Id = Id,
            Name = Name,
            WaiterId = WaiterId,
            Theme = Theme,
            Description = Description
        };
    }
}
