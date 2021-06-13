using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Cuvant
    {
        public string cuvant;
        public string explicatie;
        public string categorie;
        public Cuvant(string a, string b, string c)
        {
            cuvant = a;
            categorie = b;
            explicatie = c;
        }
        public Cuvant()
        {

        }
    }
}
