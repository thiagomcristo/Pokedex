using NUnit.Framework;
using TestStack.BDDfy;

namespace Pokedex.AcceptanceTests
{
    public class EnglishContent : TestScenario
    {
        [Test]
        public void EnglishContentIsProvided()
        {
            this
                .Given(s => s.IAmInterestedInEnglishContent())
                .When(s => s.IRequestInformationForThePokemon())
                .Then(s => s.ICanSeeBasicPokemonInformation())
                    .And(s => s.ThePokemonDescriptionIsCorrect())
                    .And(s => s.ThePokemonHabitatIsRare())
                    .And(s => s.ThePokemonIsLegendary())
                .BDDfy();
        }

        private bool ThePokemonDescriptionIsCorrect() => this.Pokemon.Description.Equals(
                "It was created by a scientist after years of horrific gene splicing and DNA engineering experiments");

        private bool ThePokemonHabitatIsRare() => this.Pokemon.Habitat.Equals("rare");

        private bool ThePokemonIsLegendary() => this.Pokemon.IsLegendary;
    }
}
