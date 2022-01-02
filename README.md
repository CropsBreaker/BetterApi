# Better Api
![Logo](https://github.com/V4L304/BetterApi/blob/master/logo.png)

Handy library for using API. It also have some cool feature

## Installation

coming soon...

```bash
coming soon...
```

## Usage

```csharp
using BetterApi;

GetRequest getRequest = new GetRequest();//main class
getRequest.Url("inventedurl.com/json?");//IMPORTANT: REMEMBER TO USE ? AT THE END OF THE URL
getRequest.AddHeader("x-key", "API_KEY");//to AddHeader to add the header
getRequest.AddParameter("city = london");//to AddParameterto add the parameter

ResultType result = getRequest.Execute();//execute the query
Console.WriteLine(ResultType.RawContent());//print the raw result
result.DefineModel("json");//defines the model with which to search for data. JSON or XML
Console.WriteLine("Result"+result.GetData("weather.day1.temp"));//print the value.
/*
* To access the nodes you need to use the ., for example: node1.node2
*/
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
## License
[MIT](https://choosealicense.com/licenses/mit/)
