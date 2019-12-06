using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Deberá heredar de Almacenador e implementar IAlmacenable.
    //Crear un constructor que reciba y asigne el/los atributos de la misma.
    //El método MostrarArchivos lanzará una excepción del tipo NotImplementedException.
    //El método Guardar deberá guardar un objeto de tipo archivo en un archivo de texto en la ubicación definida en el atributo pathArchivos.
    //El método Leer recibirá el nombre de un archivo y deberá retornar su contenido.
    //Tanto en Leer como en Guardar capturar y relanzar las excepciones.
    public class ArchiveroFisico : Almacenador, IAlmacenable<string,Archivo>
    {
        private string pathArchivos;

        public ArchiveroFisico(string path,int capacidad):base(capacidad)
        {
            this.pathArchivos = path;
        }

        public override void MostrarArchivos()
        {
            throw new NotImplementedException();
        }

        public bool Guardar(Archivo archivo)
        {
            StreamWriter streamWriter;
            bool flag = false;
            try
            {
                streamWriter = new StreamWriter(archivo.nombre+".txt");
                streamWriter.WriteLine(archivo.contenido);
                streamWriter.Close();
                flag = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return flag;
        }
        public string Leer(string path)
        {
            StreamReader streamReader;
            string retorno = "";
            try
            {
                streamReader = new StreamReader(path+".txt");
                retorno=streamReader.ReadToEnd();
                streamReader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }
    }
}
