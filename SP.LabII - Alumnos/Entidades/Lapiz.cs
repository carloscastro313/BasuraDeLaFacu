using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Entidades
{
    public class Lapiz : Utiles,ISerializa,IDeserializa
    {
        //Lapiz-> color:ConsoleColor(publico); trazo:ETipoTrazo(enum {Fino, Grueso, Medio}; publico); PreciosCuidados->true; 
        //Reutilizar UtilesToString en ToString() (mostrar todos los valores).
        
        public ConsoleColor color;
        public ETipoTrazo trazo;

        public override bool PreciosCuidados
        {
            get { return true; }
        }
        public string Path
        {
            get { return "Castro.Carlos.lapiz.xml"; }
        }
        public Lapiz(ConsoleColor color, ETipoTrazo trazo,string marca, double precio) : base(marca, precio)
        {
            this.color = color;
            this.trazo = trazo;
        }
        public Lapiz():base(" ",0)
        {

        }
        /*public double Precio
        {
            get { return base.precio; }
            set { base.precio = value; }
        }
        public string Marca
        {
            get { return base.marca; }
            set { base.marca = value; }
        }*/
        public bool Xml()
        {
            bool aux = false;
            XmlSerializer ser = new XmlSerializer(typeof(Lapiz));

            try
            {
                using (StreamWriter writer = new StreamWriter(this.Path, false))
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
        bool IDeserializa.Xml(out Lapiz lapiz)
        {
            bool Flag = false;
            XmlSerializer ser = new XmlSerializer(typeof(Lapiz));
            Lapiz aux = new Lapiz();
            try
            {
                using (StreamReader reader = new StreamReader(this.Path))
                {
                    aux = (Lapiz)ser.Deserialize(reader);
                    Flag = true;
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                lapiz = aux;
            }
            return Flag;
        }
        protected override string UtilesToString()
        {
            return "Color: " + this.color + " Trazo: " + this.trazo;
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
