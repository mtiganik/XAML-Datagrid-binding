using DataGrid2.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interactivity;
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
            Shifts.Add(new ShiftClass { Shift = "III.", Products = 500, IsCurrent = false });
            Shifts.Add(new ShiftClass { Shift = "II.", Products = 1200, IsCurrent = false });
            Shifts.Add(new ShiftClass { Shift = "I.", Products = 10000, IsCurrent = true });

            DataContext = this;
        }

    }

    public class DragBehavior : Behavior<UIElement>
    {
        private Point elementStartPosition;
        private Point mouseStartPosition;
        private TranslateTransform transform = new TranslateTransform();

        protected override void OnAttached()
        {
            Window parent = Application.Current.MainWindow;
            AssociatedObject.RenderTransform = transform;

            AssociatedObject.MouseLeftButtonDown += (sender, e) =>
            {
                elementStartPosition = AssociatedObject.TranslatePoint(new Point(), parent);
                mouseStartPosition = e.GetPosition(parent);
                AssociatedObject.CaptureMouse();
            };

            AssociatedObject.MouseLeftButtonUp += (sender, e) =>
            {
                AssociatedObject.ReleaseMouseCapture();
            };

            AssociatedObject.MouseMove += (sender, e) =>
            {
                Vector diff = e.GetPosition(parent) - mouseStartPosition;
                if (AssociatedObject.IsMouseCaptured)
                {
                    transform.X = diff.X;
                    transform.Y = diff.Y;
                }
            };
        }
    }
    public class BooleanToFontSizeConverter : IValueConverter


    {
        public static int BiggerFont = 20;
        public static int SmallerFont = 14;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
            {
                return BiggerFont; // get font sizes from some other places
            }
            return SmallerFont;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
