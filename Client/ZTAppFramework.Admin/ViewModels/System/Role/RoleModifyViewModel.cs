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
using ZTAppFreamework.Stared.ViewModels;

namespace ZTAppFramework.Admin.ViewModels
{
    public class RoleModifyViewModel : ZTDialogViewModel
    {
        #region UI
        private List<SysRoleModel> _RoleList;
        public List<SysRoleModel> RoleList
        {
            get { return _RoleList; }
            set { SetProperty(ref _RoleList, value); }
        }

        private SysRoleModel _SelectedItem;
        public SysRoleModel SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                if (SetProperty(ref _SelectedItem, value) && value != null)
                {

                    RoleModel.ParentIdList = RoleModel.ParentIdList ?? new List<string>();
                    RoleModel.ParentIdList.Clear();
                    foreach (var item in value.ParentIdList)
                    {
                        RoleModel.ParentIdList.Add(item);
                    }
                    if (!RoleModel.ParentIdList.Contains(value.Id.ToString()))
                        RoleModel.ParentIdList.Add(value.Id.ToString());
                    RoleModel.ParentId = value.Id;
                }

            }
        }

        private SysRoleModel _RoleModel;
    

        public SysRoleModel RoleModel
        {
            get { return _RoleModel; }
            set { SetProperty(ref _RoleModel, value); }
        }

        #endregion

        #region Command
        public DelegateCommand<string> StatusChanageCommand { get; }
        #endregion

        #region Service
        private readonly RoleService _roleService;
        #endregion

        #region 属性
        public bool IsEdit { get; set; }
        #endregion
        public RoleModifyViewModel(RoleService roleService)
        {
            _roleService = roleService;
            StatusChanageCommand = new (StatusChanage);
        }


        #region Event
        private void StatusChanage(string Param)
        {
            try
            {
                bool Status = bool.Parse(Param);
                RoleModel.Status = Status;
            }
            catch (Exception)
            {

                
            }
        }

        async Task GetRoleInfo(string Query = "")
        {
            var r = await _roleService.GetList(Query);
            if (r.Success)
                RoleList = Map<List<SysRoleModel>>(r.data);
            foreach (var item in RoleList)
            {
                string Name = "";
                List<string> hasOrganizeName = new List<string>();
                if (item.ParentIdList.Count > 0)
                {
                    for (int i = 0; i < item.ParentIdList.Count(); i++)
                    {
                        if (long.Parse(item.ParentIdList[i]) == item.Id) continue;
                        var info = RoleList.FirstOrDefault(x => x.Id == long.Parse(item.ParentIdList[i]));
                        if (info != null)
                        {
                            if (hasOrganizeName.Contains(info.Name)) continue;
                            hasOrganizeName.Add(info.Name);
                            Name += info.Name + "/";
                        }
                    }
                }
                if (string.IsNullOrEmpty(Name)) continue;
                item.Name = Name + item.Name;
            }

            RoleList.Insert(0, new SysRoleModel() { Name = "角色组", ParentId = 0, ParentIdList = new List<string>() { "0" } });
        }

        async Task<bool> Add()
        {
            if (RoleModel.ParentIdList.Count() > 1)
                RoleModel.ParentIdList.Remove("0");
            var Version = Verify(Map<SysRoleParm>(RoleModel));
            if (!Version.IsValid)
            {
                Show("提示", string.Join('\n', Version.Errors));
                return false;
            }


            var r = await _roleService.Add(Map<SysRoleParm>(RoleModel));
            if (r.Success)
            {
                Show("提示", r.Message);
                return true;
            }
            return false;
        }
        async Task<bool> Modif()
        {
            var r = await _roleService.Modif(Map<SysRoleParm>(RoleModel));
            if (r.Success)
            {
                Show("提示", r.Message);
                return true;
            }
            return false;
        }
        #endregion

        #region Overrdie

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

        public override async void OnDialogOpened(IZTDialogParameter parameters)
        {
            base.OnDialogOpened(parameters);
            IsEdit = true;
            await GetRoleInfo();
            var Model = parameters.GetValue<SysRoleModel>("Param");
            if (Model == null)
            {
                RoleModel = new SysRoleModel();
                IsEdit = false;
            }
            else
            {
                RoleModel = DeepCopy<SysRoleModel>(Model);
                SelectedItem = RoleList.FirstOrDefault(x => x.Id == RoleModel.ParentId);
            }
        }

        #endregion
    }
}
