using ReproductorMusica_LDE.Clases;
using ReproductorMusica_LDE.lista_circular;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nodo = ReproductorMusica_LDE.Clases.Nodo;

namespace ReproductorMusica_LDE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Lista en donde se almacenarán las canciones
        clsListaDoble lista = new clsListaDoble();
        clsListaCircular circular = new clsListaCircular();

        //Nos cargará las canciones que están en la carpeta
        OpenFileDialog añadir_canciones = new OpenFileDialog();
      //  OpenFileDialog openFileDialog1 = new OpenFileDialog();

        //Arreglos para obtener las canciones de Lista General
        string[] archivo, path;
        string[] canciones;
        string ruta = " ";
        Nodos minodo;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Agregamos las canciones a ListBox1
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           try 
           {
                //  axWindowsMediaPlayer2.URL = path[listBox1.SelectedIndex];
                if (listBox1.SelectedIndex != -1)
                {
                    axWindowsMediaPlayer2.URL = añadir_canciones.FileNames[listBox1.SelectedIndex];
                    int i = listBox1.SelectedIndex;
                    minodo = new Nodos(añadir_canciones.FileNames[i]);
                }
           } 
            catch (IndexOutOfRangeException) 
           {

           }
        }

        private void btnPausar_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.Ctlcontrols.pause();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.Ctlcontrols.play();
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.Ctlcontrols.stop();
        }
        //No está en utilización
        private void btnAgregarCabeza_Click(object sender, EventArgs e)
        {
            
        }

        //Botón de Eliminar
        private void button3_Click(object sender, EventArgs e)
        {
            String cancion_eliminar = listBox1.SelectedItem.ToString();
            lista.Eliminar(cancion_eliminar);
            listBox1.Items.Clear();
            lista.visualizar1(listBox1);
        }
        //No se utiliza
        private void Barra_tiempo_ValueChanged(object sender,decimal value)
        {
            
        }
        //No se utiliza
        private void btnAgregarDespues_Click(object sender, EventArgs e)
        {
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < listBox1.Items.Count-1) 
            {
                listBox1.SelectedIndex += 1;
            }
        }

        //No se utiliza
        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {

                macTrackBar1.Maximum = (int)axWindowsMediaPlayer2.Ctlcontrols.currentItem.duration;
                macTrackBar1.Value = (int)axWindowsMediaPlayer2.Ctlcontrols.currentPosition;

                if (macTrackBar1.Value == macTrackBar1.Maximum)
                {
                    repetir();
                }

            }


            try
            {
                macTrackBar1.Value = (int)axWindowsMediaPlayer2.Ctlcontrols.currentPosition;
                
                label4.Text = axWindowsMediaPlayer2.Ctlcontrols.currentPositionString;
            }
            catch
            {


            }
        }

        public void repetir()
        {
            
            
            if (minodo != null)
            {
                minodo = circular.ultimo.enlace; 

                while (minodo == circular.ultimo.enlace)
                {
                    if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
                    {

                        listBox1.SelectedIndex += 1;

                        minodo = minodo.enlace;
                    }
                    else
                    {

                        axWindowsMediaPlayer2.URL = añadir_canciones.FileNames[0];
                        listBox1.SelectedIndex = 0;
                        minodo = minodo.enlace;
                    }

                    minodo = minodo.enlace;
                }
            }
            else
            {
                MessageBox.Show("\t NO HAY CANCIONES DISPONIBLES");
            }
        }

        //Permite activar el timer
        public void Track()
        {
            if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {

                timer1.Start();
            }
            else if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                timer1.Stop();
            }
            else if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                timer1.Stop();
              
            }
        }
        private void axWindowsMediaPlayer2_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            Track();
        }

        private void Barra_tiempo_Scroll(object sender, EventArgs e)
        {

        }

        private void macTrackBar1_ValueChanged(object sender, decimal value)
        {
            macTrackBar1.Maximum = (int)axWindowsMediaPlayer2.currentMedia.duration;
            if (macTrackBar1.Value == (int)axWindowsMediaPlayer2.Ctlcontrols.currentPosition)
            {

            }
            else
            {

                axWindowsMediaPlayer2.Ctlcontrols.currentPosition = macTrackBar1.Value;

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnElegir_Click(object sender, EventArgs e)
        {
         

            try 
            {
                añadir_canciones.Multiselect = true;
                añadir_canciones.Filter = "Archivos audios (*.mp3),(*mp4),(*.wav),(*png)|";

                if(añadir_canciones.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
                {
                    archivo = añadir_canciones.SafeFileNames; //Guarda el nombre de los archivos
                    path = añadir_canciones.FileNames;   //Guarda la ruta de los archivos
                    //Para insertar las canciones seleccionadas en nuestras listas a usar

                    for(int i = 0; i < añadir_canciones.SafeFileNames.Length; i++) 
                    {
                        lista.insertarCabezaLista(añadir_canciones.FileNames[i]);
                        circular.InsertarCabeza3(añadir_canciones.FileNames[i]);
                        listBox1.Items.Add(añadir_canciones.SafeFileNames[i]);
                    }
                    axWindowsMediaPlayer2.URL = añadir_canciones.FileNames[0];
                    listBox1.SelectedIndex = 0;
                }
            } 
            catch (Exception en) 
            {
                MessageBox.Show(en.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
