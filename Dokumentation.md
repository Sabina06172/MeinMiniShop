# **Mein Projekt: Mini-Online-Shop**
### ***.NETShop***

## **Ziel**:
Entwicklung einer einfachen Konsolenanwendung, mit der Produkte angezeigt, in den Warenkorb gelegt, gekauft und gelöscht werden können.

### Funktionen:
- Produkte anzeigen
- Produkte in den Warenkorb einlegen
- Warenkorb anzeigen und Gesamtbetrag berechnen
  - Einkauf abschließen
  - Produkte löschen

---

## **Tag 1:**

- **Ordnerstruktur**: Einen neuen Ordner namens `MeinProjekt` erstellt und die **Markdown All in One** Extension installiert.
- **Projektvorstellung**: Eine erste Vorstellung der App gemacht und die Features definiert.
- **Produkt-Klasse**: Die Klasse `Product` erstellt.
- **GitHub Repository**: Einen neuen Repository namens `MeinMiniShop` auf GitHub erstellt.
- **Pseudocode**: Verschiedene YouTube-Videos zum Thema Pseudocode angesehen, z.B.:
  - [Pseudocode Video](https://www.youtube.com/watch?v=alYA_DJIeMI)

---

## **Tag 2:**

Mit Hilfe von ChatGPT und eigener Recherche:

- **Produktklasse**: Die `Product`-Klasse um die Attribute **Name** und **Price** erweitert.
- **Konstruktor & Methoden**: Konstruktor und Methoden zur Initialisierung und zum Verwalten von Produkten erstellt.
- **Produktliste**: In der Datei `Program.cs` eine Liste von verfügbaren Produkten (`products`) erstellt.
- **Warenkorb**: Eine Liste für den Warenkorb (`cart`) angelegt.
- **Menüstruktur**: Ein einfaches Menü mit **while**-Schleifen und **switch**-Anweisungen für die Steuerung des Programms erstellt.
  
**Fehlerbehebung**:
- Ich hatte einen Fehler im Konstruktor der `Product`-Klasse. Die Summe der Produkte im Warenkorb wurde nicht korrekt berechnet. Das Problem war, dass die Felder `Price` und `Name` im Konstruktor mit einem Großbuchstaben geschrieben waren. Der Fehler konnte behoben werden, indem die Parameter wie folgt umbenannt wurden:

```csharp
// Falsch:
public Product(string Name, decimal Price)  // Fehlerhafte Schreibweise
{
    this.Name = Name;
    this.Price = Price;
}

// Korrektur:
public Product(string name, decimal price)  // Richtige Schreibweise
{
    this.Name = name;
    this.Price = price;
}
```

**Lernsourcen**: Ich habe mir zusätzlich Videos angeschaut, um mein Wissen zu vertiefen:
- [Klassen in C#](https://www.youtube.com/watch?v=5kbv5eRsDEA)
- [C# Lernen](https://www.youtube.com/watch?v=nBf3Usw67Tw)

**Tests**: Ich habe mich selbst mit Quizfragen von ChatGPT gestestet, um mein Wissen über den Tag hinweg zu überprüfen.

Am ende habe ich mich hingesetzt und den code mit meine eigene Worte erklärt.

---

## **Tag 3:**