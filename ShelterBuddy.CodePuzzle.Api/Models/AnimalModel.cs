using ShelterBuddy.CodePuzzle.Core.Entities;

namespace ShelterBuddy.CodePuzzle.Api.Models;

public class AnimalModel
{
    public string? Id { get; init; }
    public string? Name { get; init; }
    public string? Colour { get; init; }
    public string? Species { get; init; }
    public string? MicrochipNumber { get; init; }
    public DateTime? DateOfBirth { get; init; }
    public DateTime? DateInShelter { get; init; }
    public DateTime? DateLost { get; init; }
    public DateTime? DateFound { get; init; }
    public int? AgeYears { get; init; }
    public int? AgeMonths { get; init; }
    public int? AgeWeeks { get; init; }
    public string? AgeText { get; init; }

    public AnimalModel()
    {

    }

    public AnimalModel(Animal animal)
    {
        Id = $"{animal.Id}";
        Name = animal.Name;
        Colour = animal.Colour;
        DateFound = animal.DateFound;
        DateLost = animal.DateLost;
        MicrochipNumber = animal.MicrochipNumber;
        DateInShelter = animal.DateInShelter;
        DateOfBirth = animal.DateOfBirth;
        AgeText = animal.AgeText;
        AgeMonths = animal.AgeMonths;
        AgeWeeks = animal.AgeWeeks;
        AgeYears = animal.AgeYears;
        Species = animal.Species;
    }
}