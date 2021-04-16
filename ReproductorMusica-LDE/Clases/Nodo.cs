using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusica_LDE.Clases
{
    public class Nodo
    {
        public string dato;
        public Nodo adelante;
        public Nodo atras;

        public Nodo() 
        {

        }
        public string getDato() 
        {
            return dato;
        }

        //Constructor
        public Nodo(String entrada)
        {
            dato = entrada;
            //Inicializando los punteros como null
            adelante = atras = null;
        }
    } //Fin clase Nodo
}
