using SqlSugar;
using ZT.Common.Utils;
using ZT.Common.Utils.Config;
using ZT.Generator.Utils;
using ZT.Sugar;

namespace ZT.Generator
{
    public class GeneratorService : SugarRepository<GeneratorService>, IGeneratorService
    {
        /// <summary>
        /// 目录分隔符
        /// windows "\" OSX and Linux  "/"
        /// </summary>
        private static string _directorySeparatorChar = Path.DirectorySeparatorChar.ToString();

        /// <summary>
        /// 连接数据库，并返回当前连接下所有表名字
        /// </summary>
        /// <returns></returns>
        public List<DbTableInfo> InitTable()
        {
            return base.Context.DbMaintenance.GetTableInfoList();
        }

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <returns></returns>
        public string CreateCode(GeneratorTableDto createModel)
        {
            var basePath = AppContext.BaseDirectory;
            var path = basePath + @"Generator";
            FileUtils.CreateSuffic(path);
            var db = base.Context;
            //读取模板——实体
            var modelTemp = FileUtils.ReadFile(basePath + @"Template" + _directorySeparatorChar + "Model.txt");
            //读取模板——Dto
            var dtoTemp = FileUtils.ReadFile(basePath + @"Template" + _directorySeparatorChar + "Dto.txt");
            //读取模板——服务实现
            var serviceTemp = FileUtils.ReadFile(basePath + @"Template" + _directorySeparatorChar + "Service.txt");
            //读取模板Tree——服务实现
            var treeServiceTemp = FileUtils.ReadFile(basePath + @"Template" + _directorySeparatorChar + "TreeService.txt");

            //读取模板Js——前端
            var jsTemp = FileUtils.ReadFile(basePath + @"Template" + _directorySeparatorChar + "Vue/Js.txt");
            //读取模板List——前端
            var listTemp = FileUtils.ReadFile(basePath + @"Template" + _directorySeparatorChar + "Vue/List.txt");
            //读取模板Modify——前端
            var modifyTemp = FileUtils.ReadFile(basePath + @"Template" + _directorySeparatorChar + "Vue/Modify.txt");

            var tableList = createModel.Types == 1 ?
                db.DbMaintenance.GetTableInfoList() :
                db.DbMaintenance.GetTableInfoList().Where(m => createModel.TableNames.Contains(m.Name)).ToList();
            foreach (var row in tableList)
            {
                var column = db.DbMaintenance.GetColumnInfosByTableName(row.Name);
                //判断是否存在树形结构的实体，如果存在，则使用Tree模板
                bool isParent = false, isParentList = false, isLayer = false;
                //构建属性
                string attrStr = "", dtoAttrStr = "", tableColumn = "";
                foreach (var item in column)
                {
                    switch (item.DbColumnName)
                    {
                        case "ParentId":
                            isParent = true;
                            break;
                        case "ParentIdList":
                            isParentList = true;
                            break;
                        case "Layer":
                            isLayer = true;
                            break;
                    }

                    if (!item.IsPrimarykey)
                    {
                        attrStr += "    /// <summary>\r\n";
                        attrStr += "    /// " + item.ColumnDescription + "\r\n";
                        attrStr += "    /// </summary>\r\n";
                        if (!item.IsNullable && item.DataType.ConvertModelType() == "string")
                        {
                            attrStr += "    [Required]\r\n";
                            attrStr += "    [StringLength(" + item.Length + ")]\r\n";
                        }
                        if (!item.IsNullable && item.DataType.ConvertModelType() != "string")
                        {
                            attrStr += "    [Required]\r\n";
                        }
                        attrStr += "    public " + item.DataType.ConvertModelType(item.IsNullable) + " " + item.DbColumnName + " { get; set; }" + item.DataType.ModelDefaultValue(item.DefaultValue, item.IsNullable) + "\r\n\r\n";
                    }
                    dtoAttrStr += "    /// <summary>\r\n";
                    dtoAttrStr += "    /// " + item.ColumnDescription + "\r\n";
                    dtoAttrStr += "    /// </summary>\r\n";
                    if (!item.IsNullable && item.DataType.ConvertModelType() == "string")
                    {
                        dtoAttrStr += "    [Required]\r\n";
                        dtoAttrStr += "    [StringLength(" + item.Length + ")]\r\n";
                    }
                    if (!item.IsNullable && item.DataType.ConvertModelType() != "string" && !item.IsPrimarykey)
                    {
                        dtoAttrStr += "    [Required]\r\n";
                    }
                    dtoAttrStr += "    public " + item.DataType.ConvertModelType(item.IsNullable) + " " + item.DbColumnName + " { get; set; }" + item.DataType.ModelDefaultValue(item.DefaultValue, item.IsNullable) + "\r\n\r\n";
                }
                var modelName = row.Name.TableName();
                tableColumn = modelTemp
                   .Replace("{NameSpace}", createModel.Namespace)
                   .Replace("{TableNameDescribe}", row.Description)
                   .Replace("{DataTable}", row.Name)
                   .Replace("{TableName}", modelName)
                   .Replace("{AttributeList}", attrStr);
                //写入文件-Model
                FileUtils.WriteFile(path + "/Model/" + createModel.Namespace + "/", modelName + ".cs", tableColumn);

                var serverPath = path + "/" + createModel.Namespace + "/" + modelName + "Service/";

                //Dto
                string dtoString = dtoTemp.Replace("{NameSpace}", createModel.Namespace)
                        .Replace("{TableNameDescribe}", row.Description.Replace("\r\n", "/"))
                        .Replace("{TableName}", modelName)
                        .Replace("{AttributeList}", dtoAttrStr);
                FileUtils.WriteFile(serverPath + "/Dto/", modelName + "Dto.cs", dtoString);


                if (!isParent && !isParentList && !isLayer)
                {
                    //接口实现
                    string serviceString = serviceTemp.Replace("{NameSpace}", createModel.Namespace)
                        .Replace("{TableNameDescribe}", row.Description.Replace("\r\n", "/"))
                        .Replace("{Version}", createModel.ApiVersion)
                        .Replace("{TableName}", modelName);
                    FileUtils.WriteFile(serverPath, modelName + "Service.cs", serviceString);
                }
                else
                {
                    //接口实现
                    string treeServiceString = treeServiceTemp.Replace("{NameSpace}", createModel.Namespace)
                        .Replace("{TableNameDescribe}", row.Description.Replace("\r\n", "/"))
                        .Replace("{Version}", createModel.ApiVersion)
                        .Replace("{TableName}", modelName);
                    FileUtils.WriteFile(serverPath, modelName + "Service.cs", treeServiceString);
                }

                #region 前端
                //JS
                var jsString = jsTemp.Replace("{TableName}", modelName.ToLower());
                FileUtils.WriteFile(path + "/Vue/", modelName + ".js", jsString);

                //List
                string webTableColumnStr = string.Empty, formColumnStr = string.Empty, formData = string.Empty;
                foreach (var item in column)
                {
                    webTableColumnStr += "                { prop: '" + item.DbColumnName.FirstCharToLower() + "', label: '" + item.ColumnDescription + "', width: 100 },\r\n";
                    if (!item.IsPrimarykey && item.DataType.ConvertModelType() == "bool")
                    {
                        formColumnStr += "<el-form-item label=\"" + item.ColumnDescription + "\" prop=\"" + item.DbColumnName.FirstCharToLower() + "\">\r\n";
                        formColumnStr += "	<el-switch \r\n";
                        formColumnStr += "		v-model=\"" + item.DbColumnName.FirstCharToLower() + "\" \r\n";
                        formColumnStr += "	></el-switch> \r\n";
                        formColumnStr += "</el-form-item> \r\n";
                        formData += item.DbColumnName.FirstCharToLower() + ":false, \r\n";
                    }
                    if (!item.IsPrimarykey && item.DataType.ConvertModelType() != "bool")
                    {
                        formColumnStr += "<el-form-item label=\"" + item.ColumnDescription + "\" prop=\"" + item.DbColumnName.FirstCharToLower() + "\"> \r\n";
                        formColumnStr += "	<el-input \r\n";
                        formColumnStr += "		v-model=\"" + item.DbColumnName.FirstCharToLower() + "\" \r\n";
                        formColumnStr += "		placeholder=\"请输入" + item.ColumnDescription + "\" \r\n";
                        formColumnStr += "		:maxlength=\"" + item.Length + "\" \r\n";
                        formColumnStr += "		show-word-limit \r\n";
                        formColumnStr += "		clearable \r\n";
                        formColumnStr += "	></el-input> \r\n";
                        formColumnStr += "</el-form-item> \r\n";
                        formData += item.DbColumnName.FirstCharToLower() + ":'', \r\n";
                    }
                }

                var listString = listTemp.Replace("{TableName}", modelName.ToLower())
                    .Replace("{NameSpace}", createModel.Namespace.ToLower())
                    .Replace("{Column}", webTableColumnStr);
                FileUtils.WriteFile(path + "/Vue/" + createModel.Namespace + "/" + modelName + "/", "index.vue", listString);

                //Modify
                var modifyString = modifyTemp.Replace("{TableName}", modelName.ToLower())
                    .Replace("{NameSpace}", createModel.Namespace.ToLower())
                    .Replace("{TableColumn}", formColumnStr)
                    .Replace("{formData}", formData)
                    .Replace("{TableNameDescribe}", row.Description);
                FileUtils.WriteFile(path + "/Vue/" + createModel.Namespace + "/" + modelName + "/", "modify.vue", modifyString);
                #endregion

            }
            return path;
        }

        /// <summary>
        /// 根据表名查询列信息
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<DbColumnInfo> GetColumn(string tableName)
        {
            return base.Context.DbMaintenance.GetColumnInfosByTableName(tableName);
        }
    }
}