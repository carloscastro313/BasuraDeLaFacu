using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CajonLlenoException: Exception
    {
        public CajonLlenoException(string mensaje):base(mensaje)
        {

        }
        public CajonLlenoException() : base("Cajon lleno!!!")
        {

        }
        public CajonLlenoException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
