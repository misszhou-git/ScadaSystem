using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Masuit.Tools;
using TulingScadaSystem.Helpers;
using TulingScadaSystem.Models;

namespace TulingScadaSystem.ViewModels;

public partial class FormulaViewModel:ObservableObject
{
    private readonly GlobalConfig _globalConfig;

    [ObservableProperty]
    ObservableCollection<FormulaEntity> _formulaList = new();

    [ObservableProperty]
    FormulaEntity? _selectedFormula;

    [ObservableProperty]
    FormulaEntity _currentFormula =new();

    public FormulaViewModel(GlobalConfig globalConfig)
    {
        _globalConfig = globalConfig;
        QueryFormula();
    }

    [RelayCommand]
    void QueryFormula()
    {
        // 1. 清空所有的 FormulaList
        FormulaList.Clear();
        // 2. 从数据库中查询所有配方
        SqlSugarHelper.Db.Queryable<FormulaEntity>()
            .OrderBy(x => x.CreateTime, SqlSugar.OrderByType.Desc)
            .ToList()
            .ForEach(x => FormulaList.Add(x));
    }

    [RelayCommand]
    void SelectFormula(FormulaEntity formula)
    {
        //1. 更新选中状态，将配方中所有的配方都设置为未选中
        foreach (var item in FormulaList)
        {
            item.IsSelected = false;
        }

        //2. 设置当前的配方 formula 为选中状态
        formula.IsSelected = true;
        //3. 选中的配方
        SelectedFormula = formula;
        //4. 当前的配方
        CurrentFormula = formula.DeepClone();
    }

    [RelayCommand]
    void NewFormula()
    {
        SelectedFormula = null;
        CurrentFormula = new FormulaEntity();
    }

    [RelayCommand]
    void SaveFormula()
    {
        try
        {
            // 1.验证必填的字段 Name
            if (CurrentFormula.Name.IsNullOrEmpty())
            {
                MessageBox.Show("配方名称不能为空");

                return;
            }

            //2. 如果编辑的是现有配方
            if (SelectedFormula != null)
            {
                var existFormula = FormulaList.FirstOrDefault(x => x.Id == SelectedFormula.Id);

                if (!existFormula.IsNullOrEmpty())
                {
                    CurrentFormula.UpdateTime = DateTime.Now;

                    var index = FormulaList.IndexOf(existFormula);
                    FormulaList[index] = CurrentFormula;
                }
            }
            else
            {
                //3. 如果编辑的是新配方
                CurrentFormula.CreateTime = DateTime.Now;
                CurrentFormula.UpdateTime = DateTime.Now;
                FormulaList.Add(CurrentFormula);
            }

            // 4.将所有配方插入数据
            var rows = SqlSugarHelper.Db.Storageable<FormulaEntity>(FormulaList)
                .ExecuteCommand();

            if (rows > 0)
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
        }
    }

    [RelayCommand]
    void DeleteFormula()
    {
        if(SelectedFormula == null)
        {
            MessageBox.Show("请选择要删除的配方");

            return;
        }

        if (MessageBox.Show("确定要删除配方吗？", "删除配方", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
            FormulaList.Remove(SelectedFormula);
            var rows = SqlSugarHelper.Db.Deleteable(SelectedFormula)
                .ExecuteCommand();

            if (rows > 0)
            {
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }
    }

    [RelayCommand]
    void DownloadFormula()
    {
        try
        {
            foreach (var prop in typeof(FormulaEntity).GetProperties())
            {
                // 寻找对应的 PLC 地址
                var address = _globalConfig.WriteEntities
                    .FirstOrDefault(x => x.En == prop.Name)
                    ?.Address;

                if (!address.IsNullOrEmpty())
                {
                    // 判定 PLC 是否连接，如果连接我们则直接下发
                    if (_globalConfig.PlcConnected)
                    {
                        var value = prop.GetValue(CurrentFormula);

                        if (value != null)
                        {
                            _globalConfig.Plc.WriteAsync(address, (float)value);
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
           Debug.WriteLine(e);
        }
    }
}