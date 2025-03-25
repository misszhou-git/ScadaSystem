using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScottPlot;
using ScottPlot.WPF;
using TulingScadaSystem.Helpers;
using TulingScadaSystem.Models;

namespace TulingScadaSystem.ViewModels;

public partial class ChartViewModel:ObservableObject
{
    private WpfPlot _plot;

    [ObservableProperty]
    DateTime _startTime = DateTime.Now.AddDays(-30);

    [ObservableProperty]
    DateTime _endTime = DateTime.Now;

    public void InitPlot(WpfPlot plot)
    {
        _plot = plot;
        ConfigurePlot();
    }

    /// <summary>
    /// 所有的配置参考 https://scottplot.net/cookbook/5.0/
    /// </summary>
    private void ConfigurePlot()
    {
        if (_plot == null) return;

        // 配置图标样式
        _plot.Plot.Title("ScadaData Show");
        _plot.Plot.XLabel("Point");
        _plot.Plot.YLabel("Value");
        // 显示图例
        _plot.Plot.ShowLegend();

        Search();
    }

    [RelayCommand]
    void Search()
    {
        if (EndTime < StartTime) return;

        try
        {
            // 1. plot 清除所有的数据
            _plot.Plot.Clear();
            // 2. 查询数据库中的数据
            var data = SqlSugarHelper.Db.Queryable<ScadaReadData>()
                .Where(x => x.CreateTime >= StartTime && x.CreateTime <= EndTime)
                .OrderBy(x => x.CreateTime, SqlSugar.OrderByType.Asc)
                .ToList();
            // 3. 判定数据是否为空，如果为空则直接返回
            if (data.Count == 0) return;

            // 4. 将数据添加到 plot 中
            var degreasingSprayPumpPressureY = data.Select(x => x.DegreasingSprayPumpPressure).ToArray();
            var degreasingPhValueY = data.Select(x => x.DegreasingPhValue).ToArray();

            // 5. 设置线条样式
            List<LinePattern> patterns = [];
            patterns.AddRange(LinePattern.GetAllPatterns());

            // 6. 添加数据
            var sig1 = _plot.Plot.Add.Signal(degreasingSprayPumpPressureY);
            sig1.LineWidth = 3;
            sig1.LegendText = "DegreasingSprayPumpPressure";
            sig1.LinePattern = patterns[1]; // Dotted

            var sig2 = _plot.Plot.Add.Signal(degreasingPhValueY);
            sig2.LineWidth = 3;
            sig2.LegendText = "DegreasingPhValueY";
            sig2.LinePattern = patterns[3]; // Dashed

            // 7. 缩放
            _plot.Plot.ScaleFactor = 2;

            // 8. 刷新显示
            _plot.Refresh();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
        }
    }
}