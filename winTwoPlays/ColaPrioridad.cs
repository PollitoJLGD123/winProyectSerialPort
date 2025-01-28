using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace winTwoPlays
{
    public class ColaPrioridad
    {
        public List<ClasePrioridad> prioridadCola = new List<ClasePrioridad>();
        public readonly object lockCola = new object();

        public void agregarCola(byte[] data, int priority, int orden, string nombre)
        {
            lock (lockCola)
            {
                Console.WriteLine("Se dio: " + nombre);
                prioridadCola.Add(new ClasePrioridad {Nombre = nombre, Data = data, Priority = priority , Orden = orden });
                prioridadCola = prioridadCola.OrderBy(item => item.Priority).ThenBy(
                    item => item.Orden).ToList();
            }
        }

        public byte[] desencolarCola()
        {
            lock (lockCola)
            {
                if (prioridadCola.Count > 0)
                {
                    var item = prioridadCola[0];
                    Console.Write(item.Nombre);
                    prioridadCola.RemoveAt(0);
                    return item.Data;
                }
                return null;
            }
        }




    }
}
