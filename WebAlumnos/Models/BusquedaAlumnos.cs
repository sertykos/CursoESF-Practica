using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAlumnos.Models
{
    public class BusquedaAlumnos
    {
        CursosEntities db = new CursosEntities();

//        public List<Alumnos> GetPorApellidos (string apellidos)       -- Sin lamda
//        {
//            var datos = from o in db.Alumnos
//                        where o.apellidos == apellidos
//                        select o;

//            return datos.ToList();
//        }

        public List<Alumnos> GetPorApellidosLamda(string apellidos)
        {
            var datos = db.Alumnos.Where(o => o.apellidos == apellidos);

            return datos.ToList();
        }

    }
}