using System.Windows.Controls;
using System.Windows.Input;
using BlueCatKoKo.Ui.ViewModels.Pages;


namespace BlueCatKoKo.Ui.Views.Pages;

public partial class HomePage : Page
{
    public HomeViewModel ViewModel { get; }

    public HomePage(HomeViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
    }
}