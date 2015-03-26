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

namespace PZW_vjezba1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int selectedIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.AddButton.Click += new RoutedEventHandler(AddButton_Click);
            this.RightButton.Click += new RoutedEventHandler(RightButton_Click);
            this.LeftButton.Click += new RoutedEventHandler(LeftButton_Click);
        }

        void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var tmp = new Rectangle();
            tmp.Fill = _GetRandomBrush();
            tmp.Width = 50;
            tmp.Height = 50;
            tmp.Margin = new Thickness(5);
            RectangleContainer.Children.Add(tmp);
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            //poprima boje kvadratica iz scrollbara ito redom od zadnjeg do 1.
            VisuallyDeselectCurrentRectangle();
            if(selectedIndex > 0)
                selectedIndex--;
            VisuallySelectCurrentRectangle();
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            //poprima boje kvadratica iz scrollbara ito redom od 1. do zadnjeg
            VisuallyDeselectCurrentRectangle();
            if (selectedIndex < RectangleContainer.Children.Count - 1)
                selectedIndex++;
            VisuallySelectCurrentRectangle();
        }

        private void VisuallyDeselectCurrentRectangle()
        {
            if (selectedIndex < 0 || selectedIndex > RectangleContainer.Children.Count - 1)
            {
                return;
            }
            var element = this.RectangleContainer.Children[selectedIndex];
            if (element is Rectangle)
            {
                var rectangle = (Rectangle)element;
                rectangle.Stroke = null;
                rectangle.StrokeThickness = 5;
                SelectedRectangle.Fill = rectangle.Fill;
            }
        }

        private void VisuallySelectCurrentRectangle()
        {
            if (selectedIndex < 0 || selectedIndex > RectangleContainer.Children.Count - 1)
            {
                return;
            }
            var element = this.RectangleContainer.Children[selectedIndex];
            if (element is Rectangle)
            {
                var rectangle = (Rectangle)element;
                rectangle.Stroke = null;
                rectangle.StrokeThickness = 5;
                SelectedRectangle.Fill = rectangle.Fill;
            }
        }

        private Brush _GetRandomBrush()
        {
            var random = new Random();

            var brushesType = typeof(Brushes);
            var properties = brushesType.GetProperties();

            var randomNumber = random.Next(properties.Length);
            
            return (Brush)properties[randomNumber].GetValue(null, null);
        }
    }
}
