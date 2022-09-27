# FootyTips
When downloading, open the repository and open package manager console. You will have to run an "Update-database" command to create the database.


## Schedule

- Week 1- Create Models + Database (Done)
- Week 2- Create Service to download the excel file from https://www.football-data.co.uk/ (Done)
- Week 3- Save the data into db if not previously saved.
- Week 4- Investigate websites to pull fixtures from.
- Week 5- Create service to download and save fixtures.
- Week 6- Get the next game weeks fixtures/ get a weeks fixtures from id
- Week 7- Build a score prediction model.
- Week 8- Apply model to each team in game week.
- Week 9- Create a static front end
- Week 10- Create dynamic front end connecting to the api endpoints
- Week 11- Create hosting in Azure + hosting db
- Week 12- Create pipeline for automatic uploads
- Week 13- Test + Refine Prediction
- Week 14- Create new prediction for single game including Corners, Cards, Shots etc
- Week 15- Update front end to include single game prediction.

This should bring us to the end of the year.

## Blog
- Week 1  
  - I started the new project in VS2022
  - Created the folder structure and models
  - Created the database context and ran pmc commands to create the initial migration and to create the database.
  - followed this :https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio
  - Finally created this repo.
  
 - Week 2
  - Created services that reads the csv from a url input using the following sites for assistance/inspiration: https://stackoverflow.com/questions/54460971/c-sharp-read-csv-from-url-and-save-to-database & https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-6.0
  - Created a service that accepts a list of strings and transforms these CSV strings into a raw data object (not data models used in the db)
  - Created API controller to test it works
  
