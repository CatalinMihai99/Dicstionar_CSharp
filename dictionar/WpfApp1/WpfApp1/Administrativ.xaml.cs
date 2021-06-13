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
    /// Interaction logic for Administrativ.xaml
    /// </summary>
    public partial class Administrativ : Window
    {
        public Administrativ()
        {
            InitializeComponent();
        }
        Cuvinte cuvinte = new Cuvinte();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool ok = false;
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
            Cuvant cuvant = new Cuvant();
            cuvant.cuvant = cuvant_box.Text;

            cuvant.categorie = categorie_box.Text;

            cuvant.explicatie = explicatii_box.Text;
            for(int index=0;index<cuvinte.lista.Count;index++)
            {
                if (cuvinte.lista[index].cuvant == cuvant.cuvant)
                    ok = true;
            } 
            if (ok == false)
            {
                cuvinte.adauga(cuvant);
                File.AppendAllText("C:\\Users\\Cata\\Desktop\\dictionar\\WpfApp1\\words.txt", "\n" + cuvant.cuvant + Environment.NewLine);
                File.AppendAllText("C:\\Users\\Cata\\Desktop\\dictionar\\WpfApp1\\words.txt", cuvant.categorie + Environment.NewLine);
                File.AppendAllText("C:\\Users\\Cata\\Desktop\\dictionar\\WpfApp1\\words.txt", cuvant.explicatie);
                exceptii.Text = "Cuvantul a fost adaugat!";
            }
            else
            {
                exceptii.Text = "Cuvantul exista deja";
            }
            
            categorie_box.Text = "";
            explicatii_box.Text = "";
            
          
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           

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
            
            for(int index=0;index<cuvinte.lista.Count;index++)
            {
                if(cuvinte.lista[index].cuvant== cuvant_box.Text)
                    cuvinte.lista.RemoveAt(index);

            }
            File.Create("C:\\Users\\Cata\\Desktop\\dictionar\\WpfApp1\\words.txt").Close();

            for (int index=0;index<cuvinte.lista.Count;index++)
            {
                File.AppendAllText("C:\\Users\\Cata\\Desktop\\dictionar\\WpfApp1\\words.txt", cuvinte.lista[index].cuvant + Environment.NewLine);
                File.AppendAllText("C:\\Users\\Cata\\Desktop\\dictionar\\WpfApp1\\words.txt", cuvinte.lista[index].categorie + Environment.NewLine);
                File.AppendAllText("C:\\Users\\Cata\\Desktop\\dictionar\\WpfApp1\\words.txt", cuvinte.lista[index].explicatie + Environment.NewLine);
            }
            exceptii.Text = "Cuvantul a fost sters!";      
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow x = new MainWindow();
            x.Show();
            Close();
        }
    }
}
