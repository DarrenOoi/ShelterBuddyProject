using Microsoft.AspNetCore.Mvc;
using ShelterBuddy.CodePuzzle.Api.Models;
using ShelterBuddy.CodePuzzle.Core.DataAccess;
using ShelterBuddy.CodePuzzle.Core.Entities;

namespace ShelterBuddy.CodePuzzle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalController : ControllerBase
{
    private readonly IRepository<Animal, Guid> repository;

    public AnimalController(IRepository<Animal, Guid> animalRepository)
    {
        repository = animalRepository;
    }

    [HttpGet]
    public AnimalModel[] Get() => repository.GetAll().Select(animal => new AnimalModel
    {
        Id = $"{animal.Id}",
        Name = animal.Name,
        Colour = animal.Colour,
        DateFound = animal.DateFound,
        DateLost = animal.DateLost,
        MicrochipNumber = animal.MicrochipNumber,
        DateInShelter = animal.DateInShelter,
        DateOfBirth = animal.DateOfBirth,
        AgeText = animal.AgeText,
        AgeMonths = animal.AgeMonths,
        AgeWeeks = animal.AgeWeeks,
        AgeYears = animal.AgeYears
    }).ToArray();

    [HttpPost]
    public IActionResult Post(AnimalModel newAnimal)
    {
        if (string.IsNullOrEmpty(newAnimal.Name))
        {
            return BadRequest($"{nameof(newAnimal.Name)} is mandatory.");
        }
        
        if (string.IsNullOrEmpty(newAnimal.Species))
        {
            return BadRequest($"{nameof(newAnimal.Species)} is mandatory.");
        }

        if (!newAnimal.DateOfBirth.HasValue && !newAnimal.AgeYears.HasValue && !newAnimal.AgeMonths.HasValue && !newAnimal.AgeWeeks.HasValue)
        {
            return BadRequest(
                $@"Either {nameof(newAnimal.DateOfBirth)} or the Age fields 
                ({nameof(newAnimal.AgeYears)}, {nameof(newAnimal.AgeMonths)}, {nameof(newAnimal.AgeWeeks)}) must be provided."                
            );
        }

        var animal = new Animal
        {
            Name = newAnimal.Name,
            Colour = newAnimal.Colour, 
            DateFound = newAnimal.DateFound, 
            DateLost = newAnimal.DateLost, 
            MicrochipNumber = newAnimal.MicrochipNumber, 
            DateInShelter = newAnimal.DateInShelter, 
            DateOfBirth = newAnimal.DateOfBirth,
            AgeYears = newAnimal.AgeYears, 
            AgeMonths = newAnimal.AgeMonths, 
            AgeWeeks = newAnimal.AgeWeeks, 
            Species = newAnimal.Species
        };
        
        repository.Add(animal);
        return Ok(new AnimalModel(animal));
    }
}