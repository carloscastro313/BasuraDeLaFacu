using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Entidades
{
    public class Cajon<T>: ISerializar
    {
        //Crear la clase Cajon<T>
        //atributos: _capacidad:int, _elementos:List<T> y _precioUnitario:double (todos protegidos)
        protected int _capacidad;
        protected List<T> _elementos;
        protected double _precioUnitario;


        public event PrecioSobrepasado precioMayor50;

        public delegate void PrecioSobrepasado(double precioTotal);
        //Propiedades
        //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
        //PrecioTotal:(sólo lectura) retorna el precio total del cajón (precio * cantidad de elementos).
        public int Capacidad
        {
            get { return this._capacidad; }
        }
        public List<T> Elemento
        {
            get { return this._elementos; }
        }
        public double PrecioTotal
        {
            get { return this._precioUnitario * this._capacidad; }
        }
        //Constructor
        //Cajon(), Cajon(int), Cajon(double, int); 
        //El por default: es el único que se encargará de inicializar la lista.
        public Cajon()
        {
            this._elementos = new List<T>();
        }
        public Cajon(int capacidad):this()
        {
            this._capacidad = capacidad;
        }
        public Cajon(double precioUnitario, int capacidad):this(capacidad)
        {
            this._precioUnitario = precioUnitario;
        }
        //Métodos
        //ToString: Mostrará en formato de tipo string, la capacidad, la cantidad total de elementos, el precio total 
        //y el listado de todos los elementos contenidos en el cajón. Reutilizar código.
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("Capacidad: {0}\nCantidad de elementos: {1}", this._capacidad, this._elementos.Count());
            foreach (T item in this._elementos)
            {
                builder.AppendFormat("\n {0}",item.ToString());
            }
            return builder.ToString();
        }
        public bool Xml(string path)
        {
            bool aux = false;
            XmlSerializer ser= new XmlSerializer(typeof(Cajon<T>));
            
            try
            {
                using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+@"\"+path,false))
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
        //Sobrecarga de operador
        //(+) Será el encargado de agregar elementos al cajón, siempre y cuando no supere la capacidad del mismo.
        public static Cajon<T> operator +(Cajon<T> c,T t)
        {
            if(c._capacidad>c._elementos.Count())
            {
                c._elementos.Add(t);
                if(c.PrecioTotal>=50&&c.precioMayor50!=null)
                {
                    c.precioMayor50(c.PrecioTotal);
                }
            }else
            {
                throw new CajonLlenoException();
            }

            return c;
        }


    }
}
