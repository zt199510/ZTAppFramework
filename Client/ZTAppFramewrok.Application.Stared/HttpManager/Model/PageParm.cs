using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramewrok.Application.Stared.HttpManager.Model
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间      ：  2022/9/7 8:32:04 
    /// Description   ：  分页参数
    ///********************************************/
    /// </summary>
    /// <summary>
    /// 分页参数
    /// </summary>
    public class PageParm
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int page { get; set; } = 1;

        /// <summary>
        /// 每页总条数
        /// </summary>
        public int limit { get; set; } = 15;

        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; } = 0;

        /// <summary>
        /// 编号
        /// </summary>
        public string guid { get; set; }

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string key { get; set; }

        /// <summary>
        /// 类型条件
        /// </summary>
        public int types { get; set; } = 0;

        /// <summary>
        /// 审核状态
        /// </summary>
        public int audit { get; set; } = -1;

        /// <summary>
        /// 状态
        /// </summary>
        public int status { get; set; } = -1;

        /// <summary>
        /// 属性
        /// </summary>
        public int attr { get; set; } = 0;

        /// <summary>
        /// 搜索日期，可能是2个日期，通过-分隔
        /// </summary>
        public string time { get; set; }

        /// <summary>
        /// 排序方式，可根据数字来判断，
        /// </summary>
        public int orderType { get; set; } = 0;

        /// <summary>
        /// 排序的字段
        /// </summary>
        public string field { get; set; }

        /// <summary>
        /// 排序的类型 asc  desc
        /// </summary>
        public string order { get; set; } = "desc";

        /// <summary>
        /// 动态条件
        /// </summary>
        public string where { get; set; }

        /// <summary>
        /// 站点
        /// </summary>
        public string site { get; set; }

        /// <summary>
        /// 英文名称
        /// </summary>
        public string number { get; set; }
    }
}
