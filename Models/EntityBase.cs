using CommunityToolkit.Mvvm.ComponentModel;
using SqlSugar;

namespace TulingScadaSystem.Models;

public class EntityBase:ObservableObject
{
	private int _id;

	[SugarColumn(IsPrimaryKey =true,IsIdentity =true)]
	public int Id
	{
		get => _id;
		set => SetProperty(ref _id, value);
	}

    private DateTime _createTime = DateTime.Now;

    public DateTime CreateTime
    {
        get => _createTime;
        set => SetProperty(ref _createTime, value);
    }

    private DateTime _updateTime = DateTime.Now;

    public DateTime UpdateTime
    {
        get => _updateTime;
        set => SetProperty(ref _updateTime, value);
    }

}