using Flurl.Http;
using Flurl.Http.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramewrok.Application.Stared.HttpManager
{
    public class ApiClinetRepository : ApiClientBase
    {
        public readonly AccessTokenManager _accessTokenManager;

        public ApiClinetRepository(AccessTokenManager accessTokenManager )
        {
            _accessTokenManager = accessTokenManager;
        }

        public void SetToken(LoginTokenDto loginToken)
        {
            _accessTokenManager.AuthenticateResult.AccessToken = loginToken.accessToken;
            _accessTokenManager.userInfo=loginToken.userInfo;
        }

        #region PostAsync<T>

        public async Task<ApiResult<T>> PostAsync<T>(string endpoint)
        {
            return await PostAsync<T>(endpoint, null, null, _accessTokenManager.GetAccessToken(), true);
        }

        public async Task<ApiResult<T>> PostAnonymousAsync<T>(string endpoint)
        {
            return await PostAsync<T>(endpoint, null, null, null, true);
        }

        public async Task<ApiResult<T>> PostAsync<T>(string endpoint, object inputDto)
        {
            return await PostAsync<T>(endpoint, inputDto, null, _accessTokenManager.GetAccessToken(), true);
        }

        public async Task<ApiResult<T>> PostAsync<T>(string endpoint, object inputDto, object queryParameters)
        {
            return await PostAsync<T>(endpoint, inputDto, queryParameters, _accessTokenManager.GetAccessToken(), true);
        }

        /// <summary>
        /// Makes POST request without authentication token.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        public async Task<ApiResult<T>> PostAnonymousAsync<T>(string endpoint, object inputDto)
        {
            return await PostAsync<T>(endpoint, inputDto, null, null, true);
        }

        public async Task<ApiResult<T>> PostAsync<T>(string endpoint, object inputDto, object queryParameters, string accessToken, bool stripAjaxResponseWrapper)
        {
            var httpResponse = GetClient(accessToken)
                .Request(endpoint)
                .SetQueryParams(queryParameters)
                .PostJsonAsync(inputDto);

            return await ValidateAbpResponse<T>(httpResponse, stripAjaxResponseWrapper);
        }

        public async Task<ApiResult<T>> PostMultipartAsync<T>(string endpoint, Action<CapturedMultipartContent> buildContent, bool stripAjaxResponseWrapper = true)
        {
            var httpResponse = GetClient(_accessTokenManager.GetAccessToken())
                .Request(endpoint)
                .PostMultipartAsync(buildContent);

            return await ValidateAbpResponse<T>(httpResponse, stripAjaxResponseWrapper);
        }

        public async Task<ApiResult<T>> PostMultipartAsync<T>(string endpoint, Stream stream, string fileName, bool stripAjaxResponseWrapper = true)
        {
            var httpResponse = GetClient(_accessTokenManager.GetAccessToken())
                    .Request(endpoint)
                    .PostMultipartAsync(multiPartContent => multiPartContent.AddFile("file", stream, fileName));
            return await ValidateAbpResponse<T>(httpResponse, stripAjaxResponseWrapper);
        }

        public async Task<ApiResult<T>> PostMultipartAsync<T>(string endpoint, string filePath, bool stripAjaxResponseWrapper = true)
        {
            var httpResponse = GetClient(_accessTokenManager.GetAccessToken())
                .Request(endpoint)
                .PostMultipartAsync(multiPartContent => multiPartContent.AddFile("file", filePath));
            return await ValidateAbpResponse<T>(httpResponse, stripAjaxResponseWrapper);
        }

        #endregion PostAsync<T>

        #region PostAsync

        public async Task PostAsync(string endpoint)
        {
            await PostAsync(endpoint, null, null, _accessTokenManager.GetAccessToken(), true);
        }

        public async Task PostAsync(string endpoint, object inputDto)
        {
            await PostAsync(endpoint, inputDto, null, _accessTokenManager.GetAccessToken(), true);
        }

        /// <summary>
        /// Makes POST request without authentication token.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        public async Task PostAnonymousAsync(string endpoint, object inputDto)
        {
            await PostAsync(endpoint, inputDto, null, null, true);
        }

        public async Task PostAsync(string endpoint, object inputDto, object queryParameters)
        {
            await PostAsync(endpoint, inputDto, queryParameters, _accessTokenManager.GetAccessToken(), true);
        }

        public async Task PostAsync(string endpoint, object inputDto, object queryParameters, string accessToken,
            bool stripAjaxResponseWrapper)
        {
            await PostAsync<object>(endpoint, inputDto, queryParameters, accessToken, stripAjaxResponseWrapper);
        }

        #endregion PostAsync

        #region GetAsync<T>

        public async Task<ApiResult<T>> GetAsync<T>(string endpoint)
        {
            return await GetAsync<T>(endpoint, null);
        }

        /// <summary>
        /// Makes GET request without authentication token.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public async Task<ApiResult<T>> GetAnonymousAsync<T>(string endpoint)
        {
            return await GetAsync<T>(endpoint, null, null, true);
        }

        public async Task<ApiResult<T>> GetAsync<T>(string endpoint, object queryParameters)
        {
            return await GetAsync<T>(endpoint, queryParameters, _accessTokenManager.GetAccessToken(), true);
        }

        public async Task<ApiResult<T>> GetAsync<T>(string endpoint, object queryParameters, string accessToken, bool stripAjaxResponseWrapper)
        {
            var httpResponse = GetClient(accessToken)
                .Request(endpoint)
                .SetQueryParams(queryParameters)
                .GetAsync();

            return await ValidateAbpResponse<T>(httpResponse, stripAjaxResponseWrapper);
        }

        #endregion GetAsync<T>

        #region GetAsync

        public async Task GetAsync(string endpoint)
        {
            await GetAsync(endpoint, null);
        }

        public async Task GetAsync(string endpoint, object queryParameters)
        {
            await GetAsync(endpoint, queryParameters, _accessTokenManager.GetAccessToken(), true);
        }

        public async Task GetAsync(string endpoint, object queryParameters, string accessToken, bool stripAjaxResponseWrapper)
        {
            await GetAsync<object>(endpoint, queryParameters, accessToken, stripAjaxResponseWrapper);
        }

        #endregion GetAsync

        #region PutAsync<T>
        public async Task<ApiResult<T>> PutAsync<T>(string endpoint)
        {
            return await PutAsync<T>(endpoint, null, null, _accessTokenManager.GetAccessToken(), true);
        }

        public async Task<ApiResult<T>> PutAnonymousAsync<T>(string endpoint)
        {
            return await PutAsync<T>(endpoint, null, null, null, true);
        }

        public async Task<ApiResult<T>> PutAsync<T>(string endpoint, object inputDto)
        {
            return await PutAsync<T>(endpoint, inputDto, null, _accessTokenManager.GetAccessToken(), true);
        }

        public async Task<ApiResult<T>> PutAsync<T>(string endpoint, object inputDto, object queryParameters)
        {
            return await PutAsync<T>(endpoint, inputDto, queryParameters, _accessTokenManager.GetAccessToken(), true);
        }

        public async Task<ApiResult<T>> PutAsync<T>(string endpoint, object inputDto, object queryParameters, string accessToken, bool stripAjaxResponseWrapper)
        {
            var httpResponse = GetClient(accessToken)
                .Request(endpoint)
                .SetQueryParams(queryParameters)
                .PutJsonAsync(inputDto);

            return await ValidateAbpResponse<T>(httpResponse, stripAjaxResponseWrapper);
        }

        #endregion

        #region PutAsync

        public async Task PutAsync(string endpoint)
        {
            await PutAsync(endpoint, null, null, _accessTokenManager.GetAccessToken(), true);
        }

        public async Task PutAsync(string endpoint, object inputDto)
        {
            await PutAsync(endpoint, inputDto, null, _accessTokenManager.GetAccessToken(), true);
        }

        /// <summary>
        /// Makes POST request without authentication token.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        public async Task PutAnonymousAsync(string endpoint, object inputDto)
        {
            await PutAsync(endpoint, inputDto, null, null, true);
        }

        public async Task PutAsync(string endpoint, object inputDto, object queryParameters)
        {
            await PutAsync(endpoint, inputDto, queryParameters, _accessTokenManager.GetAccessToken(), true);
        }

        public async Task PutAsync(string endpoint, object inputDto, object queryParameters, string accessToken,
            bool stripAjaxResponseWrapper)
        {
            await PutAsync<object>(endpoint, inputDto, queryParameters, accessToken, stripAjaxResponseWrapper);
        }
        #endregion

        #region Delete<T>
        public async Task<ApiResult<T>> DeleteAsync<T>(string endpoint)
        {
            return await DeleteAsync<T>(endpoint, null);
        }

        /// <summary>
        /// Makes GET request without authentication token.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public async Task<ApiResult<T>> DeleteAnonymousAsync<T>(string endpoint)
        {
            return await DeleteAsync<T>(endpoint, null, null, true);
        }

        public async Task<ApiResult<T>> DeleteAsync<T>(string endpoint, object queryParameters)
        {
            return await DeleteAsync<T>(endpoint, queryParameters, _accessTokenManager.GetAccessToken(), true);
        }

        public async Task<ApiResult<T>> DeleteAsync<T>(string endpoint, object queryParameters, string accessToken, bool stripAjaxResponseWrapper)
        {
            var httpResponse = GetClient(accessToken)
                .Request(endpoint)
                .SetQueryParams(queryParameters)
                .DeleteAsync();

            return await ValidateAbpResponse<T>(httpResponse, stripAjaxResponseWrapper);
        }

        #endregion

        #region Delete
        public async Task DeleteAsync(string endpoint)
        {
            await DeleteAsync(endpoint, null);
        }

        public async Task DeleteAsync(string endpoint, object queryParameters)
        {
            await DeleteAsync(endpoint, queryParameters, _accessTokenManager.GetAccessToken(), true);
        }

        public async Task DeleteAsync(string endpoint, object queryParameters, string accessToken, bool stripAjaxResponseWrapper)
        {
            await DeleteAsync<object>(endpoint, queryParameters, accessToken, stripAjaxResponseWrapper);
        }
        #endregion

        #region GetStringAsync

        public async Task GetStringAsync(string endpoint)
        {
            await GetStringAsync(endpoint, null);
        }

        public async Task GetStringAsync(string endpoint, object queryParameters)
        {
            await GetStringAsync(endpoint, queryParameters, _accessTokenManager.GetAccessToken());
        }

        public async Task<string> GetStringAsync(string endpoint, object queryParameters, string accessToken)
        {
            return await GetClient(accessToken)
                    .Request(endpoint)
                    .SetQueryParams(queryParameters)
                    .GetStringAsync();
        }

        #endregion GetStringAsync

    }
}
