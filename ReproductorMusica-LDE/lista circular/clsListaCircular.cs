using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReproductorMusica_LDE.lista_circular
{
  public  class clsListaCircular
  {
        private Nodos lc;
        public Nodos ultimo;
        public Nodos nuevo1;

        public clsListaCircular()
        {
            lc = null;
            nuevo1 = null;
        }

        public clsListaCircular insertar(String entrada)
        {
            Nodos nuevo;
            nuevo = new Nodos(entrada);
            if (lc != null) // lista circular no vacía
            {
                nuevo.enlace = lc.enlace;
                lc.enlace = nuevo;
            }
            lc = nuevo;
            return this;
        }

        public void InsertarCabeza3(String entrada) 
        {
            Nodos nuevo;
            nuevo = new Nodos(entrada);

            if (lc == null)
            {
                lc = nuevo;
                lc.enlace = lc;
                ultimo = lc;
            }
            else 
            {
                ultimo.enlace = nuevo;
                nuevo.enlace = lc;
                ultimo = nuevo;
            } 
        }

        public void eliminar(String entrada)
        {
            Nodos actual;
            actual = lc;
            while ((actual.enlace != lc) && !(actual.enlace.dato1.Equals(entrada)))
            {
                if (!actual.enlace.dato1.Equals(entrada))
                {
                    actual = actual.enlace;
                }
            }
            // Enlace de nodo anterior con el siguiente
            // si se ha encontrado el nodo.
            if (actual.enlace.dato1.Equals(entrada))
            {
                Nodos p;
                p = actual.enlace; // Nodo a eliminar
                if (lc == lc.enlace) // Lista con un solo nodo
                {
                    lc = null;
                }
                else
                {
                    if (p == lc)
                    {
                        lc = actual; // Se borra el elemento referenciado por lc,   
                                     // el nuevo acceso a la lista es el anterior
                    }
                    actual.enlace = p.enlace;
                }
                p = null;
            }
        }

        public void borrarLista()
        {
            Nodos p;
            if (lc != null)
            {
                p = lc;
                do
                {
                    Nodos t;
                    t = p;
                    p = p.enlace;
                    t = null; // no es estrictamente necesario
                } while (p != lc);
            }
            else
            {
                Console.WriteLine("\n\t Lista vacía.");
            }
            lc = null;
        }

        public void recorrer()
        {
            Nodos p;
            if (lc != null)
            {
                p = lc.enlace; // siguiente nodo al de acceso
                do
                {
                    Console.WriteLine("\t" + p.dato1);
                    p = p.enlace;
                } while (p != lc.enlace);
            }
            else
            {
                Console.WriteLine("\t Lista Circular vacía.");
            }
        }
    }
}
