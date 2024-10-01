using System.Diagnostics.CodeAnalysis;

namespace SharedLib.Models.Room;

public record RoomUpdateDto(int Id, [NotNull]string Name, int WaiterId, string? Theme, string? Description);

