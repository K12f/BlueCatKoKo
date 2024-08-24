using System.Windows.Controls;

using BlueCatKoKo.Ui.ViewModels;


using HomeViewModel = BlueCatKoKo.Ui.ViewModels.Pages.HomeViewModel;
using Pages_HomeViewModel = BlueCatKoKo.Ui.ViewModels.Pages.HomeViewModel;

namespace BlueCatKoKo.Ui.Views.Pages
{
    public partial class HomePage : Page
    {
        public Pages_HomeViewModel ViewModel { get; }

        public HomePage(Pages_HomeViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = this;
        }
    }
}