using Program.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Program
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public StuartPlatform Model { get; set; }
        public Tools.Math.Vector3D T1 { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {

            Model = new StuartPlatform(16.5, 16.5, 100.0, 10.0, 28.5, 35.0);
            Model.Move(new Tools.Math.Vector3D(0, 0, 30));

            T1 = (Model.WorkPlatform.Joints[0].Position - Model.BasePlatform.Joints[0].Position) * 0.5 + Model.BasePlatform.Joints[0].Position;
            OnPropertyChanged("Model");
        }

        private void HelixViewport3D_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Viewport.ResetCamera();
            OnPropertyChanged("Model");
        }

        private void Viewport_KeyDown(object sender, KeyEventArgs e)
        {
            // XY Movement
            if(e.Key == Key.NumPad4)
            {
                Model.Move(new Tools.Math.Vector3D(-0.1, 0, 0));
                OnPropertyChanged("Model");
            }
            if (e.Key == Key.NumPad8)
            {
                Model.Move(new Tools.Math.Vector3D(0, 0.1, 0));
                OnPropertyChanged("Model");
            }
            if (e.Key == Key.NumPad6)
            {
                Model.Move(new Tools.Math.Vector3D(0.1, 0, 0));
                OnPropertyChanged("Model");
            }
            if (e.Key == Key.NumPad2)
            {
                Model.Move(new Tools.Math.Vector3D(0, -0.1, 0));
                OnPropertyChanged("Model");
            }

            // Z axis movement
            if (e.Key == Key.OemPlus)
            {
                Model.Move(new Tools.Math.Vector3D(0, 0, 0.1));
                OnPropertyChanged("Model");
            }
            if (e.Key == Key.OemMinus)
            {
                Model.Move(new Tools.Math.Vector3D(0, 0, -0.1));
                OnPropertyChanged("Model");
            }

            // Rotations
            if (e.Key == Key.NumPad1)
            {
                Model.Move(new Tools.Math.Quaternion(Tools.Math.Misc.DegToRad(-1), Model.WorkPlatform.Q.Rotate(new Tools.Math.Vector3D(0, 0, 1))));
                OnPropertyChanged("Model");
            }
            if (e.Key == Key.NumPad3)
            {
                Model.Move(new Tools.Math.Quaternion(Tools.Math.Misc.DegToRad(1), Model.WorkPlatform.Q.Rotate(new Tools.Math.Vector3D(0, 0, 1))));
                OnPropertyChanged("Model");
            }

            if (e.Key == Key.NumPad7)
            {
                Model.Move(new Tools.Math.Quaternion(Tools.Math.Misc.DegToRad(-1), Model.WorkPlatform.Q.Rotate(new Tools.Math.Vector3D(1, 0, 0))));
                OnPropertyChanged("Model");
            }
            if (e.Key == Key.NumPad9)
            {
                Model.Move(new Tools.Math.Quaternion(Tools.Math.Misc.DegToRad(1), Model.WorkPlatform.Q.Rotate(new Tools.Math.Vector3D(1, 0, 0))));
                OnPropertyChanged("Model");
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
