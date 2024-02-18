## Intro  
Kolla k�llkoderna och f�lj med steg f�r steg, kolla varje assembly's dependencies, vilka project dependencies och nuget dependencies de har allihop.  


## Steg ett:  
B�rja med att skapa din model assembly, l�gg till dina entiteter i denna.  

## Steg tv�:  
Skapa en Domain.Abstract assembly och l�gg till ett interface (IPersistanceService) f�r hur du vill kunna persistera i din dom�n.  

## Steg tre:  
Skapa din Persistance och l�gg till f�ljande:  
1. Ett interface (IDbContext) som abstraherar bort on�diga metoder fr�n DbContext.
2. Ett interface (IPeopleDbContext) som implementerar IDbContext och exponerar det som �r specifikt i PeopleDbContext.
3. En DbContext (PeopleDbContext) klass som �rver fr�n DbContext och implementerar din abstraktion IPeopleDbContext.
4. Klasser som implementerar IEntityTypeConfiguration f�r dina entiteter (anropas i OnModelCreating p� ditt context).
5. En klass som implementerar IDesignTimeDbContextFactory f�r PeopleDbContext. Med denna kan EF Core r�kna ut hur den ska kunna skapa ett context vid Add-Migration och Add-Database. Gl�m inte att l�gga till en UserSecret f�r denna assembly med din connectionstring.
6. K�r Add-Migration och Update-Database.
7. Skapa en extensionklass (PersistanceExtensions) f�r att g�ra det m�jligt att med ett kommando l�gga till allt fr�n din assembly.  
 

## Steg fyra:  
Skapa din Domain assembly och l�gg till f�ljande:  
1. Mediatorklasser som implementerar IRequestHandler f�r respektive �tg�rd som ska kunna g�ras, AddPerson, DeletePerson osv. Dessa klasser injektar interfacet till persisteringsservicen.  
2. I mediatorklasserna l�gger du till de kontrakt som mediatorn ska hantera f�r request och response.  
3. L�gg till en extensionklass (DomainExtensions) f�r att g�ra det m�jligt att med ett kommando l�gga till allt fr�n din assembly.  

## Steg fem:  
Skapa en console application i enlighet med projektet ImplementPersistance och testa s� att allt fungerar.  

## Steg sex (lite �verkurs):  
Skapa assemblyn Api och se till s� ni har r�tt v�rden i csproj-filen, l�gg speciellt m�rke till FrameworkReference, det �r denna som ser till att man kan k�ra AspNet fullt ut i en assembly (att allt finns tillg�ngligt).  
Kika p� min assembly Api f�r att se hur jag har gjort.
F�rs�k sedan fundera ut hur man i en WebApi host application kan f� den till att anv�nda dessa endpoints (vilka extensions beh�ver jag ha och hur anv�nder jag dem i en WebApi host) och hur f�r jag alla andra assemblies till att lira i denna WebApi host?  

## Steg sju:
N�r jag kommer tillbaka p� torsdag s� ska vi kolla gemensamt p� helheten och komma fram till vad vi gjort och varf�r :)  
Detta exempel fungerar ju inte riktigt som en CQRS l�sning s� som vi pratat om, det saknas en hel del, vad beh�ver vi g�ra f�r att f� ihop det hela?  
Detta vill jag att ni redog�r f�r p� torsdag...  
