namespace Pokedex.Core
{
    public class Pokemon
    {
        public string Name { get; }
        public string Description { get; }
        public string Habitat { get; }//maybe this should be an enum
        public bool IsLegendary { get; }

        public Pokemon(string name, string description, string habitat, bool isLegendary)
        {
            Name = name;
            Description = description;
            Habitat = habitat;
            IsLegendary = isLegendary;
        }
    }
}
