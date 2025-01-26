using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winTwoPlays
{
    public class classArchivo
    {
        public classArchivo(string Nombre, byte[] bytes, int Avance)
        {
            this.bytes = bytes;
            this.Avance = Avance;
            this.Nombre = Nombre;
        }
        public string Nombre { get; set; }
        public byte[] bytes { get; set; }
        public int Avance { get; set; }
    }
}
