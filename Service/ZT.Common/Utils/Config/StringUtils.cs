using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZT.Common.Utils.Config
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/7 14:17:47 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public static class StringUtils
    {
        #region 随机数
        private static readonly Random Random = new();

        private static int beginNumber = 99;

        public static string RandomString(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var content = new char[length];
            for (var i = 0; i < length; i++)
            {
                content[i] = chars[Random.Next(chars.Length)];
            }

            return new string(content);
        }

        /// <summary>
        /// 短信验证码生成
        /// </summary>
        /// <returns></returns>
        public static string SsmCode()
        {
            return Random.Next(100000, 999999).ToString();
        }

        /// <summary>
        /// 订单随机数
        /// </summary>
        /// <returns></returns>
        public static string OrderNumber()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + RandomString(6);
        }

        /// <summary>
        /// 订单随机数
        /// </summary>
        /// <returns></returns>
        public static string AccordingNumber()
        {
            beginNumber += 1;
            return DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + beginNumber;
        }
        #endregion

        #region 过滤emoji字符
        public static string FilterEmoji(this string str)
        {

            var origin = str;
            try
            {
                foreach (var a in str)
                {
                    byte[] bts = Encoding.UTF32.GetBytes(a.ToString());
                    if (bts[0].ToString() == "253" && bts[1].ToString() == "255")
                    {
                        str = str.Replace(a.ToString(), "");
                    }
                }
            }
            catch (Exception)
            {
                str = origin;
            }
            return str;
        }
        #endregion

        #region 字符串转换Long类型
        /// <summary>
        /// 将字符串转换为long类型数组
        /// </summary>
        /// <param name="str">如1,2,3,4,5</param>
        /// <returns></returns>
        public static List<long> StrToListLong(this string str)
        {
            var list = new List<long>();
            if (!str.Contains(","))
            {
                list.Add(long.Parse(str));
                return list;
            }
            var slist = str.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            list.AddRange(slist.Select(long.Parse));
            return list;
        }
        #endregion

        #region 上传配置

        /// <summary>
        ///  根据文件类型分配路径
        /// </summary>
        /// <param name="fileExt"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string AssigendPath(string fileExt, string path)
        {
            var dataPath = DateTime.Now.ToString("yyyyMMdd");
            if (IsImage(fileExt))
                return path + "/upload/images/" + dataPath + "/";
            if (IsVideos(fileExt))
                return path + "/upload/videos/" + dataPath + "/";
            if (IsDocument(fileExt))
                return "/upload/files/" + dataPath + "/";
            if (IsMusics(fileExt))
                return "/upload/musics/" + dataPath + "/";
            return path + "/upload/others/";
        }

        /// <summary>
        /// 是否为图片
        /// </summary>
        /// <param name="fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        private static bool IsImage(string fileExt)
        {
            var images = new List<string> { "bmp", "gif", "jpg", "jpeg", "png" };
            return images.Contains(fileExt.ToLower());
        }

        /// <summary>
        /// 是否为视频
        /// </summary>
        /// <param name="fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        private static bool IsVideos(string fileExt)
        {
            var videos = new List<string>
            { "rmvb", "mkv", "ts", "wma", "avi", "rm", "mp4", "flv", "mpeg", "mov", "3gp", "mpg" };
            return videos.Contains(fileExt.ToLower());
        }

        /// <summary>
        /// 是否为音频
        /// </summary>
        /// <param name="fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        private static bool IsMusics(string fileExt)
        {
            var musics = new List<string> { "mp3", "wav" };
            return musics.Contains(fileExt.ToLower());
        }

        /// <summary>
        /// 是否为文档
        /// </summary>
        /// <param name="fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        private static bool IsDocument(string fileExt)
        {
            var documents = new List<string> { "doc", "docx", "xls", "xlsx", "ppt", "pptx", "txt", "pdf" };
            return documents.Contains(fileExt.ToLower());
        }

        #endregion

        #region 首字母大小写转换

        /// <summary>
        /// 首字母转小写
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string FirstCharToLower(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            var str = s.First().ToString().ToLower() + s[1..];
            return str;
        }

        /// <summary>
        /// 首字母转大写
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string FirstCharToUpper(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            var str = s.First().ToString().ToUpper() + s[1..];
            return str;
        }

        #endregion

        #region 时间处理
        private static readonly DateTime dateStart = new(1970, 1, 1, 8, 0, 0);

        private static readonly long longTime = 621355968000000000;

        private static readonly int samllTime = 10000000;

        /// <summary>
        /// 获取时间戳 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long GetTimeStamp(this DateTime dateTime)
        {
            return (dateTime.ToUniversalTime().Ticks - longTime) / samllTime;
        }

        /// <summary>
        /// 时间戳转换成日期
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime GetTimeSpmpToDate(this object timeStamp)
        {
            if (timeStamp == null) return dateStart;
            DateTime dateTime = new DateTime(longTime + Convert.ToInt64(timeStamp) * samllTime, DateTimeKind.Utc).ToLocalTime();
            return dateTime;
        }
        #endregion

        #region 截取字符串长度
        /// <summary>
        /// 截取字符长度
        /// </summary>
        /// <param name="inputString">字符</param>
        /// <param name="len">长度</param>
        /// <returns></returns>
        public static string CutString(this string inputString, int len)
        {
            if (string.IsNullOrEmpty(inputString))
                return "";
            inputString = DropHtml(inputString);
            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }

                try
                {
                    tempString += inputString.Substring(i, 1);
                }
                catch
                {
                    break;
                }

                if (tempLen > len)
                    break;
            }
            //如果截过则加上半个省略号 
            byte[] mybyte = System.Text.Encoding.Default.GetBytes(inputString);
            if (mybyte.Length > len)
                tempString += "…";
            return tempString;
        }
        public static string DropHtml(this string htmlstring)
        {
            if (string.IsNullOrEmpty(htmlstring)) return "";
            //删除脚本  
            htmlstring = Regex.Replace(htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML  
            htmlstring = Regex.Replace(htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);

            htmlstring = Regex.Replace(htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            htmlstring = htmlstring.Replace("<", "");
            htmlstring = htmlstring.Replace(">", "");
            htmlstring = htmlstring.Replace("\r\n", "");
            //htmlstring = HttpContext.Current.Server.HtmlEncode(htmlstring).Trim(); 
            return htmlstring;
        }
        #endregion
    }
}
