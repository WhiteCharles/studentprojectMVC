# studentprojectMVC
Student Website in the frame work of the Software Security course administered by Mr. Johan Peeters, lecturer at Erasmus University College, Brussels, Belgium

# webapplication
- 2nd web app for Software Security course
- School: Erasmus University College, Brussels
- Student: Charles D. White
- Instructor: Mr. Johan Peeters

#webapplication URL: www.studentproject.be  -  studentproject.be
- GitHub repository current project: https://github.com/WhiteCharles/studentprojectMVC
- Github Repository previous project attempts:
--> RecRepository - webapplication - HomeFarm - MusicRepo

De Asp.Net Core 3.1 web applicatie op www.studentproject.be geeft een 404 NotFound foutmelding wanneer die online staat. De lokale versie werkt zoals het hoort. Tot voor enkele dagen werkte de applicatie zoals het hoorde en het is niet duidelijk waarom wat er is veranderd.
De hosting provider bekijkt langs de server kant of het probleem aan een van de settings kan liggen aangezien enkele foutmeldingen erop wijzen dat dat niet helemaal uit te sluiten is. Zelf heb ik alle routing herbekeken maar niets gevonden.

De hosting provider kan TLS1.0 en TLS1.1 niet uitzetten omdat naar eigen zeggen anders de dienstverlening naar andere klanten in het gedrang komt. Via code lijkt het niet mogelijk of is het mij toch niet gelukt om de TLS1.0 en TLS1.1 af weren ondanks de code snippets die ik gevonden heb. Ik heb ook in forums niemand gevonden die daarin geslaagd lijkt te zijn.

De gebruiker kan zich aanmelden door gebruikersnaam i.e. email in tegeven evenals een paswoord. De implementatie van OpenID is niet volledig omdat ik online niet kan zien wat er gebeurd en omdat ik onder de omstandigheden van  onzichtbare website (404) geen drastische wijzigingen wil doorvoeren en zo eventueel de site helemaal onbereikbaar te maken.

Er is een knop waarmee de gebruiker kan instemmen met de privacy regels en er is een document aanwezig waarin de privacy regels uitgelegd staa.

Ik heb geen module/scanner ingebouwd – bestaat dit? – om op de hoogte te blijven van pas ontdekte beveiligingsproblemen in de componenten waarvan ik gebruik maak. In de NuGet package Manage kan ik nagaan of er updates beschikbaar zijn voor de ‘packages’ die ik heb gebruikt.

Omwille van de problemen met zichtbaarheid van de applicatie heb ik een API in een apart project (in dezelfde solution) gemaakt. Het aparte API project staat samen met het hoofdproject op GitHub. Van de GET en POST requests die ik heb kunnen opmaken heb ik screenshots bijgevoegd in het project.

NOTES:
- An additional ReadMe file is available within the project containing a list with a number of sources and references.
- I continue to experience database/server connection problems which do not allow the application to run as it does on a local machine.
- This is a work in progress as the deadline has not been reached yet.
