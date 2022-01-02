using BetterApi;
using BetterApi.Types;

GetRequest getRequest = new GetRequest();
getRequest.Url("inventedurl.com/json?");//IMPORTANT: REMEMBER TO USE ? AT THE END OF THE URL
getRequest.AddHeader("x-key", "API_KEY");
getRequest.AddParameter("city = london");

ResultType result = getRequest.Execute();//execute the query
result.DefineModel("json");//JSON or XML
Console.WriteLine(result.RawContent());//print the raw result
Console.WriteLine("Result"+result.GetData("weather.day1.temp"));//to access at nodes, use the .
/*c
 * FRIENDLY REMINDER
 * XML and JSON doesn't have the same file structure
 * EXAMPLES
 * 
 * JSON example
 * {
        "glossary": {
            "title": "example glossary",
		    "GlossDiv": {
                "title": "S",
			    "GlossList": {
                    "GlossEntry": {
                        "ID": "SGML",
					    "SortAs": "SGML",
					    "GlossTerm": "Standard Generalized Markup Language",
					    "Acronym": "SGML",
					    "Abbrev": "ISO 8879:1986",
					    "GlossDef": {
                            "para": "A meta-markup language, used to create markup languages such as DocBook.",
						    "GlossSeeAlso": ["GML", "XML"]
                        },
					    "GlossSee": "markup"
                    }
                }
            }
        }
    }
    (from https://json.org/example.html)
    XMl example
    <?xml version="1.0"?>
    <catalog>
       <book id="bk101">
          <author>Gambardella, Matthew</author>
          <title>XML Developer's Guide</title>
          <genre>Computer</genre>
          <price>44.95</price>
          <publish_date>2000-10-01</publish_date>
          <description>An in-depth look at creating applications 
          with XML.</description>
       </book>
       <book id="bk112">
          <author>Galos, Mike</author>
          <title>Visual Studio 7: A Comprehensive Guide</title>
          <genre>Computer</genre>
          <price>49.95</price>
          <publish_date>2001-04-16</publish_date>
          <description>Microsoft Visual Studio 7 is explored in depth,
          looking at how Visual Basic, Visual C++, C#, and ASP+ are 
          integrated into a comprehensive development 
          environment.</description>
       </book>
    </catalog>
    from(https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ms762271(v=vs.85)
*/