using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core
{
    public interface IPokedexApiClient
    {
        Task<PokemonResponse> GetPokemonAsync(GetPokemonRequest getPokemonRequest);
    }
}
