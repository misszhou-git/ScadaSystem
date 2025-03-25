using CommunityToolkit.Mvvm.ComponentModel;

namespace TulingScadaSystem.ViewModels;

public class UpdateViewModel<T>:ObservableObject where T:class
{
    public T Entity { get; }

    public UpdateViewModel(T entity)
    {
        Entity = entity;
    }
}