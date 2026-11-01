# TaskManager

TaskManager är en konsolapplikation utvecklad i C# och .NET. Syftet med applikationen är att hjälpa användaren att organisera och hantera sina uppgifter genom ett enkelt textbaserat gränssnitt.

## Funktioner

- Skapa nya uppgifter med titel, beskrivning och prioritet.
- Visa alla registrerade uppgifter.
- Redigera befintliga uppgifter.
- Markera uppgifter som slutförda.
- Ta bort uppgifter.
- Filtrera uppgifter efter status (slutförda eller ej slutförda).
- Spara och läsa in uppgifter automatiskt med JSON.

## Tekniker

- C#
- .NET
- Objektorienterad programmering (OOP)
- System.Text.Json
- Git och GitHub

## Projektstruktur

- `Program.cs` – Hanterar huvudmenyn och användarens inmatningar.
- `TaskItem.cs` – Representerar en uppgift med dess egenskaper.
- `TaskManagerService.cs` – Innehåller metoder för att hantera, redigera, filtrera och spara uppgifter.
- `tasks.json` – Skapas automatiskt och används för att lagra uppgifterna.

## Installation och körning

1. Klona projektet från GitHub eller ladda ner projektfilerna.
2. Öppna projektet i Visual Studio med stöd för projektets .NET-version.
3. Bygg projektet.
4. Starta applikationen med `Ctrl + F5`.
5. Använd den numrerade menyn för att hantera uppgifter.

Alternativt kan applikationen köras via terminalen i projektmappen:

```bash
dotnet run
```

.NET SDK för projektets version behöver vara installerat.

## Datalagring

Applikationen använder JSON för att spara uppgifter lokalt. När användaren skapar, redigerar, slutför eller tar bort en uppgift uppdateras JSON-filen.

När programmet startas läses tidigare sparade uppgifter in automatiskt.

## Felhantering

Programmet innehåller grundläggande validering av användarens inmatningar, exempelvis kontroll av tomma titlar och ogiltiga uppgiftsnummer. Fel vid läsning och skrivning av JSON-filen hanteras med undantagshantering.

## Syfte

Projektet har utvecklats som en del av kursen Programmering i C#.NET vid Mittuniversitetet. Syftet är att tillämpa kunskaper inom C#, objektorienterad programmering, filhantering och programstruktur.

## Videopresentation

En videodemonstration av TaskManager där jag visar applikationens funktioner, förklarar programstrukturen och beskriver hur uppgifterna sparas med JSON.

**Se videopresentationen här:** Videopresentation av TaskManager: https://youtu.be/Ld5ckVANEGU  
