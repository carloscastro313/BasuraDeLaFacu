using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace Entidades.sp
{
    public static class Extension
    {
        //Agregar un método de extensión a la clase Cajon que:
        //Reciba como parámetro un entero (será usado como valor del campo ID)
        //Elimine de la base de datos la fruta cuyo ID coincida con el parámetro recibido
        //Retorne un booleano que indique: 
        //TRUE, si se ha eliminado la fruta. 
        //FALSE, si no se elimino.
        //Excepción, si se probocó algún error en la base de datos

        public static bool EliminarFruta<T>(this Cajon<T> cajon, int id)
        {
            bool retorno = false;
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.Conexion);
            SqlCommand command;
            try
            {
                using (command = new SqlCommand("DELETE FROM frutas WHERE id=" + id, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    if(command.ExecuteNonQuery()==0)
                    {
                        retorno = true;
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }
    }
}