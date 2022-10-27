using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Generator
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/7 17:01:55 
    /// Description   ：  连接对象
    ///********************************************/
    /// </summary>
    public class GeneratorDto
    {
        public GeneratorDto(string ip, string port, string name, string passWord, string dbName)
        {
            Ip = ip;
            Port = port;
            Name = name;
            PassWord = passWord;
            DbName = dbName;
        }

        public string Ip { get; set; }

        public string Port { get; set; }

        public string Name { get; set; }

        public string PassWord { get; set; }

        public string DbName { get; set; }
    }

    /// <summary>
    /// 生成的对象
    /// </summary>
    public class GeneratorTableDto
    {
        /// <summary>
        /// 数据库表名字  例如：sys_admin
        /// </summary>
        public string[] TableNames { get; set; }

        /// <summary>
        /// 命名空间，根据不同的业务，分文件夹=命名空间
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// 生成类型 1=全部表   2=部分表
        /// </summary>
        public int Types { get; set; } = 1;

        /// <summary>
        /// Api版本
        /// </summary>
        public string ApiVersion { get; set; } = "v1";

    }
}
