using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
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
        static public string CurrentMonth {  get; set; }

        public Button currenPressedtButton;
        public Grid currentVisibleGrid;

        public Dictionary<Button, Grid> connectingButtonToGrid;

        public MainWindow()
        {
            InitializeComponent();
            currenPressedtButton = MenuPanel_Main_Button;
            currentVisibleGrid = MainPanel_Grid;
            connectingButtonToGrid = new Dictionary<Button, Grid>();
            SettingConnectionsBetweenButtonAndGrid(connectingButtonToGrid);
            CurrentMonth = "СЕНТЯБРЬ";
            MainPanel_Date_Month_Button.Content = CurrentMonth;
        }

        private void SettingConnectionsBetweenButtonAndGrid(Dictionary<Button, Grid> connectingButtonToGrid)
        {
            connectingButtonToGrid.Add(MenuPanel_Main_Button, MainPanel_Grid);
            connectingButtonToGrid.Add(MenuPanel_Categories_Button, CategoriesPanel_Grid);
            connectingButtonToGrid.Add(MenuPanel_Products_Button, ProductsPanel_Grid);
            connectingButtonToGrid.Add(MenuPanel_Diet_Button, DietPanel_Grid);
            connectingButtonToGrid.Add(MenuPanel_Limits_Button, LimitsPanel_Grid);
            connectingButtonToGrid.Add(MenuPanel_Statistics_Button, StatisticsPanel_Grid);
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
                screenHeight = 768;
                this.Height = screenHeight;
                screenWidth = 1080;
                this.Width = screenWidth;
                this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            }
        }

        private void MinimiseButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }



        private void CategoriesPanel_List_Search_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CategoriesPanel_List_Search_Field_Grid.Visibility != Visibility.Visible)
            {
                CategoriesPanel_List_Search_Field_Grid.Visibility = Visibility.Visible;
            }
            else
            {
                CategoriesPanel_List_Search_Field_Grid.Visibility = Visibility.Collapsed;
            }
        }

        private void CategoriesPanel_List_Search_Field_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.CategoriesPanel_List_Search_Field_TextBox.Text != "")
            {
                this.CategoriesPanel_List_Search_Field_Label.Visibility = Visibility.Hidden;
            }
            else
            {
                this.CategoriesPanel_List_Search_Field_Label.Visibility = Visibility.Visible;
            }
        }

        private void CategoriesPanel_AddCategory_Dish_Field_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.CategoriesPanel_AddCategory_Dish_Field_TextBox.Text != "")
            {
                this.CategoriesPanel_AddCategory_Dish_Field_Label.Visibility = Visibility.Hidden;
            }
            else
            {
                this.CategoriesPanel_AddCategory_Dish_Field_Label.Visibility = Visibility.Visible;
            }
        }

        private void CategoriesPanel_AddCategory_Diet_Field_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.CategoriesPanel_AddCategory_Diet_Field_TextBox.Text != "")
            {
                this.CategoriesPanel_AddCategory_Diet_Field_Label.Visibility = Visibility.Hidden;
            }
            else
            {
                this.CategoriesPanel_AddCategory_Diet_Field_Label.Visibility = Visibility.Visible;
            }
        }

        private void MenuPanel_Button_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush baseBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4E5D7A"));
            SolidColorBrush newBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF272E3D"));

            currentVisibleGrid.Visibility = Visibility.Hidden;
            currenPressedtButton.Background = baseBackgroundColor;

            foreach (Button button in connectingButtonToGrid.Keys)
            {
                if (button == sender)
                {
                    button.Background = newBackgroundColor;
                    connectingButtonToGrid[button].Visibility = Visibility.Visible;
                    currentVisibleGrid = connectingButtonToGrid[button];
                    currenPressedtButton = button;  
                }
            }
        }

        private void MainPanel_DaysOfMonth_LeftArrow_Button_Click(object sender, RoutedEventArgs e)
        {
    
        }

        private void MainPanel_Date_Month_Button_Click(object sender, RoutedEventArgs e)
        {
            MonthSelectionWindow monthSelectionWindow = new MonthSelectionWindow();
            monthSelectionWindow.Owner = this;
            monthSelectionWindow.ShowDialog();
            MainPanel_Date_Month_Button.Content = CurrentMonth;
        }
    }
}
