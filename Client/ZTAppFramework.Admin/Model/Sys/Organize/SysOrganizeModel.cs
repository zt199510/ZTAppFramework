using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramework.Admin.Model.Sys
{ 
    /// <summary>
    /// 组织机构
    /// </summary>
    public class SysOrganizeModel:BindableBase
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
        private long _id;
        public long Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
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
        /// 部门名称
        /// </summary>
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        /// <summary>
        /// 机构编码
        /// </summary>

        private string _Number;
        public string Number
        {
            get { return _Number; }
            set { SetProperty(ref _Number, value); }
        }
        /// <summary>
        /// 父节点集合
        /// </summary>
        private List<string> _ParentIdList;
        public List<string> ParentIdList
        {
            get { return _ParentIdList; }
            set { SetProperty(ref _ParentIdList, value); }
        }

        /// <summary>
        /// 部门层级
        /// </summary>


        private int _Layer=0;
        public int Layer
        {
            get { return _Layer; }
            set { SetProperty(ref _Layer, value); }
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
        /// 删除状态
        /// </summary>

        private bool _IsDel=false;
        public bool IsDel
        {
            get { return _IsDel; }
            set { SetProperty(ref _IsDel, value); }
        }
        /// <summary>
        /// 部门负责人
        /// </summary>
        private string _LeaderUser;
        public string LeaderUser
        {
            get { return _LeaderUser; }
            set { SetProperty(ref _LeaderUser, value); }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        private string _LeaderMobile;
        public string LeaderMobile
        {
            get { return _LeaderMobile; }
            set { SetProperty(ref _LeaderMobile, value); }
        }
        /// <summary>
        /// 联系邮箱
        /// </summary>
        private string _LeaderEmail;
        public string LeaderEmail
        {
            get { return _LeaderEmail; }
            set { SetProperty(ref _LeaderEmail, value); }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime _CreateTime=DateTime.Now;
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
        /// <summary>
        /// 修改人
        /// </summary>

        private string _UpdateUser;
        public string UpdateUser
        {
            get { return _UpdateUser; }
            set { SetProperty(ref _UpdateUser, value); }
        }

    }
}
