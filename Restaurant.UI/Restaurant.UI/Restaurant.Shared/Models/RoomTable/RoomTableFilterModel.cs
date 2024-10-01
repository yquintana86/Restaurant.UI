using SharedLib.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace SharedLib.Models.Shift;

public class RoomTableFilterModel : PagingFilter
{
    public int? RoomId { get; set; }
    public int? WaiterId { get; set; }
    public RoomTableStatusType? Status { get; set; }
    
    public int? TotalQtyFrom { get; set; }

    [CompareRoomTableCapacities()]
    public int? TotalQtyTo { get; set; }

}

internal sealed class CompareRoomTableCapacities : ValidationAttribute
{
    public CompareRoomTableCapacities() { }

    public string GetErrorMessage() =>
        "Capacity To field must be equal or more than Capacity From";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var roomTable = (RoomTableFilterModel)validationContext.ObjectInstance;
        var totalQtyTo = (int?)value;

        if (roomTable.TotalQtyFrom is not null &&
            value is not null &&
            roomTable.TotalQtyFrom > (int?)value)
        {
            return new ValidationResult(GetErrorMessage());
        }

        return ValidationResult.Success;
    }

}



