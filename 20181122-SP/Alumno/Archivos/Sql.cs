using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace Archivos
{
    public class Sql: IArchivo<Queue<Patente>>
    {
        SqlCommand comando;
        SqlConnection conexion;

        public Sql()
        {
            comando = new SqlCommand(Properties.Settings.Default.conexion);
            comando = new SqlCommand();
        }

        public void Guardar(string tabla, Queue<Patente> datos)
        {
            comando.CommandType = CommandType.Text;
            comando.CommandText = tabla;

            try
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Leer(string tabla,out Queue<Patente> datos)
        {
            comando.CommandType = CommandType.Text;
            comando.CommandText = tabla;
            SqlDataReader reader;
            Queue<Patente> aux = new Queue<Patente>();
            try
            {
                conexion.Open();
                comando.Connection = conexion;
                reader = comando.ExecuteReader();

                while(reader.Read()!=false)
                {
                    aux.Enqueue(new Patente(reader["patente"].ToString(), (Patente.Tipo)reader["tipo"]));
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos = aux;
            }
        }
    }
}
