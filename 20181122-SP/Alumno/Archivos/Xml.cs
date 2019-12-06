using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Entidades;

namespace Archivos
{
    public class Xml<T> : IArchivo<T> where T : new()
    {
        public void Guardar(string archivo, T datos)
        {
            XmlSerializer serializer;
            StreamWriter writer;

            try
            {
                using (writer = new StreamWriter(archivo))
                {
                    serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, datos);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Leer(string archivo, out T datos)
        {
            XmlSerializer serializer;
            StreamReader reader;
            T aux = new T();

            try
            {
                using (reader = new StreamReader(archivo))
                {
                    serializer = new XmlSerializer(typeof(T));
                    aux=(T)serializer.Deserialize(reader);
                }
            }
            catch (Exception)
            {

                
            }
            finally
            {
                datos = aux;
            }
            
            
        }
    }
}
