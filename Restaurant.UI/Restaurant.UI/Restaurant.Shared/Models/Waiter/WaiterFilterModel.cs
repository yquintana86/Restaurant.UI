using SharedLib.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace SharedLib.Models.Waiter;

public sealed class WaiterFilterModel : PagingFilter
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    [CompareWaiterFilterFromAndTo()]
    public decimal? SalaryTo { get; set; }
    public decimal? SalaryFrom { get; set; }

    [CompareWaiterFilterFromAndTo()]
    public DateTime? DateTo { get; set; }
    public string? DateToStr
    {
        get
        {
            if (DateTo is null)
                return null;
            else
                return DateTo.Value.ToShortDateString();
        }
        set
        {
            DateTo = DateTime.TryParse(value, out DateTime result) ? result : null;
        }
    }

    public DateTime? DateFrom { get; set; }
    public string? DateFromStr
    {
        get
        {
            if (DateFrom is null)
                return null;
            else
                return DateFrom.Value.ToShortDateString();
        }
        set
        {
            DateFrom = DateTime.TryParse(value, out DateTime result) ? result : null;
        }
    }
}

internal sealed class CompareWaiterFilterFromAndTo : ValidationAttribute
{
    public CompareWaiterFilterFromAndTo() { }

    public string GetDateError() =>
        "Date To field must be equal or more than Date From field";

    public string GetSalaryError() =>
        "Salary To field must be equal or more than Salary From field";
    
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        try
        {
            var waiter = (WaiterFilterModel)validationContext.ObjectInstance;
            if (value?.GetType() == typeof(DateTime))
            {
                var dateTo = (DateTime?)value;

                if (dateTo.HasValue &&
                    waiter.DateFrom.HasValue &&
                    dateTo < waiter.DateFrom)
                {
                    return new ValidationResult(GetDateError());
                }

            }

            if (value?.GetType() == typeof(decimal))
            {
                var salaryTo = (decimal?)value;

                if (salaryTo.HasValue &&
                    waiter.SalaryFrom.HasValue &&
                    salaryTo < waiter.SalaryFrom)
                {
                    return new ValidationResult(GetSalaryError());
                }

            }

            return ValidationResult.Success;
        }
        catch (Exception ex)
        {
            return new ValidationResult(ex.Message);
        }

    }
}


