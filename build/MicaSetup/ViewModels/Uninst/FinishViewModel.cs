using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MicaSetup.Helper;
using System.Windows;

namespace MicaSetup.ViewModels;

public partial class FinishViewModel : ObservableObject
{
    public string Message => Option.Current.MessageOfPage3;

    [RelayCommand]
    public void Close()
    {
        if (UIDispatcherHelper.MainWindow is Window window)
        {
            SystemCommands.CloseWindow(window);
        }
    }
}
