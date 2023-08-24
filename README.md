# demons-souls-rings

Project about rings in Demon's Souls that include API, Web Application and Performance Tests for them. Written in <a href="https://learn.microsoft.com/pl-pl/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0">ASP.NET Core</a>

### API

Web API that provides data about rings (name, effect, how to get it, image URL) and returns it in json. 
Data are store in sql server database and they from <a href="https://demonssouls.wiki.fextralife.com/Rings">demonssouls.wiki.fextralife.com</a>.
Also it has a function that allows to add new record to database but to use this function you will need a api key.

### Web App

Web Application is a single page application that have only 1 page where data are display in a table.

### Performance Tests

Tests are written in <a href="https://nbomber.com/">NBomber</a> framework and it test performance of every query.
