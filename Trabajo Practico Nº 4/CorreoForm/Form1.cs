using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace CorreoForm
{
    public partial class FrmPpal : Form
    {
        Correo correo;

        /// <summary>
        /// constructor del formulario, inicializo correo
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
        }

        #region eventos

        /// <summary>
        /// Agrego un nuevo paquete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if((txtDireccion.Text != "") && (mtxtTrackingID.Text != ""))
            {
                Paquete nuevoPaquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
                nuevoPaquete.InformaEstado += paq_InformaEstado;

                try
                {
                    correo = correo + nuevoPaquete;
                }
                catch(TrackingIdRepetidoException ex)
                {
                    MessageBox.Show("El tracking ID " + nuevoPaquete.TrackingID + " ya existe en la lista de envios", ex.Message);
                }

                ActualizarEstados();
            }
            txtDireccion.Text = "";
            mtxtTrackingID.Text = "";
        }
        /// <summary>
        /// Muestro todos los paquetes con estado "Entregado" en la richTextBox
        /// Guardo los datos de la misma en un archivo de texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Misma funcionalidad que el evento anterior, con la particularidad de que es solo un elemento y el mismo se selecciona con el clic secundario
        /// y solo a los paquetes "Entregados"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// Cuando cierro el formulario, tambien se cierran todos los hilos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        #endregion

        #region metodos

        /// <summary>
        /// Muestra los datos en la richTextBox y guarda los mismos datos en un archivo de texto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(elemento != null)
            {
                if(elemento is Correo || elemento is Paquete)
                {
                    rtbMostrar.Text = elemento.MostrarDatos(elemento);
                    rtbMostrar.Text.Guardar("Salida.txt");
                }
            }
        } 

        /// <summary>
        /// Llama al metodo ActualizarEstados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if(this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }
        /// <summary>
        /// Limpia los 3 list box y los actualiza volviendo a recorrer la lista
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach(Paquete p in this.correo.Paquetes)
            {
                switch (p.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(p);
                        break;

                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(p);
                        break;

                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(p);
                        break;
                }
            }

        }

        #endregion
        
        
        /*
        private void FrmPpal_Load(object sender, EventArgs e)
        {

        }
        */

        /*private void cmsListas_Opening(object sender, CancelEventArgs e)
        {

        }
        */
    }
}
