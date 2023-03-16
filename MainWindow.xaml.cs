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

namespace ColorCode_BackgroundChange
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
        private void textBox_TextChanged(object sender, TextChangedEventArgs e, BrushConverter brushConverter)
        {
            try
            {
                var text = textBox.Text.Trim();

                if (text.StartsWith("#") && text.Length == 7)
                {
                    var color = (Color)ColorConverter.ConvertFromString(text);
                    this.Background = new SolidColorBrush(color);
                }
                else if (text.StartsWith("linear-gradient(") && text.EndsWith(")"))
                {
                    var gradientText = text.Substring(16, text.Length - 17);
                    var gradient = (LinearGradientBrush)BrushConverter.ConvertFromString(gradientText);
                    this.Background = gradient;
                }
                else
                {
                    this.Background = new SolidColorBrush(Colors.White);
                }
            }
            catch
            {
                this.Background = new SolidColorBrush(Colors.White);
            }
        }
    }
}
