using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTAppFramework.Admin.Model.Device;
using ZTAppFramework.Admin.Model.Menus;
using ZTAppFramework.Admin.Model.Sys;
using ZTAppFramework.Admin.Model.Users;
using ZTAppFramewrok.Application.Stared;
using ZTAppFramewrok.Application.Stared.Sys;

namespace ZTAppFramework.Admin
{
    public class AdminMapper : Profile
    {

        public AdminMapper()
        {
            CreateMap<UserLoginModel, LoginParam>()
                .ForMember(X => X.Account, opt => opt.MapFrom(str => str.UserName))
                .ForMember(X => X.Password, opt => opt.MapFrom(str => str.Password))
                .ReverseMap();

            CreateMap<MenuModel, SysMenuDto>().ReverseMap();
            CreateMap<DeviceUseModel, DeviceUseDto>().ReverseMap();
            CreateMap<MachineInfoModel, MachineInfoDto>().ReverseMap();
            CreateMap<OperatorWorkModel, OperatorWordDto>().ReverseMap();
            CreateMap<UserEditPwdModel, OperatroPasswordParam>().ReverseMap();
            CreateMap<SysOrganizeModel, SysOrganizeDto>().ReverseMap();
            CreateMap<SysOrganizeModel, SysOrganizeParm>().ReverseMap();
            CreateMap<SysRoleModel, SysRoleDto>().ReverseMap();
            CreateMap<SysRoleModel, SysRoleParm>().ReverseMap();
            CreateMap<SysPostModel, SysPostDto>().ReverseMap();
            CreateMap<SysPostModel, SysPostParm>().ReverseMap();
            CreateMap<SysAdminModel, SysAdminDto>().ReverseMap();
            CreateMap<SysMenuModel, SysMenuDto>().ReverseMap();
            CreateMap<SysLogModel, SysLogDto>().ReverseMap();


        }
    }
}
