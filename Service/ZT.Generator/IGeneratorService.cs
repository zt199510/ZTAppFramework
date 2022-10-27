using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Generator
{
    public interface IGeneratorService
    {
        /// <summary>
        /// 查询所有表
        /// </summary>
        /// <returns></returns>
        List<DbTableInfo> InitTable();

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <param name="createModel"></param>
        /// <returns></returns>
        string CreateCode(GeneratorTableDto createModel);

        /// <summary>
        /// 根据表名查询列信息
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        List<DbColumnInfo> GetColumn(string tableName);
    }
}
