using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Common.Utils
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/7 16:58:09 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class FileUtils
    {
        /// <summary>
        /// 目录分隔符
        /// windows "\" OSX and Linux  "/"
        /// </summary>
        private static string _directorySeparatorChar = Path.DirectorySeparatorChar.ToString();
        /// <summary>
        /// 包含应用程序的目录的绝对路径
        /// </summary>
        private static string _contentRootPath = $@"{AppContext.BaseDirectory}\";

        /// <summary>
        /// 获取文件绝对路径
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string MapPath(string path)
        {
            return Path.Combine(_contentRootPath, path.TrimStart('~', '/').Replace("/", _directorySeparatorChar));
        }

        #region 检测指定路径是否存在
        /// <summary>
        /// 检测指定路径是否存在
        /// </summary>
        /// <param name="path">目录的绝对路径</param> 
        public static bool IsExistDirectory(string path)
        {
            return Directory.Exists(path);
        }
        #endregion

        #region 检测指定文件是否存在,如果存在则返回true
        /// <summary>
        /// 检测指定文件是否存在,如果存在则返回true
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>  
        public static bool IsExistFile(string filePath)
        {
            return File.Exists(filePath);
        }
        #endregion

        #region 创建文件夹
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="folderPath">文件夹的绝对路径</param>
        public static void CreateFolder(string folderPath)
        {
            if (!IsExistDirectory(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }
        #endregion

        #region 判断上传文件后缀名
        /// <summary>
        /// 判断上传文件后缀名
        /// </summary>
        /// <param name="strExtension">后缀名</param>
        public static bool IsCanEdit(string strExtension)
        {
            strExtension = strExtension.ToLower();
            if (strExtension.LastIndexOf(".", StringComparison.Ordinal) >= 0)
            {
                strExtension = strExtension.Substring(strExtension.LastIndexOf(".", StringComparison.Ordinal));
            }
            else
            {
                strExtension = ".txt";
            }
            string[] strArray = new string[] { ".htm", ".html", ".txt", ".js", ".css", ".xml", ".sitemap" };
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strExtension.Equals(strArray[i]))
                {
                    return true;
                }
            }
            return false;
        }


        public static bool IsSafeName(string strExtension)
        {
            strExtension = strExtension.ToLower();
            if (strExtension.LastIndexOf(".") >= 0)
            {
                strExtension = strExtension.Substring(strExtension.LastIndexOf("."));
            }
            else
            {
                strExtension = ".txt";
            }
            string[] strArray = new string[] { ".jpg", ".gif", ".png" };
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strExtension.Equals(strArray[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsZipName(string strExtension)
        {
            strExtension = strExtension.ToLower();
            if (strExtension.LastIndexOf(".") >= 0)
            {
                strExtension = strExtension.Substring(strExtension.LastIndexOf("."));
            }
            else
            {
                strExtension = ".txt";
            }
            string[] strArray = new string[] { ".zip", ".rar" };
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strExtension.Equals(strArray[i]))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region 创建文件夹
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="fileName">文件的绝对路径</param>
        public static void CreateSuffic(string fileName)
        {
            if (!Directory.Exists(fileName))
            {
                Directory.CreateDirectory(fileName);
            }
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="fileName">文件的绝对路径</param>
        public static void CreateFiles(string fileName)
        {
            //判断文件是否存在，不存在创建该文件
            if (IsExistFile(fileName)) return;
            var file = new FileInfo(fileName);
            var fs = file.Create();
            fs.Close();
        }

        /// <summary>
        /// 创建一个文件,并将字节流写入文件。
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        /// <param name="buffer">二进制流数据</param>
        public static void CreateFile(string filePath, byte[] buffer)
        {
            try
            {
                //判断文件是否存在，不存在创建该文件
                if (!IsExistFile(filePath))
                {
                    FileInfo file = new FileInfo(filePath);
                    FileStream fs = file.Create();
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
                else
                {
                    File.WriteAllBytes(filePath, buffer);
                }
            }
            catch
            {
                // ignored
            }
        }
        #endregion

        #region 将文件移动到指定目录
        /// <summary>
        /// 将文件移动到指定目录
        /// </summary>
        /// <param name="sourceFilePath">需要移动的源文件的绝对路径</param>
        /// <param name="descDirectoryPath">移动到的目录的绝对路径</param>
        public static void Move(string sourceFilePath, string descDirectoryPath)
        {
            string sourceName = GetFileName(sourceFilePath);
            if (IsExistDirectory(descDirectoryPath))
            {
                //如果目标中存在同名文件,则删除
                if (IsExistFile(descDirectoryPath + "\\" + sourceFilePath))
                {
                    DeleteFile(descDirectoryPath + "\\" + sourceFilePath);
                }
                else
                {
                    //将文件移动到指定目录
                    File.Move(sourceFilePath, descDirectoryPath + "\\" + sourceFilePath);
                }
            }
        }
        #endregion

        #region 将源文件的内容复制到目标文件中
        /// <summary>
        /// 将源文件的内容复制到目标文件中
        /// </summary>
        /// <param name="sourceFilePath">源文件的绝对路径</param>
        /// <param name="descDirectoryPath">目标文件的绝对路径</param>
        public static void Copy(string sourceFilePath, string descDirectoryPath)
        {
            File.Copy(sourceFilePath, descDirectoryPath, true);
        }
        #endregion

        #region 从文件的绝对路径中获取文件名( 不包含扩展名 )
        /// <summary>
        /// 从文件的绝对路径中获取文件名( 不包含扩展名 )
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param> 
        public static string GetFileName(string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            return file.Name;
        }
        #endregion

        #region 获取文件的后缀名
        /// <summary>
        /// 获取文件的后缀名
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static string GetExtension(string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            return file.Extension;
        }

        /// <summary>
        /// 返回文件扩展名，不含“.”
        /// </summary>
        /// <param name="filepath">文件全名称</param>
        /// <returns>string</returns>
        public static string GetFileExt(string filepath)
        {
            if (string.IsNullOrEmpty(filepath))
            {
                return "";
            }
            if (filepath.LastIndexOf(".", StringComparison.Ordinal) > 0)
            {
                return filepath.Substring(filepath.LastIndexOf(".", StringComparison.Ordinal) + 1); //文件扩展名，不含“.”
            }
            return "";
        }
        #endregion

        #region 删除指定文件
        /// <summary>
        /// 删除指定文件
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static void DeleteFile(string filePath)
        {
            if (IsExistFile(filePath))
            {
                File.Delete(filePath);
            }
        }
        #endregion

        #region 删除指定目录及其所有子目录
        /// <summary>
        /// 删除指定目录及其所有子目录
        /// </summary>
        /// <param name="directoryPath">文件的绝对路径</param>
        public static void DeleteDirectory(string directoryPath)
        {
            if (IsExistDirectory(directoryPath))
            {
                Directory.Delete(directoryPath);
            }
        }
        #endregion

        #region 清空指定目录下所有文件及子目录,但该目录依然保存.
        /// <summary>
        /// 清空指定目录下所有文件及子目录,但该目录依然保存.
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>
        public static void ClearDirectory(string directoryPath)
        {
            if (!IsExistDirectory(directoryPath)) return;
            //删除目录中所有的文件
            string[] fileNames = GetFileNames(directoryPath);
            for (int i = 0; i < fileNames.Length; i++)
            {
                DeleteFile(fileNames[i]);
            }
            //删除目录中所有的子目录
            string[] directoryNames = GetDirectories(directoryPath);
            for (int i = 0; i < directoryNames.Length; i++)
            {
                DeleteDirectory(directoryNames[i]);
            }
        }
        #endregion

        #region  剪切  粘贴
        /// <summary>
        /// 剪切文件
        /// </summary>
        /// <param name="source">原路径</param> 
        /// <param name="destination">新路径</param> 
        public bool FileMove(string source, string destination)
        {
            bool ret = false;
            FileInfo file_s = new FileInfo(source);
            FileInfo file_d = new FileInfo(destination);
            if (file_s.Exists)
            {
                if (!file_d.Exists)
                {
                    file_s.MoveTo(destination);
                    ret = true;
                }
            }

            Console.WriteLine(ret == true ? "剪切文件成功！" : "'剪切文件失败！");
            return ret;
        }
        #endregion

        #region 检测指定目录是否为空
        /// <summary>
        /// 检测指定目录是否为空
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>  
        public static bool IsEmptyDirectory(string directoryPath)
        {
            //判断文件是否存在
            string[] fileNames = GetFileNames(directoryPath);
            if (fileNames.Length > 0)
            {
                return false;
            }
            //判断是否存在文件夹
            string[] directoryNames = GetDirectories(directoryPath);
            if (directoryNames.Length > 0)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 获取指定目录中所有文件列表
        /// <summary>
        /// 获取指定目录中所有文件列表
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>  
        public static string[] GetFileNames(string directoryPath)
        {
            if (!IsExistDirectory(directoryPath))
            {
                throw new FileNotFoundException();
            }
            return Directory.GetFiles(directoryPath);
        }
        #endregion

        #region 获取指定目录中的子目录列表
        /// <summary>
        /// 获取指定目录中所有子目录列表,若要搜索嵌套的子目录列表,请使用重载方法
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>
        public static string[] GetDirectories(string directoryPath)
        {
            return Directory.GetDirectories(directoryPath);
        }

        /// <summary>
        /// 获取指定目录及子目录中所有子目录列表
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>
        /// <param name="searchPattern">模式字符串，"*"代表0或N个字符，"?"代表1个字符。
        /// 范例："Log*.xml"表示搜索所有以Log开头的Xml文件。</param>
        /// <param name="isSearchChild">是否搜索子目录</param>
        public static string[] GetDirectories(string directoryPath, string searchPattern, bool isSearchChild)
        {
            return Directory.GetDirectories(directoryPath, searchPattern, isSearchChild ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        }
        #endregion

        #region 获取一个文件的长度
        /// <summary> 
        /// 获取一个文件的长度,单位为Byte 
        /// </summary> 
        /// <param name="filePath">文件的绝对路径</param>         
        public static int GetFileSize(string filePath)
        {
            //创建一个文件对象 
            FileInfo fi = new FileInfo(filePath);
            //获取文件的大小 
            return (int)fi.Length;
        }
        /// <summary> 
        /// 获取一个文件的长度,单位为KB 
        /// </summary> 
        /// <param name="filePath">文件的路径</param>         
        public static double GetFileSizeByKb(string filePath)
        {
            //创建一个文件对象 
            FileInfo fi = new FileInfo(filePath);
            //获取文件的大小 
            return Math.Round(Convert.ToDouble(filePath.Length) / 1024, 2);// ConvertHelper.ToDouble(ConvertHelper.ToDouble(fi.Length) / 1024, 1);
        }

        /// <summary> 
        /// 获取一个文件的长度,单位为MB 
        /// </summary> 
        /// <param name="filePath">文件的路径</param>         
        public static double GetFileSizeByMb(string filePath)
        {
            //创建一个文件对象 
            FileInfo fi = new FileInfo(filePath);
            //获取文件的大小 
            return Math.Round(Convert.ToDouble(Convert.ToDouble(fi.Length) / 1024 / 1024), 2);
        }

        #endregion

        #region 获取文件大小并以B，KB，GB，TB
        /// <summary>
        /// 计算文件大小函数(保留两位小数),Size为字节大小
        /// </summary>
        /// <param name="size">初始文件大小</param>
        /// <returns></returns>
        public static string ToFileSize(long size)
        {
            string m_strSize = "";
            long FactSize = 0;
            FactSize = size;
            if (FactSize < 1024.00)
                m_strSize = FactSize.ToString("F2") + " 字节";
            else if (FactSize >= 1024.00 && FactSize < 1048576)
                m_strSize = (FactSize / 1024.00).ToString("F2") + " KB";
            else if (FactSize >= 1048576 && FactSize < 1073741824)
                m_strSize = (FactSize / 1024.00 / 1024.00).ToString("F2") + " MB";
            else if (FactSize >= 1073741824)
                m_strSize = (FactSize / 1024.00 / 1024.00 / 1024.00).ToString("F2") + " GB";
            return m_strSize;
        }
        #endregion

        #region 获取所有文件夹及子文件夹
        /// <summary>
        /// 获取所有文件夹及子文件夹
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public static List<ArrayFiles> GetDirs(string dirPath)
        {
            var list = new List<ArrayFiles>();
            return GetArrys(dirPath, 0, list);
        }

        private static int zdId = 0;
        private static List<ArrayFiles> GetArrys(string dirPath, int pid, List<ArrayFiles> list)
        {
            if (!Directory.Exists(dirPath)) return list;
            if (Directory.GetDirectories(dirPath).Length <= 0) return list;
            foreach (string path in Directory.GetDirectories(dirPath))
            {
                zdId++;
                var model = new ArrayFiles()
                {
                    id = zdId,
                    name = path.Substring(path.LastIndexOf('\\') + 1, path.Length - (path.LastIndexOf('\\') + 1)),
                    pId = pid,
                    open = false,
                    target = "DeployBase",
                    url = path
                };
                list.Add(model);
                GetArrys(path, model.id, list);
            }
            return list;
        }

        public class ArrayFiles
        {
            public int id { get; set; }
            public int pId { get; set; }
            public string name { get; set; }
            public Boolean open { get; set; }
            public string target { get; set; }
            public string url { get; set; }
        }
        #endregion

        #region 将文件读取到字符串中
        /// <summary>
        /// 将文件读取到字符串中
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static string FileToString(string filePath)
        {
            return FileToString(filePath, Encoding.UTF8);
        }
        /// <summary>
        /// 将文件读取到字符串中
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        /// <param name="encoding">字符编码</param>
        public static string FileToString(string filePath, Encoding encoding)
        {
            //创建流读取器
            StreamReader reader = new StreamReader(filePath, encoding);
            try
            {
                //读取流
                return reader.ReadToEnd();
            }
            finally
            {
                //关闭流读取器
                reader.Close();
            }
        }
        #endregion

        #region 重命名文件
        /// <summary>
        /// 将文件读取到字符串中
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static void FileReName(string sourcePath, string newPath)
        {
            Directory.Move(MapPath(sourcePath), MapPath(newPath));
        }
        #endregion

        #region 读取/写入文件
        public static string ReadFile(string fullName)
        {
            //  Encoding code = Encoding.GetEncoding(); //Encoding.GetEncoding("gb2312");
            var str = "";
            if (!File.Exists(fullName))
            {
                return str;
            }
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(fullName);
                str = sr.ReadToEnd(); // 读取文件
            }
            catch
            {
                // ignored
            }

            sr?.Close();
            sr?.Dispose();
            return str;
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="path">路径 </param>
        /// <param name="fileName">文件名</param>
        /// <param name="content">写入的内容</param>
        /// <param name="appendToLast">是否将内容添加到未尾,默认不添加</param>
        public static void WriteFile(string path, string fileName, string content, bool appendToLast = false)
        {
            if (!Directory.Exists(path))//如果不存在就创建file文件夹
                Directory.CreateDirectory(path);

            using (FileStream stream = File.Open(path + fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] by = Encoding.Default.GetBytes(content);
                if (appendToLast)
                {
                    stream.Position = stream.Length;
                }
                else
                {
                    stream.SetLength(0);
                }
                stream.Write(by, 0, by.Length);
            }
        }
        #endregion

        #region 获得文件目录

        public static List<FileDirectory> GetFileDirectory(string path)
        {
            try
            {
                var dir = new DirectoryInfo(path);
                var list = new List<FileDirectory>()
            {
                new FileDirectory()
                {
                    Path = "根目录",
                    Children = GetFileDirectoryNode(dir,"")
                }
            };
                return list;
            }
            catch (Exception)
            {
                return new List<FileDirectory>()
            {
                new FileDirectory()
                {
                    Path = "根目录",
                    Children = null
                }
            };
            }
        }

        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="theDir"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<FileDirectory> GetFileDirectoryNode(DirectoryInfo theDir, string path)
        {
            var list = new List<FileDirectory>();
            var subDirectories = theDir.GetDirectories();
            foreach (var item in theDir.GetDirectories())
            {
                list.Add(new FileDirectory()
                {
                    Path = item.Name,
                    Routes = path + "/" + item.Name,
                    Children = GetFileDirectoryNode(item, path + "/" + item.Name)
                });
            }
            return list;
        }

        /// <summary>
        /// 文件目录
        /// </summary>
        public class FileDirectory
        {
            public string Path { get; set; }

            public string Routes { get; set; }

            public List<FileDirectory> Children { get; set; }
        }

        #endregion

        #region 获得文件目录下的文件，支持子目录

        /// <summary>
        /// 获得指定文件夹下面的所有文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileType"></param>
        /// <param name="staticFiles"></param>
        /// <returns></returns>
        public static List<FilesInfo> ResolveFileInfo(string path, string fileType, string staticFiles = "")
        {
            string[] folders = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
            var Files = new List<FilesInfo>();

            foreach (var fsi in new DirectoryInfo(path).GetFiles())
            {
                var fileExt = fsi.Extension.Replace(".", "");
                switch (string.IsNullOrEmpty(fileType))
                {
                    case false when fileType == "image" && fileExt.IsImage():
                    case false when fileType == "file" && !fileExt.IsImage():
                        Files.Add(new FilesInfo()
                        {
                            Name = fsi.Name,
                            FullName = fsi.FullName,
                            FileExt = fsi.Extension,
                            FileOriginalSize = fsi.Length,
                            FileSize = FileSizeTransf(fsi.Length),
                            FileName = fsi.FullName.Replace(staticFiles, ""),
                            CreateDate = fsi.CreationTime,
                            LastWriteDate = fsi.LastWriteTime,
                            LastAccessDate = fsi.LastAccessTime
                        });
                        break;
                    default:
                        {
                            if (string.IsNullOrEmpty(fileType))
                            {
                                Files.Add(new FilesInfo()
                                {
                                    Name = fsi.Name,
                                    FullName = fsi.FullName,
                                    FileExt = fsi.Extension,
                                    FileOriginalSize = fsi.Length,
                                    FileSize = FileSizeTransf(fsi.Length),
                                    FileName = fsi.FullName.Replace(staticFiles, ""),
                                    CreateDate = fsi.CreationTime,
                                    LastWriteDate = fsi.LastWriteTime,
                                    LastAccessDate = fsi.LastAccessTime
                                });
                            }

                            break;
                        }
                }
            }

            foreach (var folder in folders)
            {
                foreach (var fsi in new DirectoryInfo(folder).GetFiles())
                {
                    var fileExt = fsi.Extension.Replace(".", "");
                    switch (string.IsNullOrEmpty(fileType))
                    {
                        case false when fileType == "image" && fileExt.IsImage():
                        case false when fileType == "file" && !fileExt.IsImage():
                            Files.Add(new FilesInfo()
                            {
                                Name = fsi.Name,
                                FullName = fsi.FullName,
                                FileExt = fsi.Extension,
                                FileOriginalSize = fsi.Length,
                                FileSize = FileSizeTransf(fsi.Length),
                                FileName = fsi.FullName.Replace(staticFiles, ""),
                                CreateDate = fsi.CreationTime,
                                LastWriteDate = fsi.LastWriteTime,
                                LastAccessDate = fsi.LastAccessTime
                            });
                            break;
                        default:
                            {
                                if (string.IsNullOrEmpty(fileType))
                                {
                                    Files.Add(new FilesInfo()
                                    {
                                        Name = fsi.Name,
                                        FullName = fsi.FullName,
                                        FileExt = fsi.Extension,
                                        FileOriginalSize = fsi.Length,
                                        FileSize = FileSizeTransf(fsi.Length),
                                        FileName = fsi.FullName.Replace(staticFiles, ""),
                                        CreateDate = fsi.CreationTime,
                                        LastWriteDate = fsi.LastWriteTime,
                                        LastAccessDate = fsi.LastAccessTime
                                    });
                                }

                                break;
                            }
                    }
                }
            }

            return Files;
        }

        /// <summary>
        ///  文件大小转为B、KB、MB、GB...
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string FileSizeTransf(long size)
        {
            String[] units = new String[] { "B", "KB", "MB", "GB", "TB", "PB" };
            long mod = 1024;
            int i = 0;
            while (size > mod)
            {
                size /= mod;
                i++;
            }
            return size + units[i];

        }

        public static string PhysicalToVirtual(string physicalPath)
        {
            return physicalPath.Replace(_contentRootPath, "").Replace(_directorySeparatorChar, "/");
        }


        /// <summary>
        /// 文件内容
        /// </summary>
        public class FilesInfo
        {
            /// <summary>
            /// 文件名称
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// 文件物理路径
            /// </summary>
            public string FullName { get; set; }
            /// <summary>
            /// 扩展名
            /// </summary>
            public string FileExt { get; set; }
            /// <summary>
            /// 原始大小（字节）
            /// </summary>
            public long FileOriginalSize { get; set; }
            /// <summary>
            /// 文件大小
            /// </summary>
            public string FileSize { get; set; }
            /// <summary>
            /// 文件虚拟路径
            /// </summary>
            public string FileName { get; set; }
            /// <summary>
            /// 文件类型
            /// </summary>
            public string FileStyle { get; set; }
            /// <summary>
            /// 文件图标
            /// </summary>
            public string FileIcon { get; set; }
            /// <summary>
            /// 创建时间
            /// </summary>
            public DateTime CreateDate { get; set; }
            /// <summary>
            /// 最后修改时间
            /// </summary>
            public DateTime LastWriteDate { get; set; }
            /// <summary>
            /// 最后访问时间
            /// </summary>
            public DateTime LastAccessDate { get; set; }

        }

        #endregion

        #region 文件格式
        /// <summary>
        /// 是否可添加水印
        /// </summary>
        /// <param name="_fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        public static bool IsCanWater(string _fileExt)
        {
            var images = new List<string> { "jpg", "jpeg" };
            if (images.Contains(_fileExt.ToLower())) return true;
            return false;
        }
        /// <summary>
        /// 是否为图片
        /// </summary>
        /// <param name="_fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        public static bool IsImage(string _fileExt)
        {
            var images = new List<string> { "bmp", "gif", "jpg", "jpeg", "png" };
            if (images.Contains(_fileExt.ToLower())) return true;
            return false;
        }
        /// <summary>
        /// 是否为视频
        /// </summary>
        /// <param name="_fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        public static bool IsVideos(string _fileExt)
        {
            var videos = new List<string> { "rmvb", "mkv", "ts", "wma", "avi", "rm", "mp4", "flv", "mpeg", "mov", "3gp", "mpg" };
            if (videos.Contains(_fileExt.ToLower())) return true;
            return false;
        }
        /// <summary>
        /// 是否为音频
        /// </summary>
        /// <param name="_fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        public static bool IsMusics(string _fileExt)
        {
            var musics = new List<string> { "mp3", "wav" };
            if (musics.Contains(_fileExt.ToLower())) return true;
            return false;
        }
        /// <summary>
        /// 是否为文档
        /// </summary>
        /// <param name="_fileExt">文件扩展名，不含“.”</param>
        /// <returns></returns>
        public static bool IsDocument(string _fileExt)
        {
            var documents = new List<string> { "doc", "docx", "xls", "xlsx", "ppt", "pptx", "txt", "pdf" };
            if (documents.Contains(_fileExt.ToLower())) return true;
            return false;
        }
        #endregion
    }

    /// <summary>
    /// 远程文件下载
    /// </summary>
    public class HttpDldFile
    {
        /// <summary>
        /// Http方式下载文件
        /// </summary>
        /// <param name="url">http地址</param>
        /// <param name="localfile">本地文件</param>
        /// <returns></returns>
        public bool Download(string url, string localfile)
        {
            bool flag = false;
            long startPosition = 0; // 上次下载的文件起始位置
            FileStream writeStream; // 写入本地文件流对象

            long remoteFileLength = GetHttpLength(url);// 取得远程文件长度
                                                       //System.Console.WriteLine("remoteFileLength=" + remoteFileLength);
            if (remoteFileLength == 745)
            {
                System.Console.WriteLine("远程文件不存在.");
                return false;
            }

            // 判断要下载的文件夹是否存在
            if (File.Exists(localfile))
            {

                writeStream = File.OpenWrite(localfile);             // 存在则打开要下载的文件
                startPosition = writeStream.Length;                  // 获取已经下载的长度

                if (startPosition >= remoteFileLength)
                {
                    System.Console.WriteLine("本地文件长度" + startPosition + "已经大于等于远程文件长度" + remoteFileLength);
                    writeStream.Close();

                    return false;
                }
                else
                {
                    writeStream.Seek(startPosition, SeekOrigin.Current); // 本地文件写入位置定位
                }
            }
            else
            {
                writeStream = new FileStream(localfile, FileMode.Create);// 文件不保存创建一个文件
                startPosition = 0;
            }


            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(url);// 打开网络连接

                if (startPosition > 0)
                {
                    myRequest.AddRange((int)startPosition);// 设置Range值,与上面的writeStream.Seek用意相同,是为了定义远程文件读取位置
                }


                Stream readStream = myRequest.GetResponse().GetResponseStream();// 向服务器请求,获得服务器的回应数据流


                byte[] btArray = new byte[512];// 定义一个字节数据,用来向readStream读取内容和向writeStream写入内容
                int contentSize = readStream.Read(btArray, 0, btArray.Length);// 向远程文件读第一次

                long currPostion = startPosition;

                while (contentSize > 0)// 如果读取长度大于零则继续读
                {
                    currPostion += contentSize;
                    int percent = (int)(currPostion * 100 / remoteFileLength);
                    System.Console.WriteLine("percent=" + percent + "%");

                    writeStream.Write(btArray, 0, contentSize);// 写入本地文件
                    contentSize = readStream.Read(btArray, 0, btArray.Length);// 继续向远程文件读取
                }

                //关闭流
                writeStream.Close();
                readStream.Close();

                flag = true;        //返回true下载成功
            }
            catch (Exception)
            {
                writeStream.Close();
                flag = false;       //返回false下载失败
            }

            return flag;
        }

        // 从文件头得到远程文件的长度
        private static long GetHttpLength(string url)
        {
            long length = 0;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);// 打开网络连接
            HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();

            if (rsp.StatusCode == HttpStatusCode.OK)
            {
                length = rsp.ContentLength;// 从文件头得到远程文件的长度
            }

            rsp.Close();
            return length;
        }
    }
}
