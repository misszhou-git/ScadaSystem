using Castle.Core.Logging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TulingScadaSystem.Helpers;
using TulingScadaSystem.Messages;
using TulingScadaSystem.Models;
using TulingScadaSystem.Services;

namespace TulingScadaSystem.ViewModels;

public partial class MainViewModel:ObservableObject
{
    //测试日志功能和参数获取
    // private readonly ILogger<MainViewModel> _logger;
    // private RootParam RootParamProp;

    public UserSession UserSessionProp { get; }

    public List<Menu> MenuEntities { get; set; } = new();

    public MainViewModel(UserSession userSessionProp)
    {
        UserSessionProp = userSessionProp;
        // _logger = logger;
        // RootParamProp = optionsSnapshot.Value;
        InitData();
    }

    private void InitData()
    {
        MenuEntities = SqlSugarHelper.Db.Queryable<Menu>().ToList();
        // _logger.LogInformation("测试日志");
        // _logger.LogInformation(RootParamProp.PlcParam.PlcIp);
    }

    /// <summary>
    /// 按钮被点击需要导航到固定的页面
    /// </summary>
    /// <param name="menu"></param>
    [RelayCommand]
    void Navigation(Menu menu)
    {
        WeakReferenceMessenger.Default.Send(menu);
    }

    [RelayCommand]
    void ChangeUser()
    {
        // 用户登出的消息
        WeakReferenceMessenger.Default.Send(new LogoutMessage(UserSessionProp.CurrentUser));
    }
}