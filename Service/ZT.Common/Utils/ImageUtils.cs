using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
namespace ZT.Common.Utils
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/7 16:58:59 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public static class ImageUtils
    {
        #region 文件格式
        /// <summary>
        /// 是否为图片
        /// </summary>
        /// <param name="fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        public static bool IsImage(this string fileExt)
        {
            var images = new List<string> { "bmp", "gif", "jpg", "jpeg", "png" };
            return images.Contains(fileExt.ToLower());
        }
        /// <summary>
        /// 是否为视频
        /// </summary>
        /// <param name="fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        public static bool IsVideos(this string fileExt)
        {
            var videos = new List<string> { "rmvb", "mkv", "ts", "wma", "avi", "rm", "mp4", "flv", "mpeg", "mov", "3gp", "mpg" };
            return videos.Contains(fileExt.ToLower());
        }
        /// <summary>
        /// 是否为音频
        /// </summary>
        /// <param name="fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        public static bool IsMusics(this string fileExt)
        {
            var musics = new List<string> { "mp3", "wav" };
            return musics.Contains(fileExt.ToLower());
        }
        /// <summary>
        /// 是否为文档
        /// </summary>
        /// <param name="fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        public static bool IsDocument(this string fileExt)
        {
            var documents = new List<string> { "doc", "docx", "xls", "xlsx", "ppt", "pptx", "txt", "pdf" };
            return documents.Contains(fileExt.ToLower());
        }
        #endregion

        /// <summary>
        /// 裁切图片大小
        /// </summary>
        /// <param name="imagePath">图片路径</param>
        /// <param name="maxSize">裁切尺寸</param>
        /// <param name="isCreateNew">是否另存</param>
        public static void CutImage(string imagePath, int maxSize, bool isCreateNew = false)
        {
            using var image = Image.Load(imagePath);

            var encoder = new JpegEncoder()
            {
                //标准中定义的0到100之间的质量值。默认值为75。
                //通过减少Quality松散的信息，从而减小文件大小。
                Quality = 75,
                //IgnoreMetadata = true
            };

            if (isCreateNew == true)
            {
                imagePath = imagePath.Insert(imagePath.Length - 4, "_" + maxSize);
            }
            if (image.Width > image.Height)
            {
                if (image.Width <= maxSize) return;
                image.Mutate(x => x
                    .Resize(maxSize, maxSize / image.Width * image.Height));
                image.Save(imagePath, encoder);
            }
            else
            {
                if (image.Height <= maxSize) return;
                image.Mutate(x => x
                    .Resize(maxSize / image.Height * image.Width, maxSize));
                image.Save(imagePath, encoder);
            }
        }
    }
}
