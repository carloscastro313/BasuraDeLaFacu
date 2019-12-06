using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.sp
{
    public abstract class Fruta
    {
        //Fruta-> _color:string y _peso:double (protegidos); TieneCarozo:bool (prop. s/l, abstracta);
        //constructor con 2 parametros y FrutaToString():string (protegido y virtual, retorna los valores de la fruta)
        protected string _color;
        protected double _peso;

        public abstract bool TieneCarozo { get; }
        public abstract string Nombre { get; }
        public double Peso
        {
            get { return this._peso; }
        }
        public Fruta(string color, double peso)
        {
            this._color = color;
            this._peso = peso;
        }

        public virtual string FrutaToString()
        {
            return String.Format("Peso: {0}\nColor: {1}", this._peso, this._color);
        }

    }
}
