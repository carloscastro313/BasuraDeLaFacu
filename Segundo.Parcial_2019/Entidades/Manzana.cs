using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Entidades
{
    public class Manzana : Fruta, ISerializar, IDeserializar
    {
        //Manzana-> _provinciaOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Manzana'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true
        
        protected string _provinciaOrigen;
        
        public string Origen
        {
            get { return this._provinciaOrigen; }
        }
        public override string Nombre
        {
            get { return "Manzana"; }
        }
        public string Color
        {
            get { return base._color; }
            set { base._color = value; }
        }
        new public double Peso
        {
            get { return base._peso; }
            set { base._peso = value; }
        }
        public Manzana(string color, double peso, string provinciaOrigen) : base(color, peso)
        {
            this._provinciaOrigen = provinciaOrigen;
        }
        public Manzana() : base()
        {
            
        }

        public bool Xml(string path)
        {
            bool aux = false;
            XmlSerializer ser = new XmlSerializer(typeof(Manzana));

            try
            {
                using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + path, false))
                {
                    ser.Serialize(writer, this);
                    aux = true;
                }
            }
            catch (Exception)
            {
            }
            return aux;
        }
        bool IDeserializar.Xml(string path, out Fruta fruta)
        {
            bool aux = false;
            XmlSerializer ser = new XmlSerializer(typeof(Manzana));
            Manzana manzana = new Manzana();
            try
            {
                using (StreamReader reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + path, false))
                {
                    manzana=(Manzana)ser.Deserialize(reader);
                    aux = true;
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                fruta = manzana;
            }
            return aux;
        }
        public override bool TieneCarozo
        {
            get { return true; }
        }
        protected override string FrutaToString()
        {
            return "\nNombre" + this.Nombre + "\n Origen: " + this._provinciaOrigen + "\n" + base.FrutaToString();
        }
        public override string ToString()
        {
            return this.FrutaToString(); 
        }
    }
}
