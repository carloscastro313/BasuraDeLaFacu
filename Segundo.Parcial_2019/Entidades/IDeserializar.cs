using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IDeserializar
    {
        //IDeserializar -> Xml(string, out Fruta):bool
        bool Xml(string path, out Fruta fruta);
    }
}
