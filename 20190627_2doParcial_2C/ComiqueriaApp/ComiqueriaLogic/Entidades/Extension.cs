using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic.Entidades
{
    public static class Extension
    {
        public static string FormatearPrecio(this float precio)
        {
            return string.Format("{0}$",precio);
        }
    }
}
