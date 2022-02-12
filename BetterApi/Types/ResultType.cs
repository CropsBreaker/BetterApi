using System;
using System.Collections.Generic;

namespace BetterApi.Types
{
    /// <summary>
    /// Result type class
    /// </summary>
    public class ResultType
    {

        /// <summary>
        /// Class used only as data storage
        /// </summary>
        internal class Data
        {
            internal IList<string> parameter = new List<string>();
            internal IList<Tuple<string, string>> headers = new List<Tuple<string, string>>();
            internal static string? result;
            internal static string? statusCode;
        }

        /// <summary>
        /// Return API result
        /// </summary>
        /// <returns>return API Result as string</returns>
        public string RawContent()
        {
            return Data.result ?? "something went wrong";
        }

        /// <summary>
        /// Get data by given name
        /// </summary>
        /// <param name="whatToTake">Name to search. For nitified: name1.name2.name3 etc...</param>
        /// <param name="model">Define model: JSON or XML(not case sensitive)</param>
        /// <code>
        /// GetData("pets.dog")
        /// </code>
        /// <returns>return corrispondent value by given name</returns>
        /// <exception cref="Exception"></exception>
        public string GetData(string whatToTake, string model)
        {
            string result;
            if (model.ToLower().Equals("json"))
            {
                result = JSONDeserialization.GetJsonContent(whatToTake);
            }
            else if (model.ToLower().Equals("xml"))
            {
                result = XMLDeserialization.GetXmlContent(whatToTake);
            }
            else
            {
                throw new Exception("Wrong model name");
            }

            return result;
        }

        public string GetStatusCode()
        {
            return Data.statusCode ?? "";
        }
    }
}