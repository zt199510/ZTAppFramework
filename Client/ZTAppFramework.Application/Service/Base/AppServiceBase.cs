using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ZTAppFramewrok.Application.Stared.HttpManager;
using ZTAppFreamework.Stared.Attributes;

namespace ZTAppFramework.Application.Service
{
    public class AppServiceBase
    {
        protected ApiClinetRepository _apiClinet;

        public virtual string ApiServiceUrl { get => ""; }

  

        public AppServiceBase(ApiClinetRepository apiClinet)
        {
            _apiClinet = apiClinet;
        }

        protected string GetEndpoint()
        {
            string EventStr="";
            try
            {
                string st = (new StackTrace()).GetFrame(1).GetMethod().DeclaringType.FullName; ;
                string MethodNmae = SubstringSingle(st, "<", ">");
                EventStr = GetType().GetMethod(MethodNmae).GetCustomAttribute<ApiUrlAttribute>()?.Value;
            }
            catch (Exception)
            {

            }
            
            return ApiServiceUrl + "/" + EventStr;
        }

        public string SubstringSingle(string source, string startStr, string endStr)
        {
            Regex rg = new Regex("(?<=(" + startStr + "))[.\\s\\S]*?(?=(" + endStr + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(source).Value;
        }

    }
}
