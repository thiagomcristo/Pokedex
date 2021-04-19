using Pokedex.Core;

namespace Pokedex.AcceptanceTests
{
    public class TestScenario
    {
        private readonly PokedexApiClientBuilder apiClientBuilder = new PokedexApiClientBuilder();
        internal PokemonResponse Pokemon;
        private string _pokemonName;
        private const string nameOfPokemonForEnglishContent = "mewtwo";
        private const string nameOfPokemonWhichIsLegendary = "mewtwo";
        private const string nameOfPokemonWhoLivesOnACave = "nameOfPokemonWhoLivesOnACave";
        private const string nameOfPokemonWhoDoesntLiveOnACaveAndIsNotLegendary = "nameOfPokemonWhoDoesntLiveOnACaveAndIsNotLegendary";

        internal void IAmInterestedInEnglishContent()
        {
            apiClientBuilder.ForEnglishContent();
            _pokemonName = nameOfPokemonForEnglishContent;
        }

        internal void IRequestInformationForThePokemon()
        {
            apiClientBuilder.ForPokemonName(_pokemonName);
            var (pokeApiClient, request) = apiClientBuilder.Build();

            Pokemon = pokeApiClient.GetPokemonAsync(request).GetAwaiter().GetResult();
        }

        internal void IAmInterestedInTranslatedContent()
        {
            apiClientBuilder.ForTranslatedContent();
        }

        internal void ThePokemonIAmLookingForLivesOnACave()
        {
            _pokemonName = nameOfPokemonWhoLivesOnACave;
        }

        internal void ThePokemonIAmLookingForIsLegendary()
        {
            _pokemonName = nameOfPokemonWhichIsLegendary;
        }

        internal void ThePokemonIAmLookingForIsNotLegendaryAndDoesntLiveOnACave()
        {
            _pokemonName = nameOfPokemonWhoDoesntLiveOnACaveAndIsNotLegendary;
        }

        internal bool ICanSeeBasicPokemonInformation() => this.Pokemon != null;
    }
}