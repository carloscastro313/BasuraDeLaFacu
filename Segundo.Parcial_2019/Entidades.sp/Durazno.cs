﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.sp
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

        public Durazno(string color, double peso,int cantPelusa) :base(color,peso)
        {
            this._cantPelusa = cantPelusa;
        }
        
        public override bool TieneCarozo
        {
            get { return true; }
        }
        public override string ToString()
        {
            return string.Format("\nNombre: {0}\nPais de origen: {1}\n{2}", this.Nombre, this._cantPelusa, base.FrutaToString());
        }
    }
}
