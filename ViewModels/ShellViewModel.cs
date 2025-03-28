using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using TulingScadaSystem.Helpers;
using TulingScadaSystem.Models;

namespace TulingScadaSystem.ViewModels
{
    public partial class ShellViewModel : ObservableObject
    {
        public ShellViewModel()
        {
            InitData();
        }

        /// <summary>
        /// 初次进行数据库 CodeFirst 创建表及初始化一些数据
        /// </summary>
        private void InitData()
        {
           
            if (false)
            {
                // 建库
                //SqlSugarHelper.Db.DbMaintenance.CreateDatabase();
                // 建表
                //SqlSugarHelper.Db.CodeFirst.InitTables<User>();
                //SqlSugarHelper.Db.CodeFirst.InitTables<Menu>();
                //SqlSugarHelper.Db.CodeFirst.InitTables<ScadaReadData>();
                //SqlSugarHelper.Db.CodeFirst.InitTables<FormulaEntity>();
            }

            if (false)
            {
                var menuList = new List<Menu>();
                menuList.Add(new Menu()
                {
                    MenuName = "首页",
                    Icon = "Home",
                    View = "IndexView",
                    Sort = 1,
                });
                menuList.Add(new Menu()
                {
                    MenuName = "设备总控",
                    Icon = "Devices",
                    View = "DeviceView",
                    Sort = 2,
                });
                //menuList.Add(new Menu()
                //{
                //    MenuName = "配方管理",
                //    Icon = "AirFilter",
                //    View = "FormulaView",
                //    Sort = 3,
                //});
                //menuList.Add(new Menu()
                //{
                //    MenuName = "参数管理",
                //    Icon = "AlphabetCBoxOutline",
                //    View = "ParamsView",
                //    Sort = 4,
                //});
                menuList.Add(new Menu()
                {
                    MenuName = "数据查询",
                    Icon = "DataUsage",
                    View = "DataQueryView",
                    Sort = 5,
                });
                //menuList.Add(new Menu()
                //{
                //    MenuName = "数据趋势",
                //    Icon = "ChartFinance",
                //    View = "ChartView",
                //    Sort = 6,
                //});
                //menuList.Add(new Menu()
                //{
                //    MenuName = "报表管理",
                //    Icon = "FileReport",
                //    View = "ReportView",
                //    Sort = 7,
                //});
                menuList.Add(new Menu()
                {
                    MenuName = "日志管理",
                    Icon = "NotebookOutline",
                    View = "LogView",
                    Sort = 8,
                });
                menuList.Add(new Menu()
                {
                    MenuName = "用户管理",
                    Icon = "UserMultipleOutline",
                    View = "UserView",
                    Sort = 9,
                });

                SqlSugarHelper.Db.Insertable(menuList).ExecuteCommand();
            }


            if (false)
            {
                // 插入一些用户表里面的数据 admin test test123

                var userList = new List<User>();
                userList.Add(new User
                {
                    UserName = "admin",
                    Password = "admin",
                    Role = 0
                });
                userList.Add(new User
                {
                    UserName = "test",
                    Password = "test",
                    Role = 1
                });
                userList.Add(new User
                {
                    UserName = "test123",
                    Password = "test123",
                    Role = 1
                });

                SqlSugarHelper.Db.Insertable(userList).ExecuteCommand();
            }


            if (false)
            {
                // 插入采集到的实时数据

                var scadaReadDatalist = new List<ScadaReadData>();

                for (int i = 0; i < 100; i++)
                {
                    var scadaReadData = new ScadaReadData()
                    {
                        DegreasingSprayPumpPressure = GetRandomFloat(0.5f, 5.0f),
                        DegreasingPhValue = GetRandomFloat(6.0f, 9.0f),
                        RoughWashSprayPumpPressure = GetRandomFloat(1.0f, 4.0f),
                        PhosphatingSprayPumpPressure = GetRandomFloat(0.8f, 3.5f),
                        PhosphatingPhValue = GetRandomFloat(4.0f, 7.0f),
                        FineWashSprayPumpPressure = GetRandomFloat(1.2f, 4.5f),
                        MoistureFurnaceTemperature = GetRandomFloat(40.0f, 80.0f),
                        CuringFurnaceTemperature = GetRandomFloat(120.0f, 200.0f),
                        FactoryTemperature = GetRandomFloat(15.0f, 35.0f),
                        FactoryHumidity = GetRandomFloat(30.0f, 80.0f),
                        ProductionCount = GetRandomFloat(0, 1000),
                        DefectiveCount = GetRandomFloat(0, 50),
                        ProductionPace = GetRandomFloat(0.5f, 2.0f),
                        AccumulatedAlarms = GetRandomFloat(0, 20),
                        CreateTime = DateTime.Now.AddDays(GetRandomFloat(1f, 10f)),
                        UpdateTime = DateTime.Now.AddDays(GetRandomFloat(1f, 10f))
                    };

                    scadaReadDatalist.Add(scadaReadData);
                }


                SqlSugarHelper.Db.Insertable(scadaReadDatalist).ExecuteCommand();
            }

            if (false)
            {
                // 插入配方
                var formulaEntityList = new List<FormulaEntity>();

                for (int i = 0; i < 10; i++)
                {
                    var formulaEntity = new FormulaEntity()
                    {
                        Name = "配方" + i,
                        Description = "配方描述" + i,
                        IsSelected = false,
                        DegreasingSetPressureUpperLimit
                            = GetRandomFloat(0.5f, 5.0f),
                        DegreasingSetPressureLowerLimit
                            = GetRandomFloat(6.0f, 9.0f),
                        RoughWashingSprayPumpOverloadUpperLimit
                            = GetRandomFloat(1.0f, 4.0f),
                        RoughWashingLevelLowerLimit
                            = GetRandomFloat(0.8f, 3.5f),
                        CeramicCoatingSprayPumpOverloadUpperLimit
                            = GetRandomFloat(4.0f, 7.0f),
                        FineWashingSprayPumpOverloadUpperLimit
                            = GetRandomFloat(1.2f, 4.5f),
                        FineWashingLevelLowerLimit
                            = GetRandomFloat(40.0f, 80.0f),
                        MoistureFurnaceTemperatureUpperLimit
                            = GetRandomFloat(120.0f, 200.0f),
                        MoistureFurnaceTemperatureLowerLimit
                            = GetRandomFloat(120.0f, 200.0f),
                        CoolingRoomCentrifugalFanOverloadUpperLimit
                            = GetRandomFloat(120.0f, 200.0f),
                        CuringOvenTemperatureUpperLimit
                            = GetRandomFloat(120.0f, 200.0f),
                        CuringOvenTemperatureLowerLimit
                            = GetRandomFloat(120.0f, 200.0f),
                        ConveyorSetSpeed = GetRandomFloat(120.0f, 200.0f),
                        ConveyorSetFrequency = GetRandomFloat(120.0f, 200.0f),

                        CreateTime = DateTime.Now,
                        UpdateTime = DateTime.Now,
                    };
                    formulaEntityList.Add(formulaEntity);
                }

                SqlSugarHelper.Db.Insertable(formulaEntityList).ExecuteCommand();
            }
        }

        private float GetRandomFloat(float min, float max)
        {
            return (float)(new Random().NextDouble() * (max - min) + min);
        }
    }
}