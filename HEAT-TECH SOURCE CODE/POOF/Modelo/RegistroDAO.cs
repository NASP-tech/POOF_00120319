using System;

namespace POOF.Modelo
{
    class RegistroDAO
    {
        public int idRegistro { get; set; }
        
        public int idUsuario { get; set; }
        
        public bool entrada { get; set; }
        
        public DateTime fechaYhora { get; set; }
        
        public double temperatura { get; set; }

        public RegistroDAO()
        {
            idRegistro = 0;
            idUsuario = 0;
            entrada = false;
            fechaYhora = DateTime.Now;
            temperatura = 0;
        }
    }
}
