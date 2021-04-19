using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;
using Pokedex.Core;
using Pokedex.PokedexApi.Controllers;
using System.Threading.Tasks;

namespace PokedexApi.UnitTests
{
    [TestFixture]
    public class PokemonControllerShould
    {
        private Mock<IPokeApiClient> mockApiClient;

        [SetUp]
        public void SetUp()
        {
            mockApiClient = new Mock<IPokeApiClient>();
        }

        [Test]
        public async Task ReturnNotFound_WhenPokemonDoesNotExist()
        {
            const string invalidPokemonName = "DummyPokemonName";

            mockApiClient
                .Setup(api => api.GetPokemonAsync(It.IsAny<GetPokemonRequest>()))
                .Returns(Task.FromResult((PokemonResponse)null));

            var controller = new PokemonController(mockApiClient.Object, new NullLogger<PokemonController>());

            var result = await controller.GetPokemonContentInEnglish(invalidPokemonName).ConfigureAwait(false);

            var notFoundResult = result.Should().BeOfType<NotFoundObjectResult>();
            notFoundResult.Which.Value.Should().Be("NotFound");
        }

        [Test]
        public async Task ReturnExpectedResult_WhenPokemonExists()
        {
            const string validPokemonName = "mewtwo";
            const string description = "It was created by a scientist after years of horrific gene splicing and DNA engineering experiments";
            const string habitat = "rare";
            var expectedPokemon = new PokemonResponse(validPokemonName, description, habitat, true, Language.English);

            mockApiClient
                .Setup(api => api.GetPokemonAsync(It.IsAny<GetPokemonRequest>()))
                .Returns(Task.FromResult(expectedPokemon));

            var controller = new PokemonController(mockApiClient.Object, new NullLogger<PokemonController>());
            var result = await controller.GetPokemonContentInEnglish(validPokemonName).ConfigureAwait(false);

            var okResult = result.Should().BeOfType<OkObjectResult>();
            var pokemonResponse = okResult.Which.Value.Should().BeAssignableTo<PokemonResponse>();
            pokemonResponse.Which.Should().BeEquivalentTo(expectedPokemon);
        }
    }
}
