using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace EngCalculator
{
    /// <summary>
    /// Логика взаимодействия для MoreFunctions.xaml
    /// </summary>
    public partial class MoreFunctions : Window
    {
        public MainWindow main;
        public MoreFunctions(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
            foreach(string x in main.mem)
            {
                Memory.Items.Add(x);
            }
        }

        private void sin_Click(object sender, RoutedEventArgs e)
        {
            main.currentText = main.TextPanel.Text;
            main.TextPanel.Text = "sin(" + main.TextPanel.Text + ")";
            string res = new DataTable().Compute(main.currentText, null).ToString();
            double x = Convert.ToDouble(res);
            if (!main.state)
            {
                x *= 3.1415926535;
                x /= 180.0;
            }
            res = Math.Sin(x).ToString().Replace(",", ".");
            main.ResultBox.Text = main.TextPanel.Text + " = " + res;
            main.AddToStory(main.ResultBox.Text);
            main.TextPanel.Text = res;
        }

        private void cos_Click(object sender, RoutedEventArgs e)
        {
            main.currentText = main.TextPanel.Text;
            main.TextPanel.Text = "cos(" + main.TextPanel.Text + ")";
            string res = new DataTable().Compute(main.currentText, null).ToString();
            double x = Convert.ToDouble(res);
            if (!main.state)
            {
                x *= 3.1415926535;
                x /= 180.0;
            }
            res = Math.Cos(x).ToString().Replace(",", ".");
            main.ResultBox.Text = main.TextPanel.Text + " = " + res;
            main.AddToStory(main.ResultBox.Text);
            main.TextPanel.Text = res;
        }

        private void tan_Click(object sender, RoutedEventArgs e)
        {
            main.currentText = main.TextPanel.Text;
            main.TextPanel.Text = "tan(" + main.TextPanel.Text + ")";
            string res = new DataTable().Compute(main.currentText, null).ToString();
            double x = Convert.ToDouble(res);
            if (!main.state)
            {
                x *= 3.1415926535;
                x /= 180.0;
            }
            res = Math.Tan(x).ToString().Replace(",", ".");
            main.ResultBox.Text = main.TextPanel.Text + " = " + res;
            main.AddToStory(main.ResultBox.Text);
            main.TextPanel.Text = res;
        }

        private void cot_Click(object sender, RoutedEventArgs e)
        {
            main.currentText = main.TextPanel.Text;
            main.TextPanel.Text = "cot(" + main.TextPanel.Text + ")";
            string res = new DataTable().Compute(main.currentText, null).ToString();
            double x = Convert.ToDouble(res);
            if (!main.state)
            {
                x *= 3.1415926535;
                x /= 180.0;
            }
            res = (1 / Math.Tan(x)).ToString().Replace(",", ".");
            main.ResultBox.Text = main.TextPanel.Text + " = " + res;
            main.AddToStory(main.ResultBox.Text);
            main.TextPanel.Text = res;
        }

        private void sec_Click(object sender, RoutedEventArgs e)
        {
            main.currentText = main.TextPanel.Text;
            main.TextPanel.Text = "sec(" + main.TextPanel.Text + ")";
            string res = new DataTable().Compute(main.currentText, null).ToString();
            double x = Convert.ToDouble(res);
            if (!main.state)
            {
                x *= 3.1415926535;
                x /= 180.0;
            }
            res = (1 / Math.Cos(x)).ToString().Replace(",", ".");
            main.ResultBox.Text = main.TextPanel.Text + " = " + res;
            main.AddToStory(main.ResultBox.Text);
            main.TextPanel.Text = res;
        }

        private void csc_Click(object sender, RoutedEventArgs e)
        {
            main.currentText = main.TextPanel.Text;
            main.TextPanel.Text = "csc(" + main.TextPanel.Text + ")";
            string res = new DataTable().Compute(main.currentText, null).ToString();
            double x = Convert.ToDouble(res);
            if (!main.state)
            {
                x *= 3.1415926535;
                x /= 180.0;
            }
            res = (1 / Math.Sin(x)).ToString().Replace(",", ".");
            main.ResultBox.Text = main.TextPanel.Text + " = " + res;
            main.AddToStory(main.ResultBox.Text);
            main.TextPanel.Text = res;
        }

        private void asin_Click(object sender, RoutedEventArgs e)
        {
            main.currentText = main.TextPanel.Text;
            main.TextPanel.Text = "asin(" + main.TextPanel.Text + ")";
            string res = new DataTable().Compute(main.currentText, null).ToString();
            double x = Convert.ToDouble(res);
            if (!main.state)
            {
                x *= 3.1415926535;
                x /= 180.0;
            }
            res = Math.Asin(x).ToString().Replace(",", ".");
            main.ResultBox.Text = main.TextPanel.Text + " = " + res;
            main.AddToStory(main.ResultBox.Text);
            main.TextPanel.Text = res;
        }

        private void acos_Click(object sender, RoutedEventArgs e)
        {
            main.currentText = main.TextPanel.Text;
            main.TextPanel.Text = "acos(" + main.TextPanel.Text + ")";
            string res = new DataTable().Compute(main.currentText, null).ToString();
            double x = Convert.ToDouble(res);
            if (!main.state)
            {
                x *= 3.1415926535;
                x /= 180.0;
            }
            res = Math.Acos(x).ToString().Replace(",", ".");
            main.ResultBox.Text = main.TextPanel.Text + " = " + res;
            main.AddToStory(main.ResultBox.Text);
            main.TextPanel.Text = res;
        }

        private void atan_Click(object sender, RoutedEventArgs e)
        {
            main.currentText = main.TextPanel.Text;
            main.TextPanel.Text = "atan(" + main.TextPanel.Text + ")";
            string res = new DataTable().Compute(main.currentText, null).ToString();
            double x = Convert.ToDouble(res);
            if (!main.state)
            {
                x *= 3.1415926535;
                x /= 180.0;
            }
            res = Math.Atan(x).ToString().Replace(",", ".");
            main.ResultBox.Text = main.TextPanel.Text + " = " + res;
            main.AddToStory(main.ResultBox.Text);
            main.TextPanel.Text = res;
        }

        private void acot_Click(object sender, RoutedEventArgs e)
        {
            main.currentText = main.TextPanel.Text;
            main.TextPanel.Text = "acot(" + main.TextPanel.Text + ")";
            string res = new DataTable().Compute(main.currentText, null).ToString();
            double x = Convert.ToDouble(res);
            if (!main.state)
            {
                x *= 3.1415926535;
                x /= 180.0;
            }
            res = (3.1415926535 / 2 - Math.Atan(x)).ToString().Replace(",", ".");
            main.ResultBox.Text = main.TextPanel.Text + " = " + res;
            main.AddToStory(main.ResultBox.Text);
            main.TextPanel.Text = res;
        }

        private void asec_Click(object sender, RoutedEventArgs e)
        {
            main.currentText = main.TextPanel.Text;
            main.TextPanel.Text = "asec(" + main.TextPanel.Text + ")";
            string res = new DataTable().Compute(main.currentText, null).ToString();
            double x = Convert.ToDouble(res);
            if (!main.state)
            {
                x *= 3.1415926535;
                x /= 180.0;
            }
            res = Math.Acos(1 / x).ToString().Replace(",", ".");
            main.ResultBox.Text = main.TextPanel.Text + " = " + res;
            main.AddToStory(main.ResultBox.Text);
            main.TextPanel.Text = res;
        }

        private void acsc_Click(object sender, RoutedEventArgs e)
        {
            main.currentText = main.TextPanel.Text;
            main.TextPanel.Text = "acsc(" + main.TextPanel.Text + ")";
            string res = new DataTable().Compute(main.currentText, null).ToString();
            double x = Convert.ToDouble(res);
            if (!main.state)
            {
                x *= 3.1415926535;
                x /= 180.0;
            }
            res = Math.Asin(1 / x).ToString().Replace(",", ".");
            main.ResultBox.Text = main.TextPanel.Text + " = " + res;
            main.AddToStory(main.ResultBox.Text);
            main.TextPanel.Text = res;
        }
        private void Memory_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            main.TextPanel.Text = Memory.SelectedItem.ToString();
        }

        private void MS_Click(object sender, RoutedEventArgs e)
        {
            Memory.Items.Add(main.TextPanel.Text);
            int n = Memory.Items.Count;
            main.mem.Add(Memory.Items[n - 1].ToString());
        }

        private void MMinus_Click(object sender, RoutedEventArgs e)
        {
            int n = Memory.Items.Count;
            double x = Convert.ToDouble(Memory.Items[n-1].ToString().Replace(".", ","));
            double y = Convert.ToDouble(main.TextPanel.Text);
            x -= y;
            Memory.Items.RemoveAt(n - 1);
            Memory.Items.Add(x.ToString().Replace(",", "."));
            main.mem.RemoveAt(n - 1);
            main.mem.Add(x.ToString());
        }

        private void MPlus_Click(object sender, RoutedEventArgs e)
        {
            int n = Memory.Items.Count;
            double x = Convert.ToDouble(Memory.Items[n - 1].ToString().Replace(".", ","));
            double y = Convert.ToDouble(main.TextPanel.Text);
            x += y;
            Memory.Items.RemoveAt(n - 1);
            Memory.Items.Add(x.ToString().Replace(",", "."));
            main.mem.RemoveAt(n - 1);
            main.mem.Add(x.ToString());
        }

        private void MR_Click(object sender, RoutedEventArgs e)
        {
            int n = Memory.Items.Count;
            main.TextPanel.Text = Memory.Items[n - 1].ToString();
        }

        private void MC_Click(object sender, RoutedEventArgs e)
        {
            Memory.Items.Clear();
            main.mem.Clear();
        }

        private void Cube_Click(object sender, RoutedEventArgs e)
        {
            main.currentText = main.TextPanel.Text;
            main.TextPanel.Text = "(" + main.TextPanel.Text + ")^3";
            double x = main.getCurrentValue();
            string res = Math.Pow(x, 3).ToString().Replace(",", ".");
            main.ResultBox.Text = main.get_case(res);
            main.AddToStory(main.ResultBox.Text);
            main.TextPanel.Text = res;
        }

        private void CubicRoot_Click(object sender, RoutedEventArgs e)
        {
            main.currentText = main.TextPanel.Text;
            main.TextPanel.Text = "3√(" + main.TextPanel.Text + ")";
            double x = main.getCurrentValue();
            string res = Math.Cbrt(x).ToString().Replace(",", ".");
            main.ResultBox.Text = main.get_case(res);
            main.AddToStory(main.ResultBox.Text);
            main.TextPanel.Text = res;
        }

        private void yRoot_Click(object sender, RoutedEventArgs e)
        {
            main.currentText = main.TextPanel.Text;
            main.TextPanel.Text = main.TextPanel.Text + " yroot ";
        }

        private void TwoPowX_Click(object sender, RoutedEventArgs e)
        {
            main.currentText = main.TextPanel.Text;
            main.TextPanel.Text = "2^(" + main.TextPanel.Text + ")";
            double x = main.getCurrentValue();
            string res = Math.Pow(2, x).ToString().Replace(",", ".");
            main.ResultBox.Text = main.get_case(res);
            main.AddToStory(main.ResultBox.Text);
            main.TextPanel.Text = res;
        }

        private void ePowX_Click(object sender, RoutedEventArgs e)
        {
            main.currentText = main.TextPanel.Text;
            main.TextPanel.Text = "e^(" + main.TextPanel.Text + ")";
            double x = main.getCurrentValue();
            string res = Math.Pow(2.7182818284, x).ToString().Replace(",", ".");
            main.ResultBox.Text = main.get_case(res);
            main.AddToStory(main.ResultBox.Text);
            main.TextPanel.Text = res;
        }

        private void LogYX_Click(object sender, RoutedEventArgs e)
        {
            main.currentText = main.TextPanel.Text;
            main.TextPanel.Text = main.TextPanel.Text + " log base ";
        }
    }
}
