using NUnit.Framework;
using TestStack.BDDfy;

namespace Pokedex.AcceptanceTests
{
    public class YodaTranslatedContent : TestScenario
    {
        [Test]
        public void YodaTranslationIsProvided_WhenPokemonHabitatIsCave()
        {
            this
                .Given(s => s.IAmInterestedInTranslatedContent())
                    .And(s => s.ThePokemonIAmLookingForLivesOnACave())
                .When(s => s.IRequestInformationForThePokemon())
                .Then(s => s.ICanSeeBasicPokemonInformation())
                    .And(s => s.ThePokemonDescriptionIsTranslated())
                    .And(s => s.ThePokemonHabitatIsTranslated())
                    .And(s => s.ThePokemonIsNotLegendary())
                .BDDfy();
        }

        [Test]
        public void YodaTranslationIsProvided_WhenPokemonIsLegendary()
        {
            this
                .Given(s => s.IAmInterestedInTranslatedContent())
                    .And(s => s.ThePokemonIAmLookingForIsLegendary())
                .When(s => s.IRequestInformationForThePokemon())
                .Then(s => s.ICanSeeBasicPokemonInformation())
                    .And(s => s.ThePokemonDescriptionIsTranslated())
                    .And(s => s.ThePokemonHabitatIsTranslated())
                    .And(s => s.ThePokemonIsLegendary())
                .BDDfy();
        }

        private bool ThePokemonDescriptionIsTranslated() => this.Pokemon.Description.Equals(
            "YODA translation goes here: It was created by a scientist after years of horrific gene splicing and DNA engineering experiments");

        private bool ThePokemonHabitatIsTranslated() => this.Pokemon.Habitat.Equals("YODA translation goes here: rare");

        private bool ThePokemonIsNotLegendary() => !this.Pokemon.IsLegendary;

        private bool ThePokemonIsLegendary() => this.Pokemon.IsLegendary;
    }
}
