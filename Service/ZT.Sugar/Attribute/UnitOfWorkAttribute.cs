using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ZT.Sugar
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/7 14:35:48 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class UnitOfWorkAttribute : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UnitOfWorkAttribute()
        {
        }

        /// <summary>
        /// 事务隔离级别
        /// </summary>
        public IsolationLevel IsolationLevel { get; set; } = IsolationLevel.ReadCommitted;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <remarks>
        /// <para>支持传入事务隔离级别 <see cref="IsolationLevel"/> 参数值</para>
        /// </remarks>
        /// <param name="isolationLevel">事务隔离级别</param>
        public UnitOfWorkAttribute(IsolationLevel isolationLevel)
        {
            IsolationLevel = isolationLevel;
        }
    }
}
