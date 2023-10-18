using System.ComponentModel.DataAnnotations;

namespace FormulaOneApp.Models.DTOs;
public class UserRegistrationRequestDto
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}