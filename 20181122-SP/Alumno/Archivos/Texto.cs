using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Entidades;

namespace Archivos
{
    public class Texto : IArchivo<Queue<Patente>>
    {
        public void Leer(string archivo,out Queue<Patente> datos)
        {
            string cadena;
            Queue<Patente> patentes = new Queue<Patente>();
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    do
                    {
                        cadena = reader.ReadLine();
                        patentes.Enqueue((Patente)cadena.Cast<Patente>());
                    } while (reader.EndOfStream);
                }
            }
            catch (Exception)
            {

                
            }
            finally
            {
                datos = patentes;
            }
        }

        public void Guardar(string archivo, Queue<Patente> datos)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo))
                {
                    do
                    {
                        writer.WriteLine(datos.Dequeue());
                    } while (datos.Count>0);
                }
            }
            catch (Exception)
            {

                
            }
        }
    }
}
