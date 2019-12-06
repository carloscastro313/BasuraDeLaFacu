using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    public class SerializarXml : IArchivos<Votacion>
    {
        public bool Guardar(string rutaArchivos, Votacion objeto)
        {
            bool retorno = false;
            XmlTextWriter textWriter;
            XmlSerializer serializer;
            
            try
            {
                textWriter = new XmlTextWriter(rutaArchivos, Encoding.UTF8);
                serializer = new XmlSerializer(typeof(Votacion));
                serializer.Serialize(textWriter,objeto);
                textWriter.Close();
                retorno = true;
            }
            catch (ErrorArchivoException ex)
            {

                throw ex;
            }
            return retorno;
        }

        public Votacion Leer(string rutaArchivo)
        {
            bool retorno = false;
            XmlSerializer serializer;
            XmlTextReader reader;
            Votacion objeto;
            try
            {
                reader = new XmlTextReader(rutaArchivo);
                serializer = new XmlSerializer(typeof(Votacion));
                objeto = (Votacion)serializer.Deserialize(reader);
                reader.Close();
            }
            catch (ErrorArchivoException ex)
            {

                throw ex;
            }
            return retorno;
        }
    }
}
