using System.ComponentModel.DataAnnotations;

namespace FormulaOneApp.Models.DTOs;

public class UserLoginRequestDto
{
    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}