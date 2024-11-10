# ML.Net Text-Klassifizierung
Dies ist ein kleines Testprojekt einer .NET Konsolenapplikation, die dazu verwendet werden kann, um Bewertungen klassifizieren zu können.

Mithilfe von [ML.NET](https://dotnet.microsoft.com/apps/machinelearning-ai/ml-dotnet) wird beim ersten starten ein Model mit Daten erstellt und trainiert.

## Englisch Readme
This Readme was written in German. If you want to read the English Readme click on the link below. :)
- [Englisch Readme](https://github.com/domsse/ML.Net_Text-Classification/blob/master/README_ENG.md)

## Was wird benötigt?
- [![NuGet Status](https://img.shields.io/nuget/v/Microsoft.ML.svg?style=flat)](https://www.nuget.org/packages/Microsoft.ML/)
- [.NET Core 8](https://www.microsoft.com/net/learn/get-started)

## Erster Start
1. Bevor die Anwendung gestartet werden kann, müssen sie in den Parametern ein Dateipfad mit den Daten zum erstellen/trainieren angeben werden.
2. Beim ersten Start wird zuerst das Model erstellt und mit den Daten trainiert.
3. Nachdem das erstellen und trainieren abgeschlossen ist, wird das Model Lokal im Projektverzeichnis unter ".../Models/StimmungAI.zip" gespeichert.
4. Nun kann nach belieben ein Bewertung eingegeben werden.
5. Anschließend wird jedesmal angezeigt ob die Eingabe positiv oder negativ ist, einschließlich dem erreichten Score.

## Trainingsdaten
- Die Daten wurden von mir mittels Google-Übersetzer in der deutschen Sprache übersetzt.
- Jede Bewertung wird mit 1 oder 0 klassifiziert. (1 = Positiv, 0 = Negativ)
- Die Bewertung und die Klassifizierung sind mit einem TAB separiert.

(Fühlen sie sich frei eigene Daten zu verwenden. Dies funktioniert natürlich problemlos mit jeder Sprache.)
```
Die für dieses Projekt verwendete Dataset stammt aus
„From Group to Individual Labels using Deep Features“,
Kotzias et. al. KDD 2015, und werden im UCI Machine Learning Repository
– Dua, D. und Karra Taniskidou, E. gehostet. (2017).
UCI Machine Learning Repository [http://archive.ics.uci.edu/ml ].
Irvine, CA: University of California, School of Information and Computer Science.
```

## Erneutes erstellen des Models inkl. trainieren
Wenn Sie das Model im Verzeichnis ".../Models/StimmungAI.zip" umbenennen oder löschen, wird beim nächsten Programmstart das Model neu erstellt und trainiert.
