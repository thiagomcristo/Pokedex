using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Core
{
    public interface IPokeApiClient
    {
        Pokemon GetPokemonAsync(GetPokemonRequest getPokemonRequest);
    }
}
