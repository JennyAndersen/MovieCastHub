Project Description
Vi välkomnar dig till vår filmapplikation - en plats där filmentusiaster kan samlas, dela sina favoritfilmer och utforska nya. Inspirerad av IMDb har vi skapat en användarvänlig plattform där du kan skapa ditt eget konto, utforska filmer, och lägga till dina egna favoriter.

Funktioner
Användarkonto:
Skapa och logga in på ditt personliga konto.
Alla användaruppgifter sparas säkert i vår databas.

Filmhantering:
Lägg till dina favoritfilmer till vår gemensamma databas.
Specificera regissör, titel och betyg för varje film.
Alla uppgifter om filmer sparas noggrant och är enkelt åtkomliga.

Säkerhet:
Användare utan konto kan inte lägga till filmer.
Vi använder oss av CQRS (Command Query Responsibility Segregation) och Mediator för att säkert och effektivt hantera kommunikationen i vår applikation.

How to Set Up the Project
Följ dessa steg för att komma igång med vår filmapplikation:

öppna visual studio och klicka på "Clone a repository"

därefter klona projektet till din lokala miljö genom att klistra in denna länk på din visialstudio
"https://github.com/ditt-anvandarnamn/din-repo.git"

Byt conection i appsetting strängen så den får tillgång till SSMS på din maskin
när det är gjort gör en add migration och en  ef update db så att databasen är uppdaterad 

Byt till HTTPS och kör applikationen.

Kör projektet för att öppna Swagger och utforska dess funktionaliteter.

Dependencies
Vi använder följande dependencies för att säkerställa en smidig och effektiv utvecklingsprocess:

MediatR: Ett verktyg för att implementera CQRS mönster och förenkla kommandohantering.

Mediator+FluentValidation: För att säkerställa att de inkommande kommandona och querys valideras enligt våra fördefinierade regler.

SeriLogg: Loggar händelser i consolen 

Usage Examples
Nedan finns några exempel på hur du kan använda vår filmapplikation:

Skapa konto:
Registrera dig och skapa ditt eget personliga konto.

Utforska filmer:
Bläddra bland filmer.

Lägg till favoriter:
Logga in och lägg till dina favoritfilmer med regissör och betyg.
