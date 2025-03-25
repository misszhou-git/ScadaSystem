using System.IO;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastReport;
//using FastReport.Export.Pdf;
using MiniExcelLibs;
using TulingScadaSystem.Helpers;
using TulingScadaSystem.Models;
using TulingScadaSystem.Services;

namespace TulingScadaSystem.ViewModels;

public partial class DataQueryViewModel : ObservableObject
{
    private readonly UserSession _userSession;

    [ObservableProperty]
    List<ScadaReadData> _scadaReadDataList = new();

    [ObservableProperty]
    DateTime _startTime = DateTime.Now.AddDays(-30);

    [ObservableProperty]
    DateTime _endTime = DateTime.Now;

    #region 分页实现
    [ObservableProperty]
    int _pageSize = 20;

    [ObservableProperty]
    int _currentPage = 1;

    partial void OnCurrentPageChanged(int value)
    {
        Search();
    }

    [ObservableProperty]
    int _totalPages = 1;

    public DataQueryViewModel(UserSession userSession)
    {
        _userSession = userSession;
    }

    [RelayCommand]
    void GoToFirstPage()
    {
        CurrentPage = 1;
    }

    [RelayCommand]
    void GoToNextPage()
    {
        if (CurrentPage < TotalPages)
        {
            CurrentPage++;
        }
    }

    [RelayCommand]
    void GoToPreviousPage()
    {
        if (CurrentPage > 1)
        {
            CurrentPage--;
        }
    }

    [RelayCommand]
    void GoToLastPage()
    {
        CurrentPage = TotalPages;
    }

    #endregion

    [RelayCommand]
    void Load()
    {
        Search();
    }

    [RelayCommand]
    void OutPage()
    {
        SaveByMiniExcel(ScadaReadDataList);
    }

    [RelayCommand]
    void OutAll()
    {
        var list = SqlSugarHelper.Db.Queryable<ScadaReadData>().ToList();
        SaveByMiniExcel(list);
    }

    #region FastReport
    //Json转CVS:https://www.bejson.com/json/json2excel/

    [RelayCommand]
    void DesignReport()
    {
        try
        {
            var report = new Report();
            // 加载报表设计文件
            var path = $@"{Environment.CurrentDirectory}\Configs\report.frx";
            report.Load(path);
            
            //report.Design();

            // 导出 PDF
            //var pdfExport = new PDFExport();
            //pdfExport.Export(report);

            report.Dispose();
        }
        catch (Exception e)
        {
            _userSession.ShowMessage(e.Message);
        }
    }

    [RelayCommand]
    void PreviewReport()
    {
        try
        {
            var dateSet = ScadaReadDataList.ConvertToDataSet();
            var report = new Report();
            var path = $@"{Environment.CurrentDirectory}\Configs\report.frx";
            report.Load(path);
            report.RegisterData(dateSet);
            report.Prepare();
            //report.ShowPrepared();
            report.Dispose();
        }
        catch (Exception e)
        {
            _userSession.ShowMessage(e.Message);
        }
    }

    [RelayCommand]
    void OutputReport()
    {
        try
        {
            var dateSet = ScadaReadDataList.ConvertToDataSet();
            var report = new Report();
            var path = $@"{Environment.CurrentDirectory}\Configs\report.frx";
            report.Load(path);
            report.RegisterData(dateSet);
            report.Prepare();
            // 导出 PDF
            //var pdfExport = new PDFExport();
            //pdfExport.Export(report);
            //report.Dispose();
        }
        catch (Exception e)
        {
            _userSession.ShowMessage(e.Message);
        }
    }
    #endregion
    [RelayCommand]
    void Reset()
    {
        StartTime = DateTime.Now.AddDays(-30);
        EndTime = DateTime.Now;
    }

    [RelayCommand]
    void Search()
    {
        if (StartTime > EndTime)
        {
            _userSession.ShowMessage("开始时间不能超过结束时间");

            return;
        }

        int totalNumber = 1;
        ScadaReadDataList = SqlSugarHelper.Db.Queryable<ScadaReadData>()
            //.Where(x=>x.CreateTime>=StartTime&&x.CreateTime<=EndTime)
            .ToPageList(CurrentPage, PageSize, ref totalNumber);
        TotalPages = (int)Math.Ceiling((double)totalNumber / PageSize);
    }

    private void SaveByMiniExcel<T>(List<T> list)
    {
        if (list.Count < 1)
        {
            return;
        }

        var rootPath = AppDomain.CurrentDomain.BaseDirectory + "\\Excels\\";

        if (!Directory.Exists(rootPath))
        {
            Directory.CreateDirectory(rootPath);
        }

        var excelPath = rootPath + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

        try
        {
            MiniExcel.SaveAs(excelPath, list);
            _userSession.ShowMessage($"导出成功--{excelPath}");
        }
        catch (Exception e)
        {
            _userSession.ShowMessage($"导出异常--{e.Message}");
        }
    }
}