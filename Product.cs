using System;

namespace MeinProjekt;

public class Product
{
    //get; und set; Methoden ermöglichen es diese Eigenschaften zu lesen und zu ändern
    public string Name{get; set;} //Name als string definiert
    public decimal Price{get; set;} //Preis als decimal definiert

    public Product(string name, decimal price) //Konstruktor - es ermöglicht beim erstellen einen neuen produkts den name und preis selbst zu setzen
    {
        this.Name = name; //this.name/price sorgt dafür das das wert geändert wird 
        this.Price = price;
    }

    public override string ToString() //Anzeigen des produkts lesbar: bsp. "T-Shirt - 13.89€"
    {
        return $"{Name} - {Price}€";
    }
}
