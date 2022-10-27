using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZTAppFramework.Template.Global;
using ZTAppFramework.Admin.Model.Sys;
using ZTAppFramework.Application.Service;
using ZTAppFramewrok.Application.Stared;
using ZTAppFramewrok.Application.Stared.Sys;
using ZTAppFreamework.Stared.ViewModels;

namespace ZTAppFramework.Admin.ViewModels
{
    public class SysPostModifyViewModel : ZTDialogViewModel
    {

        #region UI
   
     

        private SysPostModel  _PostModel;


        public SysPostModel PostModel
        {
            get { return _PostModel; }
            set { SetProperty(ref _PostModel, value); }
        }

        #endregion

        #region Command
        public DelegateCommand<string> StatusChanageCommand { get; }
        #endregion

        #region Service
        private readonly SysPostService _sysPostService;
        #endregion

        #region 属性
        public bool IsEdit { get; set; }
        #endregion
        public SysPostModifyViewModel(SysPostService  sysPostService)
        {
            _sysPostService = sysPostService;
            StatusChanageCommand = new(StatusChanage);
        }


        #region Event
        private void StatusChanage(string Param)
        {
            try
            {
                bool Status = bool.Parse(Param);
                PostModel.Status = Status;
            }
            catch (Exception)
            {


            }
        }

     
        async Task<bool> Add()
        {

            var Version = Verify(Map<SysPostParm>(PostModel));
            if (!Version.IsValid)
            {
                Show("提示", string.Join('\n', Version.Errors));
                return false;
            }

            var r = await _sysPostService.Add(Map<SysPostParm>(PostModel));
            if (r.Success)
            {
                Show("提示", r.Message);
                return true;
            }
            return false;
        }
        async Task<bool> Modif()
        {
            var r = await _sysPostService.Modif(Map<SysPostParm>(PostModel));
            if (r.Success)
            {
                Show("提示", r.Message);
                return true;
            }
            return false;
        }
        #endregion


       
        #region Override
        public override void Cancel()
        {
            OnDialogClosed(ZTAppFramework.Template.Enums.ButtonResult.No);
        }

        public override async void OnSave()
        {
            await SetBusyAsync(async () =>
            {
                await Task.Delay(1000);
                if (IsEdit)
                {
                    if (!await Modif())
                        return;
                }
                else
                {
                    if (!await Add())
                        return;
                }
                OnDialogClosed();
            });
        }

        public override  void OnDialogOpened(IZTDialogParameter parameters)
        {
            base.OnDialogOpened(parameters);
            IsEdit = true;
            var Model = parameters.GetValue<SysPostModel>("Param");
            if (Model == null)
            {
                PostModel = new SysPostModel();
                IsEdit = false;
            }
            else
            {
                PostModel = DeepCopy<SysPostModel>(Model);
            }
        }
        #endregion


    }
}
