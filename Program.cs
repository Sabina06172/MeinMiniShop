using System.ComponentModel.DataAnnotations;
using System.Data;
using MeinProjekt;
using System.Linq; //Wird benutzt um auf .Where und .ToList zuzugreifen
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.CompilerServices; //Wird benutzt um json datei zu erstellen
Console.OutputEncoding = System.Text.Encoding.UTF8; // Setze die Konsolencodierung auf UTF-8, um sicherzustellen, dass Sonderzeichen korrekt angezeigt werden. In diesem Fall "€"



List<Product> products = new List<Product> //Neue Produkte Liste mit paar produkten
{
    new Product("T-Shirt", 13.89m),
    new Product("Hoodie", 26.99m),
    new Product("Jeans", 19.49m),
    new Product("Sporthose", 15.99m),
    new Product("Bluse", 22.00m),
    new Product("Kapuzenpulli", 29.99m),
    new Product("Jacke", 59.99m),
    new Product("Shorts", 6.25m),
    new Product("Socken", 5.99m),
    new Product("Mütze", 7.95m),
    new Product("Schal", 11.99m),
    new Product("Sneakers", 89.99m),
    new Product("Handschuhe (3-er Pack)", 7.49m),
    new Product("Sonnenbrille", 25.99m),
    new Product("Rucksack", 34.98m)
};

// foreach(var p in products)
// {
//     System.Console.WriteLine(p);
// }

Dictionary<string, decimal> dicountsCodes = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase) //Das StringComparer.OriginalIgnorCase ist dafür da das wenn der User das Rabattcode klein schreibt auch erkannt wird - also egal ob kleine - oder große Schreibweise!
{
    {"RABATT15", 0.15m}, //15% Rabatt
    {"SPAR5", 5.00m} //5€ Rabatt

};

List<CartItem> cart = new List<CartItem>(); //Eine neue leere Liste - den Warenkorb

bool running = true; //running wird auf true gesetzt 

while (running) //while-Schleife sorgt dafür dass das Programm so lange läft bis running auf false gesetzt wird oder der User es beenden möchte
{
    //Menü für den User
    System.Console.WriteLine(""" 
    Was möchtest du tun?
    1 - Produkte anzeigen
    2 - Produkt in den Warenkorb legen
    3 - Warenkorb anzeigen
    4 - Einkauf abschließen
    5 - Produkt aus dem Warenkorb entfernen
    6 - Produkt suchen
    0 - Beenden
    """);

    Console.Write("Deine Wahl: ");
    string selection = Console.ReadLine() ?? ""; //User kann etwas angeben / angeben was er auswählt 

    switch (selection) //Hier wird fest gestellt je nachdem was der Benutzer eingibt was passieren soll
    {
        case "1":
            System.Console.WriteLine("\nProdukte: ");
            for (int i = 0; i < products.Count; i++) //Wenn User 1 eingibt werden alle Produkte aus der Liste angezeigt in Reienfolge 
            {
                System.Console.WriteLine($"{i + 1}: {products[i]}");
            }
            break;

        case "2":
            System.Console.WriteLine("\nGib die Nummer des Produkts ein:"); //Wenn User 2 eingibt wird er aufgefordert die Nummer des Produkts einzugeben, das er dem Warenkorb hinzufügen möchte
            for (int i = 0; i < products.Count; i++)
            {
                System.Console.WriteLine($"{i + 1}: {products[i]}");
            }
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= products.Count) //Eingabe wird überprüft - wenn nr gültig wird das produkt von der Liste "products" in der Liste "cart" (Warenkorb) hinzugefügt
            {
                // cart.Add(products[index - 1]);
                // System.Console.WriteLine("Produkt wurde dem Warenkorb hinzugefügt!");
                var selectedProduct = products[index - 1];

                var existingItem = cart.FirstOrDefault(item => item.Product.Name == selectedProduct.Name); //Damit wird geprüft ob das Produkt schon im Warenkorb ist - FirstOrDefault durchläuft die Liste

                if (existingItem != null) //Falls das Produkt sich bereits in dem Warenkorb befinden erhöhen wir die Menge - existingItem.Quantity++
                {
                    existingItem.Quantity++;
                    System.Console.WriteLine("Produktmenge erhöht.");
                }
                else
                {
                    cart.Add(new CartItem (selectedProduct, 1)); //Wenn es noch nicht in den Warenkorb ist wird es erst hinzugefügt
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
            if (cart.Count == 0)
            {
                System.Console.WriteLine("Dein Warenkorb ist leer."); //Falls nichts drin wird Ihm diese Meldung angezeigt
            }
            else
            {
                decimal sum = 0;
                foreach (var item in cart) //Wenn es Produkte in den Warenkorb gibt werden die aufgelistet mit preis 
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
            if (cart.Count == 0) //Prüfen ob der Warenkorb leer ist
            {
                System.Console.WriteLine("Dein Warenkorb ist leer.");
            }
            else
            {
                decimal sum = 0; //Gesamtbetrag wir auf 0 gesetzt

                // List<string> orderLines = new(); //Eine neue leere Liste für abgeschlossene Bestellungen

                // orderLines.Add($"Bestellung vom {DateTime.Now}"); //Datum und Uhrzeit der Bestellung - //Console.WriteLine wird mit orderLines.Add ersetzt - orderLines.Add = fügt jede Zeile als String zur Liste

                foreach (var item in cart)
                {
                    decimal UnitPrice = item.Product.Price * item.Quantity; //Hier wird die summe der einzelne produkte gerechnet
                    System.Console.WriteLine($"{item.Quantity}x {item.Product.Name} - {UnitPrice:F2}€");
                    sum += UnitPrice; //Hier wird alles summiert
                }

                System.Console.WriteLine("\nHast du einen Rabbatcode? (j/n): "); //User wird gefragt ob er einen Rabattcode hat
                string answer = Console.ReadLine() ?? "".ToLower();

                if (answer == "j" || answer == "ja") //Wenn antwort ja - wird überprüft ob code existiert
                {
                    System.Console.WriteLine("Bitte gib den Rabattcode ein: ");
                    string enteredDiscount = Console.ReadLine() ?? "";

                    if (dicountsCodes.ContainsKey(enteredDiscount)) //Hier findet die überprüfung statt
                    {
                        decimal discountValue = dicountsCodes[enteredDiscount];

                        if (discountValue < 1) //Hier wird das Prozent gerechnet - zbs. 15%
                        {
                            decimal discountAmount = sum * discountValue;
                            sum -= discountAmount;
                            System.Console.WriteLine($"Rabatt angewendet: -{discountAmount:F2}€ ({discountValue * 100}% Rabatt)");
                        }
                        else
                        {
                            sum -= discountValue; //Hier wird ein fester Betrag gerechnet - zbs. 5€
                            if (sum < 0) sum = 0;
                            System.Console.WriteLine($"Rabatt angewendet: -{discountValue:F2}€");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Ungültiger Rabattcode."); //Ansonsten wird diese meldung angezeigt
                    }
                }

                System.Console.WriteLine($"Gesamtbetrag: {sum:F2}€");
                // orderLines.Add(new string('-', 30)); //Trenner damit die Bestellungen übersicht haben

                // File.AppendAllLines("orders.txt", orderLines); //Speichern in einer Datei - in diesem Fall "orders.txt" (Es erstellt die datei)

                System.Console.WriteLine("Bestellung gespeichert!");

                // Console.WriteLine("Bestellung gespeichert unter: " + Path.GetFullPath("bestellungen.txt")); //Als Hilfe wenn man nicht weißt wo die datei erstellt wurde

                System.Console.WriteLine("\nEinkauf abgeschlossen. Vielen Dank!"); //Wenn User 4 eingibt wird der Einkauf abgeschlossen und diese meldung angezeigt


                string ordersFile = "Bestellungen"; //Ordner erstellen
                if (!Directory.Exists(ordersFile))
                {
                    Directory.CreateDirectory(ordersFile);
                }

                string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"); //Zeitstempel für fileName
                string fileName = Path.Combine(ordersFile, $"bestellung_{timestamp}.json"); //Vollständiger pfad zur Datei

                var bestellung = new
                {
                    Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Gesamtbetrag = sum,
                    Artikel = cart.Select(item => new
                    {
                        Produkt = item.Product.Name,
                        Einzelpreis = item.Product.Price,
                        Menge = item.Quantity,
                        Gesamtpreis = item.Product.Price * item.Quantity
                    }).ToList()
                };

                string json = JsonSerializer.Serialize(bestellung, new JsonSerializerOptions{WriteIndented = true});
                File.WriteAllText(fileName, json);
                System.Console.WriteLine($"Bestellung wurde gespeichert als: {fileName}");
                cart.Clear();

                // //Bestellung als JSON speichern:
                // string path = "order.json"; //Erstellung der Datei - bzw den Namen der datei
                // string json = JsonSerializer.Serialize(cart, new JsonSerializerOptions { WriteIndented = true }); //JsonSerializer.Serialize(...) Das ist eine Methode aus System.Text.Json, die ein C#-Objekt (z. B. eine Liste oder ein Warenkorb) in einen JSON-Text umwandelt.
                //                                                                                                   //new JsonSerializerOptions { WriteIndented = true } Diese Option sorgt dafür, dass das JSON lesbar (formatiert) geschrieben wird – also mit Einrückungen.
                // File.WriteAllText(path, json); //File.WriteAllText(...) Schreibt den Text in eine Datei. Wenn die Datei nicht existiert, wird sie erstellt. Wenn sie existiert, wird sie überschrieben.
                // System.Console.WriteLine($"Bestellung wurde gespeichert als: {path}"); //Wird angezeigt als was die Bestellung gespeichert wurde in diesem Fall json datei
                // cart.Clear(); //der Warenkorb wird geleert
            }
            break;


        case "5":
            System.Console.WriteLine("\nWelchen Produkt möchtest du aus dem Warenkorb entfernen?");
            if (cart.Count == 0)
            {
                System.Console.WriteLine("Dein Warenkorb ist leer.");
                break;
            }

            for (int i = 0; i < cart.Count; i++)
            {
                System.Console.WriteLine($"{i + 1}: {cart[i].Quantity}x {cart[i].Product.Name}"); //Jedes Produkt wird aufgelistet
            }

            System.Console.WriteLine("Deine Auswahl: ");

            if (int.TryParse(Console.ReadLine(), out int removeIndex) && removeIndex > 0 && removeIndex <= cart.Count) //Eingabe wird überprüft - wenn nr gültig wird das produkt aus der Liste "cart" (Warenkorb) entfernt
            {
                // cart.Remove(products[index2 - 1]);
                // System.Console.WriteLine("Produkt wurde aus dem Warenkorb entfernt!");
                var selectedItem = cart[removeIndex - 1]; //Auswählen des Produkts

                if (selectedItem.Quantity > 1) //Wenn mehr als 1 Produkt in warenkorb
                {
                    System.Console.WriteLine($"Es sind {selectedItem.Quantity} Stück. Möchtest du nur 1 entfernen (j/n)?"); //Wird gefragt ob der User nur 1 Produkt entfernen möschte
                    string antwort = Console.ReadLine() ?? "".ToLower(); //Auch großgeschrieben wird zu klein und erkannt

                    if (antwort == "j" || antwort == "ja") //Wenn antwort ja dann wird nur 1 produkt entfernt
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


        case "6":
            System.Console.WriteLine("\nNach welchem Produkt suchst du?");
            string searchTerm = Console.ReadLine() ?? "".ToLower();

            var searchResults = products
            .Where(p => p.Name.ToLower().Contains(searchTerm)) //.Where geht jedes Produkt durch - "p" = jedes einzelne produkt | .ToLower().Contains(searchTerm) vergleicht, ob der Produktname den Suchbegriff enthält
            .ToList(); //Macht daraus wieder eine Liste

            if (searchResults.Count == 0) //Wenn die Suche nicht überreinstimmt bekommt der User diese Meldung
            {
                System.Console.WriteLine("\nKeine Produkte gefunden.");
            }
            else //Ansonsten werden die produkte angezeigt
            {
                System.Console.WriteLine("\nSuchergebnisse: ");
                foreach (var produkt in searchResults)
                {
                    System.Console.WriteLine(produkt);
                }
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