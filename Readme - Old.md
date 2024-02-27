## Intro  
Kolla källkoderna och följ med steg för steg, kolla varje assembly's dependencies, vilka project dependencies och nuget dependencies de har allihop.  


## Steg ett:  
Börja med att skapa din model assembly, lägg till dina entiteter i denna.  

## Steg två:  
Skapa en Domain.Abstract assembly och lägg till ett interface (IPersistanceService) för hur du vill kunna persistera i din domän.  

## Steg tre:  
Skapa din Persistance och lägg till följande:  
1. Ett interface (IDbContext) som abstraherar bort onödiga metoder från DbContext.
2. Ett interface (IPeopleDbContext) som implementerar IDbContext och exponerar det som är specifikt i PeopleDbContext.
3. En DbContext (PeopleDbContext) klass som ärver från DbContext och implementerar din abstraktion IPeopleDbContext.
4. Klasser som implementerar IEntityTypeConfiguration för dina entiteter (anropas i OnModelCreating på ditt context).
5. En klass som implementerar IDesignTimeDbContextFactory för PeopleDbContext. Med denna kan EF Core räkna ut hur den ska kunna skapa ett context vid Add-Migration och Add-Database. Glöm inte att lägga till en UserSecret för denna assembly med din connectionstring.
6. Kör Add-Migration och Update-Database.
7. Skapa en extensionklass (PersistanceExtensions) för att göra det möjligt att med ett kommando lägga till allt från din assembly.  
 

## Steg fyra:  
Skapa din Domain assembly och lägg till följande:  
1. Mediatorklasser som implementerar IRequestHandler för respektive åtgärd som ska kunna göras, AddPerson, DeletePerson osv. Dessa klasser injektar interfacet till persisteringsservicen.  
2. I mediatorklasserna lägger du till de kontrakt som mediatorn ska hantera för request och response.  
3. Lägg till en extensionklass (DomainExtensions) för att göra det möjligt att med ett kommando lägga till allt från din assembly.  

## Steg fem:  
Skapa en console application i enlighet med projektet ImplementPersistance och testa så att allt fungerar.  

## Steg sex (lite överkurs):  
Skapa assemblyn Api och se till så ni har rätt värden i csproj-filen, lägg speciellt märke till FrameworkReference, det är denna som ser till att man kan köra AspNet fullt ut i en assembly (att allt finns tillgängligt).  
Kika på min assembly Api för att se hur jag har gjort.
Försök sedan fundera ut hur man i en WebApi host application kan få den till att använda dessa endpoints (vilka extensions behöver jag ha och hur använder jag dem i en WebApi host) och hur får jag alla andra assemblies till att lira i denna WebApi host?  

## Steg sju:
När jag kommer tillbaka på torsdag så ska vi kolla gemensamt på helheten och komma fram till vad vi gjort och varför :)  
Detta exempel fungerar ju inte riktigt som en CQRS lösning så som vi pratat om, det saknas en hel del, vad behöver vi göra för att få ihop det hela?  
Detta vill jag att ni redogör för på torsdag...  
