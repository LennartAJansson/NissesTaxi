## Intro  
Kolla k�llkoderna och f�lj med steg f�r steg, kolla varje assembly's dependencies, vilka project dependencies och nuget dependencies de har allihop.  


## Steg ett:  
B�rja med att skapa din model assembly, l�gg till dina entiteter i denna.  

## Steg tv�:  
Skapa en Projector.Domain.Abstract assembly och l�gg till ett interface (IPersistanceService) f�r hur du vill kunna persistera i din dom�n.  

## Steg tre:  
Skapa din Persistance och l�gg till f�ljande:  
1. Ett interface (IDbContext) som abstraherar bort on�diga metoder fr�n DbContext.
2. Ett interface (IPeopleDbContext) som implementerar IDbContext och exponerar det som �r specifikt i PeopleDbContext.
3. En DbContext (PeopleDbContext) klass som �rver fr�n DbContext och implementerar din abstraktion IPeopleDbContext.
4. Klasser som implementerar IEntityTypeConfiguration f�r dina entiteter (anropas i OnModelCreating p� ditt context).
5. En klass som implementerar IDesignTimeDbContextFactory f�r PeopleDbContext. Med denna kan EF Core r�kna ut hur den ska kunna skapa ett context vid Add-Migration och Add-Database. Gl�m inte att l�gga till en UserSecret f�r denna assembly med din connectionstring.
6. K�r Add-Migration och Update-Database.
7. Skapa en extensionklass (PersistanceExtensions) f�r att g�ra det m�jligt att med ett kommando l�gga till allt fr�n din assembly.  
8. Kolla p� extensionmetoden UpdateDatabase och interface + implementation av Migrate 

## Steg fyra:  
Skapa din Projector.Domain assembly och l�gg till f�ljande:  
1. Mediatorklasser som implementerar IRequestHandler f�r respektive kommando som ska kunna g�ras, AddPersonCommand, DeletePersonCommand osv. Dessa klasser injektar interfacet till persisteringsservicen.  
2. I mediatorklasserna l�gger du till de kontrakt som mediatorn ska hantera f�r request och ingen response.  
3. L�gg till en extensionklass (ProjectorDomainExtensions) f�r att g�ra det m�jligt att med ett kommando l�gga till allt fr�n din assembly.  

## Steg fem:  
Skapa en Common.Contracts. Den ska inneh�lla kontrakten f�r CQRS-kommandon, t�nk p� att de ska implementera ICommand och att de ska hanteras av en ICommandQueue (detta �r interfacet f�r v�r hantering av Channel)  

## Steg sex:  
Skapa en assembly Common.Messaging. Den ska inneh�lla en klass som implementerar ICommandQueue. L�gg �ven till en extension f�r att addera detta till IServiceCollection.  

## Steg sju:  
Skapa Projector.Endpoints.  

## Steg �tta:  
Skapa Api.Endpoints.

## Steg nio:  
Skapa Api.Domain och Api.Domain.Abstract.

## Steg tio:  
Skapa Api.Persistance.  

## Steg elva:
S�k jobb p� PostNord.  

