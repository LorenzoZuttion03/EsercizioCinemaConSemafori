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
using System.Threading;

namespace Esercizio_Cinema_Con_Semafori
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private static object x = new object();
        private bool[] posti = new bool[10];
        private int tmp = 0;
       
        //private static Semaphore _pool;
        public MainWindow()
        {
            for(int i = 0; i < 10; i++)
            {
                posti[i] = false; // Posti tutti liberi
            }
 
        }
        void Cassa1()
        {

            lock (x)
            {
                if(posti[tmp-1] == false)
                {
                    posti[tmp - 1] = true;
                    MessageBox.Show("Posto Libero");
                }
                else
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show("Posto occupato");
                    }));
                }

            }
 
        }
        void Cassa2()
        {


            lock (x)
            {
                if (posti[tmp - 1] == false)
                {
                    posti[tmp - 1] = true;
                    MessageBox.Show("Posto Libero");
                }
                else
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show("Posto occupato");
                    }));
                }

            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tmp = int.Parse(txtCassa1.Text);
            Thread t1 = new Thread(new ThreadStart(Cassa1));
            t1.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tmp = int.Parse(txtCassa2.Text);
            Thread t2 = new Thread(new ThreadStart(Cassa2));
            t2.Start();
        }
    }
}
