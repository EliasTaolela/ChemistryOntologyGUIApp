namespace ChemistryOntologyGUIApp
{
    public class Element
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int AtomicNumber { get; set; }

        public Element(string name, string symbol, int atomicNumber)
        {
            Name = name;
            Symbol = symbol;
            AtomicNumber = atomicNumber;
        }

        public override string ToString()
        {
            return $"{Name} ({Symbol}), Atomic Number: {AtomicNumber}";
        }
    }
}
