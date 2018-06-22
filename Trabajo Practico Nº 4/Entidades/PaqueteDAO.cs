using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand sqlComando;
        private static SqlConnection sqlConexion;

        static PaqueteDAO()
        {
            sqlConexion = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True");
            sqlComando = new SqlCommand();

            sqlComando.CommandType = System.Data.CommandType.Text;
            sqlComando.Connection = sqlConexion;

        }
        public static bool Insertar(Paquete p)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendFormat("INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) VALUES('{0}','{1}','{2}');", p.DireccionEntrega, p.TrackingID, "Chimiski Pablo Nicolas");
            return EjecutarNonQuery(sql.ToString());
        }

        private static bool EjecutarNonQuery(string sql)
        {
            bool todoOk = false;
            try
            {
                sqlComando.CommandText = sql;
                sqlConexion.Open();
                sqlComando.ExecuteNonQuery();

                todoOk = true;
            }
            catch (Exception e)
            {
                todoOk = false;
            }
            finally
            {
                if (todoOk)
                    sqlConexion.Close();
            }
            return todoOk;
        }
    }
}
