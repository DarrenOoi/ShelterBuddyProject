using ShelterBuddy.CodePuzzle.Core.Entities;
using Shouldly;
using Xunit;

namespace ShelterBuddy.CodePuzzle.Core.Tests.Entities;


public class AnimalTests
{
    [Theory]
    [InlineData(null, null, null, "")]
    [InlineData(7, null, 3, "7 years 3 weeks")]
    [InlineData(null, 2, null, "2 months")]
    [InlineData(null, 1, null, "1 month")]
    [InlineData(null, null, 1, "1 week")]
    [InlineData(1, 2, null, "1 year 2 months")]

    public void Animal_AgeTest_IsCorrect(int? years, int? months, int? weeks, string expected)
    {
        var animal = new Animal
        {
            AgeYears = years,
            AgeMonths = months,
            AgeWeeks = weeks
        };

        animal.AgeText.ShouldBe(expected);
    }
}