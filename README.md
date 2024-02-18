# progi-test-car-prices

**Run the backend**
To run the backend you need .net 7

 1. Open a console inside of `car-prices-backend/car-prices-backend` folder
 2. Execute `dotnet restore` command
 3. Execute `dotnet build`
 4. execute `dotnet run`
 Note: The default app url is `https://localhost:7065`. This value need to be configured in the frontend.

**Run the Front VUE js**
To run the front you need node 18 and vue

 1. Open a console inside of `front-vue` folder
 2. Execute `npm install`
 3. Execute `npm run serve`
**Note: Remember change the `api service` in the file `src\components\CarForm.vue` in the line 104 to the backend api.**