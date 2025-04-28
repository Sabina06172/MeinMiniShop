using System.ComponentModel.DataAnnotations;
using System.Data;
using MeinProjekt;
using System.Linq; //Wird benutzt um auf .Where und .ToList zuzugreifen
using System.Text.Json; //Wird für json datei benötigt
using System.Text.Json.Serialization;
using System.Runtime.CompilerServices; //Wird benutzt um json datei zu erstellen
Console.OutputEncoding = System.Text.Encoding.UTF8; // Setze die Konsolencodierung auf UTF-8, um sicherzustellen, dass Sonderzeichen korrekt angezeigt werden. In diesem Fall "€"


List<Category> categories = new List<Category> //Liste mit Kategorien und dann Produkte
            {
                new Category("Kleidung", new List<Product>
                {
                    new Product("Lederjacke", 89.99m),
                    new Product("T-Shirt", 19.99m),
                    new Product("Jeans", 49.99m),
                    new Product("Sneaker", 59.99m),
                    new Product("Hoodie", 39.99m)
                }),
                new Category("Elektronik", new List<Product>
                {
                    new Product("Bluetooth-Kopfhörer", 59.99m),
                    new Product("Smartwatch", 129.99m),
                    new Product("Laptop", 799.99m),
                    new Product("Smartphone", 599.99m),
                    new Product("Tablet", 299.99m)
                }),
                new Category("Haus & Garten", new List<Product>
                {
                    new Product("Kaffeemaschine", 79.49m),
                    new Product("Staubsauger", 119.99m),
                    new Product("Pflanzen", 15.99m),
                    new Product("Gartenmöbel-Set", 349.99m),
                    new Product("Rasenmäher", 199.99m)
                }),
                new Category("Sport", new List<Product>
                {
                    new Product("Yoga-Matte", 19.99m),
                    new Product("Laufband", 499.99m),
                    new Product("Hanteln", 29.99m),
                    new Product("Fitness-Tracker", 59.99m),
                    new Product("Fahrrad", 399.99m)
                }),
                new Category("Bücher", new List<Product>
                {
                    new Product("Thriller-Roman 'Gefährliche Spur'", 14.99m),
                    new Product("Science Fiction 'Mars Mission'", 19.99m),
                    new Product("Romantik 'Verliebt in Paris'", 12.99m),
                    new Product("Krimi 'Der Tote im Wald'", 16.99m),
                    new Product("Fantasy 'Die Drachenkriege'", 22.99m)
                }),
                new Category("Spielzeug", new List<Product>
                {
                    new Product("LEGO Set", 49.99m),
                    new Product("Puppe", 24.99m),
                    new Product("Actionfigur", 19.99m),
                    new Product("Bauklötze", 9.99m),
                    new Product("Ferngesteuertes Auto", 39.99m)
                }),
                new Category("Beauty", new List<Product>
                {
                    new Product("Parfüm 'Ocean Breeze'", 39.99m),
                    new Product("Gesichtscreme", 19.99m),
                    new Product("Shampoo", 9.99m),
                    new Product("Nagellack Set", 14.99m),
                    new Product("Make-up Set", 29.99m)
                }),
                new Category("Lebensmittel", new List<Product>
                {
                    new Product("Bio-Schokoladenbox", 12.99m),
                    new Product("Kaffee", 4.99m),
                    new Product("Olivenöl", 6.99m),
                    new Product("Tee Set", 8.99m),
                    new Product("Frischkäse", 3.99m)
                }),
                new Category("Accessoires", new List<Product>
                {
                    new Product("Designer-Armbanduhr", 199.99m),
                    new Product("Sonnenbrille", 89.99m),
                    new Product("Ledergürtel", 39.99m),
                    new Product("Hut", 29.99m),
                    new Product("Schal", 19.99m)
                }),
                new Category("Bürobedarf", new List<Product>
                {
                    new Product("Ergonomischer Bürostuhl", 149.99m),
                    new Product("Schreibtischlampe", 29.99m),
                    new Product("Tastatur", 49.99m),
                    new Product("Mauspad", 9.99m),
                    new Product("Aktenordner", 4.99m)
                }),
                new Category("Gaming", new List<Product>
                {
                    new Product("Gaming-Maus", 49.00m),
                    new Product("Gaming-Tastatur", 99.99m),
                    new Product("Gaming-Headset", 79.99m),
                    new Product("Playstation 5", 499.99m),
                    new Product("XBOX Series X", 499.99m)
                }),
                new Category("Freizeit", new List<Product>
                {
                    new Product("Camping-Zelt", 89.99m),
                    new Product("Campingstuhl", 29.99m),
                    new Product("Rucksack", 39.99m),
                    new Product("Schlafsack", 49.99m),
                    new Product("Taschenlampe", 19.99m)
                }),
                new Category("Musik", new List<Product>
                {
                    new Product("Akustik-Gitarre", 119.00m),
                    new Product("E-Gitarre", 249.99m),
                    new Product("Klavier", 499.99m),
                    new Product("Drumset", 299.99m),
                    new Product("Mikrofon", 69.99m)
                }),
                new Category("Haustierbedarf", new List<Product>
                {
                    new Product("Hundebett", 45.50m),
                    new Product("Katzenstreu", 5.99m),
                    new Product("Hundespielzeug", 8.99m),
                    new Product("Katzenkratzbaum", 29.99m),
                    new Product("Hundeleine", 12.99m)
                })
            };

// Rabattcodes
Dictionary<string, decimal> dicountCodes = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase)
            {
                {"RABATT15", 0.15m}, //15% Rabatt
                {"SPAR5", 5.00m} //5€ Rabatt
            };

List<CartItem> cart = new List<CartItem>(); // Warenkorb

bool running = true; // running wird auf true gesetzt 

Console.ForegroundColor = ConsoleColor.Magenta;
System.Console.WriteLine("Willkommen zu .NETShop 🛍️");
Console.ResetColor();

while (running) // while-Schleife sorgt dafür, dass das Programm so lange läuft, bis running auf false gesetzt wird oder der User es beenden möchte
{
    // Menü für den User
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\n===============================");
    Console.WriteLine("       📦 .NETShop Menü       ");
    Console.WriteLine("===============================");
    Console.ResetColor();

    System.Console.WriteLine("[1] - Produkte anzeigen");
    System.Console.WriteLine("[2] - Produkt in den Warenkorb legen");
    System.Console.WriteLine("[3] - Warenkorb anzeigen");
    System.Console.WriteLine("[4] - Einkauf abschließen");
    System.Console.WriteLine("[5] - Produkt aus dem Warenkorb entfernen");
    System.Console.WriteLine("[6] - Produkt suchen");
    System.Console.WriteLine("[0] - Beenden");

    Console.ForegroundColor = ConsoleColor.Cyan;
    System.Console.WriteLine("===============================");
    Console.ResetColor();

    System.Console.Write("Bitte wähle eine Option: ");
    string selection = Console.ReadLine() ?? ""; // User kann etwas angeben / angeben was er auswählt 


    switch (selection) // Hier wird festgestellt, je nachdem was der Benutzer eingibt, was passieren soll
    {
        case "1":
            // Kategorien anzeigen
            System.Console.WriteLine("\nWählen Sie eine Kategorie:");
            for (int i = 0; i < categories.Count; i++) //User wird aufgefordert eine Kategorie auszuwählen
            {
                System.Console.WriteLine($"{i + 1}. {categories[i].Name}");
            }

            int categoryChoice;
            if (int.TryParse(Console.ReadLine(), out categoryChoice) && categoryChoice >= 1 && categoryChoice <= categories.Count)
            {
                // Die ausgewählte Kategorie holen
                var selectedCategory = categories[categoryChoice - 1];

                System.Console.WriteLine($"\nProdukte in der Kategorie {selectedCategory.Name}:"); //Je nachdem welche Kategorie der User auswählt werden die Produkte angezeigt
                foreach (var product in selectedCategory.Products)
                {
                    System.Console.WriteLine(product);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Ungültige Eingabe. Bitte eine gültige Kategorie auswählen."); //Ansonsten die Meldung
                Console.ResetColor();
            }
            break;


        case "2":
            // Kategorien anzeigen
            System.Console.WriteLine("\nWählen Sie eine Kategorie, um ein Produkt hinzuzufügen:");
            for (int i = 0; i < categories.Count; i++)
            {
                System.Console.WriteLine($"{i + 1}. {categories[i].Name}");
            }

            int categoryChoiceForCart;
            if (int.TryParse(Console.ReadLine(), out categoryChoiceForCart) && categoryChoiceForCart >= 1 && categoryChoiceForCart <= categories.Count)
            {
                var selectedCategoryForCart = categories[categoryChoiceForCart - 1];

                // Produkte aus der ausgewählten Kategorie anzeigen
                System.Console.WriteLine($"\nProdukte in der Kategorie {selectedCategoryForCart.Name}:");

                for (int i = 0; i < selectedCategoryForCart.Products.Count; i++)
                {
                    System.Console.WriteLine($"{i + 1}. {selectedCategoryForCart.Products[i]}");
                }

                int productChoice;
                if (int.TryParse(Console.ReadLine(), out productChoice) && productChoice >= 1 && productChoice <= selectedCategoryForCart.Products.Count)
                {
                    // Das ausgewählte Produkt
                    var selectedProduct = selectedCategoryForCart.Products[productChoice - 1];

                    // Menge abfragen
                    System.Console.WriteLine("Wie viele möchten Sie hinzufügen?");
                    int quantity = int.Parse(Console.ReadLine() ?? "");

                    // Produkt zum Warenkorb hinzufügen
                    var cartItem = new CartItem(selectedProduct, quantity);
                    cart.Add(cartItem);
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine($"{selectedProduct.Name} wurde zum Warenkorb hinzugefügt.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Ungültige Produktauswahl.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Ungültige Kategorieauswahl.");
                Console.ResetColor();
            }
            break;


        // // List<Product> products = new List<Product> //Neue Produkte Liste mit paar produkten
        // // {
        // //     new Product("T-Shirt", 13.89m),
        // //     new Product("Hoodie", 26.99m),
        // //     new Product("Jeans", 19.49m),
        // //     new Product("Sporthose", 15.99m),
        // //     new Product("Bluse", 22.00m),
        // //     new Product("Kapuzenpulli", 29.99m),
        // //     new Product("Jacke", 59.99m),
        // //     new Product("Shorts", 6.25m),
        // //     new Product("Socken", 5.99m),
        // //     new Product("Mütze", 7.95m),
        // //     new Product("Schal", 11.99m),
        // //     new Product("Sneakers", 89.99m),
        // //     new Product("Handschuhe (3-er Pack)", 7.49m),
        // //     new Product("Sonnenbrille", 25.99m),
        // //     new Product("Rucksack", 34.98m)
        // // };

        // // foreach(var p in products)
        // // {
        // //     System.Console.WriteLine(p);
        // // }

        // Dictionary<string, decimal> dicountCodes = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase) //Das StringComparer.OriginalIgnorCase ist dafür da das wenn der User das Rabattcode klein schreibt auch erkannt wird - also egal ob kleine - oder große Schreibweise!
        // {
        //     {"RABATT15", 0.15m}, //15% Rabatt
        //     {"SPAR5", 5.00m} //5€ Rabatt

        // };

        // List<CartItem> cart = new List<CartItem>(); //Eine neue leere Liste - den Warenkorb

        // bool running = true; //running wird auf true gesetzt 


        // Console.ForegroundColor = ConsoleColor.Magenta;
        // Console.WriteLine("Willkommen zu .NETShop 🛍️");
        // Console.WriteLine("--------------------------------------------");
        // Console.ResetColor();


        // while (running) //while-Schleife sorgt dafür dass das Programm so lange läft bis running auf false gesetzt wird oder der User es beenden möchte
        // {
        //     //Menü für den User
        //     Console.ForegroundColor = ConsoleColor.Cyan;
        //     Console.WriteLine("\n===============================");
        //     Console.WriteLine("       📦 .NETShop Menü       ");
        //     Console.WriteLine("===============================");
        //     Console.ResetColor();

        //     System.Console.WriteLine("[1] - Produkte anzeigen");
        //     System.Console.WriteLine("[2] - Produkt in den Warenkorb legen");
        //     System.Console.WriteLine("[3] - Warenkorb anzeigen");
        //     System.Console.WriteLine("[4] - Einkauf abschließen");
        //     System.Console.WriteLine("[5] - Produkt aus dem Warenkorb entfernen");
        //     System.Console.WriteLine("[6] - Produkt suchen");
        //     System.Console.WriteLine("[0] - Beenden");

        //     Console.ForegroundColor = ConsoleColor.Cyan;
        //     System.Console.WriteLine("===============================");
        //     Console.ResetColor();

        //     System.Console.Write("Bitte wähle eine Option: ");

        //     Console.Write("Deine Wahl: ");
        //     string selection = Console.ReadLine() ?? ""; //User kann etwas angeben / angeben was er auswählt 

        //     switch (selection) //Hier wird fest gestellt je nachdem was der Benutzer eingibt was passieren soll
        //     {
        //         case "1":
        //             System.Console.WriteLine("\nProdukte: ");
        //             for (int i = 0; i < products.Count; i++) //Wenn User 1 eingibt werden alle Produkte aus der Liste angezeigt in Reienfolge 
        //             {
        //                 System.Console.WriteLine($"{i + 1}: {products[i]}");
        //             }
        //             break;

        //         case "2":
        //             System.Console.WriteLine("\nGib die Nummer des Produkts ein:"); //Wenn User 2 eingibt wird er aufgefordert die Nummer des Produkts einzugeben, das er dem Warenkorb hinzufügen möchte
        //             for (int i = 0; i < products.Count; i++)
        //             {
        //                 System.Console.WriteLine($"{i + 1}: {products[i]}");
        //             }
        //             if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= products.Count) //Eingabe wird überprüft - wenn nr gültig wird das produkt von der Liste "products" in der Liste "cart" (Warenkorb) hinzugefügt
        //             {
        //                 // cart.Add(products[index - 1]);
        //                 // System.Console.WriteLine("Produkt wurde dem Warenkorb hinzugefügt!");
        //                 var selectedProduct = products[index - 1];

        //                 var existingItem = cart.FirstOrDefault(item => item.Product.Name == selectedProduct.Name); //Damit wird geprüft ob das Produkt schon im Warenkorb ist - FirstOrDefault durchläuft die Liste

        //                 if (existingItem != null) //Falls das Produkt sich bereits in dem Warenkorb befinden erhöhen wir die Menge - existingItem.Quantity++
        //                 {
        //                     existingItem.Quantity++;
        //                     System.Console.WriteLine("Produktmenge erhöht.");
        //                 }
        //                 else
        //                 {
        //                     cart.Add(new CartItem(selectedProduct, 1)); //Wenn es noch nicht in den Warenkorb ist wird es erst hinzugefügt
        //                     Console.ForegroundColor = ConsoleColor.Green;
        //                     System.Console.WriteLine("Produkt wurde dem Warenkorb hinzugefügt!");
        //                     Console.ResetColor();
        //                 }

        //             }
        //             else
        //             {
        //                 Console.ForegroundColor = ConsoleColor.Red;
        //                 System.Console.WriteLine("Ungültige Eingabe."); //Sonst wird diese Fehlermeldung angezeigt
        //                 Console.ResetColor();
        //             }
        //             break;



        case "3":
            Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine("\n🛒 Dein Warenkorb:"); // Überschrift für den Warenkorb
            Console.ResetColor();

            if (cart.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Dein Warenkorb ist leer."); // Falls keine Produkte drin sind
                Console.ResetColor();
            }
            else
            {
                System.Console.WriteLine($"\n{"Menge",6} | {"Produkt",-20} | {"Einzelpreis",12} | {"Gesamtpreis",12}");
                System.Console.WriteLine(new string('-', 60)); // Trennlinie für bessere Übersicht

                decimal sum = 0;

                foreach (var item in cart) // Alle Produkte im Warenkorb auflisten
                {
                    decimal UnitPrice = item.Product.Price;
                    decimal TotalPrice = item.Product.Price * item.Quantity;
                    sum += TotalPrice;

                    System.Console.WriteLine($"{item.Quantity,6} | {item.Product.Name,-20} | {UnitPrice,10:F2}€ | {TotalPrice,10:F2}€");
                }

                System.Console.WriteLine(new string('-', 60));
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine($"{"Gesamt",-29}: {sum:F2}€"); // Gesamtsumme
                Console.ResetColor();
            }
            break;




        case "4":
            // System.Console.WriteLine("\nEinkauf angeschlossen: ");
            if (cart.Count == 0) //Prüfen ob der Warenkorb leer ist
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Dein Warenkorb ist leer.");
                Console.ResetColor();
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

                Console.ForegroundColor = ConsoleColor.Blue;
                System.Console.WriteLine("\nHast du einen Rabbatcode? (j/n): "); //User wird gefragt ob er einen Rabattcode hat
                Console.ResetColor();
                string answer = Console.ReadLine() ?? "".ToLower();

                if (answer == "j" || answer == "ja") //Wenn antwort ja - wird überprüft ob code existiert
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    System.Console.WriteLine("Bitte gib den Rabattcode ein: ");
                    Console.ResetColor();
                    string enteredDiscount = Console.ReadLine() ?? "";

                    if (dicountCodes.ContainsKey(enteredDiscount)) //Hier findet die überprüfung statt
                    {
                        decimal discountValue = dicountCodes[enteredDiscount];

                        if (discountValue < 1) //Hier wird das Prozent gerechnet - zbs. 15%
                        {
                            decimal discountAmount = sum * discountValue;
                            sum -= discountAmount;
                            Console.ForegroundColor = ConsoleColor.Green;
                            System.Console.WriteLine($"Rabatt angewendet: -{discountAmount:F2}€ ({discountValue * 100}% Rabatt)");
                            Console.ResetColor();
                        }
                        else
                        {
                            sum -= discountValue; //Hier wird ein fester Betrag gerechnet - zbs. 5€
                            if (sum < 0) sum = 0;
                            Console.ForegroundColor = ConsoleColor.Green;
                            System.Console.WriteLine($"Rabatt angewendet: -{discountValue:F2}€");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Ungültiger Rabattcode."); //Ansonsten wird diese meldung angezeigt
                        Console.ResetColor();
                    }
                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                System.Console.WriteLine($"Gesamtbetrag: {sum:F2}€");
                Console.ResetColor();
                // orderLines.Add(new string('-', 30)); //Trenner damit die Bestellungen übersicht haben

                // File.AppendAllLines("orders.txt", orderLines); //Speichern in einer Datei - in diesem Fall "orders.txt" (Es erstellt die datei)

                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Bestellung gespeichert!");
                Console.ResetColor();

                // Console.WriteLine("Bestellung gespeichert unter: " + Path.GetFullPath("bestellungen.txt")); //Als Hilfe wenn man nicht weißt wo die datei erstellt wurde

                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("\nEinkauf abgeschlossen. Vielen Dank!"); //Wenn User 4 eingibt wird der Einkauf abgeschlossen und diese meldung angezeigt
                Console.ResetColor();


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

                string json = JsonSerializer.Serialize(bestellung, new JsonSerializerOptions { WriteIndented = true });
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
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("Ein Stück wurde entfernt.");
                        Console.ResetColor();
                    }
                    else //Ansonsten werden alle gleiche Produkte aus den Warenkorb entfernt
                    {
                        cart.RemoveAt(removeIndex - 1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("Alle wurden entfernt.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    cart.RemoveAt(removeIndex - 1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine("Produkt wurde entfernt."); //Wenn nur 1 Produkt im Warenkorb wird dieser direkt entfernt ohne nach Menge zu fragen
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Ungültige Eingabe."); //Sonst wird diese Fehlermeldung angezeigt
                Console.ResetColor();
            }
            break;


        case "6":
            System.Console.WriteLine("\nNach welchem Produkt suchst du?");
            string searchTerm = Console.ReadLine() ?? "".ToLower();

            var allProducts = categories.SelectMany(c => c.Products).ToList();

            var searchResults = allProducts
            .Where(p => p.Name.ToLower().Contains(searchTerm)) //.Where geht jedes Produkt durch - "p" = jedes einzelne produkt | .ToLower().Contains(searchTerm) vergleicht, ob der Produktname den Suchbegriff enthält
            .ToList(); //Macht daraus wieder eine Liste

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            System.Console.Write("Suche wird durchgeführt"); //Das ist eine Suche-Animation
            Console.ResetColor();
            Thread.Sleep(500);
            System.Console.Write(".");
            Thread.Sleep(500);
            System.Console.Write(".");
            Thread.Sleep(500);
            System.Console.WriteLine(".");


            if (searchResults.Count == 0) //Wenn die Suche nicht überreinstimmt bekommt der User diese Meldung
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("\nKeine Produkte gefunden.");
                Console.ResetColor();
            }
            else //Ansonsten werden die produkte angezeigt
            {
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("\nSuchergebnisse: ");
                Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Ungültige Auswahl."); //Falls der User etwas anderes als angefordert eingibt erscheint diese Meldung 
            Console.ResetColor();
            break;
    }

}
