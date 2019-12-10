using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Durazno : Fruta
    {
        //Durazno-> _cantPelusa:int (protegido); Nombre:string (prop. s/l, retornará 'Durazno'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true

        protected int _cantPelusa;

        public override string Nombre
        {
            get { return "Durazno"; }
        }
        public Durazno(string color, double peso, int cantPelusa) : base(color, peso)
        {
            this._cantPelusa = cantPelusa;
        }
        public Durazno():base()
        {

        }
        protected override string FrutaToString()
        {
            return "\nNombre" + this.Nombre + "\n Cantidad de pelusa: " + this._cantPelusa + "\n" + base.FrutaToString();
        }
        public override string ToString()
        {
            return this.FrutaToString();
        }
        public override bool TieneCarozo
        {
            get { return true; }
        }
    }
}
