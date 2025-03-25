using System.Runtime.InteropServices;
using SqlSugar;

namespace TulingScadaSystem.Models;

public class ScadaReadData:EntityBase
{
    #region Control 设备状态
    private bool _totalStart;
    /// <summary>
    /// 总启动
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool TotalStart
    {
        get => _totalStart;
        set => SetProperty(ref _totalStart, value);
    }

    private bool _totalStop;
    /// <summary>
    /// 总停止
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool TotalStop
    {
        get => _totalStop;
        set => SetProperty(ref _totalStop, value);
    }

    private bool _mechanicalReset;
    /// <summary>
    /// 机械复位
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool MechanicalReset
    {
        get => _mechanicalReset;
        set => SetProperty(ref _mechanicalReset, value);
    }

    private bool _alarmReset;
    /// <summary>
    /// 报警复位
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool AlarmReset
    {
        get => _alarmReset;
        set => SetProperty(ref _alarmReset, value);
    }

    private bool _idleRun;
    /// <summary>
    /// 空运行
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool IdleRun
    {
        get => _idleRun;
        set => SetProperty(ref _idleRun, value);
    }

    private bool _degreasingStationOpen;
    /// <summary>
    /// 脱脂工位
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool DegreasingStationOpen
    {
        get => _degreasingStationOpen;
        set => SetProperty(ref _degreasingStationOpen, value);
    }
    #endregion

    #region Monitor（监控状态）
    private bool _degreasingSprayPumpStatus;
    /// <summary>
    /// 脱脂喷淋泵运行状态
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool DegreasingSprayPumpStatus
    {
        get => _degreasingSprayPumpStatus;
        set => SetProperty(ref _degreasingSprayPumpStatus, value);
    }

    private bool _degreasingExhaustFanStatus;
    /// <summary>
    /// 脱脂排风机运行状态
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool DegreasingExhaustFanStatus
    {
        get => _degreasingExhaustFanStatus;
        set => SetProperty(ref _degreasingExhaustFanStatus, value);
    }

    private bool _roughWashSprayPumpStatus;
    /// <summary>
    /// 粗洗喷淋泵运行状态
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool RoughWashSprayPumpStatus
    {
        get => _roughWashSprayPumpStatus;
        set => SetProperty(ref _roughWashSprayPumpStatus, value);
    }

    private bool _phosphatingSprayPumpStatus;
    /// <summary>
    /// 陶化喷淋泵运行状态
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool PhosphatingSprayPumpStatus
    {
        get => _phosphatingSprayPumpStatus;
        set => SetProperty(ref _phosphatingSprayPumpStatus, value);
    }

    private bool _phosphatingExhaustFanStatus;
    /// <summary>
    /// 陶化排风机运行状态
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool PhosphatingExhaustFanStatus
    {
        get => _phosphatingExhaustFanStatus;
        set => SetProperty(ref _phosphatingExhaustFanStatus, value);
    }

    private bool _fineWashSprayPumpStatus;
    /// <summary>
    /// 精洗喷淋泵运行状态
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool FineWashSprayPumpStatus
    {
        get => _fineWashSprayPumpStatus;
        set => SetProperty(ref _fineWashSprayPumpStatus, value);
    }

    private bool _moistureFurnaceInverterStatus;
    /// <summary>
    /// 水分炉变频器运行状态
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool MoistureFurnaceInverterStatus
    {
        get => _moistureFurnaceInverterStatus;
        set => SetProperty(ref _moistureFurnaceInverterStatus, value);
    }

    private bool _moistureFurnaceAirCurtainStatus;
    /// <summary>
    /// 水分炉炉口风帘风机运行状态
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool MoistureFurnaceAirCurtainStatus
    {
        get => _moistureFurnaceAirCurtainStatus;
        set => SetProperty(ref _moistureFurnaceAirCurtainStatus, value);
    }

    private bool _coolingChamberCentrifugalFanStatus;
    /// <summary>
    /// 冷却室离心风机运行状态
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool CoolingChamberCentrifugalFanStatus
    {
        get => _coolingChamberCentrifugalFanStatus;
        set => SetProperty(ref _coolingChamberCentrifugalFanStatus, value);
    }

    private bool _curingFurnaceInverterStatus;
    /// <summary>
    /// 固化炉变频器运行状态
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool CuringFurnaceInverterStatus
    {
        get => _curingFurnaceInverterStatus;
        set => SetProperty(ref _curingFurnaceInverterStatus, value);
    }

    private bool _curingFurnaceAirCurtainStatus;
    /// <summary>
    /// 固化炉炉口风帘风机运行状态
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool CuringFurnaceAirCurtainStatus
    {
        get => _curingFurnaceAirCurtainStatus;
        set => SetProperty(ref _curingFurnaceAirCurtainStatus, value);
    }

    private bool _conveyorInverterPowerStatus;
    /// <summary>
    /// 输送机变频器电源状态
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool ConveyorInverterPowerStatus
    {
        get => _conveyorInverterPowerStatus;
        set => SetProperty(ref _conveyorInverterPowerStatus, value);
    }

    private bool _conveyorInverterRunningStatus;
    /// <summary>
    /// 输送机变频器运行状态
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool ConveyorInverterRunningStatus
    {
        get => _conveyorInverterRunningStatus;
        set => SetProperty(ref _conveyorInverterRunningStatus, value);
    }
    #endregion

    #region Alarms（报警状态）
    private bool _degreasingLowLevelAlarm;

    /// <summary>
    /// 脱脂低液位报警
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool DegreasingLowLevelAlarm
    {
        get => _degreasingLowLevelAlarm;
        set => SetProperty(ref _degreasingLowLevelAlarm, value);
    }

    private bool _roughWashPumpOverloadAlarm;
    /// <summary>
    /// 粗洗喷淋泵过载报警
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool RoughWashPumpOverloadAlarm
    {
        get => _roughWashPumpOverloadAlarm;
        set => SetProperty(ref _roughWashPumpOverloadAlarm, value);
    }

    private bool _roughWashLowLevelAlarm;
    /// <summary>
    /// 粗洗低液位报警
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool RoughWashLowLevelAlarm
    {
        get => _roughWashLowLevelAlarm;
        set => SetProperty(ref _roughWashLowLevelAlarm, value);
    }

    private bool _phosphatingPumpOverloadAlarm;
    /// <summary>
    /// 陶化喷淋泵过载报警
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool PhosphatingPumpOverloadAlarm
    {
        get => _phosphatingPumpOverloadAlarm;
        set => SetProperty(ref _phosphatingPumpOverloadAlarm, value);
    }

    private bool _phosphatingLowLevelAlarm;
    /// <summary>
    /// 陶化低液位报警
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool PhosphatingLowLevelAlarm
    {
        get => _phosphatingLowLevelAlarm;
        set => SetProperty(ref _phosphatingLowLevelAlarm, value);
    }

    private bool _fineWashPumpOverloadAlarm;
    /// <summary>
    /// 精洗喷淋泵过载报警
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool FineWashPumpOverloadAlarm
    {
        get => _fineWashPumpOverloadAlarm;
        set => SetProperty(ref _fineWashPumpOverloadAlarm, value);
    }

    private bool _fineWashLowLevelAlarm;
    /// <summary>
    /// 精洗低液位报警
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool FineWashLowLevelAlarm
    {
        get => _fineWashLowLevelAlarm;
        set => SetProperty(ref _fineWashLowLevelAlarm, value);
    }

    private bool _moistureFurnaceTemperatureAlarm;
    /// <summary>
    /// 水分炉温度报警
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool MoistureFurnaceTemperatureAlarm
    {
        get => _moistureFurnaceTemperatureAlarm;
        set => SetProperty(ref _moistureFurnaceTemperatureAlarm, value);
    }

    private bool _moistureFurnaceBurnerAlarm;
    /// <summary>
    /// 水分炉燃烧机报警
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool MoistureFurnaceBurnerAlarm
    {
        get => _moistureFurnaceBurnerAlarm;
        set => SetProperty(ref _moistureFurnaceBurnerAlarm, value);
    }

    private bool _moistureFurnaceGasLeakAlarm;
    /// <summary>
    /// 水分炉煤气泄漏报警
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool MoistureFurnaceGasLeakAlarm
    {
        get => _moistureFurnaceGasLeakAlarm;
        set => SetProperty(ref _moistureFurnaceGasLeakAlarm, value);
    }

    private bool _coolingChamberFanOverloadAlarm;
    /// <summary>
    /// 冷却室离心风机过载报警
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool CoolingChamberFanOverloadAlarm
    {
        get => _coolingChamberFanOverloadAlarm;
        set => SetProperty(ref _coolingChamberFanOverloadAlarm, value);
    }

    private bool _curingFurnaceTemperatureAlarm;
    /// <summary>
    /// 固化炉温度报警
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool CuringFurnaceTemperatureAlarm
    {
        get => _curingFurnaceTemperatureAlarm;
        set => SetProperty(ref _curingFurnaceTemperatureAlarm, value);
    }

    private bool _curingFurnaceBurnerAlarm;
    /// <summary>
    /// 固化炉燃烧机报警
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool CuringFurnaceBurnerAlarm
    {
        get => _curingFurnaceBurnerAlarm;
        set => SetProperty(ref _curingFurnaceBurnerAlarm, value);
    }

    private bool _curingFurnaceGasLeakAlarm;
    /// <summary>
    /// 固化炉煤气泄漏报警
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool CuringFurnaceGasLeakAlarm
    {
        get => _curingFurnaceGasLeakAlarm;
        set => SetProperty(ref _curingFurnaceGasLeakAlarm, value);
    }

    private bool _conveyorInverterFaultAlarm;
    /// <summary>
    /// 输送机变频器故障报警
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool ConveyorInverterFaultAlarm
    {
        get => _conveyorInverterFaultAlarm;
        set => SetProperty(ref _conveyorInverterFaultAlarm, value);
    }

    private bool _conveyorTravelAlarm;
    /// <summary>
    /// 输送机行程报警
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public bool ConveyorTravelAlarm
    {
        get => _conveyorTravelAlarm;
        set => SetProperty(ref _conveyorTravelAlarm, value);
    }
    #endregion

    #region 读取参数

    private float _degreasingSprayPumpPressure;
    /// <summary>
    /// 脱脂喷淋泵压力值
    /// </summary>
    public float DegreasingSprayPumpPressure
    {
        get => _degreasingSprayPumpPressure;
        set => SetProperty(ref _degreasingSprayPumpPressure, value);
    }

    private float _degreasingPhValue;
    /// <summary>
    /// 脱脂pH值
    /// </summary>
    public float DegreasingPhValue
    {
        get => _degreasingPhValue;
        set => SetProperty(ref _degreasingPhValue, value);
    }

    private float _roughWashSprayPumpPressure;
    /// <summary>
    /// 粗洗喷淋泵压力值
    /// </summary>
    public float RoughWashSprayPumpPressure
    {
        get => _roughWashSprayPumpPressure;
        set => SetProperty(ref _roughWashSprayPumpPressure, value);
    }

    private float _phosphatingSprayPumpPressure;
    /// <summary>
    /// 陶化喷淋泵压力值
    /// </summary>
    public float PhosphatingSprayPumpPressure
    {
        get => _phosphatingSprayPumpPressure;
        set => SetProperty(ref _phosphatingSprayPumpPressure, value);
    }

    private float _phosphatingPhValue;
    /// <summary>
    /// 陶化pH值
    /// </summary>
    public float PhosphatingPhValue
    {
        get => _phosphatingPhValue;
        set => SetProperty(ref _phosphatingPhValue, value);
    }

    private float _fineWashSprayPumpPressure;
    /// <summary>
    /// 精洗喷淋泵压力值
    /// </summary>
    public float FineWashSprayPumpPressure
    {
        get => _fineWashSprayPumpPressure;
        set => SetProperty(ref _fineWashSprayPumpPressure, value);
    }

    private float _moistureFurnaceTemperature;
    /// <summary>
    /// 水分炉测量温度
    /// </summary>
    public float MoistureFurnaceTemperature
    {
        get => _moistureFurnaceTemperature;
        set => SetProperty(ref _moistureFurnaceTemperature, value);
    }

    private float _curingFurnaceTemperature;
    /// <summary>
    /// 固化炉测量温度
    /// </summary>
    public float CuringFurnaceTemperature
    {
        get => _curingFurnaceTemperature;
        set => SetProperty(ref _curingFurnaceTemperature, value);
    }

    private float _factoryTemperature;
    /// <summary>
    /// 厂内温度
    /// </summary>
    public float FactoryTemperature
    {
        get => _factoryTemperature;
        set => SetProperty(ref _factoryTemperature, value);
    }

    private float _factoryHumidity;
    /// <summary>
    /// 厂内湿度
    /// </summary>
    public float FactoryHumidity
    {
        get => _factoryHumidity;
        set => SetProperty(ref _factoryHumidity, value);
    }

    private float _productionCount;
    /// <summary>
    /// 生产计数
    /// </summary>
    public float ProductionCount
    {
        get => _productionCount;
        set => SetProperty(ref _productionCount, value);
    }

    private float _defectiveCount;
    /// <summary>
    /// 不良计数
    /// </summary>
    public float DefectiveCount
    {
        get => _defectiveCount;
        set => SetProperty(ref _defectiveCount, value);
    }

    private float _productionPace;
    /// <summary>
    /// 生产节拍
    /// </summary>
    public float ProductionPace
    {
        get => _productionPace;
        set => SetProperty(ref _productionPace, value);
    }

    private float _accumulatedAlarms;
    /// <summary>
    /// 累计报警
    /// </summary>
    public float AccumulatedAlarms
    {
        get => _accumulatedAlarms;
        set => SetProperty(ref _accumulatedAlarms, value);
    }

    #endregion

}