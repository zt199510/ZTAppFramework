using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramework.Admin.Model.Menus
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间      ：  2022/9/6 11:08:06 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class MenuModel: BindableBase
    {

        public MenuModel()
        {
            Childer = new List<MenuModel>();
        }

        private bool _IsSelected;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set { SetProperty(ref _IsSelected, value); }
        }
        /// <summary>
        /// Desc:唯一标识Guid
        /// Default:
        /// Nullable:False
        /// </summary>           

        private string _Guid;
        public string guid
        {
            get { return _Guid; }
            set { SetProperty(ref _Guid, value); }
        }
        /// <summary>
        /// Desc:菜单父级Guid
        /// Default:
        /// Nullable:True
        /// </summary>           
        private string _parentGuid;
        public string parentGuid
        {
            get { return _parentGuid; }
            set { SetProperty(ref _parentGuid, value); }
        }
        /// <summary>
        /// 父级名称
        /// </summary>

        private string _parentName;
        public string parentName
        {
            get { return _parentName; }
            set { SetProperty(ref _parentName, value); }
        }

        /// <summary>
        /// Desc:菜单名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        private string _name;
        public string name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        /// <summary>
        /// Desc:菜单名称标识
        /// Default:
        /// Nullable:False
        /// </summary>           
        private string _nameCode;
        public string nameCode
        {
            get { return _nameCode; }
            set { SetProperty(ref _nameCode, value); }
        }
        /// <summary>
        /// Desc:所属父级的集合
        /// Default:
        /// Nullable:True
        /// </summary>           

        private string _parentGuidList;
        public string parentGuidList
        {
            get { return _parentGuidList; }
            set { SetProperty(ref _parentGuidList, value); }
        }
        /// <summary>
        /// Desc:菜单深度
        /// Default:
        /// Nullable:False
        /// </summary>           

        private int _layer;
        public int layer
        {
            get { return _layer; }
            set { SetProperty(ref _layer, value); }
        }


        /// <summary>
        /// Desc:菜单图标Class
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string icon { get; set; }


        /// <summary>
        /// Desc:菜单排序
        /// Default:0
        /// Nullable:False
        /// </summary>           
        private int _sort;
        public int sort
        {
            get { return _sort; }
            set { SetProperty(ref _sort, value); }
        }

        /// <summary>
        /// Desc:权限操作是否选中
        /// Default:0
        /// Nullable:False
        /// </summary>           
        private bool _isChecked;
        public bool isChecked
        {
            get { return _isChecked; }
            set { SetProperty(ref _isChecked, value); }
        }

        private List<MenuModel> _Childer;
        public List<MenuModel> Childer
        {
            get { return _Childer; }
            set { SetProperty(ref _Childer, value); }
        }
    }
}
