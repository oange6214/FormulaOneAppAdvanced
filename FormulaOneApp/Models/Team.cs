namespace FormulaOneApp.Models;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string TeamPrinciple { get; set; } = null!;
}