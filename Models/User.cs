using SqlSugar;

namespace TulingScadaSystem.Models;

[SugarTable("user")]
public class User: EntityBase
{
    private string _userName;

    public string UserName
    {
        get => _userName;
        set => SetProperty(ref _userName, value);
    }

    private string _password;

    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    /// <summary>
    /// 0 代表管理员，1代表普通测试用户
    /// </summary>
    private int _role;

    public int Role
    {
        get => _role;
        set => SetProperty(ref _role, value);
    }
}