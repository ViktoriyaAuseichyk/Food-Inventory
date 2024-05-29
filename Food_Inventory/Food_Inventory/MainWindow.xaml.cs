using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Food_Inventory
{
    public partial class MainWindow : Window
    {  
        public MainWindow()
        {
            InitializeComponent();
            //Uri iconUri = new Uri("pack://application:,,,/WPFIcon2.ico", UriKind.RelativeOrAbsolute);
            //this.Icon = BitmapFrame.Create(iconUri);
        }

        

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void RestoreDownButton_Click(object sender, RoutedEventArgs e)
        {
            double screenHeight;
            double screenWidth;

            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                screenHeight = SystemParameters.PrimaryScreenHeight;
                this.Height = screenHeight;
                screenWidth = SystemParameters.PrimaryScreenWidth;
                this.Width = screenWidth;
                this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                screenHeight = 1024;
                this.Height = screenHeight;
                screenWidth = 1440;
                this.Width = screenWidth;
                this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
        }

        private void MinimiseButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
