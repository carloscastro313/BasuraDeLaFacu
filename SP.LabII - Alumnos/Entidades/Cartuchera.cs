using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cartuchera<T> where T:Utiles
    {
        //Crear la clase Cartuchera<T> -> restringir para que solo lo pueda usar Utiles o clases que deriven de Utiles
        //atributos: capacidad:int y elementos:List<T> (todos protegidos)    
        protected int capacidad;
        protected List<T> elementos;

        public event precioSuperado precioMayor;
        public delegate void precioSuperado(object sender, EventArgs e);
        //Propiedades
        //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
        //PrecioTotal:(sólo lectura) retorna el precio total de la cartuchera (la suma de los precios de sus elementos).
        public int Capacidad
        {
            get { return this.capacidad; }
        }
        public List<T> Elementos
        {
            get { return this.elementos; }
        }
        public double PrecioTotal
        {
            get {
                    double precio = 0;
                    foreach (T item in this.elementos)
                    {
                        precio += item.precio;
                    }
                    return precio;
                }
        }
        //Constructor
        //Cartuchera(), Cartuchera(int); 
        //El constructor por default es el único que se encargará de inicializar la lista.
        public Cartuchera()
        {
            this.elementos = new List<T>();
        }
        public Cartuchera(int capacidad):this()
        {
            this.capacidad = capacidad;
        }

        //Métodos
        //ToString: Mostrará en formato de tipo string: 
        //el tipo de cartuchera, la capacidad, la cantidad actual de elementos, el precio total y el listado completo 
        //de todos los elementos contenidos en la misma. Reutilizar código.
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("Capacidad: {0}\nPrecio Total: {1}\nCantidad actual: {2}\n",this.capacidad,this.PrecioTotal,this.elementos.Count);
            foreach (Utiles item in this.elementos)
            {
                builder.AppendLine(item.ToString());
            }
            return builder.ToString();
        }
        //Sobrecarga de operador
        //(+) Será el encargado de agregar elementos a la cartuchera siempre y cuando no supere la capacidad máxima de la misma.
        public static Cartuchera<T> operator +(Cartuchera<T> c, T u)
        {
            if(c.capacidad>c.elementos.Count)
            {
                c.elementos.Add(u);
                if(c.PrecioTotal>85&&c.precioMayor!=null)
                {
                    c.precioMayor(c,new EventArgs());
                }
            }else
            {
                throw new CartucheraLlenaException();
            }
            return c;
        }
    }
}
