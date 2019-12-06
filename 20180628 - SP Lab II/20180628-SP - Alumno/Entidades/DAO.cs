using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public class DAO : IArchivos<Votacion>
    {
        SqlConnection connection;
        SqlCommand command;

        public Votacion Leer(string rutaArchivos)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(string rutaArchivos, Votacion objeto)
        {
            connection= new SqlConnection(Propeties)
        }
    }
}
