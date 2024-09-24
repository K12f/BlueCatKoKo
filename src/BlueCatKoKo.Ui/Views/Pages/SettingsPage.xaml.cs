using System.Windows.Controls;
using BlueCatKoKo.Ui.ViewModels.Pages;

namespace BlueCatKoKo.Ui.Views.Pages;

public partial class SettingsPage : Page
{
    public SettingsViewModel ViewModel { get; }

    public SettingsPage(SettingsViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }
}