using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        /// <summary>
        /// Instancia los atributos de la clase con los parametros ingresados, estado se isntancia en "Ingresado"
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = EEstado.Ingresado;
        }

        /// <summary>
        /// Genera el ciclo de vida del paquete, cambiando su estado cada 10 segundos
        /// Al llegar al estado entregado, se guarda el paquete en la base de datos especificada en PaqueteDAO
        /// </summary>
        public void MockCicloDeVida()
        {
            do
            {
                Thread.Sleep(10000);
                if (this.estado == EEstado.Ingresado)
                {
                    this.estado = EEstado.EnViaje;
                }
                else
                {
                    this.estado = EEstado.Entregado;
                }
                InformaEstado(this, EventArgs.Empty);
            } while (this.estado != EEstado.Entregado);

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch(Exception e)
            {
                throw e;
            }

        }
        /// <summary>
        /// Muestra los datos del paquete en forma de string
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0} para {1}\n", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
            return sb.ToString();

        }

        /// <summary>
        /// Override del metodo ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Compara 2 paquetes por TrackingID para verificar igualdad, devuelve true o false
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (!(ReferenceEquals(p1, null) || ReferenceEquals(p2, null)))
            {
                if (p1.trackingID == p2.TrackingID)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Idem al ==, solo que devuelve true o false dependiendo si son distintos o no.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
    }
}
