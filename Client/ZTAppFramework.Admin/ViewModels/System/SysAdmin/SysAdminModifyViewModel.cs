using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using ZTAppFramework.Template.Global;
using ZTAppFramework.Admin.Model.Sys;

using ZTAppFramework.Application.Service;
using ZTAppFramewrok.Application.Stared;
using ZTAppFreamework.Stared.ViewModels;

namespace ZTAppFramework.Admin.ViewModels
{
    public class SysAdminModifyViewModel : ZTDialogViewModel
    {

        #region UI
        private SysAdminModel _Data;

        public SysAdminModel Data
        {
            get { return _Data; }
            set { SetProperty(ref _Data, value); }
        }


        private List<SysOrganizeModel> _OrganizeMenu;

        public List<SysOrganizeModel> OrganizeMenu
        {
            get { return _OrganizeMenu; }
            set { SetProperty(ref _OrganizeMenu, value); }
        }
        private SysOrganizeModel _SelectOrganizeModel;

        public SysOrganizeModel SelectOrganizeModel
        {
            get { return _SelectOrganizeModel; }
            set { SetProperty(ref _SelectOrganizeModel, value); }
        }

        private List<SysPostModel> _SysPostMenu;
        public List<SysPostModel> SysPostMenu
        {
            get { return _SysPostMenu; }
            set { SetProperty(ref _SysPostMenu, value); }
        }

        private List<SysPostModel> _SelectPostItems = new List<SysPostModel>();

        public List<SysPostModel> SelectPostItems
        {
            get { return _SelectPostItems; }
            set { SetProperty(ref _SelectPostItems, value); }
        }

        private List<SysRoleModel> _SysRoleMenu;

        public List<SysRoleModel> SysRoleMenu
        {
            get { return _SysRoleMenu; }
            set { SetProperty(ref _SysRoleMenu, value); }
        }

        private List<SysRoleModel> _SelectRoleItems = new List<SysRoleModel>();
        public List<SysRoleModel> SelectRoleItems
        {
            get { return _SelectRoleItems; }
            set
            {
                _SelectRoleItems = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Command
        public DelegateCommand<string> SexChanageCommand { get; }
        #endregion

        #region Service
        private readonly OrganizeService _organizeService;
        private readonly SysPostService _sysPostService;
        private readonly RoleService _SysRoleService;
        private readonly AdminService _SysAdminservice;
        #endregion

        #region 属性
        public bool IsEdit { get; set; }

        #endregion
        public SysAdminModifyViewModel(AdminService SysAdminservice, OrganizeService organizeService, SysPostService sysPostService, RoleService SysRoleService)
        {
            _organizeService = organizeService;
            _sysPostService = sysPostService;
            _SysRoleService = SysRoleService;
            _SysAdminservice = SysAdminservice;

            SexChanageCommand = new DelegateCommand<string>(SexChanage);
        }

        void SexChanage(string Param) => Data.Sex = bool.Parse(Param) ? "男" : "女";

        async Task GetOrganizeInfo(string Query = "")
        {
            var r = await _organizeService.GetList(Query);
            if (r.Success)
                OrganizeMenu = Map<List<SysOrganizeModel>>(r.data).OrderBy(X => X.Sort).ToList();
            foreach (var item in OrganizeMenu)
            {
                string Name = "";
                List<string> hasOrganizeName = new List<string>();
                if (item.ParentIdList.Count > 0)
                {
                    for (int i = 0; i < item.ParentIdList.Count(); i++)
                    {
                        if (long.Parse(item.ParentIdList[i]) == item.Id) continue;
                        var info = OrganizeMenu.FirstOrDefault(x => x.Id == long.Parse(item.ParentIdList[i]));
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
        }
        async Task GetSysPostInfo()
        {
            var r = await _sysPostService.GetPostList(new ZTAppFramewrok.Application.Stared.PageParam());
            if (r.Success)
                SysPostMenu = Map<List<SysPostModel>>(r.data.Items).OrderBy(X => X.Sort).ToList();
        }

        async Task GetRoleInfo()
        {
            var r = await _SysRoleService.GetList();
            if (r.Success)
                SysRoleMenu = Map<List<SysRoleModel>>(r.data).OrderBy(X => X.Sort).ToList();
        }
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

        private async Task<bool> Add()
        {
            if (SelectOrganizeModel != null)
            {
                Data.OrganizeId = SelectOrganizeModel.Id;
                Data.OrganizeIdList = SelectOrganizeModel.ParentIdList;
            }
 
            Data.PostGroup = SelectPostItems.Select(x => x.Id.ToString()).ToList();
            Data.RoleGroup = SelectRoleItems.Select(x => x.Id.ToString()).ToList();
            Data.RoleGroupParent = SelectRoleItems.Select(x => x.ParentIdList).ToList();
            var vali = Verify(Data);
            if (!vali.IsValid)
            {
                Show("警告", string.Join('\n', vali.Errors));
                return false;
            }
            var r = await _SysAdminservice.Add(Map<SysAdminDto>(Data));
            if (r.Success)
            {
                Show("消息", r.Message);
                return true;
            }

            Show("消息", r.Message);
            return false;
        }

        private async Task<bool> Modif()
        {
            if (SelectOrganizeModel != null)
            {
                Data.OrganizeId = SelectOrganizeModel.Id;
                Data.OrganizeIdList = SelectOrganizeModel.ParentIdList;
            }

            Data.PostGroup = SelectPostItems.Select(x => x.Id.ToString()).ToList();
            Data.RoleGroup = SelectRoleItems.Select(x => x.Id.ToString()).ToList();
            Data.RoleGroupParent = SelectRoleItems.Select(x => x.ParentIdList).ToList();
            var vali = Verify(Data);
            if (!vali.IsValid)
            {
                Show("警告", string.Join('\n', vali.Errors));
                return false;
            }

            var r = await _SysAdminservice.Modif(Map<SysAdminDto>(Data));
            if (r.Success)
            {
                Show("消息", r.Message);
                return true;
            }

            Show("消息", r.Message);
            return false;
        }

        public override async void OnDialogOpened(IZTDialogParameter parameters)
        {
            base.OnDialogOpened(parameters);
            await GetOrganizeInfo();
            await GetSysPostInfo();
            await GetRoleInfo();

            IsEdit = true;
            var Model = parameters.GetValue<SysAdminModel>("Param");
            if (Model == null)
            {
                Data = new SysAdminModel() { Sex="男",Status=true};
                IsEdit = false;
            }
            else
            {
                Data = DeepCopy<SysAdminModel>(Model);
                SelectOrganizeModel = OrganizeMenu.FirstOrDefault(x => x.Id == Data.OrganizeId);
                List<SysRoleModel> roleItems = new List<SysRoleModel>();
                foreach (var id in Data.RoleGroup)
                {
                    var rm = SysRoleMenu.FirstOrDefault(x => x.Id.ToString() == id);
                    if (rm != null)
                        roleItems.Add(rm);
                }
                SelectRoleItems = roleItems;

                List<SysPostModel> postiems = new List<SysPostModel>();
                foreach (var id in Data.PostGroup)
                {
                    var pm = SysPostMenu.FirstOrDefault(x => x.Id.ToString() == id);
                    if (pm != null)
                        postiems.Add(pm);
                }
                SelectPostItems = postiems;

            }
        }

        #endregion
    }
}
