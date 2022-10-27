using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramewrok.Application.Stared.HttpManager
{
    public class ApiClientBase : IDisposable
    {

        static FlurlClient _client;

        public static int? TimeoutSeconds { get; set; } = 30;//过期时间

        public ApiClientBase()
        {

        }


        public FlurlClient GetClient(string accessToken)
        {
            if (_client == null)
                CreateClient();

            AddHeaders(accessToken);
            return _client;
        }

        private static void CreateClient()
        {
            _client = new FlurlClient(ApiConfig.ApiUrl);

            if (TimeoutSeconds.HasValue)
            {
                _client.WithTimeout(TimeoutSeconds.Value);
            }
        }
        private void AddHeaders(string accessToken)
        {
            _client.Headers.Clear();
            _client.HttpClient.DefaultRequestHeaders.Clear();

            _client.WithHeader("Accept", "application/json");
          //  _client.WithHeader("Accept", "text/plain");
            if (accessToken != null)
            {
                _client.WithHeader("accessToken", accessToken);
            }
        }

        public static async Task<ApiResult<T>> ValidateAbpResponse<T>(Task<IFlurlResponse> httpResponse,
         bool stripAjaxResponseWrapper)
        {
            if (!stripAjaxResponseWrapper)
            {
                return await httpResponse.ReceiveJson<ApiResult<T>>();
            }

            ApiResult<T> response = new ApiResult<T>() { success = true };
            try
            {
                response = await httpResponse.ReceiveJson<ApiResult<T>>();
            }
            catch (FlurlHttpException e)
            {
                response = new ApiResult<T>() { success = false, message = e.Message, Code = 500 };
                //response = await e.GetResponseJsonAsync<ApiResult<T>>();
            }
            if (response == null)
                return default;

            return response;
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
