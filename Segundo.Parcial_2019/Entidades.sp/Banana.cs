using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades.sp
{
    public class Banana:Fruta
    {
        //Banana-> _paisOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Banana'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->false

        protected string _paisOrigen;

        public override string Nombre
        {
            get { return "Banana"; }
        }

        public Banana(string color, double peso, string paisOrigen) :base(color,peso)
        {
            this._paisOrigen = paisOrigen;
        }
        public override bool TieneCarozo
        {
            get {return true; }
        }
        public override string ToString()
        {
            return  string.Format("\nNombre: {0}\nPais de origen: {1}\n{2}",this.Nombre,this._paisOrigen,base.FrutaToString());
        }
    }
}
