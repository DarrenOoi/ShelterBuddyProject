namespace ShelterBuddy.CodePuzzle.Core.Entities;

public class Animal : BaseEntity<Guid>
{
    public string? Name { get; set; }
    public string? Colour { get; set; }
    public string? Species { get; set; }
    public string? MicrochipNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime? DateInShelter { get; set; }
    public DateTime? DateLost { get; set; }
    public DateTime? DateFound { get; set; }
    public int? AgeYears { get; set; }
    public int? AgeMonths { get; set; }
    public int? AgeWeeks { get; set; }
    public string AgeText => GenerateAgeTextArray();
    private string GenerateAgeTextArray()
    {
        var ageTextArray = new List<string>();
        
        if (AgeYears.HasValue)
        {
            ageTextArray.Add(TextUtil.Pluralize(AgeYears.Value, "year"));
        }
        if (AgeMonths.HasValue)
        {
            ageTextArray.Add(TextUtil.Pluralize(AgeMonths.Value, "month"));
        }
        if (AgeWeeks.HasValue)
        {
            ageTextArray.Add(TextUtil.Pluralize(AgeWeeks.Value, "week"));
        }

        return string.Join(' ', ageTextArray);
    }
}