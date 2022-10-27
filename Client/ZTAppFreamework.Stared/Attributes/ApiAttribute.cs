using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFreamework.Stared.Attributes
{
    
  
    public class ApiUrlAttribute: Attribute
    {
        public ApiUrlAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public string Method { get => System.Reflection.MethodBase.GetCurrentMethod().Name; }
    }
}
