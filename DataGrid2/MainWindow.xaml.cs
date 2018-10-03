using DataGrid2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace DataGrid2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<ShiftClass> Shifts { get; set; } = new List<ShiftClass>();

        public MainWindow()
        {
            InitializeComponent();
            Shifts.Add(new ShiftClass { Shift = "III.", Products = 500, FontSize = 14 });
            Shifts.Add(new ShiftClass { Shift = "II.", Products = 1200, FontSize = 14 });
            Shifts.Add(new ShiftClass { Shift = "I.", Products = 1000, FontSize = 20 });

            DataContext = this;
        }
    }
}
