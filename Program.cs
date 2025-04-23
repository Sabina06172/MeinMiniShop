using System.ComponentModel.DataAnnotations;
using MeinProjekt;

List <Product> products = new List<Product> //Neue Produkte Liste mit paar produkten
{
    new Product("T-Shirt", 13.89m),
    new Product("Pulli", 26.99m),
    new Product("Hose", 19.49m)
};

// foreach(var p in products)
// {
//     System.Console.WriteLine(p);
// }

List<CartItem> cart = new List<CartItem>(); //Eine neue leere Liste - den Warenkorb

bool running = true; //running wird auf true gesetzt 

while(running) //while-Schleife sorgt dafür dass das Programm so lange läft bis running auf false gesetzt wird oder der User es beenden möchte
{
    //Menü für den User
    System.Console.WriteLine(""" 
    Was möchtest du tun?
    1 - Produkte anzeigen
    2 - Produkt in den Warenkorb legen
    3 - Warenkorb anzeigen
    4 - Einkauf abschließen
    5 - Produkt aus dem Warenkorb entfernen
    0 - Beenden
    """);

    Console.Write("Deine Wahl: ");
    string selection = Console.ReadLine()??""; //User kann etwas angeben / angeben was er auswählt 

    switch(selection) //Hier wird fest gestellt je nachdem was der Benutzer eingibt was passieren soll
    {
        case "1":
        System.Console.WriteLine("\nProdukte: ");
        for(int i = 0; i < products.Count; i++) //Wenn User 1 eingibt werden alle Produkte aus der Liste angezeigt in Reienfolge 
        {
            System.Console.WriteLine($"{i + 1}: {products[i]}");
        }
        break;

        case "2":
        System.Console.WriteLine("\nGib die Nummer des Produkts ein:"); //Wenn User 2 eingibt wird er aufgefordert die Nummer des Produkts einzugeben, das er dem Warenkorb hinzufügen möchte
        for(int i = 0; i < products.Count; i++)
        {
            System.Console.WriteLine($"{i + 1}: {products[i]}");
        }
        if(int.TryParse(Console.ReadLine(), out int index)&& index > 0 && index <= products.Count) //Eingabe wird überprüft - wenn nr gültig wird das produkt von der Liste "products" in der Liste "cart" (Warenkorb) hinzugefügt
        {
            // cart.Add(products[index - 1]);
            // System.Console.WriteLine("Produkt wurde dem Warenkorb hinzugefügt!");
            var selectedProduct = products[index - 1];

            var existingItem = cart.FirstOrDefault(item => item.Product.Name == selectedProduct.Name); //Damit wird geprüft ob das Produkt schon im Warenkorb ist - FirstOrDefault durchläft die Liste

            if(existingItem != null) //Falls das Produkt sich bereits in dem Warenkorb befinden erhöhen wir die Menge - existingItem.Quantity++
            {
                existingItem.Quantity++;
                System.Console.WriteLine("Produktmenge erhöht.");
            }
            else
            {
                cart.Add(new CartItem{Product = selectedProduct, Quantity = 1}); //Wenn es noch nicht in den Warenkorb ist wird es erst hinzugefügt
                System.Console.WriteLine("Produkt wurde dem Warenkorb hinzugefügt!");
            }

        }
        else
        {
            System.Console.WriteLine("Ungültige Eingabe."); //Sonst wird diese Fehlermeldung angezeigt
        }
        break;

        case "3":
        System.Console.WriteLine("\nWarenkorb:"); //Wenn User 3 eingibt wird ihm das Warenkorb(cart) angezeigt
        if(cart.Count == 0)
        {
            System.Console.WriteLine("Dein Warenkorb ist leer."); //Falls nichts drin wird Ihm diese Meldung angezeigt
        }
        else
        {
            decimal sum = 0;
            foreach(var item in cart) //Wenn es Produkte in den Warenkorb gibt werden die aufgelistet mit preis 
            {
                // System.Console.WriteLine(product);
                // sum += product.Price; //mit + werden alle produkte addiert
                decimal UnitPrice = item.Product.Price * item.Quantity;
                System.Console.WriteLine($"{item.Quantity}x {item.Product.Name} - {UnitPrice:F2}€"); //:F2 zeigt immer zwei Nachkommastellen
                sum += UnitPrice;
            }
            System.Console.WriteLine($"Gesamtbetrag: {sum:F2}€"); //und am ende noch das Gesammtbetrag den ganzen Warenkorb berechnet und angezeigt
        }
        break;

        case "4":
        System.Console.WriteLine("\nEinkauf angeschlossen: ");
        if(cart.Count == 0) //Prüfen ob der Warenkorb leer ist
        {
            System.Console.WriteLine("Dein Warenkorb ist leer.");
        }
        else
        {
            decimal sum = 0; //Gesamtbetrag wir auf 0 gesetzt

            foreach(var item in cart)
            {
                decimal UnitPrice = item.Product.Price * item.Quantity; //Hier wird die summe der einzelne produkte gerechnet
                System.Console.WriteLine($"{item.Quantity}x {item.Product.Name} - {UnitPrice:F2}€");
                sum += UnitPrice; //Hier wird alles summiert
            }
            System.Console.WriteLine($"Gesamtbetrag: {sum:F2}€");
            System.Console.WriteLine("\nEinkauf abgeschlossen. Vielen Dank!"); //Wenn User 4 eingibt wird der Einkauf abgeschlossen und diese meldung angezeigt
            cart.Clear(); //nach der meldung wird der Warenkorb geleert
        }
        break;

        case "5":
        System.Console.WriteLine("\nWelchen Produkt möchtest du aus dem Warenkorb entfernen?");
        if(cart.Count == 0)
        {
            System.Console.WriteLine("Dein Warenkorb ist leer.");
            break;
        }

        for(int i = 0; i < cart.Count; i++)
        {
            System.Console.WriteLine($"{i + 1}: {cart[i].Quantity}x {cart[i].Product.Name}"); //Jedes Produkt wird aufgelistet
        }

        System.Console.WriteLine("Deine Auswahl: ");

        if(int.TryParse(Console.ReadLine(), out int removeIndex)&& removeIndex > 0 && removeIndex <= cart.Count) //Eingabe wird überprüft - wenn nr gültig wird das produkt aus der Liste "cart" (Warenkorb) entfernt
        {
            // cart.Remove(products[index2 - 1]);
            // System.Console.WriteLine("Produkt wurde aus dem Warenkorb entfernt!");
            var selectedItem = cart[removeIndex - 1]; //Auswählen des Produkts

            if(selectedItem.Quantity > 1) //Wenn mehr als 1 Produkt in warenkorb
            {
                System.Console.WriteLine($"Es sind {selectedItem.Quantity} Stück. Möchtest du nur 1 entfernen (j/n)?"); //Wird gefragt ob der User nur 1 Produkt entfernen möschte
                string antwort = Console.ReadLine()??"".ToLower(); //Auch großgeschrieben wird zu klein und erkannt

                if(antwort == "j" || antwort == "ja") //Wenn antwort ja dann wird nur 1 produkt entfernt
                {
                    selectedItem.Quantity--;
                    System.Console.WriteLine("Ein Stück wurde entfernt.");
                }
                else //Ansonsten werden alle gleiche Produkte aus den Warenkorb entfernt
                {
                    cart.RemoveAt(removeIndex - 1);
                    System.Console.WriteLine("Alle wurden entfernt.");
                }
            }
            else
            {
                cart.RemoveAt(removeIndex - 1);
                System.Console.WriteLine("Produkt wurde entfernt."); //Wenn nur 1 Produkt im Warenkorb wird dieser direkt entfernt ohne nach Menge zu fragen
            }
        }
        else
        {
            System.Console.WriteLine("Ungültige Eingabe."); //Sonst wird diese Fehlermeldung angezeigt
        }
        break;



        case "0":
        running = false; //Wenn User 0 eingibt wird das Programm beendet da running auf false gesetzt wurde
        break;

        default:
        System.Console.WriteLine("Ungültige Auswahl."); //Falls der User etwas anderes als angefordert eingibt erscheint diese Meldung 
        break;
    }

}