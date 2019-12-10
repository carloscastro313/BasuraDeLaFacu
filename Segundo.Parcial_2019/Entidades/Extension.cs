using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Entidades
{
    public static class Extension
    {
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
                    if (command.ExecuteNonQuery() == 0)
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
