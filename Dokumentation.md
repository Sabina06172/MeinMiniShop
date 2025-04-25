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

### Erweiterungen:
- Speichern von Bestellungen in einer Datei
- Suchfunktion
- Rabattcode System
  
---

## **Tag 1:** - **12.04.25**

- **Ordnerstruktur**: Einen neuen Ordner namens `MeinProjekt` erstellt und die **Markdown All in One** Extension installiert.
- **Projektvorstellung**: Eine erste Vorstellung der App gemacht und die Features definiert.
- **Produkt-Klasse**: Die Klasse `Product` erstellt.
- **GitHub Repository**: Einen neuen Repository namens `MeinMiniShop` auf GitHub erstellt.
- **Pseudocode**: Verschiedene YouTube-Videos zum Thema Pseudocode angesehen, z.B.:
  - [Pseudocode Video](https://www.youtube.com/watch?v=alYA_DJIeMI)

---

## **Tag 2:** - **22.04.25**

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

## **Tag 3:** - **23.04.25**

- **Menüpunkt 5** – Produkt aus dem Warenkorb entfernen: Einen neuen Menüpunkt hinzugefügt, um Produkte aus dem Warenkorb zu entfernen. Bei mehrfach vorhandenem Produkt wird abgefragt, ob alle oder nur eins entfernt werden soll.

- **CartItem-Klasse**: Eine neue Klasse `CartItem` erstellt, die Quantity (Menge) neben dem Product verwaltet. Dies verhindert Duplikate im Warenkorb.

- **Erweiterung Menüpunkt 2** – Produkt hinzufügen: Beim Hinzufügen wird geprüft, ob das Produkt bereits im Warenkorb liegt. Falls ja, wird die Menge erhöht; ansonsten wird ein neuer CartItem angelegt.

- **Warenkorb anzeigen**: Der Warenkorb zeigt jetzt Produktname, Menge und Gesamtpreis pro Produkt an. Der Gesamtbetrag aller Produkte wird berechnet.

- **Einkauf abschließen**: Der Warenkorb wird zusammengefasst und der Gesamtbetrag angezeigt, bevor er geleert wird.
  
  ***Im Großteil habe ich mein code verbessert und optimiert nachdem ich einen neuen Menüpunkt hinzugefügt habe - (musste auch jedes Menüpunkt angepasst werden.)***


**Fehlerbehebung:**

Beim Entfernen von Produkten aus dem Warenkorb wurde das Produkt stattdessen wieder hinzugefügt. Das Problem konnte durch das Ersetzen von + mit - und der Nutzung von .Remove behoben werden.

---

## **Tag 4:** - **24.04.25**

- **Bestellungen als JSON speichern** – Statt wie zuvor in einer `.txt`-Datei, wird die abgeschlossene Bestellung nun automatisch beim Abschluss (Menüpunkt 4) als `.json`-Datei gespeichert. 

- **Menüpunkt 6 – Suchfunktion**: Ein neuer Menüpunkt wurde erstellt, um Produkte nach Namen zu durchsuchen. Dabei wird ein Suchbegriff eingegeben und alle Produkte mit passenden Namen werden angezeigt (case-insensitive Suche über `.ToLower()` und `Contains()` via `LINQ`).

- **Erweiterung Produktliste** – Die ursprüngliche Produktliste wurde mit zusätzlichen Produkten erweitert, um die Suchfunktion besser testen zu können.

- **Anpassung Menüstruktur** – Das Menü wurde aktualisiert und übersichtlich erweitert, damit alle neuen Funktionen eingebunden sind.

***Heute lag der Fokus auf Erweiterbarkeit und Benutzerfreundlichkeit. Dazu habe ich in W3School mir das wichtigste nochmal angeschaut und auch den Quiz am ende gemacht.***


**Fehlerbehebung & Verbesserung:**

Beim Versuch, eine Bestellung zu speichern, habe ich als erstes eine `.txt`-Datei verwendet – später auf `.json` umgestellt(nachdem ich nachgesucht habe wie das gehtt, und mir videos auf Youtube angeschaut habe), da sie besser geeignet ist. 
Außerdem wurden `using`-Anweisungen ergänzt (`System.Text.Json`, `System.Linq`), um LINQ und JSON-Funktionalität zu nutzen. (Da ich beim `.Where` und `.List` fehler hatte und nicht wusste warum - nach einhabe von `using System.Linq` war der Fehler weg(nochmal was neues heute gelernt)).

**Lernsourcen**:
- [W3Schools](https://www.w3schools.com)
- ChatGPT
- [Was ist JSON](https://www.youtube.com/watch?v=BUFN0WMVW3k&t=40s)
- [Die Arbeit mit JSON in C# vereinfachen](https://www.youtube.com/watch?v=S3hXbc0DC0Q)
- [Using JSON in C#](https://www.youtube.com/watch?v=w6M-Bj-tfv4)

---

## **Tag 5:** - **25.04.25**

- **Rabattcode-System:** - Vor dem Abschluss einer Bestellung kann ein Rabattcode eingegeben werden. Wird ein gültiger Code erkannt (z. B. RABATT15), wird der Gesamtbetrag entsprechend reduziert. 

- **JSON-Dateispeicherung verbessert:** - Statt order.json wird nun bei jeder abgeschlossenen Bestellung eine eigene Datei im Bestellungen-Ordner erzeugt – benannt mit Datum und Uhrzeit.
 ***Die gespeicherte Datei enthält:***

  - Liste aller bestellten Artikel mit Name, Einzelpreis, Menge und Gesamtpreis

- **CartItem-Klasse erweitert:** - Es wurde einen Konstruktor definiert da in der Console eine Warnung angezeit war. Durch den Konstruktor war diese auch weg. Danach mussten die Stellen im Code angepasst werden, wo neue CartItem-Objekte erstellt wurden.

**Fehlerbehebung & Verbesserung:**

 - In der Konsole wurde das Euro-Zeichen als Fragezeichen (?) angezeigt. Nach viel rumprobieren und Recherche wurde die Lösung gefunden:
- ***In Program.cs wurde die folgende Zeile eingefügt:***

```csharp
Console.OutputEncoding = System.Text.Encoding.UTF8;
```
Danach wurde das Eurozeichen korrekt dargestellt.

***Heute habe ich meinen Code besser strukturiert und die Logik robuster gemacht, vor allem beim Speichern und Bearbeiten der Bestellungen.***


**Lernsourcen**:

- ChatGPT
- [Google](https://www.bing.com/search?pglt=2083&q=dictionary+c%23&cvid=ff56d98c36e6416286610a49bbdc7563&gs_lcrp=EgRlZGdlKgYIABBFGDkyBggAEEUYOTIGCAEQABhAMgYIAhAAGEAyBggDEAAYQDIGCAQQABhAMgYIBRAAGEAyBggGEAAYQDIGCAcQABhAMgYICBAAGEAyCAgJEOkHGPxV0gEINjEzMGowajGoAgCwAgA&FORM=ANNAB1&PC=U531)
- [C# Dictionary kurz und einfach erklärt](https://www.youtube.com/watch?v=D02oPfxYfDU)
- [C# Tutorial for Beginners - Dictionary](https://www.youtube.com/watch?v=7g5KySGavUI)

---

## **Tag 6:** - **28.04.25**