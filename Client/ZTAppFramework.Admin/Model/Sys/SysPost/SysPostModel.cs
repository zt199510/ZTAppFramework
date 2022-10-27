using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramework.Admin.Model.Sys
{
    public class SysPostModel:BindableBase
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
        /// 岗位名称
        /// </summary>
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        /// <summary>
        /// 岗位编码
        /// </summary>
        private string _Number;
        public string Number
        {
            get { return _Number; }
            set { SetProperty(ref _Number, value); }
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
        /// 岗位状态
        /// </summary>
        private bool _Status;
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
        /// 备注信息
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
    }
}
