using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Options;
using TulingScadaSystem.Helpers;
using TulingScadaSystem.Models;

namespace TulingScadaSystem.ViewModels;

public partial class IndexViewModel : ObservableObject
{
    private readonly GlobalConfig _globalConfig;
    private readonly RootParam _rootParam;  
    private CancellationTokenSource _cts = new();

    [ObservableProperty]
    ScadaReadData _scadaReadDataProp =new();

    public IndexViewModel(GlobalConfig globalConfig,IOptionsSnapshot<RootParam> options)
    {
        _globalConfig = globalConfig;
        _rootParam = options.Value;
        StartCollectionIndex();
        InitReadDataDic2ScadaReadDataProp();
    }

    private void StartCollectionIndex()
    {
        _globalConfig.InitPlcServer();

        if (_rootParam.PlcParam.AutoCollect)
        {
            _globalConfig.StartCollectionAsync();
        }
    }

    private void InitReadDataDic2ScadaReadDataProp()
    {
        Task.Run(async () => {

            var properties = typeof(ScadaReadData)
            .GetProperties()
            .Where(p => p.PropertyType == typeof(float) || p.PropertyType == typeof(bool));

            while (!_cts.Token.IsCancellationRequested) {
                foreach (var property in properties)
                {
                    try
                    {
                        if(property.PropertyType == typeof(float))
                        {
                            var value = _globalConfig.GetValue<float>(property.Name);
                            property.SetValue(ScadaReadDataProp, value);
                        }
                        else if (property.PropertyType == typeof(bool))
                        {
                            var value = _globalConfig.GetValue<bool>(property.Name);
                            property.SetValue(ScadaReadDataProp, value);
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                    }
                }

                await Task.Delay(100);
            }
        });
    }
}