using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramework.Admin.Model.Sys
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/27 16:11:22 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class SysAdminModel:BindableBase
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
        /// 所属角色
        /// </summary>
        private List<string> _RoleGroup;
        public List<string> RoleGroup
        {
            get { return _RoleGroup; }
            set { SetProperty(ref _RoleGroup, value); }
        }
        /// <summary>
        /// 所属角色信息
        /// </summary>
        private string _RoleGroupName;
        public string RoleGroupName
        {
            get { return _RoleGroupName; }
            set { SetProperty(ref _RoleGroupName, value); }
        }
        /// <summary>
        /// 所属角色，包含父级
        /// </summary>
        private List<List<string>> _RoleGroupParent;
        public List<List<string>> RoleGroupParent
        {
            get { return _RoleGroupParent; }
            set { SetProperty(ref _RoleGroupParent, value); }
        }
        /// <summary>
        /// 所属岗位
        /// </summary>
        private List<string> _PostGroup;
        public List<string> PostGroup
        {
            get { return _PostGroup; }
            set { SetProperty(ref _PostGroup, value); }
        }
        /// <summary>
        /// 所属部门
        /// </summary>
        private long _OrganizeId;
        public long OrganizeId
        {
            get { return _OrganizeId; }
            set { SetProperty(ref _OrganizeId, value); }
        }
        /// <summary>
        /// 所属上级部门组
        /// </summary>
        private List<string> _OrganizeIdList;
        public List<string> OrganizeIdList
        {
            get { return _OrganizeIdList; }
            set { SetProperty(ref _OrganizeIdList, value); }
        }
        /// <summary>
        /// 登录账号
        /// </summary>
        private string _LoginAccount;
        public string LoginAccount
        {
            get { return _LoginAccount; }
            set { SetProperty(ref _LoginAccount, value); }
        }
        /// <summary>
        /// 登录密码
        /// </summary>
        private string _LoginPassWord;
        public string LoginPassWord
        {
            get { return _LoginPassWord; }
            set { SetProperty(ref _LoginPassWord, value); }
        }
        /// <summary>
        /// 头像
        /// </summary>
        private string _HeadPic;
        public string HeadPic
        {
            get { return _HeadPic; }
            set { SetProperty(ref _HeadPic, value); }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        private string _FullName;
        public string FullName
        {
            get { return _FullName; }
            set { SetProperty(ref _FullName, value); }
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        private string _Mobile;
        public string Mobile
        {
            get { return _Mobile; }
            set { SetProperty(ref _Mobile, value); }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { SetProperty(ref _Email, value); }
        }
        /// <summary>
        /// 性别
        /// </summary>
        private string _Sex;
        public string Sex
        {
            get { return _Sex; }
            set { SetProperty(ref _Sex, value); }
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
        /// 备注
        /// </summary>
        private string _Summary;
        public string Summary
        {
            get { return _Summary; }
            set { SetProperty(ref _Summary, value); }
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
        /// <summary>
        /// 登录时间
        /// </summary>
        private DateTime _LoginTime;
        public DateTime LoginTime
        {
            get { return _LoginTime; }
            set { SetProperty(ref _LoginTime, value); }
        }
        /// <summary>
        /// 上次登录时间
        /// </summary>
        private DateTime _UpLoginTime;
        public DateTime UpLoginTime
        {
            get { return _UpLoginTime; }
            set { SetProperty(ref _UpLoginTime, value); }
        }
        /// <summary>
        /// 登录次数
        /// </summary>
        private int _LoginCount;
        public int LoginCount
        {
            get { return _LoginCount; }
            set { SetProperty(ref _LoginCount, value); }
        }
    }
}
