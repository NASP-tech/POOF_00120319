using System.Collections.Generic;
using System.Windows.Forms;
using POOF.Modelo;

namespace POOF
{
    public class CProxy
    {
        public interface IComponente
        {
            void entrar(int tdep);
        }
        public class ProxySencillo : IComponente
        {
            List<EmpleadoDAO> empleado = new List<EmpleadoDAO>();
            private delegate void MyDelegate(List<EmpleadoDAO> e);
            private static MyDelegate Confirmacion;
            private tipoEntrada entrada;

            public void entrar(int tdep)
            {
                if (entrada == null)
                    entrada = new tipoEntrada();

                switch(tdep){
                    case 1:
                        Confirmacion = entrada.Gerencia;
                        Confirmacion.Invoke(empleado);
                        break;
                    case 2:
                        Confirmacion = entrada.General;
                        Confirmacion.Invoke(empleado);
                        break;
                    case 3:
                        Confirmacion = entrada.Vigilancia;
                        Confirmacion.Invoke(empleado);
                        break;
                    default:
                        MessageBox.Show("No existe ese departamento!");
                        break;
                }
            }
        }
        private class tipoEntrada
        {
            public void Gerencia(List<EmpleadoDAO> ee)
            {
                ee.ForEach((lista) =>
                {
                    if (lista.idDepartamento.Equals(1)) ;
                    MessageBox.Show("Bienvenido a la Gerencia");
                });
            }
            public void General(List<EmpleadoDAO> eee)
            {
                eee.ForEach((lista) =>
                {
                    if (lista.idDepartamento.Equals(2)) ;
                    MessageBox.Show("Bienvenido al departamento general");
                });
            }
            public void Vigilancia(List<EmpleadoDAO> eeee)
            {
                eeee.ForEach((lista) =>
                {
                    if (lista.idDepartamento.Equals(3)) ;
                    MessageBox.Show("Bienvenido al departamento de vigilancia");
                });
            }
        }
    }
}