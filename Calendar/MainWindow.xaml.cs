using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Demoland.Wpf.Calendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Calendar_OnSelectedDatesChanged(object? sender, SelectionChangedEventArgs e)
        {
            YearTextBlock.Text = Calendar.SelectedDate?.ToString("yyyy年");
            DateTextBlock.Text = Calendar.SelectedDate?.ToString("M月dd日");
            WeekTextBlock.Text = Calendar.SelectedDate?.ToString("dddd");
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
