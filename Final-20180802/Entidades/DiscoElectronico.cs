using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    //a.Deberá heredar de Almacenador e implementar IAlmacenable.
    //b.El método Guardar deberá insertar un archivo en la base de datos.
    //c.El método Leer recibirá el nombre de la tabla a consultar. Deberá leer y retornar todos los archivos de la base de datos.
    //d.Tanto en Leer como en Guardar capturar y relanzar las excepciones.
    //e.El método MostrarArchivos por el momento sólo deberá recorrer la lista de archivos y por cada uno simular un retardo de 5 segundos.
    //f.Agregar un constructor en el cual se deberá cargar la lista a partir de los datos guardados en la base.
    //g.Sobrecargar el operador + para agregar un archivo a la lista siempre y cuando no supere la capacidad, caso contrario lanzará una excepción con el mensaje "El disco está lleno!".
    public class DiscoElectronico : Almacenador, IAlmacenable<string,Archivo>
    {
        public List<Archivo> archivosGuardados;
        SqlConnection connection;
        SqlCommand command;
        public event MostrarInfo manejador;
        public delegate void MostrarInfo(string info);
        private DiscoElectronico():base(5)
        {
            this.archivosGuardados = new List<Archivo>();
        }
        public DiscoElectronico(int capacidad):base(capacidad)
        {
            this.archivosGuardados = new List<Archivo>();
        }
        //public override int Capacidad => base.Capacidad;
        public bool Guardar(Archivo elemento)
        {
            bool retorno = false;
            connection = new SqlConnection(Properties.Settings.Default.conexion);
            try
            {
                connection.Open();
                command = new SqlCommand("INSERT INTO Archivo (nombre,contenido) VALUES(@F1,@F2)", connection);
                command.Parameters.Add(new SqlParameter("@F1", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@F2", SqlDbType.Text));
                command.Parameters[0].Value = elemento.nombre;
                command.Parameters[1].Value = elemento.contenido;
                if (command.ExecuteNonQuery()==0)
                {
                    retorno = true;
                }
                connection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }

        public string Leer(string path)
        {
            string archivo = "";
            connection = new SqlConnection(Properties.Settings.Default.conexion);
            try
            {
                connection.Open();
                command = new SqlCommand(string.Format("SELECT [id],[nombre],[contenido]FROM Archivo WHERE nombre='{0}'",path), connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                archivo += reader["nombre"].ToString()+" " +reader["contenido"].ToString()+"\n";
                connection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return archivo;
        }
        public override void MostrarArchivos()
        {
            int index = -1;
            int indexAux = -1;
            string aux = "";
            foreach (Archivo item in this.archivosGuardados)
            {
                index++;
                foreach (Archivo comp in this.archivosGuardados)
                {
                    if (comp==item&&index!=indexAux)
                    {
                        Thread.Sleep(5000);
                    }
                    indexAux++;
                }
                indexAux = -1;
                aux+=this.Leer(item.nombre);
            }
            this.manejador(aux);
        }
        public static DiscoElectronico operator +(DiscoElectronico d, Archivo a)
        {
            if(d.capacidad>d.archivosGuardados.Count)
            {
                d.archivosGuardados.Add(a);
            }else
            {
                throw new Exception("El disco está lleno!");
            }

            return d;
        }
    }
}
