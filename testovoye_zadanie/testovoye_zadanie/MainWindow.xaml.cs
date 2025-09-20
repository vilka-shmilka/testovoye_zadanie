using System.Diagnostics;
using System.Net.Security;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace testovoye_zadanie
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
        int L = 0;
        int N = 2;
        int[,] a;
        Random r = new Random();
        StringBuilder sb=new StringBuilder();



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textbox_result.Clear();
            sb.Clear();
            if (textBox_L.Text != null)
            {
                L = int.Parse(textBox_L.Text);
                a = new int[L, L];
                for (int i = 0; i < L; i++)
                {
                    for (int j = 0; j < L; j++)
                    {
                        if (r.Next(10) > 6) a[i, j] = 0;
                        else a[i, j] = 1;
                        sb.Append(a[i, j]).Append("\t");
                    }
                    sb.AppendLine();
                }             
            }
            textbox_result.Text=sb.ToString();

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            N = 2;
            textbox_result.Clear();
            sb.Clear();
            for (int i = 0; i < L; i++)
            {
                for (int j = 0; j < L; j++)
                {
                    if (a[i,j]==1)
                    {
                        N += check2(i, j); 
                    }
                    sb.Append(a[i, j]).Append("\t");

                }
                sb.AppendLine();

            }
            textbox_result.Text = sb.ToString();
            Label_result.Content = "Количество групп равно "+(N-2).ToString();
        }

      
        private void check(int i0, int j0)
        {
            a[i0, j0] = N;
            if ((i0>0) & (i0 < L - 1))
            {
                if (a[i0 - 1, j0] == 1)
                check(i0 - 1, j0);
                if(a[i0 + 1, j0] == 1)
                check(i0 + 1, j0);
            }
            if ((j0 > 0) & (j0 < L - 1))
            {
                if (a[i0, j0 - 1] == 1)
                check(i0, j0-1);
                if (a[i0, j0 + 1] == 1)
                    check(i0, j0 + 1);
            }
            
        }


        private int check2(int i0, int j0)
        {       
            if (i0 > 0)
            {
                if (a[i0 - 1, j0] > 1)
                {
                    a[i0, j0] = a[i0 - 1, j0];
                    return 0;
                }
            }
            if (j0 > 0) 
            {
                if (a[i0, j0 - 1] > 1)
                {
                    a[i0, j0] = a[i0, j0 - 1];
                    return 0;
                }
            }
            if (i0 < L - 1)
            {
                if (a[i0 + 1, j0] > 1)
                {
                    a[i0, j0] = a[i0 + 1, j0];
                    return 0;
                }
            }
            if  (j0 < L - 1)
            {
                if (a[i0, j0 + 1] > 1)
                {
                    a[i0, j0] = a[i0, j0 + 1];
                    return 0;
                }
                   
            }
            a[i0, j0] = N;


            return 1;


        }

    }
}