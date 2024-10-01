using System.Diagnostics.CodeAnalysis;

namespace SharedLib.Models.Room;

public record RoomInsertDto([NotNull]string Name, int WaiterId, string? Theme, string? Description);

