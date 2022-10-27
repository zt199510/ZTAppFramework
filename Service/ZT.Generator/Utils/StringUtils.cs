using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Generator.Utils
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  zt
    /// 创建时间    ：  2022/9/7 17:02:39 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public static class StringUtils
    {
        #region 数据库字段转换兼容，以及附加默认值

        /// <summary>
        /// 数据库类型，转换成实体类型
        /// </summary>
        /// <param name="dbType"></param>
        /// <param name="isNull">是否为空</param>
        /// <returns></returns>
        public static string ConvertModelType(this string dbType, bool isNull = false)
        {
            return dbType.ToLower() switch
            {
                "varchar" => "string",
                "text" => "string",
                "longtext" => "string",
                "bit" => "bool",
                "bigint" => "long",
                "datetime" => isNull ? "DateTime?" : "DateTime",
                "timestamp" => "DateTime",
                _ => dbType,
            };
        }

        /// <summary>
        /// 数据库类型，转换成实体类型
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="isNull">是否为空</param>
        /// <returns></returns>
        public static string ModelDefaultValue(this string dbType, string defaultValue, bool isNull = false)
        {
            var str = string.Empty;
            if (string.IsNullOrEmpty(defaultValue))
            {
                return str;
            }
            return dbType.ToLower() switch
            {
                "int" => " = " + defaultValue + ";",
                "long" => " = 0;",
                "datetime" => isNull ? "" : " = DateTime.Now;",
                "bit" => " = " + (defaultValue == "b'0'" ? "false" : "true") + ";",
                _ => str,
            };
        }

        /// <summary>
        /// 转换数据库名字和实体名字
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static string TableName(this string Name)
        {
            if (!Name.Contains("_"))
            {
                return Name.FirstCharToUpper();
            }
            var tname = string.Empty;
            var str = Name.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in str)
            {
                tname += item.FirstCharToUpper();
            }
            return tname;
        }

        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string FirstCharToUpper(this string input)
        {
            if (String.IsNullOrEmpty(input))
                return input;
            string str = input.First().ToString().ToUpper() + input[1..];
            return str;
        }
        #endregion
    }
}
