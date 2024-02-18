# progi-test-car-prices

**Run the backend**
To run the backend you need .net 7

 1. Open a console inside of `car-prices-backend/car-prices-backend` folder
 2. Execute `dotnet restore` command
 3. Execute `dotnet build`
 4. execute `dotnet run`
 Note: The default app URL is `https://localhost:7065`. This value needs to be configured in the front end.

**To execute unit tests:**
 1. Open a console inside of `car-prices-backend\car-prices-backend-tests` folder
 2. Execute `dotnet build`
 3. Execute `dotnet test`. You will see a similar output: `Passed!  - Failed:     0, Passed:    28, Skipped:     0, Total:    28, Duration: 25 ms - car-prices-backend-tests.dll (net6.0)`

**Run the Front VUE js**
To run the front you need node 18 and Vue

 1. Open a console inside of `front-vue` folder
 2. Execute `npm install`
 3. Execute `npm run serve`

**Note: Remember to change the `API service` in the file `src\components\CarForm.vue` in line 104 to the backend API.**


**Run the Front Angular**
To run the front you need node 18 and angular 17

 1. Open a console inside of `front-angular` folder
 2. Execute `npm install`
 3. Execute `ng serve`

**Note: Remember to change the `API service` in the file `src\app\services\vehicle-service.service.ts` in line 12 to the backend API.**
