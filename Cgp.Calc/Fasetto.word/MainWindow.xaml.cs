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

namespace Fasetto.word
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new WindowViewModel(this);

        }

        private void CalcButton_Click(object sender, RoutedEventArgs e)
        {
            Gpa.Text = Convert.ToString(Evaluate_Value());

        }

        public int DetGP(char Grade)
        {
            int GP;
            switch (Grade)
            {
                case 'A':
                    GP = 5;
                    return GP;
                case 'B':
                    GP = 4;
                    return GP;
                case 'C':
                    GP = 3;
                    return GP;
                case 'D':
                    GP = 2;
                    return GP;
                case 'E':
                    GP = 1;
                    return GP;
                case 'F':
                    GP = 0;
                    return GP;
                default:
                    return 0;
            }
        }
        public double GPU(int GP, double Unit)
        {
            double GPU = (double)GP * Unit;
            return GPU;
        }
        public double AddArray(double[] Array)
        {
            double num = 0;
            for (int i = 0; i < Array.Length; i++)
            {
                num += Array[i];
            }
            return num;
        }
        public double CalcCGP(double[] dGPU, double[] dUnit)
        {
            double Cgp = AddArray(dGPU) / AddArray(dUnit);
            Cgp = Math.Round(Cgp, 2);
            return Cgp;
        }
        public double Evaluate_Value()
        {
            string[] sGrades = {Convert.ToString(grade1.SelectionBoxItem), Convert.ToString(grade2.SelectionBoxItem),
                                Convert.ToString(grade3.SelectionBoxItem), Convert.ToString(grade4.SelectionBoxItem),
                                Convert.ToString(grade5.SelectionBoxItem), Convert.ToString(grade6.SelectionBoxItem),
                                Convert.ToString(grade7.SelectionBoxItem) };
            string[] sUnits = { Convert.ToString(cu1.SelectionBoxItem), Convert.ToString(cu2.SelectionBoxItem),
                                Convert.ToString(cu3.SelectionBoxItem), Convert.ToString(cu4.SelectionBoxItem),
                                Convert.ToString(cu5.SelectionBoxItem), Convert.ToString(cu6.SelectionBoxItem),
                                Convert.ToString(cu7.SelectionBoxItem) };
            char[] cGrade = new char[8];
            double[] dUnit = new double[8];
            int[] iGrade = new int[8];
            double[] dGPU = new double[8];

            for (int i = 0; i < sGrades.Length; i++)
            {
                char.TryParse(sGrades[i], out cGrade[i]);
                double.TryParse(sUnits[i], out dUnit[i]);
                iGrade[i] = DetGP(cGrade[i]);
                dGPU[i] = GPU(iGrade[i], dUnit[i]);
            }
            double Cgp = CalcCGP(dGPU, dUnit);
            return Cgp;
        }

    }
}
