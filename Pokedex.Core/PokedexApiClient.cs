using System.Threading.Tasks;

namespace Pokedex.Core
{
    public class PokedexApiClient : IPokedexApiClient
    {
        public async Task<PokemonResponse> GetPokemonAsync(GetPokemonRequest getPokemonRequest)
        {
            return await Task.FromResult((PokemonResponse)null);
        }
    }
}