



# CoolestMovieAPI - First Draft

API bestämmer själva vad innehållet ska vara, vilken data måste lagras och jobba med en entitet klass, en DTO klass.

Entitet klassen (tabellerna/databasen/whatnot)

**Söker på Brad Pitt, då vill jag få ut (DTO -> klass (svaret))**
{	

​	“id”: “53485349” 	

​	"name": “Brad Pitt”

​	“birthdate”: “18 december 1963”

​	“country”: “Oklahoma USA”

​	“cast”: [“Länk till film Fight Club ”, “Länk till meet joe black”]

}

**Söker på Sagan om konungens återkomst, då vill jag få ut:**
{

​	“id”: “7834875398453”

​	“title”: “Sagan om Konungens återkomst”

​	“length”: “180”

​	“director”: “Peter Jackson”

​	“rating”: “7.2”

​	“language”: “English”

​	“country”: [“New Zealand”, “somewhereelse”, “somewhere”]

​	“description”: “I den här filmen fortsätter resan i universumet”

​	“releasedate”: “2003”

​	“genre”: [“Äventyr”, “Komedi”, “Drama”, “Spänning”]

​	“trailers”: [“Http://sometrailerurl.com”, “Http://somenewtrailer.com”]

​	“cast”:[ { “Frodo Baggins”: “http://ElijahWood.com” },{ “Arwen”: “http://LivTyler.com” } ]

}

**Söker på Director Peter Jackson, då vill jag få ut: **
{

​	“id”: “534375y3984”

​	"name": “Peter Jackson”

​	“birtdate”: “18 december 1963”

​	“country”: “Oklahoma USA”

​	“director”: [“Http://saganomringen.com”, “Http://kingkong.com”]

}

**Söker på Spanska (språket), då vill jag få ut (filmer med talspråk Spanska)**
{

​	“id”: “72384239423”

​	“language”: “Spanish”

​	“movies”: [“http://sp.com”, “http://sp.com”]

}

**Söker på rating högre än 8, vill få ut filmer med rating 8 och högre**
{

​	“movies”: [“http://saganomringen.com”, “http://kingkong.com”]

}

**Söker på årtal 1966, alla filmer från året 1966**
{

“movies”: [“http://moviefromthe66s.com”, “http://66scoolmoviie.com”]

}

**Söker på genren Thriller, då vill jag få ut:**
{

​	“id”: “82374928347230”

​	“genre”: “Thriller”

​	“movies”: [“Http://uwewewe.com”, “Http://somethrillerurl.com”]

}



## Movie

| ID              | PK   |
| --------------- | ---- |
| **Title**       |      |
| **Genre**       |      |
| **Year**        |      |
| **Length**      |      |
| **Rating**      |      |
| **Description** |      |



## Trailer

| ID          | PK     |
| ----------- | ------ |
| **MovieID** | **FK** |
| **Url**     |        |
| **Title**   |        |



## Cast

| ID          | PK     |
| ----------- | ------ |
| **MovieID** | **FK** |
| **ActorID** | **FK** |
| **Role**    |        |



## Director

| ID            | PK   |
| ------------- | ---- |
| **Name**      |      |
| **BirthDate** |      |
| **Country**   |      |



## Actor

| ID            | PK   |
| ------------- | ---- |
| **Name**      |      |
| **BirthDate** |      |
| **Country**   |      |
| **Oscars**    |      |



**Base URL:**

bla/api/v1.0/

**Movies:**

**Get all movies**

*/movies*


**Get movie by Id**

*/movies/<id>*


**Search by movie name**

*/movies/searchtitle?name=<title>*


**Search by actor name**

*/movies/searchactor?name=<actor>*


**Search by director name**

*/movies/searchdirector?name=<director>*


**Search by which year the movie was released**

*/movies/searchyear?year=<year>*

*/movies/searchyeargreaterthan?year=<year>*

*/movies/searchyearlessthan?year=<year>*

*/movies/searchyearspan?year=<year>&maxyear=<year>*


**Search by specific imdb rating**

*/movies/searchrating?rating=<rating>*

*/movies/searchratinggreaterthan?rating=<rating>*

*/movies/searchratinglessthan?rating=<rating>*

*/movies/searchratingspan?rating=<rating>&maxrating=<rating>*


**Search by a specific movie length**

*/movies/searchlength?length=<length>*

*/movies/searchlengthgreaterthan?length=<length>*

*/movies/searchlengthlessthan?length=<length>*

*/movies/searchlengthspan?length=<length>&maxlength=<length>*





/movies?genre=<genre>

/movies?genre=<genre>,<genre>,<genre>


/movies?trailer=true

**Actors:**

/actors

/actors/id

/actors?name=<(name)>

/actors?country=<(country)>

**Director:**

/directors

/directors/id

/directors?name=<(name)>

/directors?country=<(country)>

**Trailer:**

/trailers

/trailers/id

/trailers?title=<(title)>

/trailers?movieID=<(ID)>

/trailers?movieID=<(ID)>&actorID=<(actorID)>



**Lista för nya issues till nästa sprint:**

**Tester för controller och repository.**
**Alla gör enskilda issues för sina ansvarsområden. 
**Gör om google docs till markdown och lägg i dokumentationsmappen i master-branchen. 
**Modifiera våra GET-requests,** 
så som de är nu har vi “ / “ men vi bör kanske ha “ ? “Alltså api/v1.0/movies?title=title istället för api/v1.0/movies/title=title 
**Gör request för POST.**
**Gör request för PUT.**
**Felhantering, exception handling.**