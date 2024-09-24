using BlueCatKoKo.Ui.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BlueCatKoKo.Ui.ViewModels.Pages;

public partial class VideoViewModel : ViewModelBase
{
    [ObservableProperty] private List<Video> videos;
}