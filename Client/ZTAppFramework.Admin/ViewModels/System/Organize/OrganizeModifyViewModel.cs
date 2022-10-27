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
    public class OrganizeModifyViewModel : ZTDialogViewModel
    {
        #region UI
        private List<SysOrganizeModel> _OrganizesList;
        public List<SysOrganizeModel> OrganizesList
        {
            get { return _OrganizesList; }
            set { SetProperty(ref _OrganizesList, value); }
        }

        private SysOrganizeModel _SelectedItem;
        public SysOrganizeModel SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                if (SetProperty(ref _SelectedItem, value) && value != null)
                {
                
                    OrganizeModel.ParentIdList = OrganizeModel.ParentIdList ?? new List<string>();
                    OrganizeModel.ParentIdList.Clear();
                    foreach (var item in value.ParentIdList)
                    {
                        OrganizeModel.ParentIdList.Add(item);
                    }
                    if (!OrganizeModel.ParentIdList.Contains(value.Id.ToString()))
                        OrganizeModel.ParentIdList.Add(value.Id.ToString());
                    OrganizeModel.ParentId=value.Id;
                }

            }
        }

        private SysOrganizeModel _OrganizeModel;

        public SysOrganizeModel OrganizeModel
        {
            get { return _OrganizeModel; }
            set { SetProperty(ref _OrganizeModel, value); }
        }


        #endregion

        #region  Command

        #endregion

        #region Service
        private readonly OrganizeService _organizeService;
        #endregion

        #region 属性
        public bool IsEdit { get; set; }

        #endregion

        public OrganizeModifyViewModel(OrganizeService organizeService)
        {
            _organizeService = organizeService;
        }

        #region Event
        async Task GetOrganizeInfo(string Query = "")
        {
            var r = await _organizeService.GetList(Query);
            if (r.Success)
                OrganizesList = Map<List<SysOrganizeModel>>(r.data);
            foreach (var item in OrganizesList)
            {
                string Name = "";
                List<string> hasOrganizeName = new List<string>();
                if (item.ParentIdList.Count > 0)
                {
                    for (int i = 0; i < item.ParentIdList.Count(); i++)
                    {
                        if (long.Parse(item.ParentIdList[i]) == item.Id) continue;
                        var info = OrganizesList.FirstOrDefault(x => x.Id == long.Parse(item.ParentIdList[i]));
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

            OrganizesList.Insert(0, new SysOrganizeModel() { Name = "组织", ParentId = 0, ParentIdList = new List<string>() { "0" } });
        }

        async Task<bool> Add()
        {
            if (OrganizeModel.ParentIdList.Count() > 1)
                OrganizeModel.ParentIdList.Remove("0");
            var Version = Verify(Map<SysOrganizeParm>(OrganizeModel));
            if (!Version.IsValid)
            {
                Show("提示", string.Join('\n', Version.Errors));
                return false;
            }


            var r = await _organizeService.Add(Map<SysOrganizeParm>(OrganizeModel));
            if (r.Success)
            {
                Show("提示", r.Message);
                return true;
            }
            return false;
        }
        async Task<bool> Modif()
        {
            var r = await _organizeService.Modif(Map<SysOrganizeDto>(OrganizeModel));
            if (r.Success)
            {
                Show("提示", r.Message);
                return true;
            }
            return false;
        }

        #endregion

        #region override


        public override void Cancel()
        {
            if (IsBusy) return;
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
            await GetOrganizeInfo();
            var Model = parameters.GetValue<SysOrganizeModel>("Param");
            if (Model == null)
            {
                OrganizeModel = new SysOrganizeModel();
                IsEdit = false;
            }
            else
            {
                OrganizeModel = DeepCopy<SysOrganizeModel>(Model);
                SelectedItem = OrganizesList.FirstOrDefault(x => x.Id == OrganizeModel.ParentId);
            }

        }

        #endregion
    }
}
