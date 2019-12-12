using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sacapunta:Utiles
    {
        //Sacapunta-> deMetal:bool(publico); 
        //Reutilizar UtilesToString en ToString() (mostrar todos los valores).
        public bool deMetal;

        public Sacapunta(bool deMetal, double precio,string marca) : base(marca,precio)
        {
            this.deMetal = deMetal;
        }
        public override bool PreciosCuidados
        {
            get { return false; }
        }
        protected override string UtilesToString()
        {
            return "Metal " + this.deMetal;
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
