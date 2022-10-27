using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramework.Template.Global
{
    public static class Extension
    {

        #region String
        /// <summary>
        /// 指示该字符串是否是Null或空字符串。
        /// </summary>
        /// <summary xml:lang="en">
        /// 
        /// </summary>
        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }

        public static string Cut(this string text, int length, string filler = null)
        {
            if (text.Length <= length)
                return text;
            else
            {
                return text.Remove(length) + filler;
            }
        }
        #endregion
    }
}
