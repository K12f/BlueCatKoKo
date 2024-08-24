using System.Windows.Controls;

using BlueCatKoKo.Ui.ViewModels;
using BlueCatKoKo.Ui.ViewModels.Pages;

namespace BlueCatKoKo.Ui.Views.Pages
{
    public partial class AboutPage : Page
    {
        public AboutViewModel ViewModel { get; }

        public AboutPage(AboutViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}