using MultiplayerDraw.Connection;
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

namespace MultiplayerDraw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point StartPosition { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            InitializeInterface();
        }

        private void InitializeInterface()
        {
            ConnectionProvider conp = new ConnectionProvider();
            networkLabel.Content = conp.GetIPv4Address().ToString();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var mousePosition = e.GetPosition((Canvas)sender);
                drawLine(mousePosition);
            }
        }


        private void drawLine(Point mousePosition)
        {
            Line line = new Line();
            //line.Width = 5;
            line.X1 = StartPosition.X;
            line.Y1 = StartPosition.Y;
            line.X2 = mousePosition.X;
            line.Y2 = mousePosition.Y;

            line.Stroke = Brushes.Red;

            StartPosition = mousePosition;

            canvasDraw.Children.Add(line);
        }

        private void CanvasDraw_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StartPosition = e.GetPosition((Canvas)sender);
        }

        private void CanvasDraw_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Right)
            {
                canvasDraw.Children.Clear();
            }
        }
    }
}
