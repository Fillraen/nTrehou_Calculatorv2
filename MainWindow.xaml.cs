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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace nTrehou_Calculatorv2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tb_DisplayNb.Text = "0";
            tb_DisplayCalc.Text = "";
        }
        float n1, n2 = 0;
        double? result = 0;
        string operation, special = "";
        private void onClick_Number(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if((tb_DisplayNb.Text == "0" && btn.Content.ToString() != ".") || btn.Content.ToString() == "(-)")
            {
                tb_DisplayNb.Text = (btn.Content.ToString() == "(-)" ? "-" : btn.Content.ToString());
            }
            else 
            {
                tb_DisplayNb.Text += btn.Content.ToString();
            }
        }
        private void onClick_Operation(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            operation = btn.Content.ToString();
            var NbrInfos = new NumberFormatInfo();
            NbrInfos.NegativeSign = "-";
            n1 = float.Parse(tb_DisplayNb.Text, NbrInfos);
            tb_DisplayCalc.Text = tb_DisplayNb.Text + " " + operation;

            tb_DisplayNb.Text = "0";
        }     
        private void onClick_Equal(object sender, RoutedEventArgs e)
        {

            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "²":
                    result = CalculSpe(n1, btn.Content.ToString());
                    break;
                case "√":
                    result = CalculSpe(n1, btn.Content.ToString());
                    break;
                case "π":
                    result = CalculSpe(n1, btn.Content.ToString());
                    break;
                default:
                    n2 = float.Parse(tb_DisplayNb.Text);
                    result = CalculOp(n1, operation, n2);
                    break;
            }
            if (result == null)
            {
                tb_DisplayNb.Text = "NaN";
            }
            else
            {
                tb_DisplayNb.Text = result.ToString();
            }

        }        
        private void onClick_AllClear(object sender, RoutedEventArgs e)
        {
            tb_DisplayNb.Text = "";
            tb_DisplayCalc.Text = "";
            operation = "";
            n1 = 0;
            n2 = 0; 
            result = 0;
        } 
        private void onClick_Return(object sender, RoutedEventArgs e)
        {
            if (tb_DisplayNb.Text == "" || tb_DisplayNb.Text == "NaN")
            {
                tb_DisplayNb.Text = "0";
            }
            else
            {
                tb_DisplayNb.Text = tb_DisplayNb.Text.Remove(tb_DisplayNb.Text.Length - 1);
            }
        } 
        private Double? CalculSpe(float n1, string operation)
        {
            n1 = float.Parse(tb_DisplayNb.Text);
            switch (operation)
                {
                    case "²":
                        result = n1 * n1;
                        tb_DisplayCalc.Text = n1 + operation;

                        break;
                    case "√":
                        result = (float)Math.Sqrt(n1);
                        tb_DisplayCalc.Text = operation + n1;
                        break;
                    case "π":
                        result = n1 * Math.PI;
                        tb_DisplayCalc.Text = n1 + operation;
                        break;
                }
            return result;
        }
        private Double? CalculOp(float n1, string operation, float n2)
        {
            tb_DisplayCalc.Text = n1 + " " + operation + " " + n2;
            switch (operation)
            {
                case "+":
                    result = n1 + n2;
                    break;
                case "-":
                    result = n1 - n2;
                    break;
                case "x":
                    result = n1 * n2;
                    break;
                case "^":
                    result = (float)Math.Pow(n1, n2);
                    break;
                case "/":
                    if (n2 == 0)
                    {
                        result = null;
                    }
                    else
                    {
                        result = n1 / n2;
                    }
                    break;
            }

            return result;
        }


    }
}
