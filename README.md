### Cats Search ###

This repo includes A .Net Core (version 3.1) WebApi(Petsearch) and A React Webapp

To run it, 

1. WebApi: Run the webapi, go to folder `/PetSearchApi`, run `dotnet build` followed by `dotnet run`, the follwoing url will be ready to consume.
[http](http://localhost:5000/pets) or [https](https://localhost:5001/pets)

   Additionally you can call [Dog](http://localhost:5000/pets/dog), [Fish](http://localhost:5000/pets/fish), or [All](http://localhost:5000/pets/all)
   to get dogs, fish and all pets.

2. WebApp: this app is using React, Redux and Typescript. To run it, go to folder `/PetSearchApp`, run `npm install` followed by `npm start`, the webserver
   http://localhost:3000 will be running. Copy `http://localhost:3000` to Browser, the cats will show in script, grouped by owner's gender.





