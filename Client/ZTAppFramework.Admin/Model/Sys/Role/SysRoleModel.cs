using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramework.Admin.Model.Sys
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间    ：  2022/9/26 14:23:34 
    /// Description   ：  角色管理模型
    ///********************************************/
    /// </summary>
    public class SysRoleModel: BindableBase
    {

        private bool _IsSelected;

        public bool IsSelected
        {
            get { return _IsSelected; }
            set { SetProperty(ref _IsSelected, value); }
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
        /// 角色名称
        /// </summary>

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        /// <summary>
        /// 角色父节点
        /// </summary>

        private long _ParentId;
        public long ParentId
        {
            get { return _ParentId; }
            set { SetProperty(ref _ParentId, value); }
        }
        /// <summary>
        /// 父节点结合
        /// </summary>
        private List<string> _ParentIdList;
        public List<string> ParentIdList
        {
            get { return _ParentIdList; }
            set { SetProperty(ref _ParentIdList, value); }
        }
        /// <summary>
        /// 角色层级
        /// </summary>

        private int _Layer;
        public int Layer
        {
            get { return _Layer; }
            set { SetProperty(ref _Layer, value); }
        }
        /// <summary>
        /// 角色编号
        /// </summary>
        private string _Number;
        public string Number
        {
            get { return _Number; }
            set { SetProperty(ref _Number, value); }
        }
        /// <summary>
        /// 是否超级管理员
        /// </summary>

        private bool _IsSystem;
        public bool IsSystem
        {
            get { return _IsSystem; }
            set { SetProperty(ref _IsSystem, value); }
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
        /// 排序
        /// </summary>
        private int _Sort=1;
        public int Sort
        {
            get { return _Sort; }
            set { SetProperty(ref _Sort, value); }
        }
        /// <summary>
        /// 描述
        /// </summary>
   
        private string _Summary="";
        public string Summary
        {
            get { return _Summary; }
            set { SetProperty(ref _Summary, value); }
        }
        /// <summary>
        /// 控制台
        /// </summary>
        private string _Console;
        public string Console
        {
            get { return _Console; }
            set { SetProperty(ref _Console, value); }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime _CreateTime = DateTime.Now;
        public DateTime CreateTime
        {
            get { return _CreateTime; }
            set { SetProperty(ref _CreateTime, value); }
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
        /// 修改时间
        /// </summary>
        private DateTime _UpdateTime;
        public DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { SetProperty(ref _UpdateTime, value); }
        }

        private List<SysRoleModel> _Childer;
        public List<SysRoleModel> Childer
        {
            get { return _Childer; }
            set { SetProperty(ref _Childer, value); }
        }
    }
}
