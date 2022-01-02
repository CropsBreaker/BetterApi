using BetterApi.Types;
using RestSharp;

namespace BetterApi
{
    public class GetRequest
    {
        private readonly ResultType.Data resultType = new();
        /// <summary>
        /// add header to the GET request
        /// </summary>
        /// <param name="headerName">Header Name</param>
        /// <param name="headerVal">Header Value</param>
        public void AddHeader(string headerName, string headerVal)
        {
            resultType.headers.Add(new Tuple<string, string>(headerName, headerVal));
        }

        private string url; //local url

        /// <summary>
        /// Sets the url
        /// </summary>
        /// <param name="url">url</param>
        public void Url(string url)
        {
            setUrl(url);
        }
        private void setUrl(string url)
        {
            this.url = url;
        }
        /// <summary>
        /// Add parameter to the query
        /// </summary>
        /// <param name="param"></param>
        public void AddParameter(string param)
        {
            resultType.parameter.Add(param);
        }
        /// <summary>
        /// Execute and return the query
        /// </summary>
        /// <returns>Return the result of the query</returns>
        public ResultType Execute()
        {
            ResultType result = new ResultType();

            foreach (string paramether in resultType.parameter)
            {
                char lastChar = url[^1];
                if (lastChar == '&' || lastChar=='?')
                {
                    url += paramether;
                }
                else
                {
                    url += '&' + paramether;
                }
            }
            url = url.Replace(" ", "");
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            foreach(var head in resultType.headers)
            {
                request.AddHeader(head.Item1, head.Item2);
            }
            IRestResponse response = client.Execute(request);
            ResultType.Data.result = response.Content;
            return result;
        }
    }
}