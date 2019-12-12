using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Goma : Utiles
    {
        //Goma-> soloLapiz:bool(publico); PreciosCuidados->true; 
        //Reutilizar UtilesToString en ToString() (mostrar todos los valores).

        public bool soloLapiz;
        public Goma(bool soloLapiz,string marca, double precio):base(marca,precio)
        {
            this.soloLapiz = soloLapiz;
        }
        public override bool PreciosCuidados
        {
            get { return true; }
        }
        protected override string UtilesToString()
        {
            return "Solo lapiz: " + this.soloLapiz;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.UtilesToString());
            builder.AppendLine(this.UtilesToString());
            return builder.ToString();
        }
    }
}
