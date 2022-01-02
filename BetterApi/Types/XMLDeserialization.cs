using Newtonsoft.Json;
using System.Xml;
using static BetterApi.ResultType;
using static BetterApi.JSONDeserialization;
namespace BetterApi
{
    internal class XMLDeserialization
    {
        /*
         * yea, ok, I know.
         * But, this is the speedest way to search in a xml
         */
        /// <summary>
        /// get value by given name
        /// </summary>
        /// <param name="name">the given name</param>
        /// <returns>value</returns>
        internal static string GetXmlContent(string name)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Data.result);
            string json= JsonConvert.SerializeXmlNode(doc);
            Data.result = json;
            string res = GetJsonContent(name);
            return res;
        }
    }
}
