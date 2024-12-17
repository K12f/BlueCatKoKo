using System.Windows;
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

    private void clearContent(object sender, MouseButtonEventArgs e)
    {
        // 将 sender 转换为 TextBox 对象
        TextBox textBox = sender as TextBox;

        // 清空 TextBox 的内容
        //if (textBox != null)
        //{
        //    textBox.Text = "";  // 清空文本框内容
        //}

        // 如果 sender 是一个 TextBox，并且剪贴板包含文本
        if (textBox != null && Clipboard.ContainsText())
        {
            // 将剪贴板中的文本设置为 TextBox 的内容
            textBox.Text = Clipboard.GetText();
        }
    }

}