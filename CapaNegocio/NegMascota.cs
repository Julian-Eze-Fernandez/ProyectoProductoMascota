using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using Entidades;

namespace CapaNegocio
{
    public class NegMascota
    {
        AdminMascota DatosObjMascota = new AdminMascota();

        public int abmMascotas(string accion, Mascota objMasocta)
        {
            return DatosObjMascota.abmMascotas(accion, objMasocta);
        }

        public DataSet listadoMascotas(string cual) 
        {
            return DatosObjMascota.listadoMascotas(cual);
        }
    }
}
