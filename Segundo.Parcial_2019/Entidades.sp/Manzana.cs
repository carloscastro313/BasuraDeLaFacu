using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace Entidades.sp
{
    public class Manzana :Fruta, ISerializar, IDeserializar
    {
        //Manzana-> _provinciaOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Manzana'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true
        protected string _provinciaOrigen;
        
        
        public override string Nombre
        {
            get { return "Manzana"; }
        }
        public override bool TieneCarozo
        {
            get { return true; }
        }
        public Manzana():base("",0) { }
        public Manzana( string color, double peso, string provinciaOrigen) :base(color,peso)
        {
            this._provinciaOrigen = provinciaOrigen;
        }

        public bool Xml(string path)
        {
            bool retorno;
            XmlSerializer ser = new XmlSerializer(typeof(Manzana));
            XmlTextWriter xw = new XmlTextWriter(path, Encoding.UTF8);
            try
            {
                xw.Formatting = Formatting.Indented;
                ser.Serialize(xw, this);
                retorno = true;
            }
            catch (Exception)
            {

                retorno = false;
            }
            finally
            {
                xw.Close();
            }
            return retorno;
        }

        public bool Xml(string path, out Fruta fruta)
        {
            bool retorno;
            Fruta aux = null;
            XmlSerializer ser = new XmlSerializer(typeof(Fruta));
            XmlTextReader xr = new XmlTextReader(path);
            try
            {
                
                aux = (Fruta)ser.Deserialize(xr);
                retorno = true;
            }
            catch (Exception)
            {

                retorno = false;
            }
            finally
            {
                fruta = aux;
                xr.Close();
            }

            return retorno;
        }

        public override string ToString()
        {
            return string.Format("\nNombre: {0}\nPais de origen: {1}\n{2}", this.Nombre, this._provinciaOrigen, base.FrutaToString());
        }
    }
}
