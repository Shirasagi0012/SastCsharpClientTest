using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace SastCsharpClientTest.Views
{
    /// <summary>
    /// HelpPage.xaml 的交互逻辑
    /// </summary>
    public partial class HelpPage : Page
    {
        public HelpPage()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RoutedEventArgs e)
        {
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command\")!;
            string s = key.GetValue("")!.ToString()!;
            var str = s.Substring(1, s.Length - 4);
            System.Diagnostics.Process.Start(
                str,
                "https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf"
            );
        }
    }
}
