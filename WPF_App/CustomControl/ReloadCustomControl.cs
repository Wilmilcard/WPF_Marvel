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

namespace WPF_App.CustomControl
{
    public class ReloadCustomControl : System.Windows.Controls.Control
    {

        public bool RotateOn { get { return (bool)GetValue(RotateOn Property); } set { SetValue(RotateOn Property, value); } }
        public static readonly DependencyProperty RotateOn Property = DependencyProperty.Register("RotateOn ", typeof(bool), typeof(ReloadCustomControl), new PropertyMetadata(false));

        static ReloadCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ReloadCustomControl), new FrameworkPropertyMetadata(typeof(ReloadCustomControl)));
        }
    }
}
