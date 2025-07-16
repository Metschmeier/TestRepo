using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        TestStringMethods();
        TestNumbers();
        TestBooleanLogic();
        TestDateTime();
        TestLists();
        TestDictionaries();
        TestEnumHandling();
    }

    /// <summary>
    /// Demonstriert grundlegende Methoden des Datentyps `string`.
    /// `string` ist ein unveränderbarer (immutable) Datentyp für Text. 
    /// Typische Operationen: Länge, Teilstring, Suche, Ersetzen, Formatierung.
    /// </summary>
    static void TestStringMethods()
    {
        Console.WriteLine("== String-Tests ==");

        string text = "Hallo .NET-Welt!";
        Console.WriteLine($"Original: {text}");

        Console.WriteLine($"Length: {text.Length}");
        Console.WriteLine($"Substring(6, 4): {text.Substring(6, 4)}");
        Console.WriteLine($"Contains('.NET'): {text.Contains(".NET")}");
        Console.WriteLine($"ToUpper: {text.ToUpper()}");
        Console.WriteLine($"Replace('.NET', 'C#'): {text.Replace(".NET", "C#")}");
        Console.WriteLine($"StartsWith('Hallo'): {text.StartsWith("Hallo")}");
        Console.WriteLine($"EndsWith('Welt!'): {text.EndsWith("Welt!")}");
        Console.WriteLine();
    }

    /// <summary>
    /// Zeigt den Umgang mit Ganzzahlen (`int`), Gleitkommazahlen (`double`)
    /// und exakten Dezimalzahlen (`decimal`).
    /// - `int` ist eine 32-Bit-Ganzzahl ohne Nachkommastellen.
    /// - `double` ist eine 64-Bit-Gleitkommazahl (binär, sehr schnell, aber evtl. ungenau).
    /// - `decimal` ist langsamer, aber exakt (z. B. für Geldbeträge, Finanzen).
    /// </summary>
    static void TestNumbers()
    {
        Console.WriteLine("== Zahlen-Tests ==");

        int x = 10;
        double y = 3.14;
        decimal money = 19.99m;

        Console.WriteLine($"int: {x}, double: {y}, decimal: {money}");
        Console.WriteLine($"x + 5 = {x + 5}");
        Console.WriteLine($"x * 2 = {x * 2}");
        Console.WriteLine($"money * 1.2 = {money * 1.2m}");

        string input = "123";
        if (int.TryParse(input, out int result))
        {
            Console.WriteLine($"'{input}' ist eine gültige Zahl: {result}");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Zeigt grundlegende boolesche Operatoren.
    /// `bool` kann nur die Werte `true` oder `false` haben.
    /// </summary>
    static void TestBooleanLogic()
    {
        Console.WriteLine("== Boolesche Logik ==");

        bool isActive = true;
        bool isAdmin = false;

        Console.WriteLine($"isActive && isAdmin: {isActive && isAdmin}");
        Console.WriteLine($"isActive || isAdmin: {isActive || isAdmin}");
        Console.WriteLine($"!isAdmin: {!isAdmin}");

        Console.WriteLine();
    }

    /// <summary>
    /// Demonstriert die Verwendung von `DateTime` zur Darstellung von Datum und Uhrzeit.
    /// Unterstützt Zeitberechnungen, Formatierung und Vergleich.
    /// </summary>
    static void TestDateTime()
    {
        Console.WriteLine("== Datum/Uhrzeit ==");

        DateTime now = DateTime.Now;
        DateTime tomorrow = now.AddDays(1);
        DateTime specific = new DateTime(2025, 1, 1);

        Console.WriteLine($"Jetzt: {now}");
        Console.WriteLine($"Morgen: {tomorrow}");
        Console.WriteLine($"Neujahr 2025: {specific}");
        Console.WriteLine($"Vergleich: now < tomorrow = {now < tomorrow}");
        Console.WriteLine();
    }

    /// <summary>
    /// Verwendet `List<T>` als dynamische Liste.
    /// Listen können Elemente enthalten, hinzufügen, entfernen, durchsuchen usw.
    /// </summary>
    static void TestLists()
    {
        Console.WriteLine("== Liste (List<T>) ==");

        List<string> names = new List<string> { "Anna", "Bob", "Charlie" };
        names.Add("Dora");

        foreach (var name in names)
        {
            Console.WriteLine($"- {name}");
        }

        Console.WriteLine($"Enthält 'Bob'? {names.Contains("Bob")}");
        Console.WriteLine($"Anzahl: {names.Count}");
        Console.WriteLine();
    }

    /// <summary>
    /// Demonstriert `Dictionary<K,V>` – eine Zuordnungstabelle (Key-Value).
    /// Man greift über den Schlüssel auf Werte zu.
    /// </summary>
    static void TestDictionaries()
    {
        Console.WriteLine("== Dictionary<K,V> ==");

        Dictionary<string, int> ages = new Dictionary<string, int>
        {
            ["Anna"] = 30,
            ["Bob"] = 25
        };

        ages["Dora"] = 35;

        foreach (var kvp in ages)
        {
            Console.WriteLine($"{kvp.Key} ist {kvp.Value} Jahre alt");
        }

        if (ages.TryGetValue("Anna", out int alter))
        {
            Console.WriteLine($"Anna ist {alter}");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Enum (Aufzählungstyp) zur Definition fester Werte.
    /// Praktisch für Zustände, Rollen, Kategorien.
    /// </summary>
    enum Role { User, Admin, Guest }

    /// <summary>
    /// Zeigt, wie man Enums verwendet und aus Strings parsed.
    /// </summary>
    static void TestEnumHandling()
    {
        Console.WriteLine("== Enum ==");

        Role r = Role.Admin;
        Console.WriteLine($"Rolle: {r}");

        string input = "Guest";
        if (Enum.TryParse(input, out Role parsedRole))
        {
            Console.WriteLine($"Parsed Role: {parsedRole}");
        }

        Console.WriteLine();
    }
}
