using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HslCommunication.Profinet.Siemens;
using SqlSugar;

namespace TulingScadaSystem.Models;

public class RootParam
{
    public SqlParam SqlParam { get; set; }
    public SystemParam SystemParam { get; set; }
    public PlcParam PlcParam { get; set; }
}

public class SqlParam
{
    /// <summary>
    /// 数据库类型
    /// </summary>
    public DbType DbType { get; set; }
    /// <summary>
    /// 连接字符串
    /// </summary>
    public string ConnectionString { get; set; }
}

public class PlcParam
{
    /// <summary>
    /// PlcIp 地址
    /// </summary>
    public string PlcIp { get; set; }
    /// <summary>
    /// Plc 端口
    /// </summary>
    public int PlcPort { get; set; }
    /// <summary>
    /// Plc 类型
    /// </summary>
    public SiemensPLCS PlcType { get; set; }
    /// <summary>
    /// Plc 机架号
    /// </summary>
    public byte PlcRack { get; set; }
    /// <summary>
    /// Plc 插槽号
    /// </summary>
    public byte PlcSlot { get; set; }
    /// <summary>
    /// Plc 连接超时时间
    /// </summary>
    public int PlcConnectTimeOut { get; set; }
    /// <summary>
    /// Plc 断线重连时间
    /// </summary>
    public int PlcReConnectTime { get; set; }
    /// <summary>
    /// Plc 循环间隔
    /// </summary>
    public int PlcCycleInterval { get; set; }
    /// <summary>
    /// Plc 是否采集
    /// </summary>
    public bool AutoCollect { get; set; }
    /// <summary>
    /// Plc 模拟数据
    /// </summary>
    public bool AutoMock { get; set; }
}

public class SystemParam
{
    /// <summary>
    /// 日志文件路径
    /// </summary>
    public string AutoLogPath { get; set; }
    /// <summary>
    /// 自动清除日志
    /// </summary>
    public string AutoClearLog { get; set; }
    /// <summary>
    /// 自动清除天数
    /// </summary>
    public int AutoClearDay { get; set; }
    /// <summary>
    /// 机器授权码
    /// </summary>
    public string AuthCode { get; set; }
}
