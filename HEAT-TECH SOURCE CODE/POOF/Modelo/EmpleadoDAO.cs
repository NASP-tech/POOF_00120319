using System;

namespace POOF.Modelo
{
    class EmpleadoDAO
    {
        public int idUsuario { get; set; }
        
        public int idDepartamento { get; set; }
        
        public string contrasena { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }
        
        public string DUI { get; set; }

        public DateTime FechadeNacimiento { get; set; }

        public EmpleadoDAO()
        {
            idUsuario = 0;
            idDepartamento = 0;
            contrasena = "";
            nombre = "";
            apellido = "";
            DUI = "";
            FechadeNacimiento = DateTime.Now;
        }
    }
}
