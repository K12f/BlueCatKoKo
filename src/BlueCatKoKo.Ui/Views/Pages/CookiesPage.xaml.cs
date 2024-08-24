using System.Windows.Controls;

using BlueCatKoKo.Ui.ViewModels.Pages;

namespace BlueCatKoKo.Ui.Views.Pages
{
    public partial class CookiesPage : Page
    {
        public CookiesViewModel ViewModel { get; }

        public CookiesPage(CookiesViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}