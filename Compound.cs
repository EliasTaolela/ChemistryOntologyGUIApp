namespace ChemistryOntologyGUIApp
{
    public class Compound
    {
        public string Name { get; set; }
        public string Formula { get; set; }
        public List<Element> Elements { get; set; }

        public Compound(string name, string formula, List<Element> elements)
        {
            Name = name;
            Formula = formula;
            Elements = elements;
        }

        public override string ToString()
        {
            return $"{Name} ({Formula})";
        }
    }
}
