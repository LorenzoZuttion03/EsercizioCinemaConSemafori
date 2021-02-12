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
        static int buffer = 5;
        private static object x = new object();
        private bool[] posti = new bool[10];
        
       
        //private static Semaphore _pool;
        public MainWindow()
        {
            for(int i = 0; i < 10; i++)
            {
                posti[i] = false; // Posti tutti liberi
            }
            

            //_pool = new Semaphore(0, 1);

            

            //_pool.Release(1);
        }
        void Cassa1()
        {
            int tmp = 1;
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
               tmp = int.Parse(txtCassa1.Text);
            }));

            lock (x)
            {
                if(posti[tmp-1] == false)
                {
                    posti[tmp - 1] = true;
                }
                else
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show("Posto occupato");
                    }));
                }

            }
                //se x=1 significa semaforo verde quindi posso eseguire le istruzioni, se x=0 semaforo rosso

            
                  //_pool.WaitOne();

                  
                

            
        }
        void Cassa2()
        {
            
            int tmp = 1;
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                tmp = int.Parse(txtCassa2.Text);
            }));

            lock (x)
            {
                if (posti[tmp - 1] == false)
                {
                    posti[tmp - 1] = true;
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
            Thread t1 = new Thread(new ThreadStart(Cassa1));
            t1.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Thread t2 = new Thread(new ThreadStart(Cassa2));
            t2.Start();
        }
    }
}
