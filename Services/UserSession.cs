using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using MaterialDesignThemes.Wpf;
using TulingScadaSystem.Models;
using TulingScadaSystem.Ucs;

namespace TulingScadaSystem.Services;

public class UserSession:ObservableObject
{
    private User _user = new User() { UserName = "admin", Password = "123456" };

    public User CurrentUser
    {
        get => _user;
        set => SetProperty(ref _user, value);
    }

    public void ShowMessage(string content,MessageBoxButton button= MessageBoxButton.OK)
    {
        App.Current.Dispatcher.Invoke(() =>
        {
            DialogHost.Show(new Dialog(content, button), "ShellDialog");
        });
    }
}