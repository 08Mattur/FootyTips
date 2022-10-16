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
  
- Week of 16/10/2022
  - Been a while since updating due to illness, childcare etc.
  - Deviated from the planned week by week schedule
  - This week: save if not already in db, basic prediction created from 2 teams input.
  - So far the prediction brings back the >1.5 and BTTS stats for the match.
  - Below is a breakdown of the result set (last 5 games):  
    - MoreThan15Goals: The count of games that have had more than 1.5 goals where the team input has been a part of it
    - MoreThan15GoalsPercent: The percentage of the above
    - BTTS: The count of games both teams have scored where the team input has been a part of it
    - BTTSPercent: percentage of the above
    - ScoreMin1: count of games where the team input has scored at least 1
    - ScoreMin1Percent: percentage of the above
    - moreThan15Percent: total likelihood there will be more than 1.5 goals (MoreThan15GoalsPercent multiplied home * away)
    - bttsPercent: total likelihood both teams will score (BTTSPercent multipied home * away)
  - I ran the predictions for this week games with a caveat <0.45 percent would be a no and > 45% is a yes, the predictions got 5/10 >1.5 goals correct and 4/10 BTTS       correct. 
  - Although there were some odd results this week and tough games to predict. 
    - Liverpool 1 - 0 City
    - Leeds 0 - Arsenal 1
    - United 0 - 0 Newcastle
  
