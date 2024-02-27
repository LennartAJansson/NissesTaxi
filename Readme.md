## Intro  
Kolla källkoderna och följ med steg för steg, kolla varje assembly's dependencies, vilka project dependencies och nuget dependencies de har allihop.  


## Steg ett:  
Börja med att skapa din model assembly, lägg till dina entiteter i denna.  

## Steg två:  
Skapa en Projector.Domain.Abstract assembly och lägg till ett interface (IPersistanceService) för hur du vill kunna persistera i din domän.  

## Steg tre:  
Skapa din Persistance och lägg till följande:  
1. Ett interface (IDbContext) som abstraherar bort onödiga metoder från DbContext.
2. Ett interface (IPeopleDbContext) som implementerar IDbContext och exponerar det som är specifikt i PeopleDbContext.
3. En DbContext (PeopleDbContext) klass som ärver från DbContext och implementerar din abstraktion IPeopleDbContext.
4. Klasser som implementerar IEntityTypeConfiguration för dina entiteter (anropas i OnModelCreating på ditt context).
5. En klass som implementerar IDesignTimeDbContextFactory för PeopleDbContext. Med denna kan EF Core räkna ut hur den ska kunna skapa ett context vid Add-Migration och Add-Database. Glöm inte att lägga till en UserSecret för denna assembly med din connectionstring.
6. Kör Add-Migration och Update-Database.
7. Skapa en extensionklass (PersistanceExtensions) för att göra det möjligt att med ett kommando lägga till allt från din assembly.  
8. Kolla på extensionmetoden UpdateDatabase och interface + implementation av Migrate 

## Steg fyra:  
Skapa din Projector.Domain assembly och lägg till följande:  
1. Mediatorklasser som implementerar IRequestHandler för respektive kommando som ska kunna göras, AddPersonCommand, DeletePersonCommand osv. Dessa klasser injektar interfacet till persisteringsservicen.  
2. I mediatorklasserna lägger du till de kontrakt som mediatorn ska hantera för request och ingen response.  
3. Lägg till en extensionklass (ProjectorDomainExtensions) för att göra det möjligt att med ett kommando lägga till allt från din assembly.  

## Steg fem:  
Skapa en Common.Contracts. Den ska innehålla kontrakten för CQRS-kommandon, tänk på att de ska implementera ICommand och att de ska hanteras av en ICommandQueue (detta är interfacet för vår hantering av Channel)  

## Steg sex:  
Skapa en assembly Common.Messaging. Den ska innehålla en klass som implementerar ICommandQueue. Lägg även till en extension för att addera detta till IServiceCollection.  

## Steg sju:  
Skapa Projector.Endpoints.  

## Steg åtta:  
Skapa Api.Endpoints.

## Steg nio:  
Skapa Api.Domain och Api.Domain.Abstract.

## Steg tio:  
Skapa Api.Persistance.  

## Steg elva:
Sök jobb på PostNord.  

