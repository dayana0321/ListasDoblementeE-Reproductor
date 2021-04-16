using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusica_LDE.lista_circular
{
   public class Nodos
    {
        public String dato1;
        public Nodos enlace;

        public Nodos(String entrada)
        {
            dato1 = entrada;
            enlace = this; // se apunta asímismo

        }
    }
}
