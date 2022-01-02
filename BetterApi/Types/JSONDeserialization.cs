using Newtonsoft.Json;
using static BetterApi.ResultType;

namespace BetterApi
{
    internal class JSONDeserialization
    {
        internal static string GetJsonContent(string whatToTake)
        {
            string json = Data.result ?? "";                          //placeholder if something, for some strange reason, is wrong
            string result = Deserialize(whatToTake, json) ?? "";      //placeholder if something, for some strange reason, is wrong
            return result;
        }

        private static string Deserialize(string whatToTake, string json)
        {
            string res = "placeholder";
            string[] stagesTake = whatToTake.Split('.');//split nodes
            Dictionary<string, object> dict = DeserializeJson<Dictionary<string, object>>(json);
            for (int i = 0; i < stagesTake.Length; i++)
            {
                foreach (KeyValuePair<string, object> key in dict)
                {
                    if (key.Key.Equals(stagesTake[i]))//check if the key is equal to the node
                    {
                        if (key.Value != null)//check if is not null(for example empty data)
                        {
                            if (key.Value.ToString().Contains(':'))
                            {
                                /*
                                 * 
                                 * So it contains more results
                                 * 
                                 */
                                string value = Convert.ToString(key.Value);
                                value = RightFormatJson(value);
                                dict = DeserializeJson<Dictionary<string, object>>(value);
                                break;
                            }
                        }
                        if (i == stagesTake.Length - 1)
                        {
                            //so is the final node
                            res = key.Value.ToString();
                        }
                    }
                }
            }
            return res;
        }
        private static string RightFormatJson(string json)
        {
            //check if is an array
            if (json[0] == '[')
            {
                json = json[1..^1];
            }
            return json;
        }
        private static T DeserializeJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(value: json);
        }
    }
}
