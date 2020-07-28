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

namespace TicTacToeNN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float[][] Course;
        int[] layer = new int[6] { 9, 20, 16, 14, 12, 9 };
        public MainWindow()
        {
            InitializeComponent();
            InitializeCourse();

        }

        void StartTraining()
        {
            for (int i = 0; i < 100; i++)
            {




            }
        }

        void InitializeCourse()
        {
            List<float[]> row = new List<float[]>();
            for (int i = 0; i < 3; i++)
            {
                row.Add(new float[3]);
            }
            Course = row.ToArray();
        }
        void RestartCourse()
        {
            for (int i = 0; i < Course.Length; i++)
            {
                for (int j = 0; j < Course[i].Length; j++)
                {
                    Course[i][j] = 0;
                }
            }
        }
    }
}
