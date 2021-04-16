using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusica_LDE.Clases
{
    public class IteradorLista
    {
        private Nodo actual;

        //Constructor
        public IteradorLista(clsListaDoble ld)
        {
            actual = ld.cabeza; //Para iniciar por la cabeza
        }

        //Devuelve el nodo siguiente
        public Nodo siguiente()
        {
            Nodo a; //Nodo temporal
            a = actual; //Apunta a actual

            if (actual != null)
            {
                actual = actual.adelante;
            }
            return a;
        }
    }
}
