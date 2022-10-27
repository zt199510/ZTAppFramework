using System.Diagnostics;

namespace ZTAppFramework.SqliteCore
{
    public class DbContext
    {
        public IFreeSql  freeSql { get; set; }
        public DbContext()
        {
            freeSql= new FreeSql.FreeSqlBuilder()
         .UseMonitorCommand(cmd => Trace.WriteLine($"Sql：{cmd.CommandText}"))//监听SQL语句,Trace在输入选项卡中查看
         .UseConnectionString(FreeSql.DataType.Sqlite, @"Data Source=freedb.db")
         .UseAutoSyncStructure(true) //自动同步实体结构到数据库，FreeSql不会扫描程序集，只有CRUD时才会生成表。
         .Build();
        }
    }
}