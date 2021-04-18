using NUnit.Framework;
using TestStack.BDDfy;

namespace Pokedex.AcceptanceTests
{
    public class ShakespeareTranslation : TestScenario
    {
        [Test]
        public void ShakespeareTranslationIsProvided_WhenPokemonHabitatIsNotACageAndPokemonIsNotLegendary()
        {
            this
                .Given(s => s.IAmInterestedInTranslatedContent())
                    .And(s => s.ThePokemonIAmLookingForIsNotLegendaryAndDoesntLiveOnACave())
                .When(s => s.IRequestInformationForThePokemon())
                .Then(s => s.ICanSeeBasicPokemonInformation())
                    .And(s => s.ThePokemonDescriptionIsTranslated())
                    .And(s => s.ThePokemonHabitatIsTranslated())
                    .And(s => s.ThePokemonIsNotLegendary())
                .BDDfy();
        }

        private bool ThePokemonDescriptionIsTranslated() => this.Pokemon.Description.Equals(
            "Shakespeare translation goes here: It was created by a scientist after years of horrific gene splicing and DNA engineering experiments");

        private bool ThePokemonHabitatIsTranslated() => this.Pokemon.Habitat.Equals("Shakespeare translation goes here: rare");

        private bool ThePokemonIsNotLegendary() => !this.Pokemon.IsLegendary;
    }
}
