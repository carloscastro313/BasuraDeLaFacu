using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class ImprimirTicket
    {
        
        public static bool precioSuperado(double precio)
        {
            bool aux = false;
            try
            {
                using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "PrecioSuperado.txt", true))
                {
                    writer.WriteLine(DateTime.Now + "-Precio Superado: " + precio);
                }
                aux = true;
            }
            catch (Exception)
            {

            }

            return aux;
        }
    }
}
