namespace Pokedex.Core
{
    public class PokemonResponse
    {
        public string Name { get; }
        public string Description { get; }
        public string Habitat { get; }//maybe this should be an enum
        public bool IsLegendary { get; }
        public Language Language { get; }

        public PokemonResponse(string name, string description, string habitat, bool isLegendary, Language language)
        {
            Name = name;
            Description = description;
            Habitat = habitat;
            IsLegendary = isLegendary;
            Language = language;
        }
    }
}
