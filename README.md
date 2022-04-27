# Better Api
![Logo](https://github.com/CropsBreaker/BetterApi/blob/1cb20b4a5e6125cac7d79229a9dac3844ab8ada4/BetterApi/logo.png)

Handy library for using API. It also have some cool feature

## Installation

You can download the package from [Nuget](https://www.nuget.org/packages/BetterApi/)

```bash
PM > Install-Package BetterApi -Version 1.0.0.8
```

## Usage

```csharp
using BetterApi;
using BetterApi.Types;

GetRequest getRequest = new();
getRequest.Url("inventedurl.com/json?");//IMPORTANT: REMEMBER TO USE ? AT THE END OF THE URL
getRequest.AddHeader("x-key", "API_KEY");
getRequest.AddParameterNoRules("city=london");
getRequest.AddParameter("day", "today");

ResultType result = getRequest.ExecuteAsync().Result;//execute the query and get the instance

Console.WriteLine(result.RawContent()); //print the raw result
Console.WriteLine($"Result{result.GetData("weather.day1.temp", "JsoN")}");//to access at nodes, use the .
Console.WriteLine($"Statuc code: {result.GetStatusCode()}");//returns the status code of the request

/*
 * FRIENDLY REMINDER
 * XML and JSON doesn't have the same file structure
*/
```
More details in the [wiki](https://github.com/V4L304/BetterApi/wiki#documentation)
## What I used
I used [Json.NET](https://www.newtonsoft.com/json) to deserialize the json

## About the logo
In italian, "api" also means "bees"
better -> butter 

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
## License
[MIT](https://choosealicense.com/licenses/mit/)
