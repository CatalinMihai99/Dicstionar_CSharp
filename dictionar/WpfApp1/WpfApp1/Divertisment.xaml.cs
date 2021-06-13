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
using System.Windows.Shapes;
using System.IO;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Divertisment.xaml
    /// </summary>
    public partial class Divertisment : Window
    {
        Random rnd = new Random();
        Cuvinte cuvinte = new Cuvinte();
        int index_punctaj = 0;
        int index_random;
        int index_check = 0;
        public Divertisment()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //check
            button2.IsEnabled = false;
            index_check++;
            if (raspuns.Text == cuvinte.lista[index_random].cuvant)
            {
                index_punctaj++;
                validare.Text = "Corect";
                Punctaj.Text =(char)index_punctaj+0 + "/5";
            }
            else
                validare.Text = "Incorect";
            if (index_check == 5)
            {
                button1.IsEnabled = false;
                button4.Visibility = Visibility.Visible;
                button2.Visibility = Visibility.Hidden;
                button3.Visibility = Visibility.Hidden;
            }
            button2.IsEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            raspuns.Text = "";
            validare.Text = "";
            index_random=rnd.Next(0, cuvinte.lista.Count);
            indiciu.Text = cuvinte.lista[index_random].explicatie;
            button2.IsEnabled = false;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            button3.Visibility = Visibility.Visible;
            button2.Visibility = Visibility.Visible;
            button2.IsEnabled = false;
            using (StreamReader r = new StreamReader("C:\\Users\\Cata\\Desktop\\dictionar\\WpfApp1\\words.txt"))
            {
                while (r.Peek() > 0)
                {
                    string s = r.ReadLine();
                    string c = r.ReadLine();
                    string ex = r.ReadLine();
                    Cuvant aux = new Cuvant(s, c, ex);
                    cuvinte.adauga(aux);

                }

            }
            
            index_random = rnd.Next(0, cuvinte.lista.Count);
            indiciu.Text = cuvinte.lista[index_random].explicatie;
            button1.Visibility = Visibility.Hidden;
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Close();
            System.Windows.MessageBox.Show("Felicitari! Scorul vostru este: "+ Punctaj.Text);
           

        }
    }
}
