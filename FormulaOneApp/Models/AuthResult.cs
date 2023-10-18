namespace FormulaOneApp.Models;
public class AuthResult
{
    public string Token { get; set; } = null!;
    public bool Result { get; set; }
    public List<string> Errors { get; set; } = null!;
}