using System.Collections.Generic;

namespace ChemistryOntologyGUIApp
{
    public class OntologyManager
    {
        private List<Element> elements = new List<Element>();
        private List<Compound> compounds = new List<Compound>();
        private List<Reaction> reactions = new List<Reaction>();

        public void AddElement(Element element)
        {
            elements.Add(element);
        }

        public void AddCompound(Compound compound)
        {
            compounds.Add(compound);
        }

        public void AddReaction(Reaction reaction)
        {
            reactions.Add(reaction);
        }

        public Element FindElement(string symbol)
        {
            return elements.Find(e => e.Symbol == symbol);
        }

        public Compound FindCompound(string formula)
        {
            return compounds.Find(c => c.Formula == formula);
        }

        public List<Element> FindElements()
        {
            return elements;
        }

        public List<Compound> FindCompounds()
        {
            return compounds;
        }

        public List<Reaction> GetReactions()
        {
            return reactions;
        }
    }
}
