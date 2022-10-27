using AutoMapper;
using FluentValidation.Results;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Text;
using System.Xml.Serialization;
using ZTAppFramework.Template.Global;
using ZTAppFreamework.Stared.Validations;

namespace ZTAppFreamework.Stared.ViewModels
{
    public class ViewModelBase : BindableBase
    {

        public ViewModelBase()
        {
            mapper = ContainerLocator.Container.Resolve<IMapper>();
            validator = Prism.Ioc.ContainerLocator.Container.Resolve<GlobalValidator>();
        }
        private bool isBusy;
        private readonly IMapper mapper;
        protected readonly GlobalValidator validator;

        public bool IsNotBusy => !IsBusy;

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(IsNotBusy));
            }
        }
        private string _LodingMessage;

        public string LodingMessage
        {
            get { return _LodingMessage; }
            set { SetProperty(ref _LodingMessage, value); }
        }

        public virtual async Task SetBusyAsync(Func<Task> func)
        {
            IsBusy = true;
            try
            {
                await func();
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// 实体验证器方法
        /// </summary>
        /// <typeparam name="T">验证结果</typeparam>
        /// <param name="model">验证实体</param>
        /// <returns></returns>
        public virtual ValidationResult Verify<T>(T model, bool ShowError = true)
        {
            var validationResult = validator.Validate(model);

            if (!validationResult.IsValid && ShowError)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var item in validationResult.Errors)
                {
                    stringBuilder.AppendLine(item.ErrorMessage);
                }
                //AppDialogHelper.Warn(stringBuilder.ToString());
            }
            return validationResult;
        }


        /// <summary>
        /// 实体映射方法
        /// </summary>
        /// <typeparam name="T">最终类型</typeparam>
        /// <param name="model">映射实体</param>
        /// <returns></returns>
        public T Map<T>(object model) => mapper.Map<T>(model);


        #region 消息方法
        public void ShowDialog(string Title, string Message, System.Windows.MessageBoxButton type = System.Windows.MessageBoxButton.OK)
        {
            ZTDialogParameter dialogParameter = new ZTDialogParameter();
            dialogParameter.Add("Title", "消息");
            dialogParameter.Add("Messgae", Message);
            dialogParameter.Add("MessgaeButtonType", type);
            ZTDialog.ShowDialogWindow(AppView.DialogMessageName, dialogParameter, "window");
        }

        public void ShowDialog(string Title, string Message, Action<IZTDialogResult> Result, System.Windows.MessageBoxButton type= System.Windows.MessageBoxButton.OK)
        {
            
            ZTDialogParameter dialogParameter = new ZTDialogParameter();
            dialogParameter.Add("Title", "消息");
            dialogParameter.Add("Messgae", Message);
            dialogParameter.Add("MessgaeButtonType", type);
            ZTDialog.ShowDialogWindow(AppView.DialogMessageName, dialogParameter, Result, "window");
        }

        public void Show(string Title, string Message)
        {
            ZTDialogParameter dialogParameter = new ZTDialogParameter();
            dialogParameter.Add("Title", "消息");
            dialogParameter.Add("Messgae", Message);
            ZTDialog.ShowWindow(AppView.DialogMessageName, dialogParameter, "window");
        }
        #endregion

        #region 深拷贝
        public T DeepCopy<T>(T obj)
        {
            object retval;
            using (MemoryStream ms = new MemoryStream())
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                xml.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                retval = xml.Deserialize(ms);
                ms.Close();
            }
            return (T)retval;
        }

        #endregion
    }
}
