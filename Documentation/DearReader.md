# Till våra kära klasskamrater:two_hearts:,

Vi gör ett api med de bästa filmerna ni kan tänka er. 

## Inledningsvis så delade vi upp arbetsuppgifterna så att 
*:sparkles: Fredrika arbetade med allt som rörde Movies (MovieController, MovieRepository, MovieDTO etc..)

*:confused: Pontus arbetade med allt som rörde Director (DirectorController, DirectorRepository, DirectorDTO etc..)

*:fire: Sebastian arbetade med allt som rörde Actor (ActorController, ActorRepository, ActorDTO etc..)

*:smiley_cat: Albin arbetade med allt som rörde Trailer (TrailerController, TrailerRepository, TrailerDTO etc..)

Vi arbetade ihop på vissa liknande metoder, exempelvis vissa get-metoder som liknade varandra. 
Sebastian har även gjort metoder i MovieRepository. 

Ni får såklart bestämma om detta arbetsätt är något som ni vill ta över, 
i så fall så ärver de två nya gruppmedlemmarna Fredrika & Sebastians klasser/models.

## Vi har försökt att joina (Models: Movie, Genre, MovieGenre) för att kunna få ut filmer med en specifik genre. 
Det har vi dock inte lyckats med, en möjlig lösning på detta är förmodligen att använda sig utav .Include()-metoden. 
Metodern vi pratar om är: GetByGenre() i MovieRepository.cs.

## Vi returnerar inte DTO-klasser i alla Get-metoder i controller-klasserna än.

## Vi har märkt att Modellerna matchar inte riktigt DTO-klasserna. 
Exempelvis i Movie-DTO så har vi en property som heter *"language"*, denna finns dock inte med i MovieModel så denna bör läggas till.
kika gärna över resten av DTOerna och modellerna. 
Behöver Modell-properties heta exakt lika dant som DTO-properties för att automapping ska fungera? Detta vet vi inte riktigt än.

## Trailer-klasserna är något övergivna, dessa skulle kunna tas bort då de inte är superviktiga egentligen. 

## 

