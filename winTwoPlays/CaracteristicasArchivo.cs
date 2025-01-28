using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winTwoPlays
{
    public enum TipoComunicacion
    {
        Mensaje,
        Archivo,
        Comando
    }

    public class CaracteristicasArchivo
    {
        public CaracteristicasArchivo(TipoComunicacion tipo, byte[] datos)
        {
            this.tipo = tipo;
            this.datos = datos;
        }

        public TipoComunicacion tipo { get; set; }
        public byte[] datos { get; set; }
    }
}
