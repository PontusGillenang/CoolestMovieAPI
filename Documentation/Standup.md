# Standups
## Standup - 2020-05-05
* Secretary - Pontus
* Each person
     * Albin - What will I do next? Trailer controller class och DTO class.
     * Fredrika - What will I do next? Movie controller class och DTO class.
     * Pontus - What will I do next? Director controller class och DTO class.
     * Sebastian - What will I do next? Skapa alla Model classer. Skapa DbContext.

### Secretary notes...

## Standup - 2020-05-06

* Secretary - Pontus
* Each person
     * Albin - What have I done since last standup? Trailer controller class, DTO class och repository. What will I do next? Hjälpa till där det behövs eller jobba tillsammans med någon.
     * Fredrika - What have I done since last standup? Movie controller class, model class för movie, DTO class och repository. What will I do next? Testa mot databasen om man får ut det man ska. 
     * Pontus - What have I done since last standup? Director controller class och DTO class. What will I do next? Skapa ett Backlog Issue för DirectorRepository och namngivnings ändringar.
     * Sebastian - What have I done since last standup? Skapa alla Model classer. Skapa DbContext. What will I do next? Actor controller class och DTO class.

### Secretary notes...

## Standup - 2020-05-07

* Secretary - Pontus
* Each person
  * Albin - What have I done since last standup? Läst på mer om objektorienterad programmering. What will I do next? Merga master med Trailerbranchen.
  * Fredrika - What have I done since last standup? Testa mot databasen. What will I do next? Testa att få databasen att fungera.
  * Pontus - What have I done since last standup? Skapa ett Backlog Issue för DirectorRepository och namngivnings ändringar. What will I do next? Testa att få databasen att fungera.
  * Sebastian - What have I done since last standup? Påbörjat Actor cotroller class och DTO class What will I do next? Slutföring av Actor controller class och DTO class.

### Secretary notes...

## Standup - 2020-05-08

* Secretary - Sebastian

* Each person

  * Albin - What have I done since last standup? fått min getmethod i repot att fungera

    What will I do next? göra en pull rquest och merga till master

  * Fredrika - What have I done since last standup? Jobbat med linq och testat att joina tables. What will I do next? göra en pull rquest och merga till master

  * Pontus - What have I done since last standup? gjort director repo och jobbat med methoderna där i och får rätt resultat. What will I do next? göra fler issus på jira och göra en pull rquest och merga till master

  * Sebastian - What have I done since last standup? Slutfört  Actor controller class och DTO class. What will I do next? göra en pull rquest och merga till master

### Secretary notes...

## Standup - 2020-05-12
* Secretary - Fredrika

* Fredrika - Tester, på repository och controller klassen. Exception handling på båda klasserna. 
* Sebastian - Göra base repository och interface. Gör GetRequest för genre, att kunna hitta film utifrån genre. Och en metod för hur man kan använda flera genrer i ett get request. Om jag hinner klart -> modifiera repository eller skriver tester.    
* Pontus - Jag kommer att jobba med att skapa unittester på DirectorRepository och skriva till markdown fil google documentationen samt fortsätta skriva issues.
* Albin - Göra exception handling för trailer-klasserna. 

### Secretary notes...

## Standup - 2020-05-13
* Secretary - Fredrika 

* Albin - Exceptionhandling. Fortsätta med exceptionhandling.
* Fredrika - Gjort exception handling på Movieklasserna, fortsätta med tester och join-linq-queries.
* Sebastian - Base repositoryklasser, modifyade så den matchade/actorklasserna använde den. Försökte mig på join-linq-queries (link method query). Fortsätta med att få join att fungera, om det funkar sätta igång med testerna på actorklasserna.
* Pontus - XUnitTest på DirectorRepository och det fick jag inte att funka. Tyvärr. Jag ska fortsätta hålla på med testerna och få det att fungera. 

### Secretary notes...

## Standup - 2020-05-15

* Secretary - Pontus
* Each person
  * Fredrika - What have I done since last standup? Arbetade i MovieRepository med att joina olika tabeller. Gjort efterforskning på lösningar till detta. What will I do next? Slutföra det jag gör så långt som möjligt innan jag skickar en Pull Request. 
  * Pontus - What have I done since last standup? Arbetade med att göra tester till DirectorRepository och DirectorsController. What will I do next? Slutföra det jag gör så långt som möjligt innan jag skickar en Pull Request.
  * Sebastian - What have I done since last standup? Gjort test för metoden GetAllActors, refactorerat ActorsController så det finns exceptionhadling. Försökt att göra joina Movie på Genre taballen  What will I do next? Slutföra det jag gör så långt som möjligt innan jag skickar en Pull Request.

### Secretary notes...



## Standup - 2020-05-18

* Secretary - Pontus
* Each person
  * **Fredrik** - What will I do next? 
    * MOV-42 - MoviesByLengthSpan
    * MOV-34 - MoviesByYear
    * MOV-41 - MoviesByLength
    * MOV-37 - MoviesByRatingHigherThan
    * MOV-36 - MoviesByRatingLowerThan
    
    
  * **Anton** - What will I do next?
    * Update Get Methods in ActorsController
    * Add and modify issues in backlog
    * Place issues in Sprint 2020/05/18-2020/05/22
    
    
  * **Albin** - What will I do next?
    * MOV-145 - modda TrailerController så den använder '?'
    * Add and modify issues in backlog
    * Place issues in Sprint 2020/05/18-2020/05/22
    
    
  * **Pontus** - What will I do next?
    * Add and modify issues in backlog
    * Place issues in Sprint 2020/05/18-2020/05/22

### Secretary notes...



## Standup - 2020-05-19

* Secretary - Pontus

* Each person

  **Fredrik** 

  What have I done since last standup? 

  * MOV-42 - MoviesByLengthSpan
  * MOV-34 - MoviesByYear
  * MOV-41 - MoviesByLength
  * MOV-37 - MoviesByRatingHigherThan
  * MOV-36 - MoviesByRatingLowerThan

  What will I do next?

  * Create a new branch and dig into AutoMapper.
  * If pull request needs corrections make them and do a re-request.
  * When approved merge into master the branch MOV-144 MovieControllerUpdate.

  

  **Anton** 

  What have I done since last standup? 

  * Update Get Methods in ActorsController
  * Add and modify issues in backlog
  * Place issues in Sprint 2020/05/18-2020/05/22

  What will I do next?

  * Add and modify issues in backlog
  * Place issues in Sprint 2020/05/18-2020/05/22
  * Update Get Methods in ActorsController
  * Do code review on branch MOV-144 MovieControllerUpdate

  

  **Albin** 

  What have I done since last standup? 

  * MOV-145 - modda TrailerController så den använder '?'
  * Add and modify issues in backlog
  * Place issues in Sprint 2020/05/18-2020/05/22

  What will I do next?

  * MOV-145 - modda TrailerController så den använder '?'
  * Add and modify issues in backlog
  * Place issues in Sprint 2020/05/18-2020/05/22
  * Do code review on branch MOV-144 MovieControllerUpdate

  

  **Pontus** 

  What have I done since last standup? 

  * Add and modify issues in backlog
  * Place issues in Sprint 2020/05/18-2020/05/22

  What will I do next?

  * MOV-146 - [Refactor] DirectorsController Get Requests
  * MOV-150 - [Refactor] DirectorsController GetByName
  * MOV-156 - [Refactor] DirectorsController GetByCountry
  * MOV-166 - [Refactor] DirectorDTO
  * MOV-157 - [Refactor] DirectorRepository Get Methods
  * MOV-158 - [Refactor] DirectorRepository GetAllDirectors
  * MOV-163 - [Refactor] DirectorRepository GetDirectorById
  * MOV-164 - [Refactor] DirectorRepository GetDirectorsByName
  * MOV-165 - [Refactor] DirectorRepository GetDirectorsByCountry
  * Do code review on branch MOV-144 MovieControllerUpdate

### Secretary notes...