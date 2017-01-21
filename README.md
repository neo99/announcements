# how to run
run `dotnet restore` then `dotnet run` in `src` folder

open `doc/examples/basic/index.html`

# system architecture
The system utilizes ASP Core. 

HomeController.cs provides end points for JavaScript `/api/{id}.js` and JSON `/api/{id}.json` endpoints.

# make server listen to IP instead of localhost
```
export ASPNETCORE_URLS="http://192.168.1.144:5000"
```

