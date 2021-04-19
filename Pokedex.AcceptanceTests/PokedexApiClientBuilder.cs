using Pokedex.Core;

namespace Pokedex.AcceptanceTests
{
    public class PokedexApiClientBuilder
    {
        private Language _language;
        private string _pokemonName;
        public string PokemonName => _pokemonName;

        public void ForEnglishContent()
        {
            _language = Language.English;
        }

        public void ForTranslatedContent()
        {
            _language = Language.Translated;
        }

        public void ForPokemonName(string pokemonName)
        {
            _pokemonName = pokemonName;
        }

        public (IPokedexApiClient apiClient, GetPokemonRequest getPokemonRequest) Build()
        {
            return (new PokedexApiClient(), new GetPokemonRequest(PokemonName, _language));
        }
    }
}
