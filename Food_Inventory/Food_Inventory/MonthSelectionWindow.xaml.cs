using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Food_Inventory
{
    /// <summary>
    /// Interaction logic for MonthSelectionWindow.xaml
    /// </summary>
    public partial class MonthSelectionWindow : Window
    {
        private Dictionary<Button, String> connectingButtonToMonth;
        private Button currentMonth;
        private Button selectedMonth;

        public MonthSelectionWindow()
        {
            InitializeComponent();

            connectingButtonToMonth = new Dictionary<Button, String>();
            SettingConnectionBetweenButtonAndMonth(connectingButtonToMonth);
            currentMonth = MainPanel_MonthsOfYear_September_Button;
            currentMonth.Style = (Style)FindResource("MainPanel_MonthsOfYear_CurrentMonth_Button");
            
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void SettingConnectionBetweenButtonAndMonth(Dictionary<Button, String> connectingButtonToMonth)
        {
            connectingButtonToMonth.Add(MainPanel_MonthsOfYear_January_Button, "ЯНВАРЬ");
            connectingButtonToMonth.Add(MainPanel_MonthsOfYear_February_Button, "ФЕВРАЛЬ"); 
            connectingButtonToMonth.Add(MainPanel_MonthsOfYear_March_Button, "МАРТ");
            connectingButtonToMonth.Add(MainPanel_MonthsOfYear_April_Button, "АПРЕЛЬ");
            connectingButtonToMonth.Add(MainPanel_MonthsOfYear_May_Button, "МАЙ");
            connectingButtonToMonth.Add(MainPanel_MonthsOfYear_June_Button, "ИЮНЬ");
            connectingButtonToMonth.Add(MainPanel_MonthsOfYear_July_Button, "ИЮЛЬ");
            connectingButtonToMonth.Add(MainPanel_MonthsOfYear_August_Button, "АВГУСТ");
            connectingButtonToMonth.Add(MainPanel_MonthsOfYear_September_Button, "СЕНТЯБРЬ");
            connectingButtonToMonth.Add(MainPanel_MonthsOfYear_October_Button, "ОКТЯБРЬ");
            connectingButtonToMonth.Add(MainPanel_MonthsOfYear_November_Button, "НОЯБРЬ");
            connectingButtonToMonth.Add(MainPanel_MonthsOfYear_December_Button, "ДЕКАБРЬ");
        }


        private void WindowControlPanel_Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MainPanel_MonthsOfYear_Button_Click(object sender, RoutedEventArgs e)
        {
            if (selectedMonth != null) 
            {
                selectedMonth.Style = (Style)FindResource("MainPanel_MonthsOfYear_Button");
            }
           
            foreach (Button button in connectingButtonToMonth.Keys)
            {
                if (button == sender)
                {
                    if (button != currentMonth)
                    {
                        button.Style = (Style)FindResource("MainPanel_MonthsOfYear_SelectedMonth_Button");
                        selectedMonth = button;
                        MainWindow.CurrentMonth = connectingButtonToMonth[button];
                        
                    }    
                }
            }

            this.Close();
        }
    }
}
