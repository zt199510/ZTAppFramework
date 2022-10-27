using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Common.Utils
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/12 14:00:36 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class HttpUtils
    {
        /// <summary>
        /// 发起POST同步请求
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="contentType">application/xml、application/json、application/text、application/x-www-form-urlencoded</param>
        /// <param name="headers">填充消息头</param>        
        /// <returns></returns>
        public static string HttpPost(string url, string postData = null, string contentType = null, int timeOut = 30, Dictionary<string, string> headers = null)
        {
            postData ??= "";
            var httpclientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, error) => true
            };
            using var client = new HttpClient(httpclientHandler);
            if (headers != null)
            {
                foreach (var (key, value) in headers)
                    client.DefaultRequestHeaders.Add(key, value);
            }

            using HttpContent httpContent = new StringContent(postData, Encoding.UTF8);
            if (contentType != null)
            {
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                var data = Encoding.UTF8.GetBytes(postData);
                httpContent.Headers.ContentLength = data.Length;
            }

            var response = client.PostAsync(url, httpContent).Result;
            return response.Content.ReadAsStringAsync().Result;
        }


        /// <summary>
        /// 发起POST异步请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="contentType">application/xml、application/json、application/text、application/x-www-form-urlencoded</param>
        /// <param name="headers">填充消息头</param>        
        /// <returns></returns>
        public static async Task<string> HttpPostAsync(string url, string postData = null, string contentType = null, int timeOut = 30, Dictionary<string, string> headers = null)
        {
            postData ??= "";
            var httpclientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, error) => true
            };
            using var client = new HttpClient(httpclientHandler);
            client.Timeout = new TimeSpan(0, 0, timeOut);
            if (headers != null)
            {
                foreach (var (key, value) in headers)
                    client.DefaultRequestHeaders.Add(key, value);
            }

            using HttpContent httpContent = new StringContent(postData, Encoding.UTF8);
            if (contentType != null)
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);

            var response = await client.PostAsync(url, httpContent);
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 发起GET同步请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static string HttpGet(string url, Dictionary<string, string> headers = null)
        {
            var httpclientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, error) => true
            };
            using var client = new HttpClient(httpclientHandler);
            if (headers != null)
            {
                foreach (var (key, value) in headers)
                    client.DefaultRequestHeaders.Add(key, value);
            }
            var response = client.GetAsync(url).Result;
            return response.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// 发起GET异步请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static async Task<string> HttpGetAsync(string url, Dictionary<string, string> headers = null)
        {
            var httpclientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, error) => true
            };
            using var client = new HttpClient(httpclientHandler);
            if (headers != null)
            {
                foreach (var (key, value) in headers)
                    client.DefaultRequestHeaders.Add(key, value);
            }
            var response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
