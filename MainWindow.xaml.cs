using System.Collections.Generic;
using System.Windows;

namespace ChemistryOntologyGUIApp
{
    public partial class MainWindow : Window
    {
        private OntologyManager ontologyManager;

        public MainWindow()
        {
            InitializeComponent();
            ontologyManager = new OntologyManager();
        }

        private void AddElement_Click(object sender, RoutedEventArgs e)
        {
            string name = ElementNameTextBox.Text;
            string symbol = ElementSymbolTextBox.Text;
            if (int.TryParse(AtomicNumberTextBox.Text, out int atomicNumber))
            {
                ontologyManager.AddElement(new Element(name, symbol, atomicNumber));
                MessageBox.Show("Element added successfully.");
                ElementNameTextBox.Clear();
                ElementSymbolTextBox.Clear();
                AtomicNumberTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Invalid atomic number.");
            }
        }

        private void AddCompound_Click(object sender, RoutedEventArgs e)
        {
            string name = CompoundNameTextBox.Text;
            string formula = CompoundFormulaTextBox.Text;
            List<Element> elements = new List<Element>();
            string[] symbols = CompoundElementsTextBox.Text.Split(',');

            foreach (var symbol in symbols)
            {
                Element element = ontologyManager.FindElement(symbol.Trim());
                if (element != null)
                {
                    elements.Add(element);
                }
                else
                {
                    MessageBox.Show($"Element with symbol {symbol} not found.");
                    return;
                }
            }

            ontologyManager.AddCompound(new Compound(name, formula, elements));
            MessageBox.Show("Compound added successfully.");
            CompoundNameTextBox.Clear();
            CompoundFormulaTextBox.Clear();
            CompoundElementsTextBox.Clear();
        }

        private void AddReaction_Click(object sender, RoutedEventArgs e)
        {
            List<Compound> reactants = new List<Compound>();
            List<Compound> products = new List<Compound>();
            string[] reactantFormulas = ReactantsTextBox.Text.Split(',');
            string[] productFormulas = ProductsTextBox.Text.Split(',');

            foreach (var formula in reactantFormulas)
            {
                Compound compound = ontologyManager.FindCompound(formula.Trim());
                if (compound != null)
                {
                    reactants.Add(compound);
                }
                else
                {
                    MessageBox.Show($"Compound with formula {formula} not found.");
                    return;
                }
            }

            foreach (var formula in productFormulas)
            {
                Compound compound = ontologyManager.FindCompound(formula.Trim());
                if (compound != null)
                {
                    products.Add(compound);
                }
                else
                {
                    MessageBox.Show($"Compound with formula {formula} not found.");
                    return;
                }
            }

            ontologyManager.AddReaction(new Reaction(reactants, products));
            MessageBox.Show("Reaction added successfully.");
            ReactantsTextBox.Clear();
            ProductsTextBox.Clear();
        }

        private void ViewElements_Click(object sender, RoutedEventArgs e)
        {
            ElementsListBox.Items.Clear();
            foreach (var element in ontologyManager.FindElements())
            {
                ElementsListBox.Items.Add(element);
            }
        }

        private void ViewCompounds_Click(object sender, RoutedEventArgs e)
        {
            CompoundsListBox.Items.Clear();
            foreach (var compound in ontologyManager.FindCompounds())
            {
                CompoundsListBox.Items.Add(compound);
            }
        }

        private void ViewReactions_Click(object sender, RoutedEventArgs e)
        {
            ReactionsListBox.Items.Clear();
            foreach (var reaction in ontologyManager.GetReactions())
            {
                ReactionsListBox.Items.Add(reaction);
            }
        }
    }
}
