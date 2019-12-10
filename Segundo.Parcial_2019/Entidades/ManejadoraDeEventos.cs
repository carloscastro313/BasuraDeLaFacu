using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public class ManejadoraDeEventos
    {
        public ManejadoraDeEventos()
        {

        }
        public void precioSuperado(double precio)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" +"PrecioSuperado.txt", true))
                {
                    writer.WriteLine(DateTime.Now + "-Precio Superado: " + precio);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
