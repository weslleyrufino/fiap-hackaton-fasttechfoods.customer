using System.ComponentModel.DataAnnotations;

namespace FastTechFoods.Customer.Application.ViewModel.Login;

[AtLeastOneRequired(nameof(Email), nameof(CPF), ErrorMessage = "You must provide either Email or CPF.")]
public class LoginViewModel
{
    public string? Email { get; set; }
    public string? CPF { get; set; }

    [Required(ErrorMessage = "The Password field is required.")]
    public required string Password { get; set; }

}
