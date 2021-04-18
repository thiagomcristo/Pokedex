namespace Pokedex.Core
{
    public class PokeApiClient : IPokeApiClient
    {
        public Pokemon GetPokemonAsync(GetPokemonRequest getPokemonRequest)
        {
            return new Pokemon("name", "description", "habitat", false);
        }
    }
}