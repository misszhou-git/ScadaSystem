using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Options;
using TulingScadaSystem.Helpers;
using TulingScadaSystem.Models;

namespace TulingScadaSystem.ViewModels;

public partial class ParamsViewModel:ObservableObject
{
    private readonly GlobalConfig _globalConfig;
    private CancellationTokenSource _cts = new();

    [ObservableProperty]
    RootParam _rootParamProp;

    public ParamsViewModel(IOptionsSnapshot<RootParam> optionsSnapshot, GlobalConfig globalConfig)
    {
        _globalConfig = globalConfig;
        RootParamProp = optionsSnapshot.Value;
    }

    [RelayCommand]
    void ToggleCollection()
    {
        if (RootParamProp.PlcParam.AutoCollect)
        {
            _globalConfig.StopCollection();
            _globalConfig.StartCollectionAsync();
        }
        else
        {
            _globalConfig.StopCollection();
        }
    }

    [RelayCommand]
    void ToggleMock()
    {
        if (RootParamProp.PlcParam.AutoMock)
        {
            StartMockData();
        }
        else
        {
            StopMockData();
        }
    }

    private void StopMockData()
    {
        if (_cts != null)
        {
            _cts.Cancel();
            _cts.Dispose();
        }
    }

    private void StartMockData()
    {
        _cts = new CancellationTokenSource();

        Task.Run(async () => {
            var scadaData = new ScadaReadData();
            // 获取所有浮点型的属性
            var properties = typeof(ScadaReadData).GetProperties()
            .Where(p => p.PropertyType == typeof(float));
            // 获取 Bool 值
            var propertiesBool = typeof(ScadaReadData).GetProperties()
                .Where(p => p.PropertyType == typeof(bool));

            while (!_cts.Token.IsCancellationRequested)
            {
                var random = new Random();

                foreach (var property in properties)
                {
                    var value = (float)(random.NextDouble() * 4 + 1);

                    var address = _globalConfig.ReadEntities.FirstOrDefault(
                        x => x.En == property.Name)?.Address;

                    if (!string.IsNullOrEmpty(address))
                    {
                        await _globalConfig.Plc.WriteAsync(address, value);
                    }
                }

                foreach (var property in propertiesBool)
                {
                    var address = _globalConfig.ReadEntities.FirstOrDefault(
                        x => x.En == property.Name)?.Address;

                    if (!string.IsNullOrEmpty(address))
                    {
                        if (random.Next(0, 2) != 0)
                        {
                            await _globalConfig.Plc.WriteAsync(address, true);
                        }
                        else
                        {
                            await _globalConfig.Plc.WriteAsync(address, false);
                        }
                    }
                }

                await Task.Delay(1000);
            }
        },_cts.Token);
    }
}