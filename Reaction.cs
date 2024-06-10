namespace ChemistryOntologyGUIApp
{
    public class Reaction
    {
        public List<Compound> Reactants { get; set; }
        public List<Compound> Products { get; set; }

        public Reaction(List<Compound> reactants, List<Compound> products)
        {
            Reactants = reactants;
            Products = products;
        }

        public override string ToString()
        {
            return $"{string.Join(" + ", Reactants)} -> {string.Join(" + ", Products)}";
        }
    }
}
