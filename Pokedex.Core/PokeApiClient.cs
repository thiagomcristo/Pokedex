using System.Threading.Tasks;

namespace Pokedex.Core
{
    public class PokeApiClient : IPokeApiClient
    {
        public async Task<PokemonResponse> GetPokemonAsync(GetPokemonRequest getPokemonRequest)
        {
            return await Task.FromResult((PokemonResponse)null);
        }
    }
}