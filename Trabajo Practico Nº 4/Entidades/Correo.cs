using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo:IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        /// <summary>
        /// Instancia los atributos mockPaquetes y paquetes
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Finaliza los hilos de ejecucion de mockPaquetes
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread t in this.mockPaquetes)
            {
                if(t.IsAlive)
                {
                    t.Abort();
                }
            }
        }

        /// <summary>
        /// Retorna string que representa los datos de todos los paquetes del correo
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder stringSalida = new StringBuilder();

            if ((Correo) elementos is Correo && !ReferenceEquals(elementos, null))
            {
                
                foreach(Paquete p in ((Correo)elementos).paquetes)
                {
                    stringSalida.AppendFormat("{0} para {1} --> ({2}) \n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
                }
            }

            return stringSalida.ToString();
        }
        
        /// <summary>
        /// Agrega un paquete al correo, siempre y cuando ya no este en el mismo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(Paquete paquete in c.paquetes)
            {
                if(p == paquete)
                {
                    throw new TrackingIdRepetidoException("Paquete con id " + p.TrackingID + "repetido");
                }
            }

            c.paquetes.Add(p);

            Thread nuevoHilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(nuevoHilo);
            nuevoHilo.Start();

            return c;
        }

    }
}
