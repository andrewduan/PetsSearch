### Cats Search ###

This repo includes A .Net Core (version 3.1) WebApi(Petsearch) and A React Webapp

To run it, 

1. WebApi: Run the webapi, go to folder `/PetSearchApi`, run `dotnet build` followed by `dotnet run`, the follwoing url will be ready to consume.  
   http://localhost:5000/pets or https://localhost:5001/pets

   Additionally you can call http://localhost:5000/pets/dog, http://localhost:5000/pets/fish, or http://localhost:5000/pets/all
   to get `dogs`, `fish` and `all pets`.

   Whole project is under `unit test` and `E2E test`.

2. WebApp: this app is using React, Redux and Typescript. To run it, go to folder `/PetSearchApp`, run `npm install` followed by `npm start`, the webserver
   http://localhost:3000 will be running. Enter http://localhost:3000 to Browser, the cats will show in script, grouped by owner's gender.





