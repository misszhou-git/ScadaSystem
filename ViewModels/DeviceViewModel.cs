using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TulingScadaSystem.Helpers;
using TulingScadaSystem.Models;
using TulingScadaSystem.Services;

namespace TulingScadaSystem.ViewModels;

public partial class DeviceViewModel : ObservableObject
{
    public readonly GlobalConfig GlobalConfigProp;
    private readonly UserSession _userSession;

    [ObservableProperty]
    ScadaReadData _scadaReadDataProp = new();

    [ObservableProperty]
    string _logContent = string.Empty;

    public DeviceViewModel(GlobalConfig globalConfigProp, UserSession userSession)
    {
        GlobalConfigProp = globalConfigProp;
        _userSession = userSession;
        LogContent = $"程序运行中...{Environment.NewLine}程序已启动...{Environment.NewLine}";
    }

    [RelayCommand]
    void ClearLog()
    {
        LogContent = string.Empty;
    }

    [RelayCommand]
    void WriteDeviceControl(string paramName)
    {
        if (!GlobalConfigProp.PlcConnected)
        {
            LogContent += "PLC未连接或连接异常" + Environment.NewLine;
            _userSession.ShowMessage("PLC未连接或连接异常");

            return;
        }

        var readAddress = GlobalConfigProp.ReadEntities
            .FirstOrDefault(x => x.En == paramName)?.Address;

        if(string.IsNullOrEmpty(readAddress))
        {
            LogContent += "找不到对应的读取地址" + Environment.NewLine;
            _userSession.ShowMessage("找不到对应的读取地址");

            return;
        }

        // 写入 PLC 数据
        var result = GlobalConfigProp.Plc.Write(readAddress, true);

        if(result.IsSuccess)
        {
            // 记录日志
            LogContent += $"写入{paramName} 地址{readAddress} 写入值:true{Environment.NewLine}";
        }
    }

    private bool CanToggleCollection()
    {
        return GlobalConfigProp.PlcConnected;
    }

    [RelayCommand(CanExecute =nameof(CanToggleCollection))]
    void ToggleCollection(string paramName)
    {
        if (!GlobalConfigProp.PlcConnected)
        {
            LogContent += "PLC未连接或连接异常" + Environment.NewLine;
            _userSession.ShowMessage("PLC未连接或连接异常");

            return;
        }

        var readAddress = GlobalConfigProp.ReadEntities
            .FirstOrDefault(x => x.En == paramName);

        if (readAddress== null)
        {
            LogContent += "找不到对应的读取地址" + Environment.NewLine;
            _userSession.ShowMessage("找不到对应的读取地址");

            return;
        }

        // 写入 PLC 数据
        var value = (bool)ScadaReadDataProp.GetType()
            .GetProperty(readAddress.En)?.GetValue(ScadaReadDataProp);

        var result = GlobalConfigProp.Plc.Write(readAddress.Address, value);

        if (result.IsSuccess)
        {
            // 记录日志
            LogContent += $"写入{paramName} 地址{readAddress.Address} 写入值:{value}{Environment.NewLine}";
        }
    }
}