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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace EngCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> mem = new List<string>();

        private static StoryWindow story_wnd;
        private static MoreFunctions func_wnd;

        public Random rnd = new Random();

        public string currentText = "";
        public const string E = "2.7182818284";
        public const string Pi = "3.1415926535";

        List<string> story_list = new List<string>();

        public bool state = true;

        public double x;
        public double dop;
        public MainWindow()
        {
            InitializeComponent();
            TextPanel.IsEnabled= false;
            ResultBox.IsEnabled= false;

            foreach(UIElement element in AllButtons.Children)
            {
                if(element is Button)
                {
                    ((Button)element).Click += ButtonClick;
                }
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string content = ((Button)e.OriginalSource).Content.ToString();
            try
            {
                switch (content)
                {
                    case "=":
                        if (TextPanel.Text.Contains("/0"))
                        {
                            TextPanel.Clear();
                            MessageBox.Show("На ноль нельзя делить!");
                            break;
                        }
                        if (TextPanel.Text.Contains('^'))
                        {
                            TextPanel.Text = pow_to_y(currentText).Replace(',', '.');
                        }
                        else
                        {
                            if (TextPanel.Text.Contains("e+"))
                            {
                                TextPanel.Text = exp(currentText).Replace(',', '.');
                            }
                            else
                            {
                                if (TextPanel.Text.Contains("mod"))
                                {
                                    TextPanel.Text = mod(currentText).Replace(',', '.');
                                }
                                else
                                {
                                    if (TextPanel.Text.Contains("yroot"))
                                    {
                                        TextPanel.Text = yroot(currentText).Replace(',', '.');
                                    }
                                    else
                                    {
                                        if (TextPanel.Text.Contains("log base"))
                                        {
                                            TextPanel.Text = logbase(currentText).Replace(',', '.');
                                        }
                                        else
                                        {
                                            string res = new DataTable().Compute(TextPanel.Text, null).ToString().Replace(',', '.');
                                            ResultBox.Text = get_case(res);
                                            AddToStory(ResultBox.Text);
                                            TextPanel.Text = res;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "C":
                        TextPanel.Clear();
                        ResultBox.Clear();
                        break;
                    case "n!":
                        currentText = TextPanel.Text;
                        TextPanel.Text += "!";
                        TextPanel.Text = factorial();
                        break;
                    case "√x":
                        currentText = TextPanel.Text;
                        TextPanel.Text = "√(" + TextPanel.Text + ")";
                        TextPanel.Text = square_root();
                        break;
                    case "x^y":
                        currentText = TextPanel.Text;
                        TextPanel.Text = "(" + TextPanel.Text + ")^";
                        break;
                    case "10^x":
                        currentText = TextPanel.Text;
                        TextPanel.Text = "10^(" + TextPanel.Text + ")";
                        TextPanel.Text = pow_10_to_x();
                        break;
                    case "lg(x)":
                        currentText = TextPanel.Text;
                        TextPanel.Text = "lg(" + TextPanel.Text + ")";
                        TextPanel.Text = log10();
                        break;
                    case "ln(x)":
                        currentText = TextPanel.Text;
                        TextPanel.Text = "ln(" + TextPanel.Text + ")";
                        TextPanel.Text = logE();
                        break;
                    case "x^2":
                        currentText = TextPanel.Text;
                        TextPanel.Text = "(" + TextPanel.Text + ")^2";
                        TextPanel.Text = pow_to_2();
                        break;
                    case "1/x":
                        currentText = TextPanel.Text;
                        TextPanel.Text = "1/(" + TextPanel.Text + ")";
                        TextPanel.Text = one_per_x();
                        break;
                    case "|x|":
                        currentText = TextPanel.Text;
                        TextPanel.Text = "|" + TextPanel.Text + "|";
                        TextPanel.Text = modul();
                        break;
                    case "exp":
                        currentText = TextPanel.Text;
                        TextPanel.Text = "(" + TextPanel.Text + "),e+";
                        break;
                    case "mod":
                        currentText = TextPanel.Text;
                        TextPanel.Text = "(" + TextPanel.Text + ") mod ";
                        break;
                    case "⌫":
                        string s = TextPanel.Text;
                        s = s.Substring(0, s.Length - 1);
                        TextPanel.Text = s;
                        break;
                    case "+/-":
                        TextPanel.Text = reverse_value();
                        break;
                    case "e":
                        TextPanel.Text += E;
                        break;
                    case "π":
                        TextPanel.Text += Pi;
                        break;
                    case "⌈x⌉":
                        TextPanel.Text = (Math.Ceiling(getValue())).ToString();
                        break;
                    case "⌊x⌋":
                        TextPanel.Text = (Math.Truncate(getValue())).ToString();
                        break;
                    case "rand":
                        TextPanel.Text += rnd.NextDouble().ToString().Replace(',', '.');
                        break;
                    case "Функции":
                        if (func_wnd != null)
                        {
                            func_wnd.Close();
                        }
                        func_wnd = new MoreFunctions(this);
                        func_wnd.Show();
                        break;
                    default:
                        TextPanel.Text += content;
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
            }
        }

        public string get_case(string res)
        {
            string full_case = TextPanel.Text + " = " + res;
            return full_case;
        }


        public double getValue()
        {
            string res = new DataTable().Compute(TextPanel.Text, null).ToString();
            double x = Convert.ToDouble(res);
            return x;
        }

        public double getCurrentValue()
        {
            string res = new DataTable().Compute(currentText, null).ToString();
            double x = Convert.ToDouble(res);
            return x;
        }

        private double get_y(char symb)
        {
            double x = getCurrentValue();
            int length = TextPanel.Text.Length;
            string y = "";
            for (int i = length - 1; i >= 0; i--)
            {
                if (TextPanel.Text[i] != symb)
                {
                    if (TextPanel.Text[i] == '.')
                    {
                        y = ',' + y;
                    }
                    else
                    {
                        y = TextPanel.Text[i] + y;
                    }
                }
                else
                {
                    break;
                }
            }
            return Convert.ToDouble(y);
        }

        private string factorial()
        {
            double x = getCurrentValue();
            double multiply = 1;
            if(x % 1 == 0)
            {
                for(long i = 2; i <= x; i++)
                {
                    multiply *= i;
                }
            }
            else
            {
                return "Ошибка";
            }
            string res = multiply.ToString();
            ResultBox.Text = get_case(res);
            AddToStory(ResultBox.Text);
            return res;
        }

        private string square_root()
        {
            double x = getCurrentValue();
            if (x >= 0)
            {
                string res = (Math.Sqrt(x)).ToString().Replace(",", ".");
                ResultBox.Text = get_case(res);
                AddToStory(ResultBox.Text);
                return res;
            }
            return "Ошибка";
        }

        private string pow_to_y(string current)
        {
            double x = getCurrentValue();
            double y_numb = get_y('^');
            string res = (Math.Pow(x, y_numb)).ToString().Replace(",", ".");
            ResultBox.Text = get_case(res);
            AddToStory(ResultBox.Text);
            return res;
        }

        private string pow_10_to_x()
        {
            double x = getCurrentValue();
            string res = Math.Pow(10, x).ToString().Replace(",", ".");
            ResultBox.Text = get_case(res);
            AddToStory(ResultBox.Text);
            return res;
        }

        private string log10()
        {
            double x = getCurrentValue();
            string res = Math.Log10(x).ToString().Replace(",", ".");
            ResultBox.Text = get_case(res);
            AddToStory(ResultBox.Text);
            return res;
        }

        private string logE()
        {
            double x = getCurrentValue();
            string res = Math.Log(x).ToString().Replace(",", ".");
            ResultBox.Text = get_case(res);
            AddToStory(ResultBox.Text);
            return res;
        }

        private string pow_to_2()
        {
            double x = getCurrentValue();
            string res = Math.Pow(x, 2).ToString().Replace(",", ".");
            ResultBox.Text = get_case(res);
            AddToStory(ResultBox.Text);
            return res;
        }

        private string one_per_x()
        {
            double x = getCurrentValue();
            string res = (1 / x).ToString().Replace(",", ".");
            ResultBox.Text = get_case(res);
            AddToStory(ResultBox.Text);
            return res;
        }

        private string exp(string current)
        {
            double y_numb = get_y('+');
            string new_current = current.Replace(".", ",");
            string res = ((Convert.ToDouble(new_current)) * Math.Pow(10, y_numb)).ToString();
            ResultBox.Text = get_case(res);
            AddToStory(ResultBox.Text);
            return res;
        }

        private string mod(string current)
        {
            double y_numb = get_y(' ');
            string new_current = current.Replace(".", ",");
            string res = ((Convert.ToDouble(new_current)) % y_numb).ToString();
            ResultBox.Text = get_case(res);
            AddToStory(ResultBox.Text);
            return res;
        }

        private string modul()
        {
            double x = getCurrentValue();
            string res = Math.Abs(x).ToString().Replace(",", ".");
            ResultBox.Text = get_case(res);
            AddToStory(ResultBox.Text);
            return res;
        }

        private string reverse_value()
        {
            double x = getValue();
            x *= -1;
            return x.ToString();
        }

        private string yroot(string current)
        {
            double y_numb = get_y(' ');
            double x = getCurrentValue();
            string res = Math.Pow(x, 1 / y_numb).ToString().Replace(",", ".");
            ResultBox.Text = get_case(res);
            AddToStory(ResultBox.Text);
            return res;
        }

        private string logbase(string current)
        {
            double y_numb = get_y(' ');
            double x = getCurrentValue();
            string res = Math.Log(x, y_numb).ToString().Replace(",", ".");
            ResultBox.Text = get_case(res);
            AddToStory(ResultBox.Text);
            return res;
        }

        public void AddToStory(string value)
        {
            story_list.Add(value + "\n");
        }

        public void Story_Click(object sender, RoutedEventArgs e)
        {
            if(story_wnd != null)
            {
                story_wnd.Close();
            }
            story_wnd = new StoryWindow();
            foreach(string x in story_list)
            {
                story_wnd.story_box.Text += x;
            }
            story_wnd.Show();
        }

        private void StoryUpdate_Click(object sender, RoutedEventArgs e)
        {
            if(story_wnd != null)
            {
                story_wnd.story_box.Clear();
                foreach (string x in story_list)
                {
                    story_wnd.story_box.Text += x;
                }
                story_wnd.Activate();
            }
        }

        private void StoryClear_Click(object sender, RoutedEventArgs e)
        {
            story_list.Clear();
            story_wnd.story_box.Clear();
        }

        private void RadBtn_Checked(object sender, RoutedEventArgs e)
        {
            state = true;
        }

        private void DegBtn_Checked(object sender, RoutedEventArgs e)
        {
            state = false;
        }
    }
}
