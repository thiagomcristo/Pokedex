namespace Pokedex.Core
{
    public class GetPokemonRequest
    {
        public string PokemonName { get; }
        public Language Language { get; }

        public GetPokemonRequest(string pokemonName, Language language)
        {
            PokemonName = pokemonName;
            Language = language;
        }
    }
}
