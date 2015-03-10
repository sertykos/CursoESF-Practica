using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAlumnos.Models
{
    public partial class Alumnos
    {
        public List<int> idCursos { get; set; }

        //WARNING: Si regeneramos el modelo estas validaciones se borraran !!! 
        //(Por lo que lo hemos cortado/pegado en esta clase en ves de dejarlo en el modelo).
        //De esta manera al regenerar el modelo, aparecera un error, sustituiremos este codigo de abajo por el del modelo.

        [DisplayName("DNI")]
        [RegularExpression("^[0-9]{6,8}[A-Za-z]{1}$", ErrorMessage = "El DNI es incorrecto")]
        // 6 u 8 digitos entre 0-9 y 1 entre A-Z o a-z (^ Lo empieza y $ lo acaba)
        public string dni { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Apellidos")]
        public string apellidos { get; set; }
        [DisplayName("Fecha de Nacimiento")]
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        [DisplayName("Nacionalidad")]
        public int idNacionalidad { get; set; }
    }
}