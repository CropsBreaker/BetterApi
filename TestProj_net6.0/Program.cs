using BetterApi;
using BetterApi.Types;

GetRequest getRequest = new();
getRequest.Url("inventedurl.com/json?");//IMPORTANT: REMEMBER TO USE ? AT THE END OF THE URL
getRequest.AddHeader("x-key", "API_KEY");
getRequest.AddParameterNoRules("city=london");
getRequest.AddParameter("day", "today");

ResultType result = getRequest.ExecuteAsync().Result;//execute the query and get the instance

Console.WriteLine(result.RawContent());//print the raw result
Console.WriteLine($"Result{result.GetData("weather.day1.temp", "JsoN")}");//to access at nodes, use the .
Console.WriteLine($"Statuc code: {result.GetStatusCode()}");

/*
 * FRIENDLY REMINDER
 * XML and JSON doesn't have the same file structure
*/