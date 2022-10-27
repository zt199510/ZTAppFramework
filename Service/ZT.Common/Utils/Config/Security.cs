namespace ZT.Common.Utils.Config
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/7 10:47:05 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class Security
    {
        public const string Name = "Security";

        /// <summary>
        /// 应用编号
        /// </summary>
        public string AppKey { get; set; }

        /// <summary>
        /// Aes加密密钥
        /// </summary>
        public string AesKey { get; set; }

        /// <summary>
        /// 前端约定签名值
        /// </summary>
        public string SignKey { get; set; }

        /// <summary>
        /// Des加密密钥
        /// </summary>
        public string DesKey { get; set; }
    }
}
