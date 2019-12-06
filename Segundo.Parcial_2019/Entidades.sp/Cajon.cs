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
    [Serializable]
    public class Cajon<T> :ISerializar
    {
        //Crear la clase Cajon<T>
        //atributos: _capacidad:int, _elementos:List<T> y _precioUnitario:double (todos protegidos)   
        protected int _capacidad;
        protected List<T> _elementos;
        protected double _precioUnitario;
        public event PrecioSuperado PrecioMayor50;
        public delegate void PrecioSuperado(string precio);

        //Propiedades
        //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
        //PrecioTotal:(sólo lectura) retorna el precio total del cajón (precio * cantidad de elementos).
        public List<T> Elementos
        {
            get { return this._elementos; }
        }

        public int PrecioTotal
        {
            get { return (int)(double)(this._elementos.Count * this._precioUnitario); }
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
            this._capacidad=capacidad;
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
            string retorno = string.Format("Capacidad: {0}\nCantidad De elemento: {1}\nPrecio Total: {2}", this._capacidad, this.Elementos.Count, this.PrecioTotal);

            foreach (T item in this._elementos)
            {
                retorno += item.ToString();
            }

            return retorno;
        }
        public bool Xml(string path)
        {
            bool retorno;
            XmlSerializer ser = new XmlSerializer(typeof(Cajon<T>));
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
            }finally
            {
                xw.Close();
            }
            return retorno;
        }

        //Sobrecarga de operador
        //(+) Será el encargado de agregar elementos al cajón, siempre y cuando no supere la capacidad del mismo.

        public void PrecioSuperadoMsg(string precio)
        {
            using (StreamWriter sw = new StreamWriter("PrecioSuperado.txt"))
            {
                sw.WriteLine(DateTime.Now +precio);
            }
        }

        public static Cajon<T> operator +(Cajon<T> c, T t)
        {

            if (c._capacidad>c.Elementos.Count)
            {
                c._elementos.Add(t);
                if(c.PrecioTotal>=50)
                {
                    c.PrecioMayor50(c.PrecioTotal.ToString());
                }
            }else
            {
                throw new CajonLlenoException(new Exception());
            }

            return c;
        }
    }
}
