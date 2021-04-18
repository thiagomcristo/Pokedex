using Pokedex.Core;

namespace Pokedex.AcceptanceTests
{
    public class PokeApiClientBuilder
    {
        private string _pokemonName;
        public string PokemonName => _pokemonName;

        public void ForEnglishContent()
        {
            
        }

        public void ForTranslatedContent()
        {

        }

        public void ForPokemonName(string pokemonName)
        {
            _pokemonName = pokemonName;
        }

        public (IPokeApiClient apiClient, GetPokemonRequest getPokemonRequest) Build()
        {
            return (new PokeApiClient(), new GetPokemonRequest());
        }
    }
}
