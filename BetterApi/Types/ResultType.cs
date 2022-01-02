using Newtonsoft.Json;

namespace BetterApi.Types
{
    /// <summary>
    /// Result type class
    /// </summary>
    public class ResultType
    {
        private string model = "";
        /// <summary>
        /// Class used only as data storage
        /// </summary>
        internal class Data
        {
            internal List<string> parameter = new List<string>();
            internal List<Tuple<string, string>> headers = new List<Tuple<string, string>>();
            internal static string? result;
        }
        /// <summary>
        /// Usage: ResultType.DefineModel(...)
        /// JSON or XML(not case sensitive)
        /// <code>
        /// DefineModel(json)
        /// </code>
        /// </summary>
        public void DefineModel(string model)
        {
            this.model = model.ToLowerInvariant();
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
        /// <code>
        /// GetData("pets.dog")
        /// </code>
        /// <returns>return corrispondent value by given name</returns>
        /// <exception cref="Exception"></exception>
        public string GetData(string whatToTake)
        {
            if (CheckModel())
            {
                throw new Exception("Model not defined, remember to define the model with ResultType.DefineModel");
            }
            string result;
            if (model.Equals("json"))
            {
                result = JSONDeserialization.GetJsonContent(whatToTake);
            }
            else if (model.Equals("xml"))
            {
                result = XMLDeserialization.GetXmlContent(whatToTake);
            }
            else
            {
                throw new Exception("wrong model name");
            }

            return result;
        }
        /// <summary>
        /// return if the model is set
        /// </summary>
        /// <returns></returns>
        private bool CheckModel() => model.Length == 0;

    }
}
