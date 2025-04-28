namespace MeinProjekt
{
    public class Category
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        // Konstruktor für Name ohne Produkte
        public Category(string name)
        {
            Name = name;
            Products = new List<Product>(); // Initialisiert die Produktliste
        }

        // Konstruktor für Name und eine Liste von Produkten
        public Category(string name, List<Product> products)
        {
            Name = name;
            Products = products; // Setzt die Produkte auf die übergebene Liste
        }

        public void AddProduct(Product product)
        {
            Products.Add(product); // Fügt das Produkt der Liste hinzu
        }
    }
}


