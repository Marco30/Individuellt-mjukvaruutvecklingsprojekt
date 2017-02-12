#Vision och Kravspecifikation

**Bakgrund och problembeskrivning**

Jag vill skapa en administrativ applikation som riktar sig till föreningar, Applikationen ska användas av föreningar för att registrerar nya medlemmar och administrerar existerande medlemmar. Man ska också i applikation kunna administrerar aktivteter och befattningar.

Jag vill göra en applikation inom det här området för att jag själv har en egen förening och håller förenings verksamhet varmt om hjärtat.

**Målgrupp**

Min målgrupp är bred efter som jag riktar mig till förening aktiva, de kan vara 15-95 År. Jag har pratat med andra föreningar jag känner att och fot positiv feedback, jag känner applikationens tänkta design och idé tilltalar den målgruppen jag riktat in mig på. En grupp som är i konstant förändring och utveckling, medlemmar kommer och medlemmar går, nya aktiviteter kommer och går. Min applikation behövde byggas med insikten att, kunskap till kommer en förening genom medlemmar och försvinner när medlemmar slutar. 

Applikationen behövde vara flexibel nog att hantera nya användare utan att vara allt för svår att lära sig. I min målgrupp finns det både låg och hög datakunskap. Något som finns med den nya generationen är en nyfikenhet kring allt vad gäller datorer och ny teknologi. Samtidigt ser jag dock inte det som en omöjlighet att äldre kommer att kunna lära sig applikationen. Då mer datorteknologin integrerad in i våra liv, då längre upp i åldrarna kommer användare bli en tidigare.

Målet med min applikation var att skapa en plattform som är lett att använda, lät att lära sig och tydlig. 

**Liknande system** 

VISMA Föreningsprogram
https://vismaspcs.se/produkter/bokforingsprogram/visma-forening

MYCLUB medlemssystem
https://www.myclub.se/


**Kravspecifikation för databas** 
* Man ska i databasen spara medlems information, till exempel namn, efternamn adress, ort m.m.
* Kontakt information ska sparas och kontakttyp 
* Datum när man blev medlem och hur lång tid man varit medlem ska skötas automatiskt, om medlemstid gåt ut så ska det med hjälp av användargränssnitt presenteras för användare, så att man kan meddela medlem att betala medlemsavgift. 
* Databasen ska ha möjlighet att spara förenings aktiviteter så att det kan användas i användargränssnitt för att registrera medlemmar till aktiviteter. 
* Hierarki ska skapas, det ska gå att se om användare är ordförande, vice ordförande, ekonomiansvarig eller vanlig medlem. 

**Kravspecifikation för användargränssnitt**
* man ska med hjälp utav den kunna registrera, uppdatera och ta bort nya och befintliga medlemmar samt se information om medlem som adress, personnummer, befattning, telefonnummer, vilka förenings aktiviteter man kommer delta i m.m.
* man ska kunna se en lista på alla aktiviteter som finns, man ska kunna skapa aktiviteter, ta bort aktivteter och lägga till medlemmar i aktivitet och ta bort medlemmar från aktivteter 
* man ska kunna lägga till befattningar och ta bort befattningar 
* man ska kunna lägga till kontakt information och ta bort kontakt information

**Teknik**
Jag ska använda ASP.NET, C#, JavaScript, CSS, SQL 

-----------------------------------------------------------------------------------------------------------
Webbprogrammerare 
delkurs: Individuellt mjukvaruutvecklingsprojekt
Marco Villegas
