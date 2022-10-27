using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT.Common.Enum;

namespace ZT.Application.Sys
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间      ：  2022/9/7 13:57:12 
    /// Description   ： 登录日志/操作日志/任务日志 
    ///********************************************/
    /// </summary>
    public class SysLogDto
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 日志级别
        /// </summary>
        public LogEnum Level { get; set; }

        /// <summary>
        /// 日志级别
        /// </summary>
        public string LevelName { get; set; }

        /// <summary>
        /// 日志类型  1=登录  2=操作
        /// </summary>
        [Required]
        public LogTypeEnum LogType { get; set; }

        /// <summary>
        /// 操作模块
        /// </summary>
        public string Module { get; set; }

        /// <summary>
        /// 操作类型:例如添加、修改
        /// </summary>
        public string OperateType { get; set; }

        /// <summary>
        /// 提交类型：get/post/delete
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string OperateUser { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 请求参数
        /// </summary>
        public string Parameters { get; set; }

        /// <summary>
        /// 操作地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 操作状态
        /// </summary>
        [Required]
        public bool Status { get; set; } = true;

        /// <summary>
        /// 详细信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public string ReturnValue { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        [Required]
        public DateTime OperateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 浏览器信息
        /// </summary>
        public string Browser { get; set; }

        /// <summary>
        /// 执行时长
        /// </summary>
        [Required]
        public int ExecutionDuration { get; set; } = 0;

    }
}
