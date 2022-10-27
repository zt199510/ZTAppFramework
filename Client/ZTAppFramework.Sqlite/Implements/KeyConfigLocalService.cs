using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAppFramework.SqliteCore.Models;
using ZTAppFramework.SqliteCore.Repository;
using ZTAppFreamework.Stared;

namespace ZTAppFramework.SqliteCore.Implements
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间      ：  2022/9/5 13:47:01 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class KeyConfigLocalService : BaseService<KeyConfig>
    {
        public async Task<SqlResult<KeyConfig>> GetUserSaveInfo()
        {
            SqlResult<KeyConfig> result = new SqlResult<KeyConfig>();
            var r = await GetModelAsync(x => x.Key == AppKeys.SaveUserInfoKey);
            if (r.success)
            {
                if (r.data == null)
                {
                    KeyConfig info = new KeyConfig() { Key = AppKeys.SaveUserInfoKey, Check = false, Values = "" };
                    await AddAsync(info);
                    result.data = info;
                }
                else
                {
                    result.data = r.data;
                }
            }
            else
            {
                r.success = false;
                r.message = result.message;
            }
            return result;
        }
    }
}
