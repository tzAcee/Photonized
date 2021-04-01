# Dokumentation: Photonized
  - [Was ist Photonized?](#was-ist-photoniced)
  - [Wie lasse ich die Software laufen?](#wie-lasse-ich-die-software-laufen)
	- [Startparameter](#params)
  - [Frameworks](#frameworks)
  - [Unit Testing](#testi)
  - [Clean Architecture](#clean-architecture)
  - [Domain Driven Design](#domain-driven-design)
  - [Refactoring](#refactoring)
  - [Programming Principles](#princ)
  - [Entwurfsmuster](#entwurfsmuster)
  - [TODO](#todo)

<a name="what"></a>
## Was ist Photonized?
Photonized ist eine Software, welche im Zuge eines Programmentwurfs für die TINF18B4 Advanced Software Engineering Vorlesung entwickelt wurde.
Die Anwendung dient dazu, Bilder in selbst festgelegte Ordner zu sortieren.
Durch eine minimalistische Darstellung, basierender auf einer Konsolenanwendung, ist die Handhabung sehr durchsichtig.


Die Ordner werden relativ zum Ortspfad der Anwendung erstellt. Das heißt: Wird photonized in "/home/test/" ausgeführt, werden auch die Ordner in "/home/test/*" erstellt. Dieser Pfad kann entweder über einen [Startparameter](#params) oder direkt in der Anwendung ("Change Device Path") verändert werden. Der derzeitige Device Pfad wird im Titel der Konsolenanwendung angezeigt.

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

(Code wurde in Visual Studio (Windows) und in Rider (Linux) programmiert, somit sollte es direkt laufen, wenn man es damit startet)
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

<a name="testi"></a>
## Unit Testing
Unit Testing war ein essentieller Part während des Programmsentwurfs. Wie oben schon erwähnt wurde MSTest zum Testen und Moq zum Mocken verwendet.
Die Test- sowie Codecoverage ist aus dem nächsten Bild zu entnehmen.
![Test und Codecoverage](assets/test_cover.png)

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
![Test UML (Zeigt die Isolation)](uml/tests/uml_tests.png)

<a name="clean"></a>
## Clean Architecture
Die Software besteht, um es zusammenfassen, aus zwei klaren Schichten.
Einer Präsentationsschicht und einer logischen Schicht.
Die Logikschicht ist im Modul `device` zu finden und ist dafür zuständig auf die Festplatte zuzugreifen, die Daten zu verwalten und später auch an die "View" zu übergeben.

Die Präsentationsschicht ist im Modul `ui` zu finden und braucht eine dringende Referenz auf das `device`, um an die Daten sowie die `MethodsHolder` zukommen, damit man die einzelnen Menüpunkte zu den Funktionen aus dem `device` zuordnen kann.

Jede Schicht wird in der `Factory` bereitgestellt.

![UML Diagramm der Software](uml/software/uml_programm.svg)

<a name="DDD"></a>
## Domain Driven Design
Um auf einen Nenner bei der Programmierung und dem Verständnis zu kommen, muss die Ubiquitous Language analysiert werden.
Ein sehr auffälliger Punkt in der Ubiquitous Language, dass es notwendig ist, dass jede Klasse ein Interface mit (`I` gekennzeichnet) benötigt. Es sei denn die Klasse ist orbitant klein. Die Getter/Setter werden außerdem über die Keywords `get, set` erstellt und nicht über eigene Funktionen. Wenn eine Funktion aus einem Einzeiler besteht, wird die Lambda-Schreibweise (`=>`) verwendet.

Innerhalb der Klassen (ausgeschlossen ist die Factory) dürfen keine `new` Keywords fallen. Dies kann zu Inkonsistenz führen.

Außerdem wurden einige taktische Muster des DDD verwendet.
Das wohl gängiste Muster sind die Domain Services, welche sich in den Modulen innerhalb der "services" Ordner befinden. Diese sind dazu gedacht unabhängige bzw. komplett isolierte Aufgabe durchzuführen. Wie zum Beispiel aus einem Pfadstring, den Filenamen zu extrahieren.

Zum Darstellen der Menüfelder wurden auch Value Objects - der MethodsHolder - verwendet. Dieser beinhaltet die Action & den Titel der Action im Menü.

Die Deviceklasse bildet das Agregat Muster. Wenn man ein Device anfordert, wird immer der Reader, Changer und Sorter mitgeliefert.
<a name="refactor"></a>
## Refactoring
Zunächst wurde eine Refactoring für das Unit Testing betrieben, denn in C# kann man die Console Klasse nicht direkt testen. Man muss diese zunächst Wrappen und innerhalb der Unit Tests mocken.


Um Code-Smells richtig zu analysieren wurde eine Visual Studio Extension, namens Designite benutzt. Diese bietet einen Haufen an Details über den geschrieben Code und zeigt unter Anderem auch die erkannten Code-Smells an. In dem Fall wird sich auch nur auf diese Smells fokusiert:

![](assets/smell1.PNG) | ![](assets/smell2.PNG) |![](assets/smell3.PNG)


So sieht die Übersicht nach einer Projektanalyse aus. Logischerweise sind im Unit-Testing Projekt mehr Smells, da diese mehr oder weniger einer bestimmten Struktur folgen und zum Teil auch auto-generiert sind.

Als Beispiel wird hier nur das Refactoring der Implementation-Smells behandelt. Andere Smells wurden intern gelöst.
Der erste Schritt ist die beiden Magic Numbers aufzulösen. Hier ein Beispiel aus dem DeviceSorter:


```
Magic Number: 
The smell arises when a potentially unexplained literal is used in an expression.
The following statement contains a magic number:
dateSplitted.Length != 3
```
Das Ganze lässt sich einfach durch eine konstante Variable lösen. Der Sinn diesen Smell aufzulösen ist, dass Magic Numbers von Leuten, die den Code nicht kennen, nicht ohne weiteres gedeutet werden können und nicht verstehen können, wieso nun genau diese Nummer da steht. Weshalb Hintergrundwissen durch einen Variablen Namen helfen kann.

Ein anderer Smell ist das Long-Statment:
```
Long Statement: 
The smell arises when a statement is long.
The length of the statement 
"                    File.Delete(entry); // either auth exception or double file exception -> so delete (which follows another exception, when auth)
" is 127.
```
Das lässt sich auflösen indem, man den Kommentar mehrzeilig macht. Diesen Smell aufzulösen macht vorallem wegen der Übersichtlichkeit und der Lesbarkeit des Codes Sinn. Denn man will ohne weiteres Scrollen Inhalte des Codes lesen können.
<a name="princ"></a>
## Programming Principles
#### KISS
Um die Software möglichst simpel zu halten, wurde auf eine größere Viewschicht verzichtet. Da es zum Teil mehrere tausend Bilder sein können, wäre auch ein Click-To-Select Feature nicht allzu sinnvoll. Somit ist eine simple Konsolenanwendung optimal.

#### GRASP
In der Präsentationsschicht wird sehr auf Polymorphismus gesetzt, um unnötige Komplikationen zu vermeiden.
Allgemein werden sehr viele Klassen bzw. Subsysteme (s. `device`) angelegt, um eine möglichst hohe Kohäsion zu erzeugen.

#### DRY
Um Wiederholungen zu vermeiden wurde Abläufe entweder in Funktionen ausgelagert oder es wurde, je nach dem, direkt ein ganzer Services geschrieben.

#### SOLID
Durch die Factory Lösung und die klare Schichtarchitektur, kann jedes einzelne Modul durch weitere Module einfach erweitert werden. Jedes einzelne Objekt innerhalb der Factory sind auch `public`.

<a name="entwurf"></a>
## Entwurfsmuster
Von Beginn an war geplant eine Factory zu verwenden. Jedoch erstmal nur experimentell, wie es in folgendem Bild zu sehen ist. Es werden ständig neue Objekte erzeugt, was logischerweise zu inkosistenzen führen kann.
![Old Factory Content](assets/fac_old1.png)
![Old Factory Usage](assets/fac_old2.png)

Nachdem eine richtige Factory umgesetzt wurde, konnte diese endlich richtig verwendet werden.
![New Factory Content](assets/fac_new1.png)
![New Factory Usage](assets/fac_new2.png)

Der Zweck der Factory ist, dass man innerhalb von Klassen keine `new`-Keywords hat. Sondern eben nur in der Factory. Das hilft Inkosistenzen durch doppelte Objekte zu vermeiden. 

<a name="todo"></a>
## TODO
Aufgrund der 1500 Codezeilen Grenze, war es nicht möglich weitere Funktionen zu implementieren, dennoch ist es wichtig, die geplanten Änderungen hier festzuhalten.

Man könnte sich zum Beispiel überlegen, die Factory Module spezifisch aufzubauen. Also für jede Schicht eine eigene Factory und eine Main Factory, welche die Unter-Factories verwaltet. 

Ein technisches Feature wäre zum Beispiel das Updaten der Einträge, sodass ein vollständiges CRUD Modell vorliegt. 
