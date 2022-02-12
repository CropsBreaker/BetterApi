using BetterApi.Types;
using RestSharp;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BetterApi
{
    public class GetRequest
    {
        private readonly ResultType.Data resultType = new ResultType.Data();

        /// <summary>
        /// add header to the request
        /// </summary>
        /// <param name="headerName">Header Name</param>
        /// <param name="headerVal">Header Value</param>
        public void AddHeader(string headerName, string headerVal)
        {
            resultType.headers.Add(new Tuple<string, string>(headerName, headerVal));
        }

        private string? url; //local url

        /// <summary>
        /// Sets the url
        /// </summary>
        /// <param name="url">url</param>
        public void Url(string url)
        {
            SetUrl(url);
        }

        private void SetUrl(string url)
        {
            this.url = url;
        }

        /// <summary>
        /// Add parameter to the query
        /// </summary>
        /// <param name="param"></param>
        public void AddParameter(string param1, string param2)
        {
            param1=param1.Trim();
            param2=param2.Trim();
            resultType.parameter.Add($"{param1}={param2}");
        }
        /// <summary>
        /// Add parameter as given
        /// </summary>
        /// <param name="param">Parameter</param>
        public void AddParameterNoRules(string param)
        {
            resultType.parameter.Add(param);
        }


        /// <summary>
        /// Execute and return the query
        /// </summary>
        /// <returns>Return the result of the query</returns>
        public async Task<ResultType> ExecuteAsync()
        {
            ResultType result = new ResultType();//this it to pass the instance of data.
            if (url != null)
            {
                foreach (string paramether in resultType.parameter)
                {
                    char lastChar = url[^1];
                    if (lastChar == '&' || lastChar == '?')
                    {
                        url += paramether;
                    }
                    else
                    {
                        url += '&' + paramether;
                    }
                }
                url = url.Replace(" ", "");

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url),
                };
                foreach (var head in resultType.headers)
                {
                    request.Headers.Add(head.Item1, head.Item2);
                }
                string resp = "";
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    resp = await response.Content.ReadAsStringAsync();
                    ResultType.Data.statusCode = response.StatusCode.ToString();
                }
                
                ResultType.Data.result = resp;
            }
            return result;
        }
    }
}