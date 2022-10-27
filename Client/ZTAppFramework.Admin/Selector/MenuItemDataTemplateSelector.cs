using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ZTAppFramework.Admin.Model.Menus;
using ZTAppFramework.Admin.Model.Sys;

namespace ZTAppFramework.Admin.Selector
{
    /// <summary>
    ///********************************************
    /// 创建人        ：  ZT
    /// 创建时间      ：  2022/9/6 11:24:09 
    /// Description   ：  
    ///********************************************/
    /// </summary>
    /// 
    public class MenuItemDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null)
            {
                var fe = container as FrameworkElement;
                SysRoleModel menuItem = item as SysRoleModel;
                if (menuItem != null)
                {
                    if (menuItem.Childer != null)
                        return fe.FindResource("MenuItemsDataTemplate") as DataTemplate;
                    else
                        return fe.FindResource("MenuItemDataTemplate") as DataTemplate;

                }
                else
                {
                    SysLogMenuModel menuLogItem = item as SysLogMenuModel;
                    if (menuLogItem.Childer != null)
                        return fe.FindResource("MenuItemsDataTemplate") as DataTemplate;
                    else
                        return fe.FindResource("MenuItemDataTemplate") as DataTemplate;
                }

                
            }
            return null;
        }
    }
   
}
