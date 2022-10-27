using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Color = SixLabors.ImageSharp.Color;
using FontStyle = SixLabors.Fonts.FontStyle;
using Pen = SixLabors.ImageSharp.Drawing.Processing.Pen;
using PointF = SixLabors.ImageSharp.PointF;
using SystemFonts = SixLabors.Fonts.SystemFonts;

using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.Fonts;

namespace ZT.Common.Utils
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/7 16:45:35 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public static class CaptchaUtils
    {
        private const string Letters = "1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z";
        private static readonly string[] EnTextArr = { "a", "b", "c", "d", "e", "f", "g", "h", "k", "m", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        /// <summary>
        /// 颜色池,较深的颜色
        /// </summary>
        private static readonly string[] ColorHexArr = new string[] { "#00E5EE", "#000000", "#2F4F4F", "#000000", "#43CD80", "#191970", "#006400", "#458B00", "#8B7765", "#CD5B45" };

        ///较浅的颜色
        private static readonly string[] LightColorHexArr = new string[] { "#f6f4fc", "#f6f4fc", "#f6f4fc", "#f6f4fc", "#f6f4fc", "#f6f4fc", "#f6f4fc", "#f6f4fc" };
        private static readonly Random Random = new();

        /// <summary>
        /// 字体池
        /// </summary>
        private static Font[] _fontArr = { };

        /// <summary>
        /// 生成随机英文字母/数字组合字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static Task<string> GenerateRandomCaptchaAsync(int length)
        {
            var sb = new StringBuilder();
            if (length <= 0) return Task.FromResult(sb.ToString());
            do
            {
                if (Random.Next(0, 2) > 0)
                {
                    sb.Append(Random.Next(2, 10));
                }
                else
                {
                    sb.Append(EnTextArr[Random.Next(0, EnTextArr.Length)]);
                }
            }
            while (--length > 0);
            return Task.FromResult(sb.ToString());
        }

        /// <summary>
        /// 生成验证码及图片
        /// </summary>
        /// <param name="captchaCode"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Task<(string code, MemoryStream ms)> GenerateCaptchaImageAsync(string captchaCode, int width = 0, int height = 30)
        {
            InitFonts(24);

            if (width == 0) { width = captchaCode.Length * 25; }
            //定义图像的大小，生成图像的实例
            using var image = new Image<Rgba32>(width, height);

            image.Mutate(ctx =>
            {
                // 白底背景
                ctx.Fill(Color.White);

                // 画验证码
                for (int i = 0; i < captchaCode.Length; i++)
                {
                    var colorTextHex = ColorHexArr[Random.Next(0, ColorHexArr.Length)];
                    var lignthColorHex = LightColorHexArr[Random.Next(0, LightColorHexArr.Length)];
                    ctx.DrawText(captchaCode[i].ToString()
                        , _fontArr[Random.Next(0, _fontArr.Length)]
                        , Color.ParseHex(colorTextHex)
                        , new PointF(20 * i + 10, Random.Next(1, 10)));
                }

                // 画干扰线
                for (int i = 0; i < 3; i++)
                {
                    var colorTextHex = ColorHexArr[Random.Next(0, ColorHexArr.Length)];
                    var pen = new Pen(Color.ParseHex(colorTextHex), 1);
                    var p1 = new PointF(Random.Next(width), Random.Next(height));
                    var p2 = new PointF(Random.Next(width), Random.Next(height));

                    ctx.DrawLines(pen, p1, p2);
                }

                // 画噪点
                for (int i = 0; i < 30; i++)
                {
                    var colorTextHex = ColorHexArr[Random.Next(0, ColorHexArr.Length)];
                    var pen = new Pen(Color.ParseHex(colorTextHex), 1);
                    var p1 = new PointF(Random.Next(width), Random.Next(height));
                    var p2 = new PointF(p1.X + 1f, p1.Y + 1f);

                    ctx.DrawLines(pen, p1, p2);
                }
            });
            using var ms = new MemoryStream();

            // gif 格式
            image.SaveAsGif(ms);
            return Task.FromResult((captchaCode, ms));
        }

        /// <summary>
        /// 初始化字体池
        /// </summary>
        /// <param name="fontSize">一个初始大小</param>
        private static void InitFonts(int fontSize)
        {
            if (_fontArr.Length != 0) return;
            var assembly = Assembly.GetExecutingAssembly();
            var names = assembly.GetManifestResourceNames();
            if (names?.Length > 0)
            {
                var fontList = new List<Font>();
                var fontCollection = new FontCollection();
                foreach (var name in names)
                {
                    fontList.Add(new Font(fontCollection.Add(assembly.GetManifestResourceStream(name)), fontSize));
                }
                _fontArr = fontList.ToArray();
            }
            else
            {
                throw new Exception($"绘制验证码字体文件加载失败");
            }
        }


    }
}
