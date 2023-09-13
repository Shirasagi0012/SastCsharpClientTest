using SastCsharpClientTest.Views;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SastCsharpClientTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ContentFrame.Navigate(WelcomePage);
        }

        #region Page字段&属性
        private WelcomePage welcomePage = null!;
        private WelcomePage WelcomePage
        {
            get
            {
                if (welcomePage is null)
                    welcomePage = new WelcomePage();
                return welcomePage;
            }
        }

        private FriendPage friendPage = null!;
        private FriendPage FriendPage
        {
            get
            {
                if (friendPage is null)
                    friendPage = new FriendPage();
                return friendPage;
            }
        }
        private HelpPage helpPage = null!;
        private HelpPage HelpPage
        {
            get
            {
                if (helpPage is null)
                    helpPage = new HelpPage();
                return helpPage;
            }
        }
        #endregion

        #region 窗体相关操作
        private bool isDragging = false;
        private Point offset;

        private void ExitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            offset = e.GetPosition(this);
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed && offset != e.GetPosition(this))
            {
                isDragging = true;
                Navbar.Background = new SolidColorBrush(Color.FromRgb(16, 32, 16));
                DragMove();
            }
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isDragging)
            {
                isDragging = false;
                Navbar.Background = new SolidColorBrush(Color.FromRgb(16, 16, 16));
                e.Handled = true;
            }
        }
        #endregion

        #region 菜单相关
        private void NavHelpPage(object sender, RoutedEventArgs e) =>
            ContentFrame.Navigate(HelpPage);

        private void NavWelcomePage(object sender, RoutedEventArgs e) =>
            ContentFrame.Navigate(WelcomePage);

        private void NavFriendPage(object sender, RoutedEventArgs e) =>
            ContentFrame.Navigate(FriendPage);

        #endregion
    }
}
