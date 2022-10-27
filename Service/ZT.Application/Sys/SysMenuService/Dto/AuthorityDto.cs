using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZT.Application.Sys
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/8 11:49:37 
    /// Description   ：  返回给前端的权限菜单
    ///********************************************/
    /// </summary>
    public class AuthorityDto
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string path { get; set; }

        /// <summary>
        /// 组件
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string component { get; set; }

        /// <summary>
        /// 重定向
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string redirect { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 属性
        /// </summary>
        public AuthorityMeta meta { get; set; }

        //public bool alwaysShow { get; set; } = true;

        /// <summary>
        /// 子级
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<AuthorityDto> children { get; set; }
    }

    public class AuthorityMeta
    {

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 图表
        /// </summary>
        public string icon { get; set; }

        public bool affix { get; set; } = false;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string type { get; set; }

        [JsonIgnore]
        public bool? hidden { get; set; } = null;

        [JsonIgnore]
        public bool? dynamicNewTab { get; set; } = null;

        /// <summary>
        /// 是否关闭
        /// </summary>
        [JsonIgnore]
        public bool noClosable { get; set; } = false;

        //不缓存
        [JsonIgnore]
        public bool noKeepAlive { get; set; } = false;

        /// <summary>
        /// 按钮权限
        /// </summary>
        [JsonIgnore]
        public string[] roles { get; set; }
    }
}
