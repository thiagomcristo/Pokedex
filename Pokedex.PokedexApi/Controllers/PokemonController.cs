using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokedex.Core;
using System.Threading.Tasks;

namespace Pokedex.PokedexApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokeApiClient _pokeApiClient;
        private readonly ILogger<PokemonController> _logger;

        public PokemonController(
            IPokeApiClient pokeApiClient,
            ILogger<PokemonController> logger)
        {
            _pokeApiClient = pokeApiClient;
            _logger = logger;
        }

        [HttpGet("{pokemonName}")]
        public async Task<IActionResult> GetPokemonContentInEnglish(string pokemonName)
        {
            //Todo before production
            //Performance, Caching and Security
            //Apply basic validation
            //Add logging
            //Decide on handling exceptions here or on a middleware/filter

            var response = await _pokeApiClient.GetPokemonAsync(new GetPokemonRequest(pokemonName, Language.English));

            if (response == null)
            {
                return new NotFoundObjectResult("NotFound");
            }

            return Ok(response);
        }
    }
}
