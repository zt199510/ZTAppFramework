using Microsoft.AspNetCore.Http;
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
    /// 创建时间      ：  2022/9/7 16:44:50 
    /// Description   ：  公共类
    ///********************************************/
    /// </summary>
    public static class CommonUtils
    {
        #region 上传配置
        /// <summary>
        ///  根据文件类型分配路径
        /// </summary>
        /// <param name="fileExt"></param>
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
        /// <param name="_fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        private static bool IsImage(string _fileExt)
        {
            var images = new List<string> { "bmp", "gif", "jpg", "jpeg", "png" };
            if (images.Contains(_fileExt.ToLower())) return true;
            return false;
        }

        /// <summary>
        /// 是否为视频
        /// </summary>
        /// <param name="_fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        private static bool IsVideos(string _fileExt)
        {
            var videos = new List<string> { "rmvb", "mkv", "ts", "wma", "avi", "rm", "mp4", "flv", "mpeg", "mov", "3gp", "mpg" };
            if (videos.Contains(_fileExt.ToLower())) return true;
            return false;
        }

        /// <summary>
        /// 是否为音频
        /// </summary>
        /// <param name="_fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        private static bool IsMusics(string _fileExt)
        {
            var musics = new List<string> { "mp3", "wav" };
            if (musics.Contains(_fileExt.ToLower())) return true;
            return false;
        }

        /// <summary>
        /// 是否为文档
        /// </summary>
        /// <param name="_fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        private static bool IsDocument(string _fileExt)
        {
            var documents = new List<string> { "doc", "docx", "xls", "xlsx", "ppt", "pptx", "txt", "pdf" };
            if (documents.Contains(_fileExt.ToLower())) return true;
            return false;
        }
        #endregion

        #region 获得IP地址
        /// <summary>
        /// 获得IP地址
        /// </summary>
        /// <returns>字符串数组</returns>
        public static string GetIp()
        {
            HttpContextAccessor _context = new HttpContextAccessor();
            var ip = string.Empty;
            if (_context.HttpContext.Request.Headers.ContainsKey("X-Real-IP"))
            {
                ip = _context.HttpContext.Request.Headers["X-Real-IP"].ToString();
            }
            if (_context.HttpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                ip = _context.HttpContext.Request.Headers["X-Forwarded-For"].ToString();
            }
            if (string.IsNullOrEmpty(ip))
            {
                ip = _context.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            return ip;
        }
        #endregion

        #region 获得浏览器信息
        /// <summary>
        /// 获得IP地址
        /// </summary>
        /// <returns>字符串数组</returns>
        public static string GetBrowser()
        {
            var context = new HttpContextAccessor();
            var browserAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();
            string res;
            if (browserAgent.Contains("Chrome"))
            {
                res = "Chrome";
            }
            else if (browserAgent.Contains("Safari"))
            {
                res = "Safari";
            }
            else if (browserAgent.Contains("Firefox"))
            {
                res = "Firefox";
            }
            else if (browserAgent.Contains("Firefox"))
            {
                res = "Firefox";
            }
            else if (browserAgent.Contains("Edg"))
            {
                res = "Microsoft Edge";
            }
            else if (browserAgent.Contains("Opera"))
            {
                res = "Opera";
            }
            else if (browserAgent.Contains("MSIE"))
            {
                res = "IE";
            }
            else
            {
                res = browserAgent;
            }
            return res;
        }
        #endregion
    }
}
