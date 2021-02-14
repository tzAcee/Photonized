# Dokumentation: Photonized
  - [Was ist Photoniced?](#was-ist-photoniced)
  - [Wie lasse ich die Software laufen?](#wie-lasse-ich-die-software-laufen)
	- [Startparameter](#params)
  - [Frameworks](#frameworks)
  - [Unit Testing](#unit-testing)
  - [Clean Architecture](#clean-architecture)
  - [Domain Driven Design](#domain-driven-design)
  - [Refactoring](#refactoring)
  - [Programming Principles](#princ)
  - [Entwurfsmuster](#entwurfsmuster)
  - [TODO](#todo)

<a name="what"></a>
## Was ist Photoniced?
Photoniced ist eine Software, welche im Zuge eines Programmentwurfs für die TINF18B4 Advanced Software Engineering Vorlesung entwickelt wurde.
Die Anwendung dient dazu, Bilder in selbst festgelegte Ordner zu sortieren.
Durch eine minimalistische Darstellung, basierender auf einer Konsolenanwendung, ist die Handhabung sehr durchsichtig.


Die Ordner werden relativ zum Ortspfad der Anwendung erstellt. Das heißt: Wird photoniced in "/home/test/" ausgeführt, werden auch die Ordner in "/home/test/*" erstellt. Dieser Pfad kann entweder über einen [Startparameter](#params) oder direkt in der Anwendung ("Change Device Path") verändert werden. Der derzeitige Device Pfad wird im Titel der Konsolenanwendung angezeigt.

Um nun Bilder zu sortieren, muss zunächst "Sort Device" angewählt werden. Man wird direkt aufgefordert ein Datum anzugeben, an dem die Fotos, die man sortieren möchte, erstellt wurden. Dies ist auch das **Sortierkriterium**. Bei ungültigem Format wird ein Fehler geworfen.
Sobald man ein Datum festgelegt hat, soll man ein Schlagwort (Im Optimalfall ein Ereignis) angeben, welches den Tag zusammenfasst. Zum Beispiel, wenn man nach Urlaubsereignissen sortiert, wäre "Sightseeing" ein Schlagwort.

Im nächste Schritt soll man das Ereignis etwas genauer beschreiben, damit man sich z.B. auch nach längerer Zeit an das Ereignis wieder errinnern kann.


Um die sich im Workspace befindlichen Sortierungen anzuschauen, muss "Read Device" ausgewählt werden.


Um eine Sortierung zu löschen, muss dementsprechend "Delete Entry from Device" ausgewählt werden.


Jegliche angegebenen Meta Daten werden in einer ".photon.json" gespeichert und ausgelesen. Obwohl Konsistenz größtenteils gewährleistet ist, ist es nicht empfehlenswert diese Datei von Hand zu verändern.
<a name="run"></a>
## Wie lasse ich die Software laufen?
Bei der Software handelt sich um eine in C# entwickelte dotnet 3.1 Anwendung. Sie ist somit plattformübergreifend lauffähig.

Um die Anwendung zum Laufen zu bekommen sind im Grunde zwei Schritte zu tun.
Der erste ist, die externen Bibliotheken, sowie Abhängigkeiten wiederherzustellen.
Dies geschieht über `dotnet restore`

Als nächstes kann die Anwendung über `dotnet run` gestartet werden (über diesen Befehl können auch die Startparameter übergeben werden, sofern man die Anwendung nicht über die Binaries startet. Sonst muss man die Parameter Betriebssystem spezifisch, beim Anwendungsstart, übergeben).
<a name="params"></a>
### Startparameter
`-p oder --path`: Setzt den Device Pfad ("./" standardmäßig).
<a name="frameworks"></a>
## Frameworks
*Software Dependencies:*

`CommandLineParser`: Einlesen der Startparameter.

`ConsoleMenu-simple`: Gesamte Viewschicht. Notwending für die Menünavigation.

`NewtonSoft.Json`: Verarbeitung von JSON Dateien.


*Test Dependencies:*


`MSTest`: Testframework

`Moq`: Mocking von Objekten, etc.

<a name="tet"></a>
## Unit Testing
Unit Testing war ein essentieller Part während des Programmsentwurfs. Wie oben schon erwähnt wurde MSTest zum Testen und Moq zum Mocken verwendet.
Die Test- sowie Codecoverage ist aus dem nächsten Bild zu entnehmen.
![Test und Codecoverage](/assets/test_cover.png)
Wie man sieht sind noch nicht alle Tests implementiert, jedoch würde dies ebenfalls die Codezeilengrenze überschreiten. Denn es wurde zum Beispiel ein Console Wrapper (um die Konsole "mockbar" zu machen) geschrieben, jedoch kein Wrapper für die "File" Klasse von C#. Die Console Wrapper Klasse ist nebenbei unter [Refactoring](#refactoring) zu finden.

Das Prinzip der geschriebenen Tests ist relativ simpel. Die erste Eigenschaft ist, dass die Tests sich jeweils immer nur um maximal einen "Use Case" kümmern sollen, denn so weiß man ganz genau, wo auch der Fehler entstanden ist. Einfachheitshalber wurde dann auch nur ein `Assert` bzw. ein (ein weiteres bei chronologischen Abläufen) `Setup` pro Test verwendet.

Weitere Eigenschaften der Tests sind "isoliert" und "zustandslos". Letzteres ist ziemlich klar. Die Testklasse, soll einfach keinen Zustand speichern/haben. Isoliert heißt, dass die individuellen Tests die anderen nicht beeinflussen.


Ein Mock mit dem Framework war ziemlich einfach, ein Beispielt sieht so aus: `var reader = new Mock<IDeviceReader>()`, um auf das Objekt direkt zuzugreifen müsste man auf `reader.Object` zugreifen.

Um einen Funktionsaufruf zu überprüfen, muss man entweder direkt `Verify` aufrufen (`Mock.Get(view).Verify((m)=>m.render(), Times.Once);`) oder vorher ein Setup mit den genauen Funktionen aufbauen und später dann ein `Verify` aufrufen:
```
            console.Setup(fun => fun.Clear());
            console.Setup(fun => fun.WriteLine("Device Structure: (Any Key to continue)"));
            console.Setup(fun => fun.ReadLine()).Returns("");

            reader.read();

            console.VerifyAll();
```
<a name="clean"></a>
## Clean Architecture

<a name="DDD"></a>
## Domain Driven Design

<a name="refactor"></a>
## Refactoring

<a name="princ"></a>
## Programming Principles


<a name="entwurf"></a>
## Entwurfsmuster

<a name="todo"></a>
## TODO
Aufgrund der 1500 Codezeilen Grenze, war es nicht möglich weitere Funktionen zu implementieren, dennoch ist es wichtig, die geplanten Änderungen hier festzuhalten.