using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAppFramewrok.Application.Stared;

namespace ZTAppFramework.Admin.Model.Sys
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/29 9:15:18 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class SysMenuModel:BindableBase
    {
        private bool _IsSelected;

        public bool IsSelected
        {
            get { return _IsSelected; }
            set { SetProperty(ref _IsSelected, value); }
        }


        private bool _IsChecked;

        public bool IsChecked
        {
            get { return _IsChecked; }
            set { SetProperty(ref _IsChecked, value); }
        }
        /// <summary>
        /// 唯一编号
        /// </summary>
        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        /// <summary>
        /// 菜单名称
        /// </summary>

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }
        /// <summary>
        /// 父节点
        /// </summary>
        private long _ParentId;
        public long ParentId
        {
            get { return _ParentId; }
            set { SetProperty(ref _ParentId, value); }
        }
        /// <summary>
        /// 父节点集合组
        /// </summary>
        private List<string> _ParentIdList;
        public List<string> ParentIdList
        {
            get { return _ParentIdList; }
            set { SetProperty(ref _ParentIdList, value); }
        }
        /// <summary>
        /// 权限标识
        /// </summary>
        private string _Code;
        public string Code
        {
            get { return _Code; }
            set { SetProperty(ref _Code, value); }
        }

        /// <summary>
        /// 路由地址
        /// </summary>
        private string _Urls;
        public string Urls
        {
            get { return _Urls; }
            set { SetProperty(ref _Urls, value); }
        }

        /// <summary>
        /// 重定向
        /// </summary>
        private string _Redirect;
        public string Redirect
        {
            get { return _Redirect; }
            set { SetProperty(ref _Redirect, value); }
        }
        /// <summary>
        /// Vue文件路径
        /// </summary>
        private string _VuePath;
        public string VuePath
        {
            get { return _VuePath; }
            set { SetProperty(ref _VuePath, value); }
        }
        /// <summary>
        /// 菜单图标
        /// </summary>
        private string _Icon;
        public string Icon
        {
            get { return _Icon; }
            set { SetProperty(ref _Icon, value); }
        }
        /// <summary>
        /// 高亮
        /// </summary>
        private string _Active;
        public string Active
        {
            get { return _Active; }
            set { SetProperty(ref _Active, value); }
        }
        /// <summary>
        /// 颜色
        /// </summary>
        private string _Color;
        public string Color
        {
            get { return _Color; }
            set { SetProperty(ref _Color, value); }
        }
        /// <summary>
        /// 排序
        /// </summary>

        private int _Sort=1;
        public int Sort
        {
            get { return _Sort; }
            set { SetProperty(ref _Sort, value); }
        }
        /// <summary>
        /// 状态
        /// </summary>
        private bool _Status=true;
        public bool Status
        {
            get { return _Status; }
            set { SetProperty(ref _Status, value); }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        private bool _IsDel;
        public bool IsDel
        {
            get { return _IsDel; }
            set { SetProperty(ref _IsDel, value); }
        }
        /// <summary>
        /// 菜单类型
        /// </summary>
        private string _Types;
        public string Types
        {
            get { return _Types; }
            set { SetProperty(ref _Types, value); }
        }

        ///// <summary>
        ///// 接口权限
        ///// </summary>
        //public List<SysMenuApiUrl> Api { get; set; } = new();

        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime _CreateTime = DateTime.Now;
        public DateTime CreateTime
        {
            get { return _CreateTime ; }
            set { SetProperty(ref _CreateTime , value); }
        }

        /// <summary>
        /// 创建人
        /// </summary>
        private string _CreateUser;
        public string CreateUser
        {
            get { return _CreateUser; }
            set { SetProperty(ref _CreateUser, value); }
        }
        /// <summary>
        /// 接口权限
        /// </summary>
        private List<SysMenuApiUrl> _Api;
        public List<SysMenuApiUrl> Api
        {
            get { return _Api; }
            set { SetProperty(ref _Api, value); }
        }

     


        private ObservableCollection<SysMenuModel> _Childer;
        public ObservableCollection<SysMenuModel> Childer
        {
            get { return _Childer; }
            set { SetProperty(ref _Childer, value); }
        }
    }
}
