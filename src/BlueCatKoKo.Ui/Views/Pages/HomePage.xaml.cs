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
        // �� sender ת��Ϊ TextBox ����
        TextBox textBox = sender as TextBox;

        // ��� TextBox ������
        //if (textBox != null)
        //{
        //    textBox.Text = "";  // ����ı�������
        //}

        // ��� sender ��һ�� TextBox�����Ҽ���������ı�
        if (textBox != null && Clipboard.ContainsText())
        {
            // ���������е��ı�����Ϊ TextBox ������
            textBox.Text = Clipboard.GetText();
        }
    }

}