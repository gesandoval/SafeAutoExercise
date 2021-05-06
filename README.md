# SafeAutoExercise
This is an Exercise generated by GESM

For API.
- I based my approach in the clean architecture, but for timing reason I only separate the layers logically (not different projects).
I took as base the webapi template, I build it from scratch all elements from thar point on 
    - Controller only send/receive petitions
    - There is a Application Layer where the business occur. No Dependency on ASP or HTTP modules at this layer. 
    - There is a Model (Domain) with the Entities. No dependencies.
    - I use Dto’s to present  data 
    - Created a Repository layer so implementation of DB is decoupled and can be easily change.
    - For Data I use Entity Framework implemented as InMemory DB (so no SQL is need for this exercise). This implementation can be switch for any other DB.
    - For Loading data I created a Controller which only receives a File. Then at Application layer I process that file.
         - The file is processed in MEMORY STREAM so no physical file is needed.
         The process is simple It reads line by line the file and registers Drivers and sets Trips for drivers. 
         
          -  Assumptions for file:
              1. All drivers appear at the top of the file
              2. All lines for trips are placed after all drivers
              3. If a line does not have a valid Command the line is not processed
              4. If a line for a TRIP has a non-registered Driver is not processed
              5. No validations of data were implemented at this time for the exercise.
          - Assumptions for the persistence of data
              1. Drivers are registered and if one exists from other load their new trips are loaded into their account.
              2. All trips are always considered new (they are added to the list of trips for the driver) 
             
            CORS policy allowsorigin.
          
          - No security was implemented at this exercise, but easily could be added (for example JWT)
          
 For ClientApp
     - It is an Angular SPA.
      - At environment.ts the constant baseAPIUrl es set (should be set with the URI for the API)
      - Only one component and one service were developed

Thanks