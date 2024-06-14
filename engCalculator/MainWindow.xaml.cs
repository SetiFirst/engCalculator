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

namespace engCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private String BtnWidth = "50";
        private String BtnHeight = "12";
        private bool isLegit = true;

        private List<String> symbols = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "+", "-", "*", "/", " " };
        private List<string> strings = new List<string>() { "/", "*", "-", "tg", "sin", "cos", "cot", "asin", "arctg", "arcot", "log", "ln", "acos", "^", "√", "pi", "e" };


       
       

        private bool InList(List<string> symbols, string text)
        {
            for (int i = 0; i < symbols.Count; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    if (text.Contains(symbols[i]))
                    {
                        continue;
                    } else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += " + ";

        }

        private void e_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "exp ";
        }

        private void pi_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "pi ";
        }

        private void sqrt_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "√ ";
        }

        private void square_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += " ^ ";
        }

        private void acos_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "acos ";
        }

        private void ln_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "ln ";
        }

        private void log_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "log2 ";
        }

        private void arcot_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "acot ";
        }

        private void arctg_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "atan ";
        }

        private void asin_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "asin ";
        }

        private void cot_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "cot ";
        }

        private void cos_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "cos ";
        }

        private void sin_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "sin ";
        }

        private void tg_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "tan ";
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += " - ";
        }

        private void multiple_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += " * ";
        }

        private void demultiple_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += " / ";
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox.Text == "Area of calculating...")
            {
                textBox.Text = "";
            }
        }

        private void summ_Click_1(object sender, RoutedEventArgs e)
        {

            string input = textBox.Text;
            try
            {
                double result = Calculate(input);
                textBox.Text = $"Result: {result}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }


        }

        public static double Calculate(string input)
        {
            string[] tokens = input.Split(' ');

            if (tokens.Length == 2 && IsUnaryFunction(tokens[0]))
            {
                double num = double.Parse(tokens[1]);
                return ApplyUnaryFunction(tokens[0], num);
            }
            else if (tokens.Length == 3 && IsBinaryOperator(tokens[1]))
            {
                double num1 = double.Parse(tokens[0]);
                double num2 = double.Parse(tokens[2]);
                return ApplyBinaryOperator(num1, tokens[1], num2);
            }
            else
            {
                throw new ArgumentException("Invalid input format. Please use 'number operator number' or 'function number' format.");
            }
        }


        private static double ApplyUnaryFunction(string function, double num)
        {
            switch(function)
            {
                case "ln": return Math.Log(num);
                case "log2": return Math.Log(num, 2);
                case "√": return Math.Sqrt(num);
                case "sin": return Math.Sin(num);
                case "cos": return Math.Cos(num);
                case "tan": return Math.Tan(num);
                case "cot": return 1 / Math.Tan(num);
                case "asin": return Math.Asin(num);
                case "acos": return Math.Acos(num);
                case "atan": return Math.Atan(num);
                case "acot": return Math.Atan(1 / num);
                case "exp": return Math.Exp(num);
                default: throw new ArgumentException($"Invalid function '{function}'. Supported functions are 'ln', 'log2', 'sqrt', 'sin', 'cos', 'tan', 'cot', 'asin', 'acos', 'atan', and 'acot'.");
            };
        }

        private static double ApplyBinaryOperator(double num1, string operation, double num2)
        {
            switch(operation)
            {
                case "+": return num1 + num2;
                case "-": return num1 - num2;
                case "*": return num1 * num2;
                case "/": return num1 / num2;
                case "^": return Math.Pow(num1, num2);
                default: throw new ArgumentException($"Invalid operator '{operation}'. Supported operators are '+', '-', '*', and '/'.");
            };
        }

        private static bool IsBinaryOperator(string operation)
        {
            switch(operation)
            {
                case "+": return true;
                case "-": return true;
                case "*":  return true;
                case "/": return true;
                case "^": return true;
                default: return false;
            };
        }

        private static bool IsUnaryFunction(string function)
        {
            switch(function)
            {
                case "ln":
                    return true;
                case "log2":  return true;
                case "√": return true;
                case "sin": return true;
                case "cos": return true;
                case "tan": return true;
                case "cot": return true;
                case "asin": return true;
                case "acos": return true;
                case "atan": return true;
                case "acot": return true;
                case "exp": return true;
                default: return false;
            };
        }
    }
}
