using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTAppFramework.Admin.Model.Users
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  WeiXiaolei
    /// 创建时间    ：  2022/9/22 13:58:30 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    public class OperatorWorkModel:BindableBase
    {
        private string _Account;
        public string Account
        {
            get { return _Account; }
            set { SetProperty(ref _Account, value); }
        }

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set { SetProperty(ref _fullName, value); }
        }

        private string _headPic;
        public string HeadPic
        {
            get { return _headPic; }
            set { SetProperty(ref _headPic, value); }
        }

        private string _sex;
        public string Sex
        {
            get { return _sex; }
            set { SetProperty(ref _sex, value); }
        }

        private List<string> _post;
        public List<string> Post
        {
            get { return _post; }
            set { SetProperty(ref _post, value); }
        }

        private List<string> _role;
        public List<string> Role
        {
            get { return _role; }
            set { SetProperty(ref _role, value); }
        }

        private string _organize;
        public string Organize
        {
            get { return _organize; }
            set { SetProperty(ref _organize, value); }
        }

        private DateTime _lastTime;
        public DateTime LastTime
        {
            get { return _lastTime; }
            set { SetProperty(ref _lastTime, value); }
        }
        private int _loginSum;
        public int LoginSum
        {
            get { return _loginSum; }
            set { SetProperty(ref _loginSum, value); }
        }

        private int _messageSum;
        public int MessageSum
        {
            get { return _messageSum; }
            set { SetProperty(ref _messageSum, value); }
        }
        private int _agencySum;
        public int AgencySum
        {
            get { return _agencySum; }
            set { SetProperty(ref _agencySum, value); }
        }
        private string _summary;
        public string Summary
        {
            get { return _summary; }
            set { SetProperty(ref _summary, value); }
        }
     
    }
}
