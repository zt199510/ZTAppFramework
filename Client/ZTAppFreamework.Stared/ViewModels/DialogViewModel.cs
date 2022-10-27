using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAppFramework.Template.Global;

namespace ZTAppFreamework.Stared.ViewModels
{
    public abstract class DialogViewModel : ViewModelBase, IDialogAware
    {

        public DelegateCommand SaveCommand { get; set; }

        public DelegateCommand CancelCommand { get; set; }

        public string Title { get; set; }

        public DialogViewModel()
        {
            SaveCommand = new DelegateCommand(OnSave);
            CancelCommand = new DelegateCommand(Cancel);
        }

       

        #region 基础抽象


        public event Action<IDialogResult> RequestClose;

        public abstract void Cancel();

        public abstract void OnSave();

        public  virtual bool CanCloseDialog() => true;

        public void OnDialogClosed(ButtonResult result)
        {
            RequestClose?.Invoke(new DialogResult(result));
        }

        public void OnDialogClosed(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public void OnDialogClosed() => OnDialogClosed(ButtonResult.OK);

        

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
           
        }

        #endregion
    }
}
