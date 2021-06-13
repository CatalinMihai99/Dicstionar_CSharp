using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Cuvinte
    { 
  
        public List<Cuvant> lista { get; set; }

        public Cuvinte()
        {
            lista = new List<Cuvant>();
        }

        public void adauga(Cuvant c)
        {
            lista.Add(c);
        }
    }
}
