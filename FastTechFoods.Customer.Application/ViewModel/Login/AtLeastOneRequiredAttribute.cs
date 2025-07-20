using System.ComponentModel.DataAnnotations;

namespace FastTechFoods.Customer.Application.ViewModel.Login;
internal sealed class AtLeastOneRequiredAttribute : ValidationAttribute
{
    private readonly string[] _propertyNames;

    public AtLeastOneRequiredAttribute(params string[] propertyNames)
    {
        _propertyNames = propertyNames;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var type = validationContext.ObjectType;
        var values = _propertyNames
            .Select(p => type.GetProperty(p)?.GetValue(validationContext.ObjectInstance))
            .Where(v => v is string str && !string.IsNullOrWhiteSpace(str))
            .ToList();

        return values.Any()
            ? ValidationResult.Success
            : new ValidationResult(ErrorMessage ?? $"At least one of the fields [{string.Join(", ", _propertyNames)}] must be provided.");
    }
}
