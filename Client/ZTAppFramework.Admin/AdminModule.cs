using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ZTAppFramework.Template.Global;
using ZTAppFramework.Admin.Dialog;
using ZTAppFramework.Admin.ViewModels;
using ZTAppFramework.Admin.Views;
using ZTAppFramework.Application;
using ZTAppFramework.Application.Service;
using ZTAppFramework.SqliteCore;
using ZTAppFramewrok.Application.Stared.HttpManager;
using ZTAppFreamework.Stared;
using ZTAppFreamework.Stared.Service;
using ZTAppFramework.FFmpeg.Service;

namespace ZTAppFramework.Admin
{
    public class AdminModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="services"></param>
        public void RegisterTypes(IContainerRegistry services)
        {

            //验证器
            services.RegisterValidator();
    
            //服务
            services.RegisterSingleton<AppStartService>();
            services.RegisterSingleton<AccessTokenManager>();
            services.RegisterSingleton<ApiClinetRepository>();
            services.RegisterSingleton<FFmpegService>();
            
            //应用逻辑
            services.RegisterApplicationManager();
            services.RegisterStaredManager();
            services.RegisterSqliteManager ();

            #region 注册消息窗口

            #endregion

            //dialog窗口
            services.RegisterDialog<LoginView, LoginViewModel>(AppView.LoginName);
            //页面
            services.RegisterForNavigation<MainView, MainViewModel>(AppView.MainName);
            services.RegisterForNavigation<HomeView, HomeViewModel>(AppView.HomeName);
            services.RegisterForNavigation<OrganizeView, OrganizeViewModel>(AppView.OrganizeName);
            services.RegisterForNavigation<WorkbenchView, WorkbenchViewModel>(AppView.WorkbenchName);
            services.RegisterForNavigation<UserCenterView, UserCenterViewModel>(AppView.UserCenterName);
            services.RegisterForNavigation<PersonalInfoView, PersonalInfoViewModel>(AppView.PersonalInfoName);
            services.RegisterForNavigation<UserPererfabView, UserPererfabViewModel>(AppView.UserPerferfabName);
            services.RegisterForNavigation<UserEditPasswordView, UserEditPasswordViewModel>(AppView.UserEditPasswordName);
            services.RegisterForNavigation<UserNoticSettingsView, UserNoticSettingsViewModel>(AppView.UserNoticSettingsName);
            services.RegisterForNavigation<RoleView, RoleViewModel>(AppView.RoleName);
            services.RegisterForNavigation<SysPostView, SysPostViewModel>(AppView.SysPostName);
            services.RegisterForNavigation<SysAdminView, SysAdminViewModel>(AppView.SysAdminName);
            services.RegisterForNavigation<SysMenuView, SysMenuViewModel>(AppView.SysMenuName);
            services.RegisterForNavigation<SysAuthorizeView, SysAuthorizeViewModel>(AppView.SysAuthorizeName);
            services.RegisterForNavigation<SyslogView,SyslogViewModel>(AppView.SysLogsName);

            ZTDialog.RegisterDialogWindow<DialogWindowBase>("window");
            ZTDialog.RegisterDialog<DialogMessageView>(AppView.DialogMessageName);
            ZTDialog.RegisterDialog<OrganizeModifyView>(AppView.OrganizeModifyName);
            ZTDialog.RegisterDialog<RoleModifyView>(AppView.RoleModifyName);
            ZTDialog.RegisterDialog<SysPostModifyView>(AppView.SysPostModifyName);
            ZTDialog.RegisterDialog<SysAdminModifyView>(AppView.SysAdminModifyName);
        }
    }
}