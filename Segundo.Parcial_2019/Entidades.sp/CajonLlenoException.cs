using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.sp
{
    public class CajonLlenoException : Exception
    {
        public CajonLlenoException(string mensaje, Exception ex) : base(mensaje, ex) { }
        public CajonLlenoException(Exception ex) : this("Cajon lleno!!!", ex) { }
    }
}
