using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReproductorMusica_LDE.Clases
{
    public class clsListaDoble
    {
        public Nodo cabeza;

        //Constructor
        public clsListaDoble () 
        {
            cabeza = null;
        }

        //Método de insertar por la cabeza
        public clsListaDoble insertarCabezaLista (String entrada) 
        {
            Nodo nuevo;
            nuevo = new Nodo(entrada);
            nuevo.adelante = cabeza;

            if (cabeza != null)
            {
                cabeza.atras = nuevo;
            }
            cabeza = nuevo;
            return this;
        }

        //Insertar despues de una posicion
        public clsListaDoble insertaDespues(Nodo anterior, String entrada)
        {
            Nodo nuevo; //Nodo temporal antes de meterlo a la lista
            nuevo = new Nodo(entrada);
            nuevo.adelante = anterior.adelante;

            if (anterior.adelante != null)
            {
                anterior.adelante.atras = nuevo;
            }
            anterior.adelante = nuevo;
            nuevo.atras = anterior;
            return this;
        }

        //Prueba de Insertar después
        public void insertarDespues1(String entrada) 
        {
            Nodo anterior = new Nodo ();
            Nodo auxiliar = new Nodo(entrada);
            auxiliar.adelante = anterior.adelante;

            if (anterior.adelante != null) 
            {
                anterior.adelante.atras = auxiliar;
            }
            anterior.adelante = auxiliar;
            auxiliar.atras = anterior;
            
            
        }//Fin metodo

        //Método eliminar
        public void Eliminar(String entrada)
        {
            Nodo actual;
            bool encontrado = false;//Sirve para buscar el valor a eliminar
            actual = cabeza; //Inicia desde la cabeza

            //Bucle de busqueda
            while ((actual != null) && (!encontrado))
            {
                encontrado = (actual.dato.Equals(entrada)); //Si el dato es igual a la entrada que estamos buscando, se convierte en true, cuando se traba en String es Equals

                //Si aún no lo ha encontrado
                if (!encontrado)
                {
                    actual = actual.adelante;
                }
            }

            //Enlance de nodo anterior con el siguiente
            if (actual != null)
            {
                //Distinguir entre nodo cabecera del resto de la lista

                if (actual.Equals(cabeza)) //String Equals
                {
                    cabeza = actual.adelante;
                    if (actual.adelante != null)
                    {
                        actual.adelante.atras = null;
                    }
                }
                else if (actual.adelante != null)
                {
                    actual.atras.adelante = actual.adelante;
                    actual.adelante.atras = actual.atras;
                }//No es el último Nodo
                else
                {
                    actual.atras.adelante = null;
                } //Es el ultimo nodo
                actual = null;
            }

        }//Fin class Eliminar

        //Metodo para visualizar 
        public void visualizar()
        {
            Nodo n; //Variable temporal
            n = cabeza; //apunta hacia la cabeza

            while (n != null)
            {
                Console.WriteLine(n.dato + "\n");
                n = n.adelante;
            }
        }

        public void visualizar1(ListBox prueba)
        {
            Nodo n; //Variable temporal
            n = cabeza; //apunta hacia la cabeza

            while (n != null)
            {
                //Console.WriteLine(n.dato + "\n");
                prueba.Items.Add(n.dato);
                n = n.adelante;
            }
        }

    }
}
