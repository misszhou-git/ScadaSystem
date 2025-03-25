using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Masuit.Tools;
using MaterialDesignThemes.Wpf;
using TulingScadaSystem.Helpers;
using TulingScadaSystem.Models;
using TulingScadaSystem.Services;
using TulingScadaSystem.Ucs;
using TulingScadaSystem.Views;

namespace TulingScadaSystem.ViewModels;

public partial class UserViewModel:ObservableObject
{
    public UserSession UserSessionProp { get; }

    [ObservableProperty]
    List<User> _userList = new List<User>();

    public UserViewModel(UserSession userSessionProp)
    {
        UserSessionProp = userSessionProp;
    }

    /// <summary>
    /// 窗体加载实现第一次查询
    /// </summary>
    [RelayCommand]
    void Load()
    {
        Search();
    }

    /// <summary>
    /// 查询用户
    /// </summary>
    [RelayCommand]
    void Search()
    {
        UserList = SqlSugarHelper.Db.Queryable<User>().ToList();
    }


    /// <summary>
    /// 添加用户
    /// </summary>
    [RelayCommand]
    async void Add()
    {
        // 如果不是管理员权限无法添加
        if(UserSessionProp.CurrentUser.Role != 0)
        {
            UserSessionProp.ShowMessage("您不是管理员不具备添加用户的权限");

            return;
        }

        var entity = new User();
        var view = new UserOperateView { DataContext = new UpdateViewModel<User>(entity) };
        var result =(bool) await DialogHost.Show(view, "ShellDialog");

        if (result)
        {
            int count = await SqlSugarHelper.Db.Insertable(entity).ExecuteCommandAsync();

            if (count > 0)
            {
                Search();
                UserSessionProp.ShowMessage("添加成功");
            }
        }
    }

    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="user"></param>
    [RelayCommand]
    async void Delete(User user)
    {
        // 如果不是管理员权限无法添加
        if (UserSessionProp.CurrentUser.Role != 0)
        {
            UserSessionProp.ShowMessage("您不是管理员不具备删除用户的权限");

            return;
        }

        if(UserSessionProp.CurrentUser.UserName == user.UserName)
        {
            UserSessionProp.ShowMessage("您不能删除自己！");

            return;
        }

        var result = (bool)await DialogHost.Show(
            new Dialog("确定要删除吗", MessageBoxButton.YesNo)
            , "ShellDialog");

        if(result)
        {
            var count = SqlSugarHelper.Db.Deleteable(user).ExecuteCommand();

            if (count > 0)
            {
                UserSessionProp.ShowMessage("删除成功了");
                Search();
            }
        }

    }


    /// <summary>
    /// 修改用户
    /// </summary>
    /// <param name="user"></param>
    [RelayCommand]
    async void Edit(User user)
    {
        // 如果不是管理员权限无法添加
        if (UserSessionProp.CurrentUser.Role != 0)
        {
            UserSessionProp.ShowMessage("您不是管理员不具备修改用户的权限");

            return;
        }

        // 编辑用户
        var userClone = user.DeepClone();
        var view = new UserOperateView { 
            DataContext = new UpdateViewModel<User>(userClone) 
        };
        var result = (bool)await DialogHost.Show(view, "ShellDialog");

        if (result)
        {
            // 编辑用户
            user.UserName = userClone.UserName;
            user.Password = userClone.Password;
            user.Role = userClone.Role;
            user.UpdateTime = DateTime.Now;

            int count = await SqlSugarHelper.Db.Updateable(user).ExecuteCommandAsync();

            if (count > 0)
            {
                Search();
                UserSessionProp.ShowMessage("修改成功");
            }
        }
    }
}