using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Common.Utils
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/7 11:02:09 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public static class EnumUtils
    {

        public static string ToDescription(this System.Enum enumValue)
        {
            var value = enumValue.ToString();
            var field = enumValue.GetType().GetField(value);
            object[] objs = field?.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (objs.Length == 0)
                return value;
            DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
            return descriptionAttribute.Description;
        }
    }
}
