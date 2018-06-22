using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guarda un archivo de texto en el escritorio de la computadora.
        /// </summary>
        /// <param name="texto"></param> El texto a guardar
        /// <param name="archivo"></param> El nombre del archivo
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamWriter sw = new StreamWriter(desktopPath + @"\" + archivo, true);

            try
            {
                sw.WriteLine(texto);
                sw.Close();
                return true;
            }
            catch (FileLoadException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return false;
        }
    }
}
