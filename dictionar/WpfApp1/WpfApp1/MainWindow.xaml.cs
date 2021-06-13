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
using System.IO;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Cuvinte cuvinte = new Cuvinte();
        List<Cuvant> forAutocomplete = new List<Cuvant>();
        public MainWindow()
        {
            InitializeComponent();
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
                List<string> a = new List<string>();

                for (int index = 0; index < cuvinte.lista.Count; index++)
                {
                    if (a.Contains(cuvinte.lista[index].categorie) == false)
                        a.Add(cuvinte.lista[index].categorie);
                }

                    for (int index=0;index<a.Count;index++)
                {
                    ComboBoxCategorie.Items.Add(a[index]);
                }
                
                  //   completare.SelectedItems.Clear();
                  //  ComboBoxCategorie.FindItemWithText(TextBoxA.Text).Selected = true;
                

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //divertisment
            Divertisment x = new Divertisment();
            x.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            
            bool ok = false;

           
            for (int index = 0; index < cuvinte.lista.Count(); index++)
                if (cuvinte.lista[index].cuvant == TextBoxA.Text)
                {
                    txtCategorie.Text = cuvinte.lista[index].categorie;
                    txtExplicatii.Text = cuvinte.lista[index].explicatie;
                    gasit.Text = "Cuvantul se afla in dictionar";
                    ok = true;
                }
            if (ok == false)
            {
                txtCategorie.Text = "";
                txtExplicatii.Text = "";
                gasit.Text ="Cuvantul cautat nu se afla in dictionar.";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Administrativ x = new Administrativ();
            x.Show();
            Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //close
            Close();
     
        }

        private void TextBoxA_TextChanged(object sender, TextChangedEventArgs e)
        {
         
            if(completare!=null)
                completare.Items.Clear();

            foreach (Cuvant c in cuvinte.lista)
            {
                if(c.cuvant.StartsWith(TextBoxA.Text)&& c.categorie== ComboBoxCategorie.Text)
                {
                    completare.Items.Add(c.cuvant);
                }
            }
          
        }

        private void completare_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(completare.SelectedItem==null)
            {
                return;
            }

            TextBoxA.Text = completare.SelectedItem.ToString();
        }
    }
    
}
