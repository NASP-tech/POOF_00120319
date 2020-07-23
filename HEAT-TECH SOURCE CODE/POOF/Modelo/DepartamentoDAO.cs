namespace POOF.Modelo
{
    class DepartamentoDAO
    {
        public int idDepartamento { get; set; }
        
        public string nombre { get; set; }
        
        public string ubicacion { get; set; }

        public DepartamentoDAO()
        {
            idDepartamento = 0;
            nombre = "";
            ubicacion = "";
        }
    }
}
