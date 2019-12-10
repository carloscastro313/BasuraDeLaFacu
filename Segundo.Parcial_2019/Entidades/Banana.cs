using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Banana: Fruta
    {
        //Banana-> _paisOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Banana'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->false
        protected string _paisOrigen;

        public override string Nombre
        {
            get { return "Banana"; }
        }

        public Banana(string color,double peso, string paisOrigen) : base(color,peso)
        {
            this._paisOrigen = paisOrigen;
        }
        public Banana():base()
        {

        }

        protected override string FrutaToString()
        {
            return "\nNombre" + this.Nombre + "\n Origen: " + this._paisOrigen + "\n" + base.FrutaToString();
        }
        public override string ToString()
        {
            return this.FrutaToString();
        }
        public override bool TieneCarozo
        {
            get { return false; }
        }
    }
}
