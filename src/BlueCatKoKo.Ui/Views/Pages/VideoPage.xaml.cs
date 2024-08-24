using System.Windows.Controls;

using BlueCatKoKo.Ui.ViewModels;
using BlueCatKoKo.Ui.ViewModels.Pages;

namespace BlueCatKoKo.Ui.Views.Pages
{
    public partial class VideoPage : Page
    {
        public VideoViewModel ViewModel { get; }

        public VideoPage(VideoViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}